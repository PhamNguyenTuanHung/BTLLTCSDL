using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Repository<T> where T : class, new()
    {
        public static bool InsertInformation<T>(T entity) where T : class, new()
        {
            Type dataType = typeof(T);
            var properties = dataType.GetProperties();

            string tableName = dataType.Name; // Lấy tên bảng từ class T
            string columnNames = string.Join(", ", properties.Select(p => p.Name));
            string values = string.Join(", ", properties.Select(p => "@" + p.Name));

            string query = $"INSERT INTO {tableName} ({columnNames}) VALUES ({values})";

            List<SqlParameter> parameters = properties.Select(p =>
                new SqlParameter("@" + p.Name, p.GetValue(entity) ?? DBNull.Value)).ToList();

            return DBProviderDAL.MyExecuteNonQuery(query, parameters.ToArray()) > 0;
        }


        public static bool UpdateInformation<T>(T entity, string condition) where T : class, new()
        {
            Type dataType = typeof(T);
            var properties = dataType.GetProperties();

            string tableName = dataType.Name; // Lấy tên bảng từ tên class
            string setClause = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));

            string query = $"UPDATE {tableName} SET {setClause} WHERE {condition}";

            List<SqlParameter> parameters = properties.Select(p =>
                new SqlParameter("@" + p.Name, p.GetValue(entity) ?? DBNull.Value)).ToList();

            return DBProviderDAL.MyExecuteNonQuery(query, parameters.ToArray()) > 0;
        }



        public static bool DeleteInformation<T>(T entity) where T : class, new()
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            // Lấy khóa chính (giả sử luôn là thuộc tính đầu tiên)
            var primaryKey = properties.FirstOrDefault();
            if (primaryKey == null)
            {
                throw new Exception("Không tìm thấy khóa chính.");
            }

            // Lấy giá trị khóa chính từ entity
            object primaryValue = primaryKey.GetValue(entity);
            if (primaryValue == null)
            {
                throw new Exception("Giá trị khóa chính không hợp lệ.");
            }

            string tableName = type.Name;  // Lấy tên bảng từ kiểu T
            string query = $"DELETE FROM {tableName} WHERE {primaryKey.Name} = @{primaryKey.Name}";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter($"@{primaryKey.Name}", primaryValue)
            };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }




    }
}
