#region Namespaces
using MediatR;
using ProductService.Commands;
using ProductService.Models;
using ProductService.Services;
using System.Threading;
using System.Threading.Tasks;

#endregion
/// <summary>
/// Handler to handle the mediator commands
/// </summary>
namespace ProductService.Handlers.CommandHandler
{
    /// <summary> Class to handle the mediator commands</summary>
    /// <seealso cref="MediatR.IRequestHandler{ProductService.Commands.ProductItemAddCommand, ProductService.Models.ProductItem}" />
    public class ProductCommandHandler : IRequestHandler<ProductItemAddCommand, ProductItem>
    {
        /// <summary>The product repository service</summary>
        private readonly IProductRepositoryService _productRepositoryService;
        /// <summary>Initializes a new instance of the <see cref="ProductCommandHandler"/> class.</summary>
        /// <param name="ProductRepositoryService">The product repository service.</param>
        public ProductCommandHandler(IProductRepositoryService ProductRepositoryService)
        {
            _productRepositoryService = ProductRepositoryService;
        }

        /// <summary>Handles the Add Command for new product request.</summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<ProductItem> Handle(ProductItemAddCommand request, CancellationToken cancellationToken)
        {
            ProductItem newItem = new ProductItem { Owner = request.Owner, Title = request.Title };
            return await _productRepositoryService.AddProductItem(newItem);
        }
    }
}
