using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Convert;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsolePhoneBook
{
    class Program
    {

        static void Main(string[] args)
        {
            PhoneInfo[] infoStorage;
            PhoneBookManager manager = PhoneBookManager.CreatInstance();
            manager.LoadData();
            
            while (true)
            {
                try
                {

                    manager.ShowMenu();
                    int choice = Utility.ConvertInt(Console.ReadLine());

                    switch (choice)
                    {


                        case 1: manager.InputData(); break;
                        case 2: manager.ListData(); break;
                        case 3: manager.SearchData(); break;
                        case 4: manager.DeleteData(); break;
                        case 5: manager.SortDate(); break;
                        case 6:manager.SaveData(); Console.WriteLine("프로그램을 종료합니다"); return;





                    }



                }

                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    Console.WriteLine();
                }
            }
        }
    }
}
