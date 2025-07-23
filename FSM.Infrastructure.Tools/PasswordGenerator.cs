using FSM.Infrastructure.Attribute;

namespace FSM.Infrastructure.Tools
{
    /// <summary>
    /// This class is used to generate random passwords.
    /// 密码生成器工具类
    /// </summary>
    [Provider, Inject]
    public class PasswordGenerator
    {
        private readonly ReadConfigurationUtils _read;
        private readonly GuidGenerator _guidGenerator;

        public PasswordGenerator(
            ReadConfigurationUtils read,
            GuidGenerator guidGenerator)
        {
            _read = read;
            _guidGenerator = guidGenerator;
        }


        /// <summary>
        /// Generate a random password.
        /// </summary>
        /// <returns></returns>
        public PasswordGeneratorOptions Generate()
        {
            string defaultPassword = _read.GetUserDefaultPassword();

            string passwordSalt = _guidGenerator.GenerateSequentialGuid();
            string passwordHash = EncryptUtil.LoginMd5(defaultPassword, passwordSalt);

            return new PasswordGeneratorOptions
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        }
    }


    public class PasswordGeneratorOptions
    {
        public string PasswordHash { get; set; } = string.Empty;

        public string PasswordSalt { get; set; } = string.Empty;
    }
}
