using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DOT;
namespace DataLayer
{
    public class AdminDAL
    {
        public DataTable GetLecturersListDAL()
        {
            try
            {
                string query = "SELECT * FROM GiaoVien ";
                return DBConnectDAL.GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetStudentsListDAL()
        {
            try
            {
                string query = "SELECT * FROM SinhVien ";
                return DBConnectDAL.GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetSubjectsListDAL()
        {
            try
            {
                string query = "SELECT * FROM MonHoc ";
                return DBConnectDAL.GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetClassListDAL()
        {
            try
            {
                string query = "SELECT * FROM LopMonHoc ";
                return DBConnectDAL.GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetExamScheduleDAL()
        {
            try
            {
                string query = "SELECT * FROM LichThi ";
                return DBConnectDAL.GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetStudentGradesDAL()
        {
            try
            {
                string query = "SELECT * FROM Diem ";
                return DBConnectDAL.GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetScheduleDAL()
        {
            try
            {
                string query = "SELECT * FROM ThoiKhoaBieu";
                return DBConnectDAL.GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddLecturerDAL()
        {
            try
            {
                // Code to add lecturer
            }
            catch (Exception ex)
            {
                throw;
            }
            return false;
        }

        public DataTable GetDataTableDAL(string tableName)
        {
            string query = $"SELECT * FROM {tableName} ";
            return DBConnectDAL.GetDataTable(query);
        }

    }
}
