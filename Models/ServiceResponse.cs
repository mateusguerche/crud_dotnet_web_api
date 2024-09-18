namespace WebAPI_Projeto01.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

    }
}
