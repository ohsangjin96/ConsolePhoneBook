using Convert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    public class PhoneBookManager
    {
        const int MAX_CNT = 100;
        PhoneInfo[] infoStorage = new PhoneInfo[MAX_CNT];
        PhoneUnivInfo[] uniinfoStorage = new PhoneUnivInfo[MAX_CNT];
        PhoneCompanyInfo[] cominfoStorage = new PhoneCompanyInfo[MAX_CNT];
        int curcnt = 0;
        int unicurcnt = 0;
        int comcurcnt = 0;
        int count = 0;//search에서 사용
        public void ShowMenu()
        {
            Console.WriteLine("-------------------주소록----------------------");
            Console.WriteLine("1.입력 | 2. 목록 | 3. 검색 | 4. 삭제 | 5.종료");
            Console.WriteLine("-----------------------------------------------");
            Console.Write("선택 : ");
        }
        //Trim은 공백제거(가운데 뛰어쓰기는 제거불가),Replace(" ","")공백제거(가운데 뛰어쓰기까지 제거)
        //if(name=="") or if(name.Length<1) or if(name.Equals("")) 
        private void InputInfo(out string name, out string phonenum, out string brith)
        {
            Console.Write("이름을 입력하세요 : ");
            name = Console.ReadLine().Trim().Replace(" ", "");
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("이름을 입력해주세요!");

            }
            else
            {
                int data = SearchName(name);
                if (data > -1)
                {
                    Console.WriteLine("이미 등록된 이름입니다. 다른 이름으로 입려하세요");


                }
            }
            Console.Write("번호을 입력하세요 : ");
            phonenum = Console.ReadLine();
            if (phonenum == "")
            {
                Console.WriteLine("번호을 입력해주세요!");

            }

            Console.Write("생일을 입력하세요 : ");
            brith = Console.ReadLine();
        }



        public void InputData()
        {
            Console.WriteLine("1.일반 2.대학 3.회사");
            Console.Write("선택 >>");
            int a = int.Parse(Console.ReadLine());
            string name, phonenum, brith,major,company;
            int year;
            
            if (a == 1)
            {
                InputInfo(out name, out phonenum, out brith);

                if (brith.Length < 1)
                    infoStorage[curcnt++] = new PhoneInfo(name, phonenum);


                else
                    infoStorage[curcnt++] = new PhoneInfo(name, phonenum, brith);

            }
            else if (a == 2)
            {
                InputInfo(out name, out phonenum, out brith);
                Console.Write("전공을 입력하세요: ");
                major = Console.ReadLine();
                Console.Write("학년을 입력하세요:");
                year = int.Parse(Console.ReadLine());
                
                    uniinfoStorage[unicurcnt++] = new PhoneUnivInfo(name, phonenum, brith, major, year);

            }
            else if (a == 3)
            {
                InputInfo(out name, out phonenum, out brith);
                Console.Write("회사를 입력하세요: ");
                company= Console.ReadLine();
                cominfoStorage[comcurcnt++] = new PhoneCompanyInfo(name, phonenum, brith, company);
            }
        }
       

        public void ListData()
        {
            Console.WriteLine("확인하고 싶은 리스트가 어디입니까(1.일반 2. 학교, 3.회사)");
            int a = int.Parse(Console.ReadLine());
          
            if (a == 1)
            {
                if (curcnt == 0)
                {
                    Console.WriteLine("입력된 데이터가 없습니다.");
                    return;
                }
                for (int i = 0; i < curcnt; i++)
                {
                    Console.WriteLine(infoStorage[i].ToString());
                }
            }

            else if (a == 2){
                if (unicurcnt == 0)
                {
                    Console.WriteLine("입력된 데이터가 없습니다.");
                    return;
                }
                for (int i = 0; i < unicurcnt; i++)
                {
                    Console.WriteLine(uniinfoStorage[i].ToString());
                }
            }
            else if (a == 3)
            {
                if (comcurcnt == 0)
                {
                    Console.WriteLine("입력된 데이터가 없습니다.");
                    return;
                }
                for (int i = 0; i < comcurcnt; i++)
                {
                    Console.WriteLine(cominfoStorage[i].ToString());
                }
            }
        }
            
        
        public void SearchData()
        {
            Console.WriteLine("주소록을 검색을 시작합니다........");
            #region 사람을 여러명 찾을때
            //int findCnt = 0;
            //==, Equals(),CompareTo()

            //for (int i = 0; i < curcnt; i++)
            //{

            //    if (infoStorage[i].Name.Replace(" ", "").CompareTo(SearchName) == 0)
            //    {
            //        infoStorage[i].ShowPhoneInfo();
            //        findCnt++;
            //    }

            //}
            //if (findCnt < 1)
            //{
            //    Console.WriteLine("검색된 데이터가 없습니다.");
            //}
            //else
            //{
            //    Console.WriteLine($"총 {findCnt}명이 검색되었습니다.");
            //}
            #endregion
            
            int data = SearchName();
            if (data < 0)
            {
                Console.WriteLine("검색된 데이터가 없습니다.");
            }
            else
            {
                if(count==1)
                Console.WriteLine(infoStorage[data].ToString());
                else if(count==2)
                    Console.WriteLine(uniinfoStorage[data].ToString());
                else if (count == 3)
                    Console.WriteLine(cominfoStorage[data].ToString());
            }
        }

        private int SearchName()
        {
            Console.Write("이름을 입력해주세요 : ");
            string SearchName = Console.ReadLine().Trim().Replace(" ", "");

            for (int i = 0; i < curcnt; i++)
            {
                if (infoStorage[i].Name.Replace(" ", "").CompareTo(SearchName) == 0)
                {
                    count = 1;
                    return i; //검색된 이름의 위치(순서)
                }
            }


            for (int j = 0; j < unicurcnt; j++)
            
                {
                    if (uniinfoStorage[j].Name.Replace(" ", "").CompareTo(SearchName) == 0)
                    {
                        count = 2;
                        return j;
                    }
                }

            for (int k = 0; k < comcurcnt; k++)
                {
                    if (cominfoStorage[k].Name.Replace(" ", "").CompareTo(SearchName) == 0)
                    {
                        count = 3;
                        return k;
                    }
                }

                return -1;

        }

        private int SearchName(string name)
        {
            for (int i = 0; i < curcnt; i++)
            {
                        if (infoStorage[i].Name.Replace(" ", "").CompareTo(name) == 0)
                        {
                            count = 1;
                            return i; //검색된 이름의 위치(순서)
                        }   
            }


            for (int j = 0; j < unicurcnt; j++) 
                {
                    if (uniinfoStorage[j].Name.Replace(" ", "").CompareTo(name) == 0)
                    {
                        count = 2;
                        return j;
                    }
                }

            for (int k = 0; k < comcurcnt; k++)
                {
                    if (cominfoStorage[k].Name.Replace(" ", "").CompareTo(name) == 0)
                    {
                        count = 3;
                        return k;
                    }
                }

                return -1;
            }
        public void DeleteData()
        {
            Console.WriteLine("주소록을 삭제을 시작합니다........");

            int data = SearchName();
            if (data < 0)
            {
                Console.WriteLine("삭제할 데이터가 없습니다.");
            }
            else
            {
                for (int i = data; i < curcnt; i++)
                {
                    infoStorage[i] = infoStorage[i + 1];
                }
                curcnt--;
                Console.WriteLine("주소록 삭제가 완료되었습니다.");
                
            }
        }
    }
}
