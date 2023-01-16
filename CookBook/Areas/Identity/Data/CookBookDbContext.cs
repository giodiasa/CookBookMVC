using CookBook.Areas.Identity.Data;
using CookBook.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBook.Areas.Identity.Data;

public class CookBookDbContext : IdentityDbContext<CookBookUser>
{
    public CookBookDbContext(DbContextOptions<CookBookDbContext> options)
        : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new CookbookUserEntityConfiguration());
    }
}

internal class CookbookUserEntityConfiguration : IEntityTypeConfiguration<CookBookUser>
{
    public void Configure(EntityTypeBuilder<CookBookUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}