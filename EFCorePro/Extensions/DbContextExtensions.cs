using EFCorePro.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace EFCorePro.Extensions
{
    public static class DbContextExtensions
    {
        public static List<T> RawSqlQuery<T>(this DbContext context,string query)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    var entities = new List<T>();

                    return DataReaderMapToList<T>(result);
                }
            }
        }
        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (ColumnExists(dr, prop.Name))
                    {
                        if (!object.Equals(dr[prop.Name], DBNull.Value))
                        {

                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                }
                list.Add(obj);
            }
            return list;
        }
        public static bool ColumnExists(IDataReader reader, string columnName)
        {

            return reader.GetSchemaTable()
                         .Rows
                         .OfType<DataRow>()
                         .Any(row => row["ColumnName"].ToString() == columnName);
        }
    }
}
