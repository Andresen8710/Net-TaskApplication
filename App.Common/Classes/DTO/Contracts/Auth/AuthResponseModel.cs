namespace App.Common.Classes.DTO.Contracts.Auth
{
    public class AuthResponseModel:BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
        public string Role { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}