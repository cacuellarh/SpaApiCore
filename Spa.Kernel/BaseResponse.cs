namespace Spa.Kernel
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public int? RowsAffected { get; set; }
        public BaseResponse() { }
    }
}
