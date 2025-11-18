using System.Reflection;
using System.Xml;
using Newtonsoft.Json;

namespace ConsoleApp12;

public class Program
{
    


    static List<User> users = new List<User>();
    static List<Post> posts = new List<Post>();
    

    static void Main(string[] args)
    {
        

    repeat:
        Console.WriteLine(" ----------  USER  POST CRUD ----------  ");
        Console.WriteLine(" ");
        Console.WriteLine("1. Users");
        Console.WriteLine("2. Posts");
        Console.WriteLine("3. Add new user");
        Console.WriteLine("4. Add new post");
        Console.WriteLine("5. Delete user");
        Console.WriteLine("6.  Delete post");
        Console.WriteLine("0. Exit");
        Console.Write("Choice: ");

        string choice = Console.ReadLine();

        switch (choice) 
        {
            case "1":
                ShowUser();
                goto repeat;
            case "2":
                ShowPost();
                goto repeat;
            case "3":
                CreateUser();
                goto repeat;
            case "4":
                CreatePost();
                goto repeat;
            case "5":
                DeleteUser();
                goto repeat;
            case "6":
                DeletePost();
                goto repeat;
            case "0":
                break;
        }

    }

    static void ShowUser()
    {
        
        Console.WriteLine("----  Users ----");
        var user_ac = users.Where(u => !u.IsDeleted).ToList();

        foreach (var u in user_ac)
            Console.WriteLine($"{u.Id}. {u.Name} ({u.Username}) - {u.Email}");

        if (!user_ac.Any()) Console.WriteLine("User not found");
       
    }

    static void ShowPost()
    {
        
        Console.WriteLine("----POSTs ----");
        var post_ac = posts.Where(p => !p.IsDeleted).ToList();

        foreach (var p in post_ac)
        {
            var user = users.FirstOrDefault(u => u.Id == p.UserId && !u.IsDeleted);
            string name = user != null ? user.Username : "Deleted user";
            Console.WriteLine($"[{p.Id}] {p.Title}");
            Console.WriteLine($"Poster: {name}");
        }

        if (!post_ac.Any()) Console.WriteLine("Post not found.");
       
    }

    static void CreateUser()
    {
        
        Console.WriteLine("---- New User ----");
        Console.Write("Name: ");
        string user_name = Console.ReadLine();
        Console.Write("Username: ");
        string user_title = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();

        int newId = users.Count == 0 ? 1 : users.Max(u => u.Id) + 1;

        users.Add(new User
        {
            Id = newId,
            Name = user_name,
            Username = user_title,
            Email = email
        });

        Console.WriteLine($"User created! ID: {newId}");
        

    }
    static void CreatePost()
    {
        Console.WriteLine("---- New Post ----");
        Console.Write("User ID: ");

        try
        {
            int userId = Convert.ToInt32(Console.ReadLine());

            if (users.All(u => u.Id != userId || u.IsDeleted))
            {
                Console.WriteLine("No user with this Id!");
                return;
            }

            Console.Write("Title: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Body: ");
            string body = Console.ReadLine() ?? "";

            int newId = posts.Any() ? posts.Max(p => p.Id) + 1 : 1;

            posts.Add(new Post
            {
                Id = newId,
                UserId = userId,
                Title = title,
                Body = body
            });

            Console.WriteLine($"Post created! Id: {newId}");
        }
        catch
        {
            Console.WriteLine("Invalid Id! Please enter a number.");
        }
       
    }

    static void DeleteUser()
    {
        
        Console.Write("Enter user Id: ");
        string input = Console.ReadLine();
        int id =Convert.ToInt32(input);
        var user = users.FirstOrDefault(u => u.Id == id && !u.IsDeleted);
        if (user != null)
        {
            user.IsDeleted = true;
            Console.WriteLine($"User (ID: {id}) .");
        }
        else
        {
            Console.WriteLine("User not found");
        }
        
        
    }

    static void DeletePost()
    {
        Console.Write("Id: ");
        string input = Console.ReadLine();
        
        int id = Convert.ToInt32(input);
        var post = posts.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
        if (post != null)
        {
            post.IsDeleted = true;
            Console.WriteLine($"Post (ID: {id}).");
        }
        else
        {
            Console.WriteLine("Post not found");
        }

        
    }
    

    
}

/* TASK
POST

"userId": 1,
"id": 1,
"title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
"body": "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"

getId - method

User

"id": 1, - private
"name": "Leanne Graham",
"username": "Bret",
"email": "Sincere@april.biz",
"phone": "1-770-736-8031 x56442",
"website": "hildegard.org",


user ve post crud(create, read, udate, delete) => delete soft delete olmalidir.IsDeleted true/false olaraq dəyişməlisiniz.
terminalda render edərkən isDeleted false olanlar görsənməlidir.


Terminal Uİ

Users
Posts
Create User => form=>user created
Create Post => form => post created

*/