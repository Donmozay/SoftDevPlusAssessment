namespace SoftDevPlusAssessment.Responses
{
    public class GenericResponse<T> where T : new()
    {
        public string? ResponseCode { get; set; }
        public string? ResponseDescription { get; set; }
        public bool IsSuccessful { get; set; }
        public T? Data { get; set; }
    }
}
