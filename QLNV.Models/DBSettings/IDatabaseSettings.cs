using System;
using System.Collections.Generic;
using System.Text;

namespace QLNV.Models.DBSettings
{
    /// <summary>
    /// @Author: Sy Hung
    /// </summary>
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
