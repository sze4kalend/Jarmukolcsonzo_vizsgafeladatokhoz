namespace Jarmukolcsonzo.Shared.DTOs
{
    public class TableDto<T>
    {
        public TableDto(List<T> data, int totalItems)
        {
            Data = data;
            TotalItems = totalItems;
        }

        public List<T> Data { get; set; } = [];
        public int TotalItems { get; set; }
    }
}
