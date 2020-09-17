using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    public class PhoneInfo
    {
        string name; //필수
        string phoneNumber; // 필수
        string birth; //선택
        public PhoneInfo(string name, string phoneNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
        }
        public PhoneInfo(string name, string phoneNumber, string birth)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.birth = birth;
        }

        //public string Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}
        //public string PhoneNumber
        //{
        //    get { return phoneNumber; }
        //    set { phoneNumber = value; }
        //}
        //public string Birth
        //{
        //    get { return birth; }
        //    set { birth = value; }
        //}
        public void ShowPhoneInfo()
        {

        }



    }
}
