namespace App.Common.Classes.Base.DTO
{
    public class HeaderDTO
    {
        //
        // Summary:
        //     Codigo de respuesta
        public int ReponseCode { get; set; }

        //
        // Summary:
        //     Mensaje de la respuesta
        public string Message { get; set; }=string.Empty;

        //
        // Summary:
        //     Indica si la respuesta es falsa o verdadera
        public bool Success { get; set; }

        public List<string>? ErrorList { get; set; }
    }
}