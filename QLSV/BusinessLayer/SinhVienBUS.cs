using System;
using System.Data;
using DataLayer;
using DOT;

namespace BusinessLayer
{
    public class SinhVienBUS
    {
        private readonly SinhVienDAL sinhvienDAL = new SinhVienDAL();

        public DataTable GetStudentInfoTableBUS(string studentId)
        {
            try
            {
                return sinhvienDAL.GetStudentInfoTableDAL(studentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SinhVien GetStudentDetailsBUS(string studentId)
        {
            try
            {
                return sinhvienDAL.GetStudentDetailsDAL(studentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetStudentGradesBUS(string mssv)
        {
            try
            {
                return sinhvienDAL.GetStudentGradesDAL(mssv);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching student grades: " + ex.Message, ex);
            }
        }

        //Lấy thời khóa biểu sinh viên
        public DataTable GetStudentScheduleBUS(string mssv)
        {
            try
            {
                return sinhvienDAL.GetStudentScheduleDAL(mssv);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // đăng kí môn
        public bool RegisterCourseBUS(string studentId, string courseId, DateTime date)
        {
            return sinhvienDAL.RegisterCourseDAL(studentId, courseId, date);
        }

        //Hủy đăng kí môn
        public bool UnregisterCourseBUS(string studentId, string courseId)
        {
            try
            {
                return sinhvienDAL.UnregisterCourseDAL(studentId, courseId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error unregistering course: " + ex.Message, ex);
            }
        }

        //Danh sách môn đăng kí  của sinh viên
        public DataTable GetRegisteredCoursesBUS(string studentId)
        {
            try
            {
                return sinhvienDAL.GetRegisteredCoursesDAL(studentId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching registered courses: " + ex.Message);
            }
        }

        //Lấy lịch thi
        public DataTable GetExamScheduleBUS(string studentId)
        {
            try
            {
                return sinhvienDAL.GetExamScheduleDAL(studentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Lấy danh sách môn học đăng kí
        public DataTable GetAvailableCoursesBUS(string maHocKy)
        {
            return sinhvienDAL.GetAvailableCoursesDAL(maHocKy);
        }

        //Lấy danh sách học kì
        public DataTable GetSemesterBUS()
        {
            return sinhvienDAL.GetSemesterDAL();
        }

        //Đổi mật khẩu
        public bool ChangePasswordBUS(string mssv, string pass)
        {
            try
            {
                return sinhvienDAL.ChangePasswordDAL(mssv, pass);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đổi mật khẩu: " + ex.Message);
            }
        }

        //Sủa ảnh

        public bool ChangeImageBUS(byte[] anh, string msss)
        {
            return sinhvienDAL.ChangeImageDAL(anh, msss);
        }
    }
}