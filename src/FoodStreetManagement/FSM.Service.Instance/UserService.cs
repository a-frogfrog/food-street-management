using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Service.User;
using FSM.Service.Dependencies;
using FSM.Service.Interface;

namespace FSM.Service.Instance
{
    [Inject]
    public class UserService : IUserService
    {
        private readonly UserDependencies _user;
        private readonly LogDependencies _log;

        public UserService(UserDependencies user, LogDependencies log)
        {
            _user = user;
            _log = log;
        }

        public GetUserInfoDto GetUserBySessionId(string sessionId)
        {
            var log = _log._loginLog.QueryAll
                (false, o => o.CreateTime,
                 q => q.SessionId == sessionId).FirstOrDefault();

            if (log == null) return null!;

            var user = _user._user.QueryAll
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
            return _user._user.QueryAll(q => q.UserId == userId).Any();
        }
    }
}
