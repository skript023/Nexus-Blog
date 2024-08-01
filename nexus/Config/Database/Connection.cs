using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using nexus.Modules.Post.Entity;
using nexus.Modules.Comment.Entity;
using nexus.Modules.Category.Entity;
using nexus.Modules.User.Entity;
using nexus.Modules.Role.Entity;
using nexus.Utils;
using BCrypt.Net;

namespace nexus.Config.Database
{
    public class Connection(DbContextOptions<Connection> options) : DbContext(options)
    {
        public DbSet<Posts> Post { get; set; }
        public DbSet<Comments> Comment { get; set; }
        public DbSet<Categories> Category { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<Roles> Role { get; set; }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Timestamps &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((Timestamps)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((Timestamps)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var adminRoleId = Guid.NewGuid();

            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("categories");
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.HasMany(category => category.Posts).WithOne(post => post.Category).HasForeignKey(post => post.CategoryId);
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.ToTable("comments");
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.HasOne(comment => comment.Post).WithMany(post => post.Comments).HasForeignKey(comment => comment.PostId);
            });
            
            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.HasMany(role => role.Users).WithOne(user => user.Role).HasForeignKey(user => user.RoleId);

                entity.HasData(
                    new Roles 
                    { 
                        Id = adminRoleId, 
                        Name = "Admin", 
                        Status = "active", 
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                    },
                    new Roles 
                    { 
                        Id= Guid.NewGuid(), 
                        Name = "User", 
                        Status = "active",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                    }
                );
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.ToTable("posts");
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.HasOne(post => post.User).WithMany(user => user.Posts).HasForeignKey(post => post.UserId);
            });
            
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");
                entity.HasIndex(e => e.Nik).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.HasMany(user => user.Comments).WithOne(comment => comment.User).HasForeignKey(comment => comment.UserId);

                entity.HasData(
                    new Users
                    {
                        Id = Guid.NewGuid(),
                        RoleId = adminRoleId,
                        Nik = NikGenerate.Instance.EightDigit(),
                        Fullname = "Administrator",
                        Username = "admin",
                        Email = "admin@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("123"),
                        Status = "active",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                    }
                );
            });
        }
    }
}
