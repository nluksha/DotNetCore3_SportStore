using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportStore.Models;
using SportStore.Models.ViewModels;

namespace SportStore.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int MyProperty { get; set; }

        public int PageSize { get; set; } = 4;

        public HomeController(IStoreRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index(string category, int page = 1)
        {
            var products = repository.Products
                .Where(p => category == null || p.Category == category);

            var productsList = new ProductsListViewModel
            {
                Products = products
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = products.Count()
                },
                CurrentCategory = category
            };

            return View(productsList);
        }
    }
}
