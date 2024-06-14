using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Data;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDbcontext _context;

        public LoaiController(MyDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsLoai = _context.Loais;
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if(Loai != null)
            {
                return Ok(Loai);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult GetUploadLoaiByid(int id, LoaiModel model)
        {
            var Loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (Loai != null)
            {
                Loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
                if (loai == null)
                {
                    return NotFound();
                }

                _context.Loais.Remove(loai);
                _context.SaveChanges();

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
