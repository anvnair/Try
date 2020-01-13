#region Namespaces
using MediatR;
#endregion

/// <summary>
/// Commands class for Products
/// </summary>
namespace ProductService.Commands
{
    /// <summary>Command class to add Product Item</summary>
    /// <seealso cref="MediatR.IRequest{ProductService.Models.ProductItem}" />
    public class ProductItemAddCommand : IRequest<Models.ProductItem>
    {
        /// <summary>Gets or sets the owner.</summary>
        /// <value>The owner.</value>
        public string Owner { get; set; }

        /// <summary>Gets or sets the title.</summary>
        /// <value>The title.</value>
        public string Title { get; set; }
    }
}
