namespace App.Common.Classes.DTO.Contracts.Auth
{
    public class AuthRequestModel
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Boolean Checked { get; set; } = false;
    }
}