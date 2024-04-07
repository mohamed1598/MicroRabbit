using MicroRabbit.Banking.Application;
using MicroRabbit.Banking.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MicroRabbit.Banking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController(IAccountService accountService) : ControllerBase
    {
        private readonly IAccountService _accountService=accountService;

        [HttpGet]
        public ActionResult<IEnumerable<IAccount>> Get()
        {
            return Ok(_accountService.GetAccounts());
        }
        [HttpPost]
        public IActionResult Post([FromBody] AccountTransfer accountTransfer)
        {
            _accountService.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}
