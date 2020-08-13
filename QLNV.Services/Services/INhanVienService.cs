using QLNV.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLNV.Services.Services
{
    /// <summary>
    /// @Author: Sy Hung
    /// </summary>
    public interface INhanVienService
    {
        public List<NhanVien> Get();

        public NhanVien Get(string id);

        public NhanVien Create(NhanVien nhanvien);

        public void Update(string id, NhanVien nhanvienIn);

        public void Remove(string id);
    }
}
