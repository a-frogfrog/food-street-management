using FSM.Infrastructure.Attribute;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FSM.Infrastructure.Tools
{
    /// <summary>
    /// JWT生成器
    /// </summary>
    [Provider, Inject]
    public class JwtTokenGenerator
    {
        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="code"></param>
        /// <param name="securityKey"></param>
        /// <param name="issuer"></param>
        /// <returns></returns>
        public string GenerateToken(string code, string securityKey, string issuer , string audience, string role = "admin")
        {
            // 验证securityKey的长度是否足够
            if (Encoding.UTF8.GetBytes(securityKey).Length < 32)
            {
                throw new ArgumentException("Security key must be at least 32 bytes (256 bits) for HmacSha256 algorithm.", nameof(securityKey));
            }

            var claims = new[]
            {
               new Claim(ClaimTypes.Name,  code),
               new Claim(ClaimTypes.Role, role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                  issuer: issuer,
                  audience: audience,
                  claims: claims,
                  expires: DateTime.Now.AddHours(12), //token 过期时间
                  signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
