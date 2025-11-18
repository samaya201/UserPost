using ConsoleApp12;

public class Post
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public bool IsDeleted { get; set; } = false;

    public Post()
    {

    }
    public Post(int id, int userId, string title, string body)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new EmptyFieldException("Title can't be empty!");

        if (string.IsNullOrWhiteSpace(body))
            throw new EmptyFieldException("Body can't  be empty!");

        Id = id;
        UserId = userId;
        Title = title;
        Body = body;
    }
}
