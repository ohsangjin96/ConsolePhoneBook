using System;
using System.Collections;

namespace ConsolePhoneBook
{
   

    #region 정렬클래스
    class SortName : IComparer //이름 기준 정렬
    {
        public int Compare(object x, object y)
        {

            PhoneInfo first = x as PhoneInfo;
            PhoneInfo second = y as PhoneInfo;

            return first.Name.CompareTo(second.Name); //역순 -1       
        }

    }
    class SortNumber : IComparer//번호 기준 정렬
    {
        public int Compare(object x, object y)
        {
            PhoneInfo first = x as PhoneInfo;
            PhoneInfo second = y as PhoneInfo;

            return first.PhoneNumber.CompareTo(second.PhoneNumber); //역순 -1 
        }

    }
    #endregion
    public class PhoneBookManager
    {
        static PhoneBookManager instance;

        private PhoneBookManager(){}
        public static PhoneBookManager CreatInstance()
        {
            if (instance == null)
                instance = new PhoneBookManager();

            return instance;
        }
        const int MAX_CNT = 100;
        PhoneInfo[] infoStorage = new PhoneInfo[MAX_CNT];
        int curcnt = 0;
        public void ShowMenu()
        {
            Console.WriteLine("-------------------주소록-------------------------------");
            Console.WriteLine("1.입력 | 2. 목록 | 3. 검색 | 4. 삭제 | 5.정렬 | 6. 종료 ");
            Console.WriteLine("--------------------------------------------------------");
            Console.Write("선택 : ");
        }
        //Trim은 공백제거(가운데 뛰어쓰기는 제거불가),Replace(" ","")공백제거(가운데 뛰어쓰기까지 제거)
        //if(name=="") or if(name.Length<1) or if(name.Equals("")) 
        private void CommonInfo(out string name, out string phonenum, out string brith)
        {
            Console.Write("이름을 입력하세요 : ");
            name = Console.ReadLine().Trim().Replace(" ", "");
            if (string.IsNullOrEmpty(name))
            {
               throw new Exception("이름을 입력해주세요!");

            }
            else
            {
                int data = SearchName(name); //중복확인 출력
                if (data > -1)
                {
                    throw new Exception("이미 등록된 이름입니다. 다른 이름으로 입력하세요");

                }
            }
            Console.Write("번호을 입력하세요 : ");
            phonenum = Console.ReadLine();
            if (phonenum == "")
            {
                throw new Exception("번호을 입력해주세요!");

            }

            Console.Write("생일을 입력하세요 : ");
            brith = Console.ReadLine();
        }



        public void InputData()
        {
            Console.WriteLine("1.일반 2.대학 3.회사");
            Console.Write("선택 >>");
            int a = int.Parse(Console.ReadLine());
            if(a>4|| a < 0)
            {
                throw new Exception("1.일반 2.대학 3.회사 중에 골라주세요");
               
               
            }
            string name, phonenum, brith, major, company;
            int year;

            if (a == 1)
            {
                CommonInfo(out name, out phonenum, out brith);

                if (brith.Length < 1)
                    infoStorage[curcnt++] = new PhoneInfo(name, phonenum);


                else
                    infoStorage[curcnt++] = new PhoneInfo(name, phonenum, brith);

            }
            else if (a == 2)
            {
                CommonInfo(out name, out phonenum, out brith);
                Console.Write("전공을 입력하세요: ");
                major = Console.ReadLine();
                Console.Write("학년을 입력하세요:");
                year = int.Parse(Console.ReadLine());

                infoStorage[curcnt++] = new PhoneUnivInfo(name, phonenum, brith, major, year);

            }
            else if (a == 3)
            {
                CommonInfo(out name, out phonenum, out brith);
                Console.Write("회사를 입력하세요: ");
                company = Console.ReadLine();
                infoStorage[curcnt++] = new PhoneCompanyInfo(name, phonenum, brith, company);
            }

        }//정보입력


        public void ListData()//정보확인
        {
            if (infoStorage[0] == null)
            {
                throw new Exception("정보를 먼저 넣어주세요");
            }

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



        public void SearchData()//정보찾기
        {
            if (infoStorage[0] == null)
            {
                throw new Exception("정보를 먼저 넣어주세요");
            }
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
               throw new Exception("검색된 데이터가 없습니다.");
            }

            Console.WriteLine(infoStorage[data].ToString());

        }


        private int SearchName()
        {
           
            Console.Write("이름을 입력해주세요 : ");
            string SearchName = Console.ReadLine().Trim().Replace(" ", "");

            for (int i = 0; i < curcnt; i++)
            {
                if (infoStorage[i].Name.Replace(" ", "").CompareTo(SearchName) == 0)
                {

                    return i; //검색된 이름의 위치(순서)
                }
            }
            return -1;
        }



        //이름으로 찾기

        private int SearchName(string name)
        {
            for (int i = 0; i < curcnt; i++)
            {
                if (infoStorage[i].Name.Replace(" ", "").CompareTo(name) == 0)
                {
                    
                    return i; //검색된 이름의 위치(순서)
                }
            }

            return -1;
        }//입력할때 중복확인

        public void DeleteData()
        {
            if (infoStorage[0] == null)
            {
                throw new Exception("정보를 먼저 넣어주세요");
            }
            Console.WriteLine("주소록을 삭제을 시작합니다........");

            int data = SearchName();
            if (data < 0)
            {
                throw new Exception("삭제할 데이터가 없습니다.");
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
        }//삭제하기
        public void SortDate()//정렬하기
        {

            if (infoStorage[0] == null)
            {
                throw new Exception("정보를 먼저 넣어주세요");
            }

            Console.Write("무엇으로 정렬하시겠습니까: 1. 이름ASC  2. 이름DESC 3. 번호ASC 4. 번호 DESC  :");

            int b = int.Parse(Console.ReadLine());
            if (b > 5 || b < 0)
            {
                throw new Exception("1. 이름ASC  2. 이름DESC 3. 번호ASC 4. 번호 DESC  에서 골라주세요");

            }
            
            PhoneInfo[] arr = new PhoneInfo[curcnt];
            Array.Copy(infoStorage, arr, curcnt);

            if (b == 1)
            {
                Array.Sort(arr, new SortName());
            }
            else if (b == 2)
            {
                Array.Sort(arr, new SortName());
                Array.Reverse(arr);
            }
            else if (b == 3)
            {
                Array.Sort(arr, new SortNumber());
            }
            else if (b == 4)
            {
                Array.Sort(arr, new SortNumber());
                Array.Reverse(arr);
            }

            foreach (PhoneInfo info in arr)
            {
                Console.WriteLine(info.ToString());
            }


        }
    }

}
    


