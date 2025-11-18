using ConsoleApp12;

public class User
{
    public int Id { get; set; }
    private string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Website { get; set; }
    public bool IsDeleted { get; set; } = false;

    public User()
    {

    }
    public User(int id, string name, string username, string email, string phone, string website)
    {
        if (name==null)
            throw new EmptyFieldException("Name can't be empty!");

        if (username==null)
            throw new EmptyFieldException("Username can't be empty!");

        if (email == null)
            throw new EmptyFieldException("Email can't be empty!");

        if (phone == null)
            throw new EmptyFieldException("Phone can't be empty!");

        if (website == null)
            throw new EmptyFieldException("Website can't be empty!");

        Id = id;
        Name = name;
        Username = username;
        Email = email;
        Phone = phone;
        Website = website;
    }

    public string GetName()
    {
        return Name;
    }
}