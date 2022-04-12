using APIexamen.IServices;
using Microsoft.Data.SqlClient;

namespace APIexamen.Services
{
    public class UnitOfWork : IUnitOfwork
    {
        private readonly SqlConnection _connection;
        public UnitOfWork(IConfiguration configuration)
        {
            _connection = new SqlConnection(configuration.GetConnectionString(Resources.ConnectionDB));
            Products = new ProductRepository(_connection);
        }

        public IProductRepository Products { get; private set; }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
