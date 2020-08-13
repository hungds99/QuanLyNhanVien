using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLNV.Models.Models
{
    /// <summary>
    /// @Author: Sy Hung
    /// </summary>
    public class NhanVien
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string tenNhanVien { get; set; }
        public int tuoi { get; set; }
        public string diaChi { get; set; }
    }
}
