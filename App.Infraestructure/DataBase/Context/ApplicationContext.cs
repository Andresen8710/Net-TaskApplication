using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskStatusEntity = App.Domain.Entities.TaskStatusEntity;

namespace App.Infraestructure.DataBase.Context
{
    public class ApplicationContext : DbContext
    {
        public IConfiguration _Configuration { get; set; }

        #region DbSets
            public virtual DbSet<UserEntity>Users { get; set; }
            public virtual DbSet<TaskEntity>Tasks { get; set; }
            public virtual DbSet<TaskEntryEntity> TaskEntries { get; set; }
            public virtual DbSet<RoleEntity> Roles { get; set; }
            public virtual DbSet<PriorityEntity> Priorities { get; set; }
		    public virtual DbSet<TaskStatusEntity> TaskStatuses { get; set; }
            public virtual DbSet<VmGetTasksByUserId> Vm_GetTasksByUserId {  get; set; }
		#endregion DbSets


		public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration) :base(options)
        { 
            _Configuration = configuration;
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>()
                .HasOne(u=>u.Role)
                .WithMany(r=>r.Users)
                .HasForeignKey(u=>u.RoleId);

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.Property(p=> p.UserName).IsRequired();

                entity.Property(p=>p.Name).IsRequired();

                entity.Property(p=>p.LastName).IsRequired();

                entity.Property(p=>p.Email).IsRequired();

                entity.HasOne(u => u.Role)
                    .WithMany(r => r.Users)
                    .HasForeignKey(u => u.RoleId)
                    .HasConstraintName("FK_UserEntity_RoleEntity")
                    .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<TaskEntity>(entity =>
            {
                entity.Property(p => p.Name).IsRequired();

                entity.HasOne(u => u.User)
                .WithMany(r => r.Tasks)
                .HasForeignKey(u => u.UserId)
                .HasConstraintName("FK_TaskEntity_UserEntity")
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<TaskEntryEntity>(entity =>
            {
                entity.Property(p=>p.TimeSpent).IsRequired();

                entity.HasOne(u => u.Task)
                .WithMany(r => r.TaskEntries)
                .HasForeignKey(u => u.TaskId)
                .HasConstraintName("FK_TaskEntryEntity_TaskEntity")
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<TaskEntryEntity>(entity =>
            {
                entity.HasOne(u => u.User)
                .WithMany(r => r.TaskEntries)
                .HasForeignKey(u => u.UserId)
                .HasConstraintName("FK_TaskEntryEntity_UserEntity")
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<TaskEntity>(entity =>
            {
                entity.HasOne(u => u.Priority)
                .WithMany(r => r.Tasks)
                .HasForeignKey(u => u.PriorityId)
                .HasConstraintName("FK_TaskEntity_PriorityEntity")
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<TaskEntity>(entity =>
            {
                entity.HasOne(u => u.TaskStatus)
                .WithMany(r => r.Tasks)
                .HasForeignKey(u => u.StatusId)
                .HasConstraintName("FK_TaskEntity_TaskStatus")
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<VmGetTasksByUserId>().HasNoKey();

            // Convención: renombrar columna "Id" a "{Entidad}Id" en BD
            // para evitar ambigüedad en vistas y JOINs
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (!typeof(BaseEntity).IsAssignableFrom(entityType.ClrType)) continue;

                var idProperty = entityType.FindProperty(nameof(BaseEntity.Id));
                if (idProperty != null)
                {
                    var entityName = entityType.ClrType.Name.Replace("Entity", "");
                    idProperty.SetColumnName($"{entityName}Id");
                }
            }
        }
    }
}