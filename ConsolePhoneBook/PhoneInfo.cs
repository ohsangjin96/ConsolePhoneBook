using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsolePhoneBook
{
    [Serializable]

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
        #region property
        public string Name
        {
            get { return name; }
          
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string Birth
        {
            get { return birth; }
            set { birth = value; }
        }
        #endregion
        //public virtual void ShowPhoneInfo()
        //{
        //    Console.Write("name: "+name);
        //    Console.Write("\t phone: "+phoneNumber);
        //    if(birth != null) Console.WriteLine("\t birth: "+birth);
        //    else Console.WriteLine("미입력");
        //}

        //ToString()를 오버라이딩해서 PhoneManager에서 사용해보기
        public override string ToString()
        {
            if (birth != null)
            {
                string str = "이름:"+name+"\t 번호:" +phoneNumber+"\t 생일:" +birth ;
                return str;
            }
            else
            {
                string str= $"이름: {name}\t번호: {phoneNumber}\t 생일: 미입력";
                return str;
            }

        }

    }

    public class PhoneUnivInfo : PhoneInfo 
    {
        string major;
        int year;
        public PhoneUnivInfo(string name, string phonenumber,string birth, string major, int year):base(name,phonenumber,birth)
        {
            this.major = major;
            this.year = year;
        }
       
        public override string ToString()
        {
            if (Birth != null)
            {
                string str = "이름:" + Name + "\t번호:" + PhoneNumber + "\t 생일:" + Birth+ "\t전공:" + major + "\t학년:" + year;
                return str;
            }
            else
            {
                string str = "이름:"+Name+"\t번호:"+PhoneNumber+"\t 생일: 미입력" + "\t전공:" + major + "\t학년:" + year;
                return str;
            }

        }
    }

    public class PhoneCompanyInfo : PhoneInfo
    {
        string company;
        public PhoneCompanyInfo(string name, string phonenumber, string birth,string company) : base(name, phonenumber, birth)
        {
            this.company=company;
        }
      
        public override string ToString()
        {
            if (Birth != null)
            {
                string str = "이름:" + Name + "\t번호:" + PhoneNumber + "\t 생일:" + Birth + "\t 회사: " + company;
                return str;
            }
            else
            {
                string str = "이름:" + Name + "\t번호:" + PhoneNumber + "\t 생일: 미입력 \t 회사: " + company;
                return str;
            }

        }
    }
}
