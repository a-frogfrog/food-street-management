using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Api.Request.Admin.Permission;
using FSM.Infrastructure.Dto.Api.Response.Admin.Permission;
using FSM.Infrastructure.Dto.Common;
using FSM.Infrastructure.Dto.Service.Permission;
using FSM.Infrastructure.Dto.Service.User;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Infrastructure.Helpers;
using FSM.Infrastructure.Tools;
using FSM.Service.Dependencies;
using FSM.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FSM.Service.Instance
{
    /// <summary>
    /// Permission Service Instance
    /// 权限服务实例
    /// </summary>
    [Inject]
    public class PermissionService : ResponseHelper, IPermissionService
    {
        private readonly PermissionDependencies _permissionDependencies;
        private readonly GlobalStatusHelper _globalStatusHelper;
        private readonly GuidGenerator _guidGenerator;
        private readonly IUserService _userService;

        public PermissionService(
            PermissionDependencies permissionDependencies,
            GlobalStatusHelper globalStatusHelper,
            GuidGenerator guidGenerator,
            IUserService userService)
        {
            _permissionDependencies = permissionDependencies;
            _globalStatusHelper = globalStatusHelper;
            _guidGenerator = guidGenerator;
            _userService = userService;
        }

        public bool CheckPermission(CheckUserPermissionDto dto)
        {

            //TODO: Check Permission
            //转换成小写
            var permission = dto.Permissions.Select(s => s.ToLower()).ToList();
            var query = _permissionDependencies.Permission
                .QueryAll(q => permission.Contains(q.Url.ToLower()));

            if (!query.Any()) return false;

            var permissionIds = query.Select(s => s.PermId).ToList();
            var userPermissions = _permissionDependencies.UserPermission
                .QueryAll(q => q.UserId == dto.UserId && permissionIds.Contains(q.PermId)).ToList();

            if (userPermissions.Count == permission.Count) return true;
            return false;
        }

        public async Task<ApiResponse> CreatePermission(CreatePermissionRequestDto dto)
        {

            int serialNumber = 1;
            var query = await _permissionDependencies.Permission.QueryAll().ToListAsync();

            //TODO: 判断是否是子节点
            if (!string.IsNullOrEmpty(dto.ParentId))
            {

                var filter = query.Any(q => q.PermId == dto.ParentId);
                //TODO: 判断父节点是否存在
                if (!filter) return Failed("ParentId is not exist");

                // TODO: 获取子节点序号+1
                serialNumber = query.Count(s => s.ParentId == dto.ParentId) + 1;
            }
            else
            {
                dto.ParentId = null;
                //TODO: 获取根节点 序号+1
                serialNumber = query.Count(s => s.ParentId == null || s.ParentId == "") + 1;
            }


            Permission permission = new()
            {
                PermId = _guidGenerator.GenerateSequentialGuid(),
                Status = _globalStatusHelper.PERMIDENT.Active,
                PermName = dto.Name,
                Type = dto.Type,
                Url = dto.Url,
                ParentId = dto.ParentId,
                Description = dto.Description,
                Icon = dto.Icon,
                SerialNumber = serialNumber,
            };

            _permissionDependencies.Permission.Add(permission);
            var result = await _permissionDependencies.Permission.SaveChangesAsync();

            return result > 0 ? Ok("success") : Failed("failed");
        }

        public async Task<ApiResponse> GetPermissionList()
        {
            var query = await _permissionDependencies.Permission
                .QueryAll(true, order => order.SerialNumber).ToListAsync();


            var root = query.Where(q => string.IsNullOrEmpty(q.ParentId)).ToList();
            List<GetPermissionResponseDto> data = new();

            root.ForEach(s =>
            {
                data.Add(new GetPermissionResponseDto()
                {
                    Id = s.PermId,
                    Name = s.PermName,
                    Url = s.Url,
                    SerialNumber = s.SerialNumber,
                    Status = s.Status,
                    Icon = s.Icon,
                    ParentId = s.PermId,
                    Type = s.Type,
                    CreateTime = s.CrateTime,
                    Description = s.Description,
                    Children = GetPermissionChildren(query, s.PermId)
                });
            });



            return Ok("success", data);
        }

        private static List<GetPermissionResponseDto> GetPermissionChildren(List<Permission> query, string permId)
        {
            var children = query.Where(q => q.ParentId == permId).ToList();
            List<GetPermissionResponseDto> data = new();
            children.ForEach(item =>
            {
                data.Add(new GetPermissionResponseDto()
                {
                    Id = item.PermId,
                    Name = item.PermName,
                    Url = item.Url,
                    SerialNumber = item.SerialNumber,
                    Status = item.Status,
                    Icon = item.Icon,
                    ParentId = item.PermId,
                    Type = item.Type,
                    CreateTime = item.CrateTime,
                    Description = item.Description,
                    Children = GetPermissionChildren(query, item.PermId)
                });
            });

            return data;
        }

        public List<UserPermission> GetUserPermissionList(string userId)
        {
            var query = _permissionDependencies.UserPermission.QueryAll(q => q.UserId == userId).ToList();
            return query;
        }

        public async Task<ApiResponse> GetUserPermissionMenuList(string userId)
        {
            //TODO: 获取用户权限
            var permIds = await _permissionDependencies.UserPermission
                .QueryAll(q => q.UserId == userId)
                .Select(s => s.PermId).ToListAsync();

            var permissions = await _permissionDependencies.Permission
                .QueryAll(q =>
                permIds.Contains(q.PermId)
                && q.Status == _globalStatusHelper.PERMIDENT.Active)
                .ToListAsync();

            var root = permissions.Where(s => s.ParentId == null || s.ParentId == "").ToList();

            List<GetPermissionMenuResponseDto> data = new();

            root.ForEach(s =>
            {
                data.Add(new GetPermissionMenuResponseDto()
                {
                    Id = s.PermId,
                    Name = s.PermName,
                    ParentId = s.ParentId,
                    Url = s.Url,
                    Icon = s.Icon,
                    Children = GetPermissionMenuChildren(permissions, s.PermId)
                });
            });

            return Ok("Success", data);
        }

        public async Task<ApiResponse> GrantPermission(GrantPermissionRequestDto dto)
        {

            if (!_userService.IsExistUser(dto.UserId))
                return Failed("User is not exist");

            var userPermissions = GetUserPermissionList(dto.UserId);
            _permissionDependencies.UserPermission.DeleteRange(userPermissions);

            var permissions = _permissionDependencies.Permission
                .QueryAll(q => dto.Permissions.Contains(q.PermId));

            if (!permissions.Any())
                return Failed("Permission is not exist");

            List<UserPermission> data = new();
            dto.Permissions.ForEach(s =>
            {
                data.Add(new UserPermission()
                {
                    UserPermId = _guidGenerator.GenerateSequentialGuid(),
                    UserId = dto.UserId,
                    PermId = s,
                });
            });

            _permissionDependencies.UserPermission.AddRange(data);
            var result = await _permissionDependencies.UserPermission.SaveChangesAsync();

            return result > 0 ? Ok() : Failed();
        }

        private static List<GetPermissionMenuResponseDto> GetPermissionMenuChildren(List<Permission> permissions, string permId)
        {
            var children = permissions.Where(s => s.ParentId == permId).ToList();
            List<GetPermissionMenuResponseDto> data = new();
            children.ForEach(s =>
            {
                data.Add(new GetPermissionMenuResponseDto()
                {
                    Id = s.PermId,
                    Name = s.PermName,
                    ParentId = s.ParentId,
                    Url = s.Url,
                    Icon = s.Icon,
                    Children = GetPermissionMenuChildren(permissions, s.PermId)
                });
            });

            return data;
        }
    }
}
