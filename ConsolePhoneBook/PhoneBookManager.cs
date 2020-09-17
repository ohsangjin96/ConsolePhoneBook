using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    public class PhoneBookManager
    {
        const int MAX_CNT = 3; 
        PhoneInfo[] infoStorage = new PhoneInfo[MAX_CNT];
        
        int curcnt = 0;
        public void ShowMenu()
        {
            Console.WriteLine("-------------------주소록----------------------");
            Console.WriteLine("1.입력 | 2. 목록 | 3. 검색 | 4. 삭제 | 5.종료");
            Console.WriteLine("-----------------------------------------------");
            Console.Write("선택 : ");
        }

        public void InputData()
        {
            string name;
            string phonenum;
            string brith;
            
            while (true)
            {
                
                    Console.WriteLine("이름을 입력하세요 : ");
                    name = Console.ReadLine();
                    Console.WriteLine("번호을 입력하세요 : ");
                    phonenum = Console.ReadLine();
                    Console.WriteLine("생일을 입력하세요 : ");
                    brith= Console.ReadLine();
                if (brith == "")
                {
                    PhoneInfo f1 = new PhoneInfo(name, phonenum);
                    infoStorage[curcnt] = f1;
                    curcnt++;
                }
                else
                {
                    PhoneInfo f1 = new PhoneInfo(name, phonenum);
                    infoStorage[curcnt] = f1;
                    curcnt++;
                }
                
            }
        }
        public void ListData()
        {
            foreach(PhoneInfo num in infoStorage)
            {
                Console.WriteLine(num);
            }
        }
        public void SearchData()
        {

        }
        public void DeleteData()
        {

        }
    }
}
