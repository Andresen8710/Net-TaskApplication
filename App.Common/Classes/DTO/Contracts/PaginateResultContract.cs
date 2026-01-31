namespace App.Common.Classes.DTO.Contracts
{
    public class PaginateResultContract<T>
    {
        public List<T>? Data { get; set; }
        public int TotalRecords { get; set; }
    }
}