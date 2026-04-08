namespace App.Domain.Entities
{
	public class VmGetTasksByUserId
	{
		public Guid TaskId { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; }=string.Empty;
		public Guid PriorityId { get; set; }
		public string Priority { get; set; } = string.Empty;
		public Guid UserId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime DueDate { get; set; }
		public int EstimatedTime { get; set; }
		public Guid StatusId { get; set; }
		public string Status { get; set; } = string.Empty;
	}
}