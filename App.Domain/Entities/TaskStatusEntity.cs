namespace App.Domain.Entities
{
	public class TaskStatusEntity : BaseEntity
	{
		public TaskStatusEntity()
		{
			Tasks = new HashSet<TaskEntity>();
		}
		public string Name { get; set; } = string.Empty;

		public virtual ICollection<TaskEntity> Tasks { get; set; }
	}
}