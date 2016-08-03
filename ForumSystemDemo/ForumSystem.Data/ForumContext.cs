namespace ForumSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Migrations;
    using Models;

    public class ForumContext : DbContext
    {
        public ForumContext()
            : base("ForumContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ForumContext, Configuration>());
        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Question> Questions { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UserFriends");
                });

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Questions)
            //    .WithRequired(q => q.Author)
            //    .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }
    }
}