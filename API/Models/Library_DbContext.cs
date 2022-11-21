using Microsoft.EntityFrameworkCore;


namespace Models
{
    public class Library_DbContext : DbContext
    {
        public Library_DbContext(DbContextOptions<Library_DbContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Book { get; set; } 
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Modeling RelationShips
            modelBuilder.Entity<Book>()
                .HasKey(s => s.Book_index);

            modelBuilder.Entity<User>()
                .HasKey(s => s.User_index);
        }
    }
}