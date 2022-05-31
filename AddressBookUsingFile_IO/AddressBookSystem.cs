using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Globalization;
using CsvHelper;

namespace AddressBookUsingFile_IO
{
    public class AddressBookSystem
    {
       public static List<Contacts> People = new List<Contacts>();
       public static Dictionary<String, LinkedList<Contacts>> dict = new Dictionary<string, LinkedList<Contacts>>(); 
        public void AddContact()
        {
            Contacts contact = new Contacts();
            Console.WriteLine("Enter person contact detail\n");
            Console.WriteLine("Enter First Name : ");
            contact.FirstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name : ");
            contact.LastName = Console.ReadLine();

            Console.WriteLine("Enter Address : ");
            contact.Address = Console.ReadLine();

            Console.WriteLine("Enter City : ");
            contact.City = Console.ReadLine();            

            Console.WriteLine("Enter State : ");
            contact.State = Console.ReadLine();

            Console.WriteLine("Enter Zip : ");
            contact.Zip = int.Parse(Console.ReadLine());


            Console.WriteLine("Enter Phone Number : ");
            contact.PhoneNumber = Console.ReadLine();

            Console.WriteLine("Enter your EmailId");
            contact.EmailId = Console.ReadLine();

            People.Add(contact);

            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Contact saved suessfully");
            Console.ResetColor();
        }
        public void EditContact()
        {
            Console.WriteLine("Enter person name for edit");
            string name = Console.ReadLine();
            foreach (var data in People)
            {
                if (data.FirstName == name)
                {
                    Console.WriteLine("Choose one option for edit detail\n 1.FirstName\n2.LastName\n3.PhoneNumber\n4.Email\n5.Address\n6.City\n7.State\n8.Zip");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter firstname for edit contact");
                            string firstName = Console.ReadLine();
                            data.FirstName = firstName;
                            break;
                        case 2:
                            Console.WriteLine("Enter Lastname for edit contact");
                            string lastName = Console.ReadLine();
                            data.LastName = lastName;
                            break;
                        case 3:
                            Console.WriteLine("Enter phone number for edit contact");
                            string phoneNumber = Console.ReadLine();
                            data.PhoneNumber = phoneNumber;
                            break;
                        case 4:
                            Console.WriteLine("Enter email for edit contact");
                            string email = Console.ReadLine();
                            data.EmailId = email;
                            break;
                        case 5:
                            Console.WriteLine("Enter Address for edit contact");
                            string address = Console.ReadLine();
                            data.Address = address;
                            break;
                        case 6:
                            Console.WriteLine("Enter City for edit contact");
                            string city = Console.ReadLine();
                            data.City = city;
                            break;
                        case 7:
                            Console.WriteLine("Enter state for edit contact");
                            string state = Console.ReadLine();
                            data.State = state;
                            break;
                        case 8:
                            Console.WriteLine("Enter Zipcode for edit contact");
                            int ZipCode = int.Parse(Console.ReadLine());
                            data.Zip = ZipCode;
                            break;
                        default:
                            Console.WriteLine("Given input {0} is inccorrect, Try agian.", name);
                            break;
                    }
                }
                else if (data.FirstName == null)
                {
                    Console.WriteLine("Given input {0} is not available in Address Book. Please ty again.", name);
                }
            }
        }
        public void PeopleDetail()
        {
            Console.WriteLine("Enter Firstname");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Zipcode");
            int zipcode = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter PhoneNumber");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            People.Add(new Contacts()
            {
                FirstName = fname,
                LastName = lname,
                Address = address,
                City = city,
                State = state,
                Zip = zipcode,
                PhoneNumber = phone,
                EmailId = email
            }) ;

            foreach (var get in People)
            {
                Console.WriteLine("PEOPLE IN ADDRESS BOOK");
                Console.WriteLine("First Name:" + get.FirstName);
                Console.WriteLine("Last Name:" + get.LastName);
                Console.WriteLine("Address:" + get.Address);
                Console.WriteLine("City:" + get.City);
                Console.WriteLine("State:" + get.State);
                Console.WriteLine("Zipcode:" + get.Zip);
                Console.WriteLine("Phone Number:" + get.PhoneNumber);
                Console.WriteLine("EmailId:" + get.EmailId);
                Console.WriteLine("-----------------------------------------------------------");
            }
        }
        public void DeleteContact()
        {
            Console.WriteLine("Enter first name to delete contact");
            string firstname = Console.ReadLine();
            foreach (var data in People)
            {
                if (People.Contains(data))
                {
                    if (firstname != data.FirstName)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Given detail is not available in Address book, Try Again!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Are you sure you want to delete this perdon from address book? Press Y/N");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            People.Remove(data);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Contact deleted successfully.");
                            Console.ResetColor();
                            return;
                        }
                     
                    }
                }
            }
            Console.WriteLine("Given contact doesn't exist in address book.");
        }
        public void AddmultipleContacts(int n)
        {
            while (n > 0)
            {
                AddContact();
                n--;
            }

        }
        public void UniqueContact()
        {
            Console.Write("Enter Count-How Many contact You want to add?");
            int number = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine("Press 1 If you want to add a new Contact to the Address Book");
                switch (Console.ReadLine())
                {
                    case "1":
                        for (int k = 0; k < number; k++)
                        {
                            Console.Write("Enter the First Name: ");
                            string fname = Console.ReadLine();
                            Console.WriteLine($"'{fname}' is not exists in our list so you can add {fname}");
                            if (People.Exists(e => e.FirstName == fname))//used Lambda Expression to check for duplicate entry
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Yes, A person having name  '{fname}' exists in our list");
                                Console.ResetColor();
                                Console.ReadKey();
                                PeopleDetail();
                            }
                            else
                            {
                                PeopleDetail();
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("The choice is not valid.");
                        break;
                }
            }
        }
        public void SearchByCityState()
        {
            Console.WriteLine("********Search*******");
            Console.WriteLine("Enter City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter state");
            string state = Console.ReadLine();
            var lists = People.FindAll(x => (x.City == city && x.State == state));
            Console.WriteLine($"##########Peoples In {city} and {state}############");
            foreach (Contacts con in lists)
            {
                Console.WriteLine("First Name:" + con.FirstName);
                Console.WriteLine("-----------------------------------------------------------");
            }
        }
        public void CountPerson()
        {
            Console.WriteLine("#######Count person city and state wise");
            Console.WriteLine("Enter city below: ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter state below: ");
            string state = Console.ReadLine();
            var lists = People.FindAll(x => (x.City == city && x.State == state));
            var set = new List<Contacts>();
            foreach(Contacts con in lists)
            {
                set.Add(con);
            }
            var result = set.Count;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Total Persons in {city} & {state}:" + result);
            Console.ResetColor();

        }
        public static void WriteData()
        {
            const string FilePath = @"E:\C#\AddressBookUsingFile_IO\AddressBookUsingFile_IO\File.txt";
            using (StreamWriter stream = File.CreateText(FilePath))
            {
                foreach (var con in People)
                {
                    Console.WriteLine("Added record in file");
                    stream.WriteLine("############Peoples In address book###########");
                    stream.WriteLine("First Name:" + con.FirstName);
                    stream.WriteLine("Last Name:" + con.LastName);
                    stream.WriteLine("Address:" + con.Address);
                    stream.WriteLine("City:" + con.City);
                    stream.WriteLine("State:" + con.State);
                    stream.WriteLine("Zipcode:" + con.Zip);
                    stream.WriteLine("Phone Number:" + con.PhoneNumber);
                    Console.WriteLine("EmailId:" + con.EmailId);
                    stream.WriteLine("-----------------------------------------------------------");
                }
            }
        }
        public static void WriteDataUsingCSV()
        {
            try
            {
                string Filepath = @"E:\C#\AddressBookUsingFile_IO\AddressBookUsingFile_IO\Contacts.csv";

                using (CsvWriter csv = new CsvWriter(new StreamWriter(Filepath), CultureInfo.InvariantCulture))
                {
                    csv.WriteHeader<Contacts>();
                    csv.WriteRecords("\n");
                    csv.WriteRecords(People);
                }
            }
            catch (FileNotFoundException f)
            {
                new Exception(f.FileName);
            }
        }
        public static void ReadDataUsingCSV()
        {
            try
            {
                string FilePath = @"E:\C#\AddressBookUsingFile_IO\AddressBookUsingFile_IO\Contacts.csv";

                using (CsvReader csv = new CsvReader (new StreamReader(FilePath), CultureInfo.InvariantCulture))
                {
                    var record = csv.GetRecords<Contacts>();
                    foreach (var data in record)
                    {
                        Console.WriteLine("#######AddressBook#######");
                        Console.WriteLine(data.FirstName);
                        Console.WriteLine(data.LastName);
                        Console.WriteLine(data.Address);
                        Console.WriteLine(data.City);
                        Console.WriteLine(data.State);
                        Console.WriteLine(data.Zip);
                        Console.WriteLine(data.PhoneNumber);
                        Console.WriteLine(data.EmailId);
                        Console.WriteLine("\n");
                    }
                }
            }
            catch(FileNotFoundException f)
            {
                Console.WriteLine(f.FileName);
            }
            
        }

    }
}
