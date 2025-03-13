using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public class TaiKhoan
    {
        private string user_name;
        private string pass_word;
        private int type;
        public TaiKhoan() { }
        public TaiKhoan(string user_name, string pass_word, int type)
        {
            this.User_name = user_name;
            this.Pass_word = pass_word;
            this.type = type;
        }

        public string User_name { get=> this.user_name; set=> user_name =value; }
        public string Pass_word { get=>pass_word; set=>pass_word=value; }
        public int Type { get=>type; set=>type=value; }   
    }
}
