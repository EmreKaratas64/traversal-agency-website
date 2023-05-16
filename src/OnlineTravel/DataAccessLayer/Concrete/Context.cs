using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-NKLMS7G\\MSSQLSERVER01;database=OnlineTravelDB;integrated security=true");
        }

        public DbSet<About> Abouts { get; set; } = null!;

        public DbSet<About2> About2s { get; set; } = null!;

        public DbSet<Contact> Contacts { get; set; } = null!;

        public DbSet<Destination> Destinations { get; set; } = null!;

        public DbSet<Feature> Features { get; set; } = null!;

        public DbSet<Guide> Guides { get; set; } = null!;

        public DbSet<NewsLetter> NewsLetters { get; set; } = null!;

        public DbSet<SubAbout> SubAbouts { get; set; } = null!;

        public DbSet<Testimonial> Testimonials { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<Rezervation> Rezervations { get; set; } = null!;

        public DbSet<Notification> Notifications { get; set; } = null!;

        public DbSet<Account> Accounts { get; set; } = null!;
    }
}
