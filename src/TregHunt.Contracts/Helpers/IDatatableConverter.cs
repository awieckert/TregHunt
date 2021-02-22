using System.Collections.Generic;
using System.Data;

namespace TregHunt.Contracts.Helpers
{
    public interface IDatatableConverter
    {
        DataTable ListToDataTable<T>(IEnumerable<T> listToConvert);
    }
}
