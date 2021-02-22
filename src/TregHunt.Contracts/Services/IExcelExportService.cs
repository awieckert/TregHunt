using System;
using System.Collections.Generic;
using System.Text;
using TregHunt.Contracts.Models;

namespace TregHunt.Contracts.Services
{
    public interface IExcelExportService
    {
        void ExportESearchESumResult(IEnumerable<PubMedESearchESumResponse> results);
    }
}
