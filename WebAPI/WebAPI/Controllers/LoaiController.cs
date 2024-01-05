using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Data.EF;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;

        public LoaiController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        [HttpGet]
        public IActionResult GetALL()
        {
            var dsloai = _myDbContext.Loais.ToList();
            return Ok(dsloai);
        }

        [HttpGet("{ID}")]
        public IActionResult GetALL(string ID)
        {
            var loai = _myDbContext.Loais.SingleOrDefault(Lo=>Lo.MaLoai.ToString()==ID);
            if (loai != null)
            {
                return Ok(loai);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = model.TenLoai
                };

                _myDbContext.Add(loai);
                _myDbContext.SaveChanges();


                return Ok(model);
            }
            catch
            {
                return NotFound();
            }
            
        }


        [HttpPut("{ID}")]
        public IActionResult GetALL(string ID,LoaiModel loaiModel)
        {
            var loai = _myDbContext.Loais.SingleOrDefault(Lo => Lo.MaLoai.ToString() == ID);
            if (loai != null)
            {
                loai.TenLoai = loaiModel.TenLoai;
                _myDbContext.SaveChanges();
                return Ok(loai);
            }
            return NotFound();
        }
    }
}
