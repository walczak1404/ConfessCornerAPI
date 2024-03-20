using ConfessCorner.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.Reflection.Metadata.Ecma335;

namespace ConfessCorner.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Confession> Confessions { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Confession>().Property(c => c.ConfessionId).Metadata.SetValueGeneratorFactory((_,_) => new SequentialGuidValueGenerator());
            //modelBuilder.Entity<Comment>().Property(c => c.CommentId).Metadata.SetValueGeneratorFactory((_,_) => new SequentialGuidValueGenerator());

            modelBuilder.Entity<Confession>().Property(x => x.ConfessionId).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<Comment>().Property(x => x.CommentId).HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<Confession>().Property(c => c.CreatedOn).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Comment>().Property(c => c.CreatedOn).HasDefaultValueSql("GETDATE()");

        }
    }
}
