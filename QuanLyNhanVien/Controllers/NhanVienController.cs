using Microsoft.AspNetCore.Mvc;
using QLNV.Models.Models;
using QLNV.Services.Services;
using QLNV.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanVien.Controllers
{
    /// <summary>
    /// @Author: Sy Hung
    /// </summary>
    [Route("api/nhanvien/")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _nvService;

        public NhanVienController(INhanVienService nvService)
        {
            _nvService = nvService;
        }

        [HttpGet]
        public ResponseResult<List<NhanVien>> Get()
        {
            var res = new ResponseResult<List<NhanVien>>();
            res.Code = Ok().StatusCode.ToString();
            res.Message = "Success";
            res.Result = _nvService.Get();
            return res;
        }

        [HttpGet("{id:length(24)}", Name = "GetNhanVien")]
        public ResponseResult<NhanVien> Get(string id)
        {
            var res = new ResponseResult<NhanVien>();
            var nhanvien = _nvService.Get(id);

            if (nhanvien == null)
            {
                res.Code = NotFound().StatusCode.ToString();
                res.Message = "Not Found";
                return res;
            }

            res.Code = NotFound().StatusCode.ToString();
            res.Message = "Success";
            res.Result = nhanvien;

            return res;
        }

        [HttpPost]
        public ActionResult<NhanVien> Create(NhanVien nhanvien)
        {
            _nvService.Create(nhanvien);

            return CreatedAtRoute("GetNhanVien", new { id = nhanvien.id.ToString() }, nhanvien);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, NhanVien nhanvienIn)
        {
            var book = _nvService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _nvService.Update(id, nhanvienIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var nhanvien = _nvService.Get(id);

            if (nhanvien == null)
            {
                return NotFound();
            }

            _nvService.Remove(nhanvien.id);

            return NoContent();
        }
    }
}
