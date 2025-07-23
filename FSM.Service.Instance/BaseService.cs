using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Service.User;
using FSM.Service.Dependencies;
using FSM.Service.Interface;

namespace FSM.Service.Instance
{
    [Inject]
    public class BaseService : IBaseService
    {
        private readonly UserDependencies _user;
        private readonly LogDependencies _log;

        public BaseService(
            UserDependencies user,
            LogDependencies log)
        {
            _user = user;
            _log = log;
        }

        public GetUserInfoDto GetUserInfo(string sessionId)
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
    }
}
