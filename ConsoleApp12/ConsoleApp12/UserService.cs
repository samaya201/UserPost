using ConsoleApp12;

public static class UserService
{
    public static void CreateUser()
    {
        var users = JsonDatabase.LoadUsers();

        try
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Website: ");
            string website = Console.ReadLine();

            int id = users.Count == 0 ? 1 : users.Max(u => u.Id) + 1;

            User user = new User(id, name, username, email, phone, website);

            users.Add(user);
            JsonDatabase.SaveUsers(users);

            Console.WriteLine("User created!");
        }
        catch (EmptyFieldException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Error: " + ex.Message);
            Console.ResetColor();
        }
    }


    public static void ShowUsers()
    {
        var users = JsonDatabase.LoadUsers()
            .Where(u => !u.IsDeleted)
            .ToList();

        foreach (var u in users)
        {
            Console.WriteLine($"{u.Id} - {u.GetName()} ({u.Username})");
        }
    }

    public static void DeleteUser()
    {
        var users = JsonDatabase.LoadUsers();
        Console.Write("Delete user id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var user = users.FirstOrDefault(x => x.Id == id);

        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        user.IsDeleted = true;
        JsonDatabase.SaveUsers(users);

        Console.WriteLine("User  deleted!");
    }
}
