using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSM.Api.Controllers.Supplier
{
    /// <summary>
    /// Auth 模块
    /// </summary>
    public class AuthController : SupplierController
    {

        /// <summary>
        /// Supplier 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login() 
        {
            return Ok();    
        }
    }
}
