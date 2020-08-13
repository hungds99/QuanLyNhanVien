using System;
using System.Collections.Generic;
using System.Text;

namespace QLNV.Models.DBSettings
{
    /// <summary>
    /// @Author: Sy Hung
    /// </summary>
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
