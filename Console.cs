


using System;

class Program
{
    static void Main(string[] args)
    {
        var logger = new LoggingBroker();
        var filePath = "contacts.txt";  
        var contactManager = new ContactManager(filePath, logger);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Contact Manager");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Edit Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. View All Contacts");
            Console.WriteLine("5. View Contact By Name");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Name: ");
                        var name = Console.ReadLine();
                        Console.Write("Enter Phone: ");
                        var phone = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        var email = Console.ReadLine();
                        contactManager.AddContact(new Contact(name, phone, email));
                        break;
                    case "2":
                        Console.Write("Enter the name of the contact to edit: ");
                        var oldName = Console.ReadLine();
                        Console.Write("Enter new Name: ");
                        var newName = Console.ReadLine();
                        Console.Write("Enter new Phone: ");
                        var newPhone = Console.ReadLine();
                        Console.Write("Enter new Email: ");
                        var newEmail = Console.ReadLine();
                        contactManager.EditContact(oldName, new Contact(newName, newPhone, newEmail));
                        break;
                    case "3":
                        Console.Write("Enter the name of the contact to delete: ");
                        var deleteName = Console.ReadLine();
                        contactManager.DeleteContact(deleteName);
                        break;
                    case "4":
                        contactManager.ViewAllContacts();
                        break;
                    case "5":
                        Console.Write("Enter the name of the contact to view: ");
                        var viewName = Console.ReadLine();
                        contactManager.ViewContactByName(viewName);
                        break;
                    case "6":
                        return;
                    default:
                        logger.LogError("Invalid choice, please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"An unexpected error occurred: {ex.Message}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}







