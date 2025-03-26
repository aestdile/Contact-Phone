


public class Contact
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public Contact(string name, string phone, string email)
    {
        Name = name;
        Phone = phone;
        Email = email;
    }

    // Kontaktni ko'rsatish
    public override string ToString()
    {
        return $"Name: {Name}, Phone: {Phone}, Email: {Email}";
    }
}









