using System.Collections.Generic;
using System.Threading.Tasks;
using ExamTask.API.Requests;
using ExamTask.Common.Models;
using ExamTask.Services.Contracts;
using ExamTask.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamTask.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService orderService;
        private readonly IXmlOrdersImporter xmlOrdersImporter;

        public OrdersController(IOrdersService orderService, IXmlOrdersImporter xmlOrdersImporter)
        {
            this.orderService = orderService;
            this.xmlOrdersImporter = xmlOrdersImporter;
        }

        [HttpGet]
        public async Task<List<OrderVM>> Orders()
        {
            return await orderService.GetAllOrders();
        }

        [HttpGet("{filteredId}")]
        public async Task<List<OrderVM>> FilteredOrders(string filteredId)
        {
            return await orderService.FilterOrderById(filteredId);
        }

        [HttpPost]
        [Route("import")]
        public async Task<IActionResult> Import(IFormFile uploadedFile)
        {
            if (uploadedFile == null) return StatusCode(422);

            GeneralResult<IList<long>> result = await xmlOrdersImporter.ImportAsync(uploadedFile.OpenReadStream());

            if (!result.IsSuccess)
            {
                return BadRequest(new { AlreadyExistsIds = result.Error, ErrorMessage = result.Message, IntrenalErrorCode = result.ErrorCode });
            }

            return Ok();
        }

        [HttpPut]
        [Route("set-order-status")]
        public async Task<IActionResult> SetOrderStatus(OrderSetStatusRequest request)
        {
            await orderService.SetOrderStatusAsync(request.OrderId, request.Status);
            return Ok();
        }

        [HttpPut]
        [Route("set-order-invoice-number")]
        public async Task<IActionResult> SetOrderInvoiceNumber(OrderSetInvoiceNumber orderSetInvoiceNumber)
        {
            await orderService.SetOrderInvoiceAsync(orderSetInvoiceNumber.OrderId, orderSetInvoiceNumber.InvoiceNumber);
            return Ok();
        }
    }
}
