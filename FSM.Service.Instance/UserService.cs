using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Api.Request.Admin.User;
using FSM.Infrastructure.Dto.Api.Response.Admin.User;
using FSM.Infrastructure.Dto.Common;
using FSM.Infrastructure.Dto.Service.User;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Infrastructure.Helpers;
using FSM.Infrastructure.Tools;
using FSM.Service.Dependencies;
using FSM.Service.Interface;

namespace FSM.Service.Instance
{
    [Inject]
    public class UserService : ResponseHelper, IUserService
    {
        private readonly UserDependencies _user;
        private readonly LogDependencies _log;
        private readonly GlobalStatusHelper _statusHelper;
        private readonly GuidGenerator _guidGenerator;
        private readonly PasswordGenerator _passwordGenerator;

        public UserService(
            UserDependencies user,
            LogDependencies log,
            GlobalStatusHelper statusHelper,
            GuidGenerator guidGenerator,
            PasswordGenerator passwordGenerator
            )
        {
            _user = user;
            _log = log;
            _statusHelper = statusHelper;
            _guidGenerator = guidGenerator;
            _passwordGenerator = passwordGenerator;
        }

        public async Task<ApiResponse> CreateMerchant(CreateMerchantRequestDto dto)
        {
            bool isExist = IsExistAccount(dto.Account);
            if (isExist) return Failed("商户账号已存在");

            //TODO: 生成密码
            var generatorOptions = _passwordGenerator.Generate();

            Merchant merchant = new()
            {
                MerchId = _guidGenerator.GenerateSequentialGuid(),
                Account = dto.Account,
                MerchName = dto.Name,
                Contacts = dto.Contacts,
                BusinessLicense = dto.BusinessLicense,
                Description = dto.Description,
                MerchType = dto.Type,
                Status = _statusHelper.USER.Inactive,
                PasswordHash = generatorOptions.PasswordHash,
                PasswordSalt = generatorOptions.PasswordSalt,
            };

            _user.Merchant.Add(merchant);
            int result = await _user.Merchant.SaveChangesAsync();

            return result > 0 ? Ok("创建成功") : Failed("创建失败");

        }

        public Task<ApiResponse> CreateSupplier(CreateSupplierRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public GetUserInfoDto GetUserBySessionId(string sessionId)
        {
            var log = _log.LoginLog.QueryAll
                (false, o => o.CreateTime,
                 q => q.SessionId == sessionId).FirstOrDefault();

            if (log == null) return null!;

            var user = _user.User.QueryAll
                (q => q.UserId == log.UserId).Select(dto => new GetUserInfoDto()
                {
                    UserId = dto.UserId,
                    UserName = dto.UserName,
                    Account = dto.Account,
                    PasswordHash = dto.PasswordHash,
                    PasswordSalt = dto.PasswordSalt,
                    Status = dto.Status,
                    CreateTime = dto.CreateTime,
                    UpdateTime = dto.UpdateTime,
                })
                .FirstOrDefault();

            return user!;
        }

        public bool IsExistUser(string userId)
        {
            return _user.User.QueryAll(q => q.UserId == userId).Any();
        }

        private bool IsExistAccount(string account)
        {
            return _user.Merchant.QueryAll(q => q.Account == account).Any();
        }
    }
}
