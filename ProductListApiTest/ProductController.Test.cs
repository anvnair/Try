#region Namespaces
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProductService.Commands;
using ProductService.Controllers;
using ProductService.Models;
using ProductService.Services;
#endregion

/// <summary>
/// Namespace to test Product list api
/// </summary>
namespace ProductListApiTest
{
    /// <summary>Controller to test Product list api</summary>
    public class ProductControllerTest
    {
        /// <summary>The mock product repository service</summary>
        private Mock<IProductRepositoryService> mockProductRepositoryService = new Mock<IProductRepositoryService>();
        /// <summary>The user</summary>
        private ClaimsPrincipal user;
        private Mock<IMediator> mockMediator = new Mock<IMediator>();
        /// <summary>Setups this instance.</summary>
        [SetUp]
        public void Setup()
        {
            user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                     {
                            new Claim(ClaimTypes.Name, "dummy name"),
                            new Claim(ClaimTypes.NameIdentifier, "1"),
                            new Claim("custom-claim", "dummy claim value"),
                     }, "mock"));
        }
        /// <summary>Gets the test asynchronous for all products</summary>
        [Test]
        public void GetTestAsync()
        {
            string userToken = (user.FindFirst(ClaimTypes.NameIdentifier))?.Value;
            mockProductRepositoryService.Setup(x => x.GetAllProducts(userToken)).Returns(GetAllProducts());
            var controller = new ProductController(mockProductRepositoryService.Object, mockMediator.Object);
            var response = controller.Get().Result as OkObjectResult;
            Assert.IsInstanceOf<IEnumerable<ProductItem>>(response.Value);
        }
        /// <summary>Posts the test asynchronous for new item</summary>
        [Test]
        public void PostTestAsync()
        {
            var productItemAddCommand = new ProductItemAddCommand();
            mockMediator.Setup(x => x.Send(It.IsAny<ProductItemAddCommand>(), new CancellationToken())).Returns(Task.FromResult(GetProductItem()));
            var controller = new ProductController(mockProductRepositoryService.Object, mockMediator.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };
            var actionResult = controller.Post(new ProductItemAddCommand { });
            Assert.IsInstanceOf<ProductItem>(actionResult);
        }
        /// <summary>Gets the product item.</summary>
        /// <returns></returns>
        private ProductItem GetProductItem()
        {
            return new ProductItem
            {
                Id = 1,
                Owner = "Test",
                Title = "Sam"
            };
        }
        /// <summary>Gets all products.</summary>
        /// <returns></returns>
        private List<ProductItem> GetAllProducts()
        {
            var todoList = new List<ProductItem> {
                 new ProductItem { Title = "Product One" },
                 new ProductItem { Title = "Product Two" }
               };
            return todoList;

        }
    }
}
