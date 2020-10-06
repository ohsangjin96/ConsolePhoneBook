using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

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
        BinaryFormatter serializer = new BinaryFormatter();
        private PhoneBookManager() { }
        public static PhoneBookManager CreatInstance() //싱글톤
        {
            if (instance == null)
                instance = new PhoneBookManager();

            return instance;
        }

        HashSet<PhoneInfo> infostorge = new HashSet<PhoneInfo>();
        readonly string datafile = "ohsangjin.dat";

        public void ShowMenu()
        {
            Console.WriteLine("-------------------주소록-------------------------------");
            Console.WriteLine("1.입력 | 2. 목록 | 3. 검색 | 4. 삭제 | 5.정렬 | 6. 종료 ");
            Console.WriteLine("--------------------------------------------------------");
            Console.Write("선택 : ");
        }
        //Trim은 공백제거(가운데 뛰어쓰기는 제거불가),Replace(" ","")공백제거(가운데 뛰어쓰기까지 제거)
        //if(name=="") or if(name.Length<1) or if(name.Equals("")) 
        private List<string> CommonInfo()
        {
            Console.Write("이름을 입력하세요 : ");
            string name = Console.ReadLine().Trim().Replace(" ", "");
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("이름을 입력해주세요!");

            }

            Console.Write("번호을 입력하세요 : ");
            string phonenum = Console.ReadLine();
            if (phonenum == "")
            {
                throw new Exception("번호을 입력해주세요!");

            }

            Console.Write("생일을 입력하세요 : ");
            string brith = Console.ReadLine();

            List<string> list = new List<string>();
            list.Add(name);
            list.Add(phonenum);
            list.Add(brith);
            
            return list;
        }



        public void InputData()
        {
            Console.WriteLine("1.일반 2.대학 3.회사");
            Console.Write("선택 >>");
            int a = int.Parse(Console.ReadLine());
            if (a > 4 || a < 0)
            {
                throw new Exception("1.일반 2.대학 3.회사 중에 골라주세요");


            }
            string major, company;
            int year;
            

            if (a == 1)
            {
                List<string> common = CommonInfo();
               
                if (common.Count != 3)
                {
                    infostorge.Add(new PhoneInfo(common[0], common[1]));
                }
                           
                else
                    infostorge.Add(new PhoneInfo(common[0], common[1],common[2])); 


            }
            else if (a == 2)
            {
                List<string> common = CommonInfo();
                Console.Write("전공을 입력하세요: ");
                major = Console.ReadLine();
                Console.Write("학년을 입력하세요:");
                year = int.Parse(Console.ReadLine());

                infostorge.Add(new PhoneUnivInfo(common[0], common[1], common[2], major, year));


            }
            else if (a == 3)
            {
                List<string> common = CommonInfo();
                Console.Write("회사를 입력하세요: ");
                company = Console.ReadLine();
                infostorge.Add(new PhoneCompanyInfo(common[0], common[1], common[2], company)); 


            }

        }//정보입력


        public void ListData()//정보확인
        {

            if (infostorge.Count == 0)
            {
                throw new Exception("정보를 먼저 넣어주세요");
            }

            foreach (PhoneInfo item in infostorge)
            {
                Console.WriteLine(item.ToString());
            }


        }



        public void SearchData()//정보찾기
        {
            if (infostorge.Count == 0)
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
            if (data == -1)
            {
                throw new Exception("검색된 데이터가 없습니다.");
            }
            PhoneInfo[] a_infostorge = infostorge.ToArray();

            Console.WriteLine(a_infostorge[data].ToString());

        }


        private int SearchName()
        {

            Console.Write("이름을 입력해주세요 : ");
            string SearchName = Console.ReadLine().Trim().Replace(" ", "");
            PhoneInfo[] a_infostorge = infostorge.ToArray();

            for (int i = 0; i < infostorge.Count; i++)
            {
                if (a_infostorge[i].Name.Equals(SearchName)) return i;

            }
            return -1;
        }//이름으로 찾기



        public void DeleteData()
        {
            if (infostorge.Count == 0)
            {
                throw new Exception("정보를 먼저 넣어주세요");
            }
            Console.WriteLine("주소록을 삭제을 시작합니다........");

            int data = SearchName();
            if (data == -1)
            {
                throw new Exception("삭제할 데이터가 없습니다.");
            }


            else
            {
                PhoneInfo[] a_infostorge = infostorge.ToArray();
                PhoneInfo removed = a_infostorge[data];

                infostorge.Remove(removed);

                Console.WriteLine("주소록 삭제가 완료되었습니다.");

            }



        }//삭제하기

        public void SortDate()//정렬하기
        {

            if (infostorge.Count == 0)
            {
                throw new Exception("정보를 먼저 넣어주세요");
            }

            Console.Write("무엇으로 정렬하시겠습니까: 1. 이름ASC  2. 이름DESC 3. 번호ASC 4. 번호 DESC  :");

            int b = int.Parse(Console.ReadLine());
            if (b > 5 || b < 0)
            {
                throw new Exception("1. 이름ASC  2. 이름DESC 3. 번호ASC 4. 번호 DESC  에서 골라주세요");

            }
            PhoneInfo[] a_infostorge = infostorge.ToArray();


            if (b == 1)
            {
                Array.Sort(a_infostorge, new SortName());
            }
            else if (b == 2)
            {
                Array.Sort(a_infostorge, new SortName());
                Array.Reverse(a_infostorge);
            }
            else if (b == 3)
            {
                Array.Sort(a_infostorge, new SortNumber());
            }
            else if (b == 4)
            {
                Array.Sort(a_infostorge, new SortNumber());
                Array.Reverse(a_infostorge);
            }

            foreach (PhoneInfo info in a_infostorge)
            {
                Console.WriteLine(info.ToString());
            }


        }
        public void SaveData()
        {
            try
            {
                using (FileStream fs = new FileStream(datafile, FileMode.Create))
                {

                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, infostorge);

                }
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }
        public void LoadData()
        {

            if (File.Exists(datafile))
            {
                
                using (FileStream Load = new FileStream(datafile, FileMode.Open))
                {
                    infostorge = (HashSet<PhoneInfo>)serializer.Deserialize(Load);
                }

               
                foreach (PhoneInfo item in infostorge)
                {
                    
                        Console.WriteLine(item.ToString());     
                }

            }

        }
    }
}



