using EF3Data.Data;
using EF3Data.Entities;
using EF3Data;
using Microsoft.EntityFrameworkCore;

namespace efas
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new DataContext();
            if (context.Users.Count() == 0)
            {
                PopulateData(context);
            }


            var result = context.Blogs
                    .Include(blog => blog.BlogType)
                    .Include(blog => blog.Posts)
                        .ThenInclude(post => post.PostType)
                    .Include(blog => blog.Posts)
                        .ThenInclude(post => post.User)
                    .Where(blog => blog.IsDeleted == false && !string.IsNullOrEmpty(blog.Url)
                                   && blog.BlogType.Status == Statuses.Active)
                    .SelectMany(blog => blog.Posts.Where(post => post.IsDeleted == false
                                   && post.PostType.Status == Statuses.Active),
                               (blog, post) => new
                               {
                                   BlogUrl = blog.Url,
                                   BlogIsPublic = blog.IsPublic,
                                   BlogTypeName = blog.BlogType.Name,
                                   PostUserName = post.User.Name,
                                   PostUserEmailAddress = post.User.EmailAddress,
                                   TotalBlogPostsByUser = post.User.Posts.Count,
                                   PostTypeName = post.PostType.Name
                               })
                    .OrderBy(result => result.PostUserName)
                    .ToList();


            foreach (var item in result)
            {
                Console.WriteLine($"Blog URL: {item.BlogUrl}");
                Console.WriteLine($"Blog IsPublic: {item.BlogIsPublic}");
                Console.WriteLine($"Blog Type Name: {item.BlogTypeName}");
                Console.WriteLine($"Post User Name: {item.PostUserName}");
                Console.WriteLine($"Post User Email Address: {item.PostUserEmailAddress}");
                Console.WriteLine($"Total Blog Posts by User: {item.TotalBlogPostsByUser}");
                Console.WriteLine($"Post Type Name: {item.PostTypeName}");
                Console.WriteLine("-----");
            }
        }


        private static void PopulateData(DataContext context)
        {
            var name = "gohilv@mymacewan.ca";
            var dataCreator = new DataCreator(name);
            var container = dataCreator.GetData();
            context.Users.AddRange(container.Users);
            context.PostTypes.AddRange(container.PostTypes);
            context.Posts.AddRange(container.Posts);
            context.Blogs.AddRange(container.Blogs);
            context.BlogTypes.AddRange(container.BlogTypes);
            context.SaveChanges();
        }
    }
}