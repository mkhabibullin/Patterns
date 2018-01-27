using CompositeEF.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CompositeEF
{
    public class SampleDbContext : DbContext
    {
        public DbSet<BookItem> Items { get; set; }

        public SampleDbContext()
        {
        }

        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<BookItem>().ToTable("BookItems");
            model.Entity<Person>().ToTable("Persons");
            model.Entity<Group>().ToTable("Groups");
            model.Entity<Address>().ToTable("Addresses");
            model.Entity<Person>().HasMany(p => p.Addresses).WithOne(a => a.Parent).IsRequired(true);

            base.OnModelCreating(model);
        }

        public Group Root
        {
            get
            {
                return (from item in Items.ToList() where item.Parent == null let g = item as Group select g).Single();
            }
        }
    }
}
