namespace App.Domain.Entities
{
    public class PriorityEntity: BaseEntity
    {
        public PriorityEntity()
        {
            Tasks= new HashSet<TaskEntity>();
        }
        public string? Name { get; set; }

        public virtual ICollection<TaskEntity> Tasks { get; set; }
    }
}