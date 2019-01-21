using System;
using System.Collections;
using System.Threading.Tasks;
using eCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Model.Model;

namespace eCommerce.Controllers
{
    public class ShoppingCartController
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        // POST: /Basket/AddToBasket
        [HttpPost]
        public async Task<ShoppingCart> Add(Article article, ShoppingCart shoppingCart, int quantity)
        {
            var sc = await Task.Run (() => _shoppingCartService.AddArticle(shoppingCart, article, quantity));
            return sc;
        }

/*        [HttpGet]
        public ICollection<Article> GetArticles(ShoppingCart shoppingCart)
        {
            var articles = _shoppingCartService.GetAllArticles(shoppingCart);
            return articles;
        }*/

        [HttpDelete]
        public async Task<ShoppingCart> DeleteCart(ShoppingCart shoppingCart)
        {
            var done = await Task.Run(() => _shoppingCartService.DeleteShoppingCart(shoppingCart));
            return null;
        }

        [HttpDelete]
        public async Task<ShoppingCart> DeleteArticle(ShoppingCart shoppingCart, Article article)
        {
            var done = await Task.Run(() => _shoppingCartService.DeleteArticle(shoppingCart, article));
            return null;
        }
    }
}
