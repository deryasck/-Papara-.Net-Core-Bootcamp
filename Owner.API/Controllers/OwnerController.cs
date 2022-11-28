using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Owner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {

        [Route("")]
        [HttpGet]
        public IActionResult getOwnerrrs()
        {
            var list = new Data.DataOwner().GetOwnerrsList();//Data klasörümün içindeki oluşturmuş olduğum dataOwner class ımın niçindeki listeyi örnekledim
            return Ok(list);
        }


        [HttpPost("")]
        [Consumes("application/json")]// Bu işlem için sadece Application.Json istek kabul edilir
        public IActionResult addOwnerr(OwnerModel.Ownerr model)
        {

            var data = new Data.DataOwner().GetOwnerrsList();
            var listed = data.FirstOrDefault(x => x.ID == model.ID);//gönderilen model ile liste içerisindeki model idlerinin eşit olup olmadığını kotrol eder
            if (listed == null)
            {
             //idlerin eşit olmması durumunda gönderilen modelin explanation değişkeninin kontrolu durumunda modeli listeye ekler
                var owners = new List<OwnerModel.Ownerr>();
                owners.Add(model);
                var owner = owners.Any(x => x.Explanation.Contains("hack"));

                if (!owner)
                {
                    var list = new Data.DataOwner().GetOwnerrsList();
                    list.Add(model);
                    return Ok(list);
                }
                else
                {
                    return BadRequest("hack yazısı bulundurmaktadır");
                }

            }
            else
                return NotFound($"{model.ID} id si zaten bulunmakta"); 

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
         //liste içerisinde gönderilen id ye göre modeli bulup silm eişlemi yapar. id yosa notFount dönüş tipi döner
            var list = new Data.DataOwner().GetOwnerrsList();
            var listed = list.FirstOrDefault(x => x.ID == id);
           // if (listed == null)
              //  return NotFound("id bulunamadı");
            list.Remove(listed);
            return Ok(list);
        }



        [HttpPut("")]
        public IActionResult UpdateData(int id, OwnerModel.Ownerr model)
        {
            //id konrtolüyle istenilen modeli güncelleme işlemi
            if (id != model.ID)
                return BadRequest("müşteri idleri eşleşmedi");

            var list = new Data.DataOwner().GetOwnerrsList();
            var update = list.FirstOrDefault(x => x.ID == id);

            update.Name = model.Name;
            update.Type = model.Type;
            update.Explanation = model.Explanation;
            update.Date = model.Date;
            return Ok(list);
        }

    }


}
