namespace FSM.Api.Options
{
    /// <summary>
    /// AuthOptions
    /// </summary>
    public class AuthOptions
    {
        /// <summary>
        /// 配置节名称
        /// </summary>
        public const string SectionName = "JWT";

        /// <summary>
        /// SecretKey
        /// </summary>
        public string SecretKey { get; set; } = null!;

        /// <summary>
        /// Issuer
        /// </summary>
        public string Issuer { get; set; } = null!;

        /// <summary>
        /// Audience
        /// </summary>
        public string Audience { get; set; } = null!;


    }
}
