namespace JimmyTestCMS.Service.Common
{
    public class Sorting
    {
        public string Field { get; set; }
        public OrderingDirection Direction { get; set; } = OrderingDirection.Ascending;
    }

    public enum OrderingDirection
    {
        Ascending,
        Descending
    }
}
