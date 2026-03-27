namespace App.Domain.Entities
{
    public class TaskEntryEntity:BaseEntity
    {
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public int TimeSpent { get; set; }
		public DateTime ScheduleDate { get; set; }
		public bool IsCompleted { get; set; }
		public string Notes { get; set; }=string.Empty;

		public virtual UserEntity? User { get; set; }
        public virtual TaskEntity? Task { get; set; }

    }
}