using App.Common.Classes.DTO.Contracts.User;

namespace App.Common.Classes.DTO.Contracts.Task
{
    public class TaskEntryModel : BaseModel
    {
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public int TimeSpent { get; set; }

        //public virtual UserModel? User { get; set; }
        //public virtual TaskModel? Task { get; set; }
    }
}