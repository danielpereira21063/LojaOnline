namespace LojaOnline.OrderApi.Messages
{
    public record OrderCreated(Guid Id, string CustomerName, decimal TotalAmount);
}
