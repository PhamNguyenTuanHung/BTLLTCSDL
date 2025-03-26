using System;
using System.Collections.Generic;
using System.Data;
using DataLayer;
using DOT;

namespace BusinessLayer
{
    public class GiangVien_BUS
    { 
        private readonly GiangVien_DAL gvDAL = new GiangVien_DAL();

        public GiangVien GetLecturerInfoBUS(string msgv)
        {

            return gvDAL.GetLecturerInfoDAL(msgv);
        }

        public DataTable GetLecturerInfoTableBUS(string msgv)
        {
            return gvDAL.GetLecturerInfoTableDAL(msgv);
        }
        public DataTable GetLecturerScheduleBUS(string msgv)
        {
            return gvDAL.GetLecturerScheduleDAL(msgv) ;
        }

        public DataTable GetClassListBUS(string msgv)
        {
            try
            {
                return gvDAL.GetClassListDAl(msgv);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetStudentGradesBUS(string msgv, string mamonhoc)
        {
            try
            {
                return gvDAL.GetStudentGradesDAL(msgv, mamonhoc);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool ChangePasswordBUS(string msgv, string pass)
        {
            try
            {
                return gvDAL.ChangePasswordDAL(msgv, pass);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public bool UpdateStudentGradesBUS(string mssv, string mamonhoc, double diemQT, double diemThi, double diemTK)
        {
            try
            {
                return gvDAL.UpdateStudentGradesDAL(mssv, mamonhoc,diemQT,diemThi,diemTK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
