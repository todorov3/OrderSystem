namespace OrderSystem.Repository.Contracts
{
    public interface IOrderProductsRepository
    {
        Task AddProductToCart(int Id);
        Task RemoveFromCart(int Id);
    }
}
