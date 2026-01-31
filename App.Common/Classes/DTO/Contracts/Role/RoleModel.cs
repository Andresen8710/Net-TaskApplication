using App.Common.Classes.DTO.Contracts.User;

namespace App.Common.Classes.DTO.Contracts.Role
{
    public class RoleModel:BaseModel
    {
        public string? Name { get; set; }

        //public virtual List<UserModel>? Users { get; set; }
    }
}