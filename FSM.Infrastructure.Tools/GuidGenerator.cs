using FSM.Infrastructure.Attribute;

namespace FSM.Infrastructure.Tools
{
    /// <summary>
    /// Guid生成器
    /// </summary>
    [Provider, Inject]
    public class GuidGenerator
    {
        private static readonly ThreadLocal<Random> Random =
            new(() => new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0)));

        /// <summary>
        /// 生成顺序Guid
        /// </summary>
        /// <returns></returns>
        public string GenerateSequentialGuid()
        {
            var bytes = new byte[16];
            var now = DateTime.UtcNow;

            // 前8字节使用时间戳
            var ticks = now.Ticks;
            Buffer.BlockCopy(BitConverter.GetBytes(ticks), 0, bytes, 0, 8);

            // 后8字节使用随机数
            var randomBytes = new byte[8];
            Random.Value?.NextBytes(randomBytes);
            Buffer.BlockCopy(randomBytes, 0, bytes, 8, 8);

            return new Guid(bytes).ToString("N").ToUpper();
        }

        /// <summary>
        /// 生成随机Guid
        /// </summary>
        /// <returns></returns>
        public string GenerateRandomGuid()
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }
    }
}
