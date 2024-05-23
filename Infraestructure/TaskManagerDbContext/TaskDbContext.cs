using Domain.Models;
using Microsoft.EntityFrameworkCore;



namespace Infrastructure.TaskManagerDbContext
{
    public class TaskDbContext: DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
            
        } 
        public DbSet<TaskManagerModel> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskManagerModel>(entity =>
            {
                entity.HasKey(task => task.Id);
                entity.Property(task => task.Title).IsRequired();
                entity.Property(task => task.StatusTask).IsRequired();
                entity.Property(task => task.Detail).IsRequired();
                entity.Property(task => task.ExpirationDate).IsRequired();
                entity.Property(task => task.Priority).IsRequired();
            }
            );

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(user => user.IdUser);
                entity.Property(user => user.Name).IsRequired();
                entity.Property(user => user.Email).IsRequired();
                entity.Property(user => user.Password).IsRequired();
                entity.Property(user => user.Preference).IsRequired();
            });

            modelBuilder.Entity<TaskManagerModel>().HasOne(entity => entity.User);
        }
        
    }
}
