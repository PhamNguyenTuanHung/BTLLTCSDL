using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DOT;

namespace BusinessLayer
{
    public class SinhVien_BUS
    {
        private SinhVien_DAL sinhvienDAL = new SinhVien_DAL();

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

        public DataTable GetStudentGradesBUS(string query)
        {
            try
            {
                return sinhvienDAL.GetStudentGradesDAL(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching student grades: " + ex.Message, ex);
            }
        }

        public DataTable GetStudentScheduleBUS(string query)
        {
            try
            {
                return sinhvienDAL.GetStudentScheduleDAL(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public bool RegisterCourseBUS(string studentId, string courseId, DateTime date)
        {
            try
            {
                return sinhvienDAL.RegisterCourseDAL(studentId, courseId, date);
            }
            catch (Exception ex)
            {
                throw new Exception("Error registering course: " + ex.Message, ex);
            }
        }

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

        public DataTable GetAvailableCoursesBUS()
        {
            try
            {
                return sinhvienDAL.GetAvailableCoursesDAL();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching available courses: " + ex.Message, ex);
            }
        }

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
    }
}
