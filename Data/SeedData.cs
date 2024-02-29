using Microsoft.EntityFrameworkCore;

namespace api;

public static class SeedData
{
    public static void AddData(Context context)
    {
        if (context.Posts.Any())
        {
            return;
        }
        var posts = new List<Post>
        {
            new Post { Title = "First Post", Content = "This is the content of the first post",
                Comments = new List<Comment> {
                    new Comment { Content = "This is the first comment on the first post" },
                } },
            new Post { Title = "Second Post", Content = "This is the content of the second post",
                Comments = new List<Comment> {
                    new Comment { Content = "This is the first comment on the second post" },
                    new Comment { Content = "This is the second comment on the second post" },
                } },
            new Post { Title = "Third Post", Content = "This is the content of the third post",
                Comments = new List<Comment> {
                    new Comment { Content = "This is the first comment on the third post" },
                    new Comment { Content = "This is the second comment on the third post" },
                    new Comment { Content = "This is the third comment on the third post" },
                } },
            new Post { Title = "Fourth Post", Content = "This is the content of the fourth post",
                Comments = new List<Comment> {
                    new Comment { Content = "This is the first comment on the fourth post" },
                    new Comment { Content = "This is the second comment on the fourth post" },
                    new Comment { Content = "This is the third comment on the fourth post" },
                    new Comment { Content = "This is the fourth comment on the fourth post" },
                } },
            new Post { Title = "Fifth Post", Content = "This is the content of the fifth post" },
            new Post { Title = "Sixth Post", Content = "This is the content of the sixth post" },
            new Post { Title = "Seventh Post", Content = "This is the content of the seventh post" },
            new Post { Title = "Eighth Post", Content = "This is the content of the eighth post" },
            new Post { Title = "Ninth Post", Content = "This is the content of the ninth post" },
            new Post { Title = "Tenth Post", Content = "This is the content of the tenth post" },
            new Post { Title = "Eleventh Post", Content = "This is the content of the eleventh post",
                        Comments = new List<Comment> {
                            new Comment { Content = "This is the first comment on the eleventh post" },
                            new Comment { Content = "This is the second comment on the eleventh post" },
                            new Comment { Content = "This is the third comment on the eleventh post" },
                            new Comment { Content = "This is the fourth comment on the eleventh post" },
                            new Comment { Content = "This is the fifth comment on the eleventh post" },

                        } },
        };

        context.Posts.AddRange(posts);
        context.SaveChanges();


    }

}
