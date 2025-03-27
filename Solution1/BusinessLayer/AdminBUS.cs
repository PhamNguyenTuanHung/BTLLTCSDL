using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOT;
using DataLayer;
using System.Data;
using System.Web.UI.WebControls;

namespace BusinessLayer
{
    public class AdminBUS
    {
        private AdminDAL adminDAL = new AdminDAL();
        public DataTable GetDataTableBUS(string tenBang)
        {
            return adminDAL.GetDataTableDAL(tenBang);
        }

        public DataTable GetLecturersListBUS()
        {
            try
            {
                
                return adminDAL.GetLecturersListDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetStudentsListBUS()
        {
            try
            {

                return adminDAL.GetStudentsListDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetSubjectsListBUS()
        {
            try
            {
                return adminDAL.GetSubjectsListDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetClassListBUS()
        {
            try
            {
                return adminDAL.GetClassListDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetScheduleBUS()
        {
            try
            {
                return adminDAL.GetScheduleDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetExamScheduleBUS()
        {
            try
            {

                return adminDAL.GetExamScheduleDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetStudentGradesBUS()
        {
            try
            {
                return adminDAL.GetStudentGradesDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
                public bool Insert<T>( T ob) where T : class, new()
                {
                    return Repository<T>.InsertInformation(ob);
                }

                public bool Update<T>(T ob,string condition) where T :class , new()
                {
                    return Repository<T>.UpdateInformation( ob,condition);
                }

                public bool Delete<T>(T entity) where T : class, new()
                {
                    return Repository<T>.DeleteInformation (entity);
                }*/


    }
}
