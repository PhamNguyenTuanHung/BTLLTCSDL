using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOT;
using DataLayer;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class AdminBUS
    {
        private AdminDAL adminDAL = new AdminDAL();

        public List<string> GetTableNameDAL()
        {


            return adminDAL.GetTableNameDAL();
        }
        public List<string> GetPrimaryKeysBUS(string tableName)
        {

            return adminDAL.GetPrimaryKeysDAL(tableName);
        }

        public List<string> GetForiegnKeysBUS(string tableName)
        {
            return adminDAL.GetForiegnKeysDAL(tableName);
        }

        public Dictionary<string, List<string>> GetForeignKeyValuesBUS(List<string> foreignnKeys,string tableName)
        {
            return adminDAL.GetForeignKeyValuesDAL(foreignnKeys,tableName);
        }
        //Lấy dữ liệu
        public DataTable GetLecturersListBUS()
        {

            return adminDAL.GetLecturersListDAL();

        }

        public DataTable GetStudentsListBUS()
        {


            return adminDAL.GetStudentsListDAL();

        }

        public DataTable GetSubjectsListBUS()
        {

            return adminDAL.GetSubjectsListDAL();

        }

        public DataTable GetClassListBUS()
        {

            return adminDAL.GetClassListDAL();

        }

        public DataTable GetScheduleBUS()
        {

            return adminDAL.GetScheduleDAL();

        }

        public DataTable GetExamScheduleBUS()
        {

            return adminDAL.GetExamScheduleDAL();

        }

        public DataTable GetStudentGradesBUS()
        {

            return adminDAL.GetStudentGradesDAL();

        }

        public DataTable GetAccountListBUS()
        {

            return adminDAL.GetAccountListsDAL();

        }

        //Hàm thêm

        public bool InsertStudentBUS(SinhVien sv)
        {
            return adminDAL.InsertStudentDAL(sv);
        }

        public bool InsertLecturerBUS(GiangVien gv)
        {
            return adminDAL.InsertLecturerDAL(gv);
        }

        public bool InsertCourseBUS(MonHoc mh)
        {


            return adminDAL.InsertCourseDAL(mh);
        }

        public bool InsertCourseClassBUS(LopMonHoc lopMonHoc)
        {
            return adminDAL.InsertCourseClassDAL(lopMonHoc);
        }

        public bool InsertGradeBUS(DiemSV diem)
        {
            return adminDAL.InsertGradeDAL(diem);
        }

        public bool InsertScheduleBUS(ThoiKhoaBieu tkb)
        {
            return adminDAL.InsertScheduleDAL(tkb);
        }

        public bool InsertExamScheduleBUS(LichThi lichThi)
        {
            return adminDAL.InsertExamScheduleDAL(lichThi);
        }

        public bool InsertAccountBUS(TaiKhoan taiKhoan)
        {
            return adminDAL.InsertAccountDAL(taiKhoan);
        }


        //Hàm xóa
        public bool DeleteStudent(string mssv)
        {
            return adminDAL.DeleteStudentDAL(mssv);
        }

        public bool DeleteLecturer(string msgv)
        {
            return adminDAL.DeleteLecturerDAL(msgv);
        }

        public bool DeleteCourse(string maMonHoc)
        {
            return adminDAL.DeleteCourseDAL(maMonHoc);
        }

        public bool DeleteCourseClass(string maLopMonHoc)
        {
            return adminDAL.DeleteCourseClassDAL(maLopMonHoc);
        }

        public bool DeleteGrade(string mssv, string maMonHoc, string maHocKy)
        {
            return adminDAL.DeleteGradeDAL(mssv, maMonHoc, maHocKy);
        }

        public bool DeleteSchedule(string maTKB)
        {
            return adminDAL.DeleteScheduleDAL(maTKB);
        }

        public bool DeleteExamSchedule(string maLichThi)
        {
            return adminDAL.DeleteExamScheduleDAL(maLichThi);
        }

        public bool DeleteAccountBUS(string tenDangNhap)
        {
            

            return adminDAL.DeleteAccountDAL(tenDangNhap);
        }
        // Hàm cập nhật dữ liệu

        public bool UpdateStudentBUS(SinhVien sv)
        {
            return adminDAL.UpdateStudentDAL(sv);
        }
        public bool UpdateLecturerBUS(GiangVien gv)
        {
            return adminDAL.UpdateLecturerDAL(gv);
        }

        public bool UpdateCourseBUS(MonHoc mh)
        {
            return adminDAL.UpdateCourseDAL(mh);
        }

        public bool UpdateCourseClassBUS(LopMonHoc lopMonHoc)
        {
            return adminDAL.UpdateCourseClassDAL(lopMonHoc);
        }

        public bool UpdateGradeBUS(DiemSV diem)
        {
            return adminDAL.UpdateGradeDAL(diem);
        }

        public bool UpdateScheduleBUS(ThoiKhoaBieu tkb)
        {
            return adminDAL.UpdateScheduleDAL(tkb);
        }

        public bool UpdateExamScheduleBUS(LichThi lichThi)
        {
            return adminDAL.UpdateExamScheduleDAL(lichThi);
        }

        public bool UpdateAccountBUS(TaiKhoan taiKhoan)
        {
            return adminDAL.UpdateAccountDAL(taiKhoan);
        }
    }
}
