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
                Console.WriteLine("Please Press a number to take action\n1.Add Contact\n2.EditContact\n3.Search\n4.Count\n5.Read and Write file\n6.Write using csv");
                int num = int.Parse(Console.ReadLine());
                switch(num)
                {
                    case 1:
                        address.PeopleDetail();
                        break;
                    case 2:                    
                        address.EditContact();
                        break;
                    case 3:
                        address.PeopleDetail();
                        address.UniqueContact();
                        address.SearchByCityState();
                        break;
                    case 4:
                        address.PeopleDetail();
                        address.UniqueContact();
                        address.CountPerson();
                        break;
                    case 5:
                        AddressBookSystem.WriteData();
                        break;
                    case 6:
                        AddressBookSystem.WriteDataUsingCSV();
                        AddressBookSystem.ReadDataUsingCSV();
                        break;
                    

                }
            }
        }
    }
}
