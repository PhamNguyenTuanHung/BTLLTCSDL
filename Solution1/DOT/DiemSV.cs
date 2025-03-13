using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public class DiemSV
    {
        string mssv;
        string tendaydu;
        double diemquatrinh;
        double diemthi;
        int lanthi;
        double diemtongket;

        public DiemSV() { }

        public DiemSV(string mssv, string tendaydu, double diemquatrinh, double diemthi, int lanthi)
        {
            this.mssv = mssv;
            this.tendaydu = tendaydu;
            this.diemquatrinh = diemquatrinh;
            this.diemthi = diemthi;
            this.lanthi = lanthi;
        }

        public DiemSV(string mssv,string tendaydu ,double diemquatrinh, double diemthi, double diemtongket, int lanthi)
        {
            this.mssv = mssv;
            this.tendaydu = tendaydu;
            this.diemquatrinh = diemquatrinh;
            this.diemthi = diemthi;
            this.diemtongket = diemtongket;
            this.lanthi = lanthi;
        }

        public double TinhDiem(double hesoquatrinh,double hesodiemthi)
        {
            return this.DiemQuaTrinh * hesoquatrinh + this.DiemThi * hesodiemthi;
        }

        public string MSSV { get => mssv; set => mssv = value; }
        public string TenDayDu { get => tendaydu; set => tendaydu = value; }
        public double DiemQuaTrinh { get => diemquatrinh; set => diemquatrinh = value; }
        public double DiemThi { get => diemthi; set => diemthi = value; }
        public double DiemTongKet { get => diemtongket; set => diemtongket = value; }
        public int LanThi { get => lanthi; set => lanthi = value; }
    }
}
