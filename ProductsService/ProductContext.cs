#region Namespaces
using Microsoft.EntityFrameworkCore;
using ProductService.Models;
#endregion

/// <summary>
/// Namespace for Service to handle product related operation
/// </summary>
namespace ProductService
{
    /// <summary>Service to handle product related operation</summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class ProductContext : DbContext
    {
        /// <summary>Initializes a new instance of the <see cref="ProductContext"/> class.</summary>
        /// <param name="options">The options.</param>
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        { }

        /// <summary>Gets or sets the product.</summary>
        /// <value>The product.</value>
        public DbSet<ProductItem> Product { get; set; }
    }
}
