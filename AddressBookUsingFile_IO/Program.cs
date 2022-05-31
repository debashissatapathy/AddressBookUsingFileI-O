using System;
using System.IO;

namespace AddressBookUsingFile_IO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program in AddressBook!");
            AddressBookSystem address = new AddressBookSystem();

            while(true)
            {
                Console.WriteLine("Please Press a number to take action\n1.Add Contact\n2.Search\n3.Count\n4.Read and Write file\n5.Write using csv\n6.Edit Contact");
                int num = int.Parse(Console.ReadLine());
                switch(num)
                {
                    case 1:
                        address.PeopleDetail();
                        break;
                    case 2:
                        address.PeopleDetail();
                        address.UniqueContact();
                        address.SearchByCityState();
                        break;
                    case 3:
                        address.PeopleDetail();
                        address.UniqueContact();
                        address.CountPerson();
                        break;
                    case 4:
                        AddressBookSystem.WriteData();
                        break;
                    case 5:
                        AddressBookSystem.WriteDataUsingCSV();
                        AddressBookSystem.ReadDataUsingCSV();
                        break;
                    case 6:
                        address.EditContact();
                        break;
                }
            }
        }
    }
}
