using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SportStore.Controllers;
using SportStore.Models;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace SportStore.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Can_Use_Repository()
        {
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product { ProductId = 1, Name = "P1"},
                new Product { ProductId = 2, Name = "P2"}
            }).AsQueryable<Product>());
            var controller = new HomeController(mock.Object);

            var result = (controller.Index() as ViewResult).ViewData.Model as IEnumerable<Product>;


            var propd = result.ToArray();
            Assert.True(propd.Length == 2);
            Assert.Equal("P1", propd[0].Name);
            Assert.Equal("P2", propd[1].Name);
        }
    }
}
