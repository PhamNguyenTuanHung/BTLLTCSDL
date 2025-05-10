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
using System.Runtime.InteropServices.WindowsRuntime;

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

        public Dictionary<string, List<string>> GetForeignKeyValuesWithReferencedTablesBUS(string tableName)
        {
            return adminDAL.GetForeignKeyValuesWithReferencedTablesDAL(tableName);
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

        public DataTable GetAllRegisteredCoursesBUS()
        {
           return adminDAL.GetAllRegisteredCoursesDAL();
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

        public DataTable GetClassBUS()
        {
            return adminDAL.GetClassDAL();
        }

        public DataTable GetDepartmentsBUS()
        {
            return adminDAL.GetDepartmentsDAL();
        }
        //Hàm thêm

        public bool InsertClassBUSDAL(Lop lop )
        {
            return adminDAL.InsertClassDAL(lop);
        }

        public bool InsertCourseForRegistrationBUS(MonMoDangKy monMoDangKy)
        {
            return adminDAL.InsertCourseForRegistrationDAL(monMoDangKy);
        }

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
        public bool InsertDepartmentBUS(Khoa khoa)
        {
            return adminDAL.InsertDepartmentDAL(khoa);
        }


        //Hàm xóa

        public bool DeleteDepartmentBUS(string maKhoa)
        {
            return adminDAL.DeleteDepartmentDAL(maKhoa);
        }

        public bool DeleteClassBUS(string maLop )
        {
            return adminDAL.DeleteClassDAL(maLop);
        }
        public bool DeleteStudentBUS(string mssv)
        {
            return adminDAL.DeleteStudentDAL(mssv);
        }

        public bool DeleteLecturerBUS(string msgv)
        {
            return adminDAL.DeleteLecturerDAL(msgv);
        }

        public bool DeleteCourseBUS(string maMonHoc)
        {
            return adminDAL.DeleteCourseDAL(maMonHoc);
        }

        public bool DeleteCourseClassBUS(string maLopMonHoc)
        {
            return adminDAL.DeleteCourseClassDAL(maLopMonHoc);
        }

        public bool DeleteGradeBUS(string mssv, string maMonHoc, string maHocKy)
        {
            return adminDAL.DeleteGradeDAL(mssv, maMonHoc, maHocKy);
        }

        public bool DeleteScheduleBUS(string maTKB)
        {
            return adminDAL.DeleteScheduleDAL(maTKB);
        }

        public bool DeleteExamScheduleBUS(string maLichThi)
        {
            return adminDAL.DeleteExamScheduleDAL(maLichThi);
        }

        public bool DeleteAccountBUS(string tenDangNhap)
        {
            
            return adminDAL.DeleteAccountDAL(tenDangNhap);
        }
        public bool DeleteCourseFromRegistrationDAL(string maLopMo)
        {
            return adminDAL.DeleteCourseFromRegistrationDAL(maLopMo);
        }
        // Hàm cập nhật dữ liệu

        public bool UpdateDepartmentBUS(Khoa khoa)
        {
            return adminDAL.UpdateDepartmentDAL(khoa);
        }
        public bool UpdateClasstBUS(Lop lop)
        {
            return adminDAL.UpdateClassDAL(lop);
        }

        public bool UpdateCourseFromRegistrationBUS(MonMoDangKy monMoDangKy)
        {
            return adminDAL.UpdateCourseFromRegistrationDAL(monMoDangKy);
        }

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
