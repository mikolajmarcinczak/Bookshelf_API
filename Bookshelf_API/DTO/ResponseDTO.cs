namespace Bookshelf_API.DTO
{
    public class ResponseDTO
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
    public class ResponseDTO<T> : ResponseDTO
    {
        public T Result { get; set; }
    }
}
