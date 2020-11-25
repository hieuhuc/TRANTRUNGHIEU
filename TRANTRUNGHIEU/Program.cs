using System;
using System.Configuration;

namespace TranTrungHieuMidterm
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        static void Main(string[] args)
        {
            string connection = ConfigurationManager.ConnectionStrings["hieu"].ConnectionString;
            PostController pc = new PostController(connection);

            string cmd = "";
            if (args.Length > 0)
                cmd = args[0];
            int Id = 0;
            string Title = "";
            string Summary = "";
            string Hcontent = "";
          
            switch (cmd.ToLower())
            {
                case "add":

                    if (args.Length != 4)
                    {
                        Console.WriteLine("usage: Add Title Summary Hcontent ");
                        return;
                    }
                    PostModel OnePost = new PostModel();
                 
                    OnePost.Title = args[1];
                    OnePost.Summary = args[2];
                    OnePost.Hcontent = args[3];
                


                    pc.AddOnePost(OnePost);

                    Console.WriteLine("Add completed " + Title);
                    break;
                case "delete":
                    if (args.Length != 2)
                    {
                        Console.WriteLine("usage: Delete Id");
                        return;
                    }
                    string StrId = args[1];
                    bool isValid = int.TryParse(StrId, out Id);
                    if (!isValid)
                    {
                        Console.WriteLine("Invalid Id " + StrId);
                        return;
                    }

                    if (Id > 0)
                    {

                        pc.DeletePost(Id);

                    }
                    Console.WriteLine("Delete completed " + StrId);
                    break;
                case "list":
                    if (args.Length != 2)
                    {
                        Console.WriteLine("usage: List Keyword");
                        return;
                    }
                    string Keyword = args[1];
                    if (string.IsNullOrEmpty(Keyword))
                    {
                        Console.WriteLine("please enter the keyword");
                    }
                    else
                    {
                        Console.WriteLine("valid id");
                        Console.WriteLine(pc.getAll1());

                    }
                    Console.WriteLine("Query Completed " + Keyword);
                    break;
                case "Load":

                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
            return;

        }
    }
}
