#region Namespaces
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Security.Claims;
using ProductService.Models;
using ProductService.Services;
using MediatR;
using ProductService.Commands;
using System.Threading.Tasks;
#endregion

/// <summary>
/// Controller to handle products related actions
/// </summary>
namespace ProductService.Controllers
{
    /// <summary> Class to handle products related actions</summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        /// <summary>The product repository service</summary>
        private readonly IProductRepositoryService _productRepositoryService;
        /// <summary>The mediator to manage product commands and queries</summary>
        private readonly IMediator _mediator;

        /// <summary>Initializes a new instance of the <see cref="ProductController"/> class.
        /// Injected Service and Mediator class</summary>
        /// <param name="Productrepositoryservice">The productrepositoryservice.</param>
        /// <param name="Mediator">The mediator.</param>
        public ProductController(IProductRepositoryService Productrepositoryservice, IMediator Mediator)
        {
            _mediator = Mediator;
            _productRepositoryService = Productrepositoryservice;
        }

        // GET: api/values
        /// <summary>Gets the available products.</summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<ProductItem> Get()
        {
            string owner = User != null ? (User.FindFirst(ClaimTypes.NameIdentifier))?.Value : "1";//Defaulted to constant 1 to proceed if user null
            return Ok(_productRepositoryService.GetAllProducts(owner));
        }

        // POST api/values
        /// <summary>Saves the specified newly added product to in memory database.</summary>
        /// <param name="Product">The product.</param>
        /// <returns></returns>
        [HttpPost]
        public ProductItem Post([FromBody]ProductItemAddCommand Product)
        {
            Product.Owner = User != null ? (User.FindFirst(ClaimTypes.NameIdentifier))?.Value : "1";//Defaulted to constant 1 to proceed if user null
            Task<ProductItem> createdProduct = _mediator.Send(Product);
            return new ProductItem { Id = createdProduct.Result.Id, Owner = createdProduct.Result.Owner, Title = createdProduct.Result.Title };
        }
    }
}
