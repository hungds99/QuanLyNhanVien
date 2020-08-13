using MongoDB.Driver;
using QLNV.Models.DBSettings;
using QLNV.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLNV.Services.Services
{
    /// <summary>
    /// @Author: Sy Hung
    /// </summary>
    public class NhanVienService : INhanVienService
    {
        private readonly MongoDbContext _db;

        public NhanVienService(MongoDbContext db)
        {
            _db = db;
        }
        public List<NhanVien> Get() =>
           _db.NhanViens.Find(nhanvien => true).ToList();


        public NhanVien Get(string id) =>
            _db.NhanViens.Find<NhanVien>(nhanvien => nhanvien.id == id).FirstOrDefault();

        public NhanVien Create(NhanVien nhanvien)
        {
            _db.NhanViens.InsertOne(nhanvien);
            return nhanvien;
        }

        public void Update(string id, NhanVien nhanvienIn) =>
            _db.NhanViens.ReplaceOne(nhanvien => nhanvien.id == id, nhanvienIn);

        public void Remove(string id) =>
            _db.NhanViens.DeleteOne(nhanvien => nhanvien.id == id);
    }
}
