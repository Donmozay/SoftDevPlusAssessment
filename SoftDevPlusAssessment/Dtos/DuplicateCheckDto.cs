namespace SoftDevPlusAssessment.Dtos
{
    public class DuplicateCheckDto<T> where T : IEquatable<T>
    {
        public List<T> CollectionA { get; set; }
        public List<T> CollectionS { get; set; }
    }
}
