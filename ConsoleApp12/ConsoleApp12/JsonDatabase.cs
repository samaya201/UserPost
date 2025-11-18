using System.Text.Json;

public static class JsonDatabase
{
    private static string usersPath = "users.json";
    private static string postsPath = "posts.json";

    public static List<User> LoadUsers()
    {
        if (!File.Exists(usersPath)) return new List<User>();
        string json = File.ReadAllText(usersPath);
        return JsonSerializer.Deserialize<List<User>>(json);
    }

    public static List<Post> LoadPosts()
    {
        if (!File.Exists(postsPath)) return new List<Post>();
        string json = File.ReadAllText(postsPath);
        return JsonSerializer.Deserialize<List<Post>>(json);
    }

    public static void SaveUsers(List<User> users)
    {
        string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(usersPath, json);
    }

    public static void SavePosts(List<Post> posts)
    {
        string json = JsonSerializer.Serialize(posts, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(postsPath, json);
    }
}
