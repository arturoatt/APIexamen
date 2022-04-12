using APIexamen.IServices;
using APIexamen.Entities;
using Microsoft.Data.SqlClient;
using Dapper;
using APIexamen.DTOs;

namespace APIexamen.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlConnection _connection;

        public ProductRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<Product> CreateAsync(Product entity)
        {
            entity.Id = await _connection.QuerySingleAsync<int>(Resources.SPCreateProduct,
                                                new { Name = entity.Name, Price = entity.Price },
                                                commandType: System.Data.CommandType.StoredProcedure);

            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _connection.QuerySingleAsync<int>(Resources.SPDeleteProduct, new { Id = id },
                                                commandType: System.Data.CommandType.StoredProcedure);  
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _connection.QueryFirstOrDefaultAsync<Product>(Resources.SPSelectProduct, new { Id = id },
                                                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(PaginationDTO pagination)
        {
            return await _connection.QueryAsync<Product>(Resources.SPGetProductsPag, new { PageNumber = pagination.PageIndex, RowsOfPage = pagination.PageSize},
                                                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(Product entity)
        {
            return await _connection.QuerySingleAsync<int>(Resources.SPUpdProduct, new { Id = entity.Id, Name = entity.Name, Price = entity.Price},
                                                commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
