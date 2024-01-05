using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas=new List<HangHoa>();


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(string id)
        {
            try
            {

                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
                
                
                

        }


        [HttpPost]

        public IActionResult Creat(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                GiaHangHoa=hangHoaVM.GiaHangHoa,
            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Success = true,
                Data = hanghoa
            }); 
        }


        [HttpPut ("{id}")]
        public IActionResult Edit(string id,HangHoa hangHoaEdit)
        {
            try
            {

                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }

                if(id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                 
                //Update

                hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hangHoa.GiaHangHoa = hangHoaEdit.GiaHangHoa;
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]

        public IActionResult Delete(string id, HangHoa hangHoaEdit)
        {
            try
            {

                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }

                if (id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }

                hangHoas.Remove(hangHoa);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
