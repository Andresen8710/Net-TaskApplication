namespace App.Common.Classes.DTO.Contracts
{
    public class BaseModel
    {
        public Guid Id { get; set; } = Guid.Empty;
        public DateTime CreationDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}