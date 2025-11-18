using ConsoleApp12;

public static class PostService
{
    public static void CreatePost()
    {
        var posts = JsonDatabase.LoadPosts();

        try
        {
            Console.Write("UserId: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Body: ");
            string body = Console.ReadLine();

            int id = posts.Count == 0 ? 1 : posts.Max(p => p.Id) + 1;

            Post post = new Post(id, userId, title, body);

            posts.Add(post);
            JsonDatabase.SavePosts(posts);

            Console.WriteLine("Post created!");
        }
        catch (EmptyFieldException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Error: " + ex.Message);
            Console.ResetColor();
        }
    }


    public static void ShowUserPosts()
    {
        Console.Write("UserId: ");
        int uid = Convert.ToInt32(Console.ReadLine());

        var posts = JsonDatabase.LoadPosts()
            .Where(p => p.UserId == uid && !p.IsDeleted)
            .ToList();

        foreach (var p in posts)
        {
            Console.WriteLine($"{p.Id} - {p.Title}");
        }
    }

    public static void DeletePost()
    {
        var posts = JsonDatabase.LoadPosts();

        Console.Write("Delete post id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var post = posts.FirstOrDefault(p => p.Id == id);

        if (post == null)
        {
            Console.WriteLine("Post not found.");
            return;
        }

        post.IsDeleted = true;
        JsonDatabase.SavePosts(posts);

        Console.WriteLine("Post  deleted!");
    }
}
