using LinqToExcel.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TregHunt.Services.ExcelData
{
    public class SearchTerm
    {
        [ExcelColumn("Term")]
        public string Term { get; set; }
    }
}
