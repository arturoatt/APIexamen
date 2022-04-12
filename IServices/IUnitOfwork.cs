namespace APIexamen.IServices
{
    public interface IUnitOfwork:IDisposable
    {
        IProductRepository Products { get; }
    }
}
