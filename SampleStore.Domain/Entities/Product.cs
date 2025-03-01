namespace SampleStore.Domain.Entities
{
    public class Product
    {
        public required Guid Id { get; init; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }
        public required bool IsSellable { get; set; }
        public required string ImageUrl { get; set; }
    }
}