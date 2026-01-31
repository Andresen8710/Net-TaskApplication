using App.Common.Classes.Base.DTO;

namespace App.Common.Classes.Base.Extensions
{
    public static class ResponseExtension
    {
        public static ResponseDTO<T> AsResponseDTO<T>(this T resultDTO, int code, string message="",List<string>? errorList = null, bool success=false)
        {
            ResponseDTO<T> responseDTO = new ResponseDTO<T>();
            responseDTO.Data=resultDTO;
            responseDTO.Header = new HeaderDTO
            {
                ReponseCode = code,
                Message = message,
                Success = success
            };
            responseDTO.Header.ErrorList = errorList;
            return responseDTO;

        }
    }
}