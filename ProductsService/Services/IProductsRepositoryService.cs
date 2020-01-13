#region Namespaces
using ProductService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

/// <summary>
/// Namespace to handle product related operations
/// </summary>
namespace ProductService.Services
{
    /// <summary>Interface for Product operations</summary>
    public interface IProductRepositoryService
    {
        /// <summary>To Gets all products.</summary>
        /// <param name="owner">The owner.</param>
        /// <returns></returns>
        List<ProductItem> GetAllProducts(string owner);

        /// <summary>Adds the new product item.</summary>
        /// <param name="NewProduct">The new product.</param>
        /// <returns></returns>
        Task<ProductItem> AddProductItem(ProductItem NewProduct);
    }
}


