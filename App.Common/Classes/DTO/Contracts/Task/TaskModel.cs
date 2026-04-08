using App.Common.Classes.DTO.Contracts.User;

namespace App.Common.Classes.DTO.Contracts.Task
{
    public class TaskModel:BaseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid PriorityId { get; set; }
        public Guid UserId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime DueDate { get; set; }
		public int EstimatedTime { get; set; }
		public Guid StatusId { get; set; }

	}
}