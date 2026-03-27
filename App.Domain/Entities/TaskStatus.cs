namespace App.Domain.Entities
{
	public class TaskStatus : BaseEntity
	{
		public TaskStatus()
		{
			Tasks = new HashSet<TaskEntity>();
		}
		public string Name { get; set; } = string.Empty;

		public virtual ICollection<TaskEntity> Tasks { get; set; }
	}
}