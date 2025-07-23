using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Api.Request.Admin.Dictionary;
using FSM.Infrastructure.Dto.Api.Response.Admin.MasterData;
using FSM.Infrastructure.Dto.Common;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Infrastructure.Helpers;
using FSM.Infrastructure.Tools;
using FSM.Service.Dependencies;
using FSM.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FSM.Service.Instance
{
    [Inject]
    public class DictionaryService : ResponseHelper, IDictionaryService
    {
        private readonly DictionaryDependencies _dictionaryDependencies;
        private readonly GuidGenerator _guidGenerator;

        public DictionaryService(
            DictionaryDependencies dictionaryDependencies,
            GuidGenerator guidGenerator)
        {
            _dictionaryDependencies = dictionaryDependencies;
            _guidGenerator = guidGenerator;
        }

        /// <summary>
        /// Get Dictionary List.
        /// 获取字典列表（实现）
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse> GetDictionaryList()
        {
            var query = await _dictionaryDependencies.Dictionary.QueryAll().ToListAsync();
            if (!query.Any()) return Failed("No data found");
            var root = query.Where(q => q.ParentId == null).ToList();
            if (!root.Any()) return Failed("data exception");

            List<GetDictionaryResponseDto> data = new();


            root.ForEach(r =>
            {
                data.Add(new GetDictionaryResponseDto()
                {
                    Id = r.DictionaryId,
                    Name = r.DictionaryName,
                    Value = r.DictionaryValue,
                    Code = r.Code,
                    SerialNumber = r.SerialNumber,
                    Status = r.Status,
                    Level = r.Level,
                    IsNode = r.IsNode,
                    ParentId = r.ParentId,
                    UpdateTime = r.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    CreateTime = r.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Description = r.Description,
                    Children = GetDictionaryChildren(query, r.DictionaryId)
                });
            });


            return Ok("Success", data);
        }

        /// <summary>
        /// Get Children Dictionary List.
        /// 获取子字典列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="dictionaryId"></param>
        /// <returns></returns>
        private static List<GetDictionaryResponseDto> GetDictionaryChildren(List<Dictionary> query, string dictionaryId)
        {
            var children = query.Where(q => q.ParentId == dictionaryId).ToList();

            List<GetDictionaryResponseDto> response = new();

            children.ForEach(r =>
            {
                response.Add(new GetDictionaryResponseDto()
                {
                    Id = r.DictionaryId,
                    Name = r.DictionaryName,
                    Value = r.DictionaryValue,
                    Code = r.Code,
                    SerialNumber = r.SerialNumber,
                    Status = r.Status,
                    Level = r.Level,
                    IsNode = r.IsNode,
                    ParentId = r.ParentId,
                    UpdateTime = r.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    CreateTime = r.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Description = r.Description,
                    Children = GetDictionaryChildren(query, r.DictionaryId)
                });
            });

            return response;
        }

        /// <summary>
        /// Get Dictionary By Id.
        /// 根据ID获取字典（实现）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<ApiResponse> GetDictionaryById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create Dictionary.
        /// 创建字典（实现）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> CreateDictionary(CreateDictonaryRequestDto dto)
        {
            var query = await _dictionaryDependencies.Dictionary.QueryAll().ToListAsync();

            if (query.Any(q => q.DictionaryName == dto.Name || q.Code == dto.Code))
                return Failed("Dictionary name or code already exists");


            Dictionary dictionary = new();
            if (string.IsNullOrEmpty(dto.ParentId))
            {
                /// 根节点 序号为所有根节点数量+1, 根节点层级为1
                int serialNumber = query.Where(q => q.ParentId == null).Count() + 1;
                dictionary = CreateDictionaryObject(dto, serialNumber);
            }
            else
            {
                /// 子节点 序号为同级节点数量+1, 子节点层级为父节点层级+1
                var parent = query.Where(q => q.DictionaryId == dto.ParentId).ToList();
                if (!parent.Any()) return Failed("Parent dictionary does not exist");

                var children = query.Where(q => q.ParentId == dto.ParentId).ToList();

                int serialNumber = children.Count + 1;
                int level = parent.First().Level + 1;
                dictionary = CreateDictionaryObject(dto, serialNumber, level);
            }

            _dictionaryDependencies.Dictionary.Add(dictionary);
            var result = await _dictionaryDependencies.Dictionary.SaveChangesAsync();

            return result >= 1 ? Ok("Success") : Failed("Failed");
        }


        /// <summary>
        /// Create Dictionary Object.
        /// 创建字典对象
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="serialNumber">序号</param>
        /// <param name="level">节点层级</param>
        /// <returns></returns>
        private Dictionary CreateDictionaryObject(CreateDictonaryRequestDto dto, int serialNumber = 1, int level = 1)
        {
            Dictionary dictionary = new()
            {
                DictionaryId = _guidGenerator.GenerateSequentialGuid(),
                DictionaryName = dto.Name,
                Code = dto.Code,
                DictionaryValue = dto.Value,
                IsNode = dto.IsNode,
                Description = dto.Description,
                ParentId = dto.ParentId,
                SerialNumber = serialNumber,
                Level = level,
                Status = 1,
            };

            return dictionary;
        }
    }
}
