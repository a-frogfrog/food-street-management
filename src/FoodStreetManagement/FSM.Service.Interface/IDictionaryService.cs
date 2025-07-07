using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Api.Request.Admin.Dictionary;
using FSM.Infrastructure.Dto.Api.Response.Admin.MasterData;
using FSM.Infrastructure.Dto.Common;

namespace FSM.Service.Interface
{
    /// <summary>
    /// 全局字典服务接口
    /// </summary>
    [Provider]
    public interface IDictionaryService
    {
        /// <summary>
        /// 获取所有字典
        /// </summary>
        /// <returns></returns>
        Task<ApiResponse> GetDictionaryList();

        /// <summary>
        /// 根据id获取字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResponse> GetDictionaryById(string id);

        /// <summary>
        /// 创建字典
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ApiResponse> CreateDictionary(CreateDictonaryRequestDto dto);
    }
}
