using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Transfer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController(ITransferService transferService) : ControllerBase
    {
        private readonly ITransferService _transferService=transferService;
        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> Get()
        {
            return Ok(_transferService.GetTransferLogs());
        }
    }
}
