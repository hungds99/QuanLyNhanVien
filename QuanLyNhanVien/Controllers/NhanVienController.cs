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
    /// NhanVien controller for api
    /// </summary>
    /// <author>Sy Hung</author>
    /// <createdDate>13/08/2020</createdDate>
    /// <updatedDate>16/08/2020</updatedDate>
    [Route("api/nhanvien/")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _nvService;

        /// <summary>
        /// INhanVienService inject NhanVienController
        /// </summary>
        /// <param name="nvService"></param>
        public NhanVienController(INhanVienService nvService)
        {
            _nvService = nvService;
        }

        /// <summary>
        /// Get all NhanVien
        /// </summary>
        /// <returns>List NhanVien</returns>
        [HttpGet]
        public ResponseResult<List<NhanVien>> Get()
        {
            var res = new ResponseResult<List<NhanVien>>();
            res.Code = Ok().StatusCode.ToString();
            res.Message = "Success";
            res.Result = _nvService.Get();
            return res;
        }

        /// <summary>
        /// Get NhanVien By id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>NhanVien</returns>
        [HttpGet("{id}", Name = "GetNhanVien")]
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

            res.Code = Ok().StatusCode.ToString();
            res.Message = "Success";
            res.Result = nhanvien;

            return res;
        }

        /// <summary>
        /// Create a new NhanVien
        /// </summary>
        /// <param name="nhanvien">nhanvien</param>
        /// <returns>NhanVien created</returns>
        [HttpPost]
        public ActionResult<ResponseResult<NhanVien>> Create(NhanVien nhanvien)
        {
            try
            {
                _nvService.Create(nhanvien);
            } catch(Exception e)
            {
                var res = new ResponseResult<NhanVien>();
                res.Code = "500";
                res.Message = "Create Failed : " + e.Message;
                return res;
            }

            return CreatedAtRoute("GetNhanVien", new { id = nhanvien.id.ToString() }, nhanvien);
        }

        /// <summary>
        /// Update a existing NhanVien
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="nhanvienIn">nhanvien input</param>
        /// <returns>nhanvien updated</returns>
        [HttpPut("{id}")]
        public ResponseResult<NhanVien> Update(string id, NhanVien nhanvienIn)
        {
            var res = new ResponseResult<NhanVien>();
            var book = _nvService.Get(id);

            if (book == null)
            {
                res.Code = NotFound().StatusCode.ToString();
                res.Message = "Not Found";
                return res;
            }

            try
            {
                _nvService.Update(id, nhanvienIn);
            } catch (Exception e)
            {
                res.Code = "500";
                res.Message = "Update Failed : " + e.Message;
                return res;
            }

            res.Code = NoContent().StatusCode.ToString();
            res.Message = "Update Success";
            res.Result = nhanvienIn;
            return res;
        }

        /// <summary>
        /// Delete a existing NhanVien
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>NhanVien deleted</returns>
        [HttpDelete("{id}")]
        public ResponseResult<NhanVien> Delete(string id)
        {
            var res = new ResponseResult<NhanVien>();
            var nhanvien = _nvService.Get(id);

            if (nhanvien == null)
            {
                res.Code = NotFound().StatusCode.ToString();
                res.Message = "Not Found";
                return res;
            }

            _nvService.Remove(nhanvien.id);

            res.Code = NoContent().StatusCode.ToString();
            res.Message = "Delete Success";
            return res;
        }
    }
}
