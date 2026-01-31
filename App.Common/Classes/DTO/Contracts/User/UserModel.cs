using App.Common.Classes.DTO.Contracts.Role;
using App.Common.Classes.DTO.Contracts.Task;

namespace App.Common.Classes.DTO.Contracts.User
{
    public class UserModel :BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
        public bool IsAdmin { get; set; }
        public string UserName { get; set; } = string.Empty;

        //public virtual RoleModel? Role { get; set; }
        //public virtual List<TaskModel>? Tasks { get; set; }
        //public virtual List<TaskEntryModel>? TaskEntries { get; set; }
    }
}