using System.Data;

namespace TregHunt.Contracts.Helpers
{
    public interface IExcelExporter
    {
        void ExportToExcel(DataTable dataTable);
    }
}
