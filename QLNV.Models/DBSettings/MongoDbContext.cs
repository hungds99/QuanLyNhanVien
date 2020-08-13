using MongoDB.Driver;
using QLNV.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLNV.Models.DBSettings
{
    /// <summary>
    /// @Author: Sy Hung
    /// </summary>
    public class MongoDbContext
    {
        private readonly IMongoDatabase _db;

        public MongoDbContext(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<NhanVien> NhanViens => _db.GetCollection<NhanVien>("NhanVien");

    }
}
