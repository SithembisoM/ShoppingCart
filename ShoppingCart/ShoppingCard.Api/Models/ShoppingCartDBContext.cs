using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Api.Models
{
  public partial class ShoppingCartDBContext : DbContext
  {
    public ShoppingCartDBContext()
    {
    }

    public ShoppingCartDBContext(DbContextOptions<ShoppingCartDBContext> options)
      : base(options)
    {
    }

    public virtual DbSet<Product> Product { get; set; } = null!;

    public virtual DbSet<ShoppingDetail> ShoppingDetails { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer("Server=(LocalDB)\\.;Database=ShoppingCartDB;user id=ShoppingCartUser;password=Password!@#;Trusted_Connection=True;MultipleActiveResultSets=true");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //modelBuilder.Entity<Product>(
      //  entity =>
      //  {
      //    entity.ToTable("ShoppingDetail");

      //    entity.Property(e => e.Name)
      //      .HasMaxLength(100)
      //      .IsUnicode(false);

      //    entity.Property(e => e.Photo)
      //      .HasMaxLength(100)
      //      .IsUnicode(false);
      //  });

      modelBuilder.Entity<ShoppingDetail>(
        entity =>
        {
          entity.HasKey(e => e.ShopId);

          entity.Property(e => e.Description)
            .HasMaxLength(200)
            .IsUnicode(false);

          entity.Property(e => e.ShoppingDate)
            .HasColumnType("datetime")
            .HasColumnName("shoppingDate");

          entity.Property(e => e.UserName)
            .HasMaxLength(100)
            .IsUnicode(false);
        });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
