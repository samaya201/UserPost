class Program
{
    static void Main(string[] args)
    {
    repeat:
        Console.WriteLine("---- MENU -----");
            Console.WriteLine("1. Users");
            Console.WriteLine("2. Posts");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");

            int ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    UserMenu();
                goto repeat;

                case 2:
                    PostMenu();
                goto repeat; 

                case 0:
                goto repeat;
            }
        }
    

    static void UserMenu()
    {
        Console.WriteLine("--- USER MENU ---");
        Console.WriteLine("1. Create User");
        Console.WriteLine("2. Show Users");
        Console.WriteLine("3. Delete User");
        Console.Write("Choice: ");

        int ch = Convert.ToInt32(Console.ReadLine());

        switch (ch)
        {
            case 1: UserService.CreateUser();
                break;
            case 2: UserService.ShowUsers();
                break;
            case 3: UserService.DeleteUser(); 
                break;
        }
    }

    static void PostMenu()
    {
        Console.WriteLine("\n--- POST MENU ---");
        Console.WriteLine("1. Create Post");
        Console.WriteLine("2. Show User Posts");
        Console.WriteLine("3. Delete Post ");
        Console.Write("Choice: ");

        int ch = Convert.ToInt32(Console.ReadLine());

        switch (ch)
        {
            case 1: PostService.CreatePost();
                break;
            case 2: PostService.ShowUserPosts(); 
                break;
            case 3: PostService.DeletePost(); 
                break;
        }
    }
}
