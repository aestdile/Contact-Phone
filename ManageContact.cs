
public class ContactManager
{
    private List<Contact> contacts;
    private readonly string filePath;
    private LoggingBroker logger;

    public ContactManager(string filePath, LoggingBroker logger)
    {
        this.filePath = filePath;
        this.logger = logger;
        contacts = LoadContactsFromFile();
    }

    private List<Contact> LoadContactsFromFile()
    {
        List<Contact> contactsList = new List<Contact>();
        try
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        contactsList.Add(new Contact(parts[0], parts[1], parts[2]));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            logger.LogError($"Error loading contacts: {ex.Message}");
        }
        return contactsList;
    }

    private void SaveContactsToFile()
    {
        try
        {
            var lines = new List<string>();
            foreach (var contact in contacts)
            {
                lines.Add($"{contact.Name},{contact.Phone},{contact.Email}");
            }
            File.WriteAllLines(filePath, lines);
        }
        catch (Exception ex)
        {
            logger.LogError($"Error saving contacts: {ex.Message}");
        }
    }

    public void AddContact(Contact contact)
    {
        try
        {
            contacts.Add(contact);
            SaveContactsToFile();
            logger.LogInfo($"Contact added: {contact.Name}");
        }
        catch (Exception ex)
        {
            logger.LogError($"Error adding contact: {ex.Message}");
        }
    }

    public void DeleteContact(string name)
    {
        try
        {
            var contact = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contact != null)
            {
                contacts.Remove(contact);
                SaveContactsToFile();
                logger.LogInfo($"Contact deleted: {name}");
            }
            else
            {
                logger.LogError($"Contact not found: {name}");
            }
        }
        catch (Exception ex)
        {
            logger.LogError($"Error deleting contact: {ex.Message}");
        }
    }

    public void EditContact(string oldName, Contact newContact)
    {
        try
        {
            var contact = contacts.Find(c => c.Name.Equals(oldName, StringComparison.OrdinalIgnoreCase));
            if (contact != null)
            {
                contact.Name = newContact.Name;
                contact.Phone = newContact.Phone;
                contact.Email = newContact.Email;
                SaveContactsToFile();
                logger.LogInfo($"Contact edited: {newContact.Name}");
            }
            else
            {
                logger.LogError($"Contact not found: {oldName}");
            }
        }
        catch (Exception ex)
        {
            logger.LogError($"Error editing contact: {ex.Message}");
        }
    }

    public void ViewAllContacts()
    {
        try
        {
            if (contacts.Count == 0)
            {
                logger.LogInfo("No contacts available.");
                return;
            }

            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
        catch (Exception ex)
        {
            logger.LogError($"Error displaying contacts: {ex.Message}");
        }
    }

    public void ViewContactByName(string name)
    {
        try
        {
            var contact = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contact != null)
            {
                Console.WriteLine(contact);
            }
            else
            {
                logger.LogError($"Contact not found: {name}");
            }
        }
        catch (Exception ex)
        {
            logger.LogError($"Error searching contact by name: {ex.Message}");
        }
    }
}









