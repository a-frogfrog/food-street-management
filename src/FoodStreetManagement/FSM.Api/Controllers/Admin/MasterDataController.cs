using FSM.Infrastructure.Dto.Api.Request.Admin.Dictionary;
using FSM.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSM.Api.Controllers.Admin
{
    /// <summary>
    /// Master Data 模块 (全局数据管理)
    /// </summary>
    public class MasterDataController : AdminController
    {
        private readonly IDictionaryService _dictionaryService;

        /// <summary>
        /// 构造函数
        /// Constructor
        /// </summary>
        /// <param name="baseService"></param>
        /// <param name="dictionaryService"></param>
        public MasterDataController(
            IBaseService baseService, 
            IDictionaryService dictionaryService) : base(baseService)
        {
            _dictionaryService = dictionaryService;
        }

        /// <summary>
        /// 获取全局数据字典
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDictionaryList()
        {
            var result = await _dictionaryService.GetDictionaryList();
            return Ok(result);
        }

        /// <summary>
        /// 创建全局数据字典
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateDictionary([FromBody] CreateDictonaryRequestDto dto) 
        {
            var result = await _dictionaryService.CreateDictionary(dto);
            return Ok(result);
        }
    }
}
