using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace MiddlewareException.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiddlewareController:ControllerBase    
    {
        [Route("{Id}")]
        [HttpGet]
        public ActionResult<MiddlewareModel.MidModel> GetEmployeeDetails(int Id)
        {
           if (Id !=1)
            {
                return NotFound("Çalışan bulunamadı!");
            }

            else
            {
                return new MiddlewareModel.MidModel
                {
                    ID = 1,
                    Name = "Derya",
                    Surname = "Sucuk"

                };
                return NotFound("işlem başarılı");

            }
        }

        [HttpPost("")]
        public IActionResult addOwnerr(MiddlewareModel.MidModel model)
        {
                var owners = new List<MiddlewareModel.MidModel>();
                owners.Add(model);
                return Ok();
        }

        

    }
}
