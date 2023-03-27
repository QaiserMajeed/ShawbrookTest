using Microsoft.AspNetCore.Mvc;
using ShawbrookFullStackEngineer.Domain;
using ShawbrookFullStackEngineer.Models;
using ShawbrookFullStackEngineer.Services;


namespace ShawbrookFullStackEngineer.Controllers
{
    public class PurchaseOrderController : Controller
    {
        [Route("[controller]")]
        [HttpPost]
        public IActionResult Create([FromBody] PurchaseOrderModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var purchaseOrder = new PurchaseOrderBinder(model).Bind();
            return Ok(new Processor().Create(purchaseOrder));
        }
    }
}
