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
        /*public DataTable DanhSachGiangVienDAl()
        {
			try
			{
                string query = "SELECT * FROM GiaoVien ";
                return DBConnect_DAL.GetDataTable(query);

            }
			catch ( Exception ex)
			{

				throw ex;
			}
        }
        public DataTable DanhSachSinhVienDAl()
        {
            try
            {
                string query = "SELECT * FROM SinhVien ";
                return DBConnect_DAL.GetDataTable(query);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable DanhSachMonHocDAl()
        {
            try
            {
                string query = "SELECT * FROM MonHoc ";
                return DBConnect_DAL.GetDataTable(query);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable DanhSachLopMonHocDAl()
        {
            try
            {
                string query = "SELECT * FROM LopMonHoc ";
                return DBConnect_DAL.GetDataTable(query);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable DanhSachLichThiDAl()
        {
            try
            {
                string query = "SELECT * FROM LichThi ";
                return DBConnect_DAL.GetDataTable(query);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable DanhSachDiemSVDAl()
        {
            try
            {
                string query = "SELECT * FROM Diem ";
                return DBConnect_DAL.GetDataTable(query);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ThemGiangVienDAL()
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            return false;
        }*/

        public DataTable GetDataTableDAL(string tenBang)
        {
            string query = $"SELECT * FROM {tenBang} ";
            return DBConnect_DAL.GetDataTable(query) ;
        }

    }
}
