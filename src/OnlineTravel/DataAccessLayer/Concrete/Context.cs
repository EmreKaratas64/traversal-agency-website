using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-NKLMS7G\\SQLEXPRESS;database=OnlineTravelDB;integrated security=true");
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
    }
}
