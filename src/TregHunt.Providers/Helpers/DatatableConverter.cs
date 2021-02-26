using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using TregHunt.Contracts.Helpers;

namespace TregHunt.Services.Helpers
{
    public class DatatableConverter : IDatatableConverter
    {
        public DataTable ListToDataTable<T>(IEnumerable<T> listToConvert)
        {
            try
            {
                // creating a data table instance and named it as the incoming T name
                DataTable dataTable = new DataTable(typeof(T).Name);

                //Get all the properties on type
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                // Loop through all the properties            
                // Adding Column name to our datatable
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names 
                    dataTable.Columns.Add(prop.Name);
                }

                // Adding Row and its value to our dataTable
                foreach (T item in listToConvert)
                {
                    var values = new object[Props.Length];

                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows 
                        values[i] = Props[i].GetValue(item, null);
                    }
                    // Finally add value to datatable 
                    dataTable.Rows.Add(values);
                }

                return dataTable;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
