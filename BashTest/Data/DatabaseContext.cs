using BashTest.Model;
using Microsoft.EntityFrameworkCore;

namespace BashTest.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectItem> ProjectItems { get; set; }
        public DbSet<DocumentsPack> DocumentsPacks { get; set; }
        public DbSet<ProjectItemsDocuments> ProjectItemsDocuments { get; set; }
        public DbSet<Mark> Marks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectItem>()
                    .HasMany(e => e.Children)
                    .WithOne(e => e.Parent)
                    .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<ProjectItemsDocuments>()
                .HasKey(bc => new { bc.ProjectItemId, bc.DocumentsPackId });

            modelBuilder.Entity<ProjectItemsDocuments>()
                .HasOne(bc => bc.DocumentsPack)
                .WithMany(b => b.DocumentsItems)
                .HasForeignKey(bc => bc.DocumentsPackId);

            modelBuilder.Entity<ProjectItemsDocuments>()
                .HasOne(bc => bc.ProjectItem)
                .WithMany(c => c.DocumentsItems)
                .HasForeignKey(bc => bc.ProjectItemId);

            modelBuilder.Entity<Project>().HasData(new Project { Id = 1, Shifr = "pr-1", Name = "Project 1" },
                                                   new Project { Id = 2, Shifr = "pr-2", Name = "Project 2" });

            modelBuilder.Entity<Mark>().HasData(new Mark { Id = 1, ShortName = "Mark 1", FullName = "Mark One" },
                                                new Mark { Id = 2, ShortName = "Mark 2", FullName = "Mark Two" });

            modelBuilder.Entity<DocumentsPack>().HasData(new DocumentsPack { Id = 1, Number = 1, MarkId = 1 },
                                                         new DocumentsPack { Id = 2, Number = 2, MarkId = 2 },
                                                         new DocumentsPack { Id = 3, Number = 3, MarkId = 1 },
                                                         new DocumentsPack { Id = 4, Number = 4, MarkId = 2 });

            modelBuilder.Entity<ProjectItem>().HasData(new ProjectItem { Id = 1, ProjectId = 1, Code = "Code 1", Name = "Name Item 1" },
                                                       new ProjectItem { Id = 2, ProjectId = 1, ParentId = 1, Code = "Code 2", Name = "Name Item 2" },
                                                       new ProjectItem { Id = 3, ProjectId = 2, Code = "Code 3", Name = "Name Item 3" });

            modelBuilder.Entity<ProjectItemsDocuments>().HasData(new ProjectItemsDocuments { Id = 1, DocumentsPackId = 1, ProjectItemId = 1 },
                                                                 new ProjectItemsDocuments { Id = 2, DocumentsPackId = 2, ProjectItemId = 1 },
                                                                 new ProjectItemsDocuments { Id = 3, DocumentsPackId = 3, ProjectItemId = 2 },
                                                                 new ProjectItemsDocuments { Id = 4, DocumentsPackId = 4, ProjectItemId = 3 });
        }
    }
}
