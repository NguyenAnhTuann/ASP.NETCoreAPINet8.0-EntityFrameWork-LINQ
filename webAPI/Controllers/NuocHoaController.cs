using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NuocHoaController : ControllerBase
    {
        public static List<NuocHoa> NuocHoas = new List<NuocHoa>();
        private int _nextMaNH;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(NuocHoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var nuochoa = NuocHoas.SingleOrDefault(nh => nh.MaNH == Guid.Parse(id));
                if (nuochoa == null)
                {
                    return NotFound();
                }return Ok(nuochoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(NuocHoaVM nuocHoaVM)
        {
            var nuochoa = new NuocHoa
            {
                MaNH = Guid.NewGuid(),
                TenNH = nuocHoaVM.TenNH,
                Dongia = nuocHoaVM.Dongia
            };
            NuocHoas.Add(nuochoa);
            return Ok(new
            {
                Success = true, Data = nuochoa
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, NuocHoa nuochoaEdit)
        {
            try
            {
                var nuochoa = NuocHoas.SingleOrDefault(nh => nh.MaNH == Guid.Parse(id));
                if (nuochoa == null)
                {
                    return NotFound();
                }
                if (id != nuochoa.MaNH.ToString())
                {
                    return BadRequest();

                }

                nuochoa.TenNH = nuochoaEdit.TenNH;
                nuochoa.Dongia = nuochoaEdit.Dongia;

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                var nuochoa = NuocHoas.SingleOrDefault(nh => nh.MaNH == Guid.Parse(id));
                if (nuochoa == null)
                {
                    return NotFound();
                }
                if (id != nuochoa.MaNH.ToString())
                {
                    return BadRequest();

                }

                NuocHoas.Remove(nuochoa);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }


}
