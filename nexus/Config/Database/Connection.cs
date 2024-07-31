using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using nexus.Modules.Post.Entity;
using nexus.Modules.Comment.Entity;
using nexus.Modules.Category.Entity;
using nexus.Modules.User.Entity;
using nexus.Modules.Role.Entity;

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
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
                entity.ToTable("categories");
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.HasMany(category => category.Posts).WithOne(post => post.Category).HasForeignKey(post => post.CategoryId);
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.ToTable("comments");
                entity.HasOne(comment => comment.Post).WithMany(post => post.Comments).HasForeignKey(comment => comment.PostId);
            });
            
            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.ToTable("roles");
                entity.HasMany(role => role.Users).WithOne(user => user.Role).HasForeignKey(user => user.RoleId);
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.ToTable("posts");
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
            });
        }
    }
}
