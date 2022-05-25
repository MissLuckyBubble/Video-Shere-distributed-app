using Data.Entities;
using System.Data.Entity;


namespace Data.Context
{
    public class VideoDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public VideoDbContext()
        {
            this.Users = this.Set<User>();
            this.Videos = this.Set<Video>();
            this.Comments = this.Set<Comment>();
        }


    }

}