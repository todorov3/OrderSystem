namespace OrderSystem.Repository.Contracts
{
    public interface IOrderProducts
    {
        Task AddProductToOrder(int Id);
    }
}
