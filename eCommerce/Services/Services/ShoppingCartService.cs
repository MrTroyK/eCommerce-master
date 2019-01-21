using System;
using System.Collections.Generic;
using Model.Model;
using Repositories.Interfaces;

namespace eCommerce.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCart AddArticle(ShoppingCart sc, Article article, int quantity)
        {
            return _shoppingCartRepository.AddArticle(sc, article);
        }

        public bool DeleteArticle(ShoppingCart sc, Article article)
        {
            return _shoppingCartRepository.DeleteArticle(sc, article);
        }

        public bool DeleteShoppingCart(ShoppingCart sc)
        {
            var id = sc.Id;
            _shoppingCartRepository.Delete(sc);

            return _shoppingCartRepository.Find(sc);

         }

        public ICollection<Article> GetAllArticles(ShoppingCart sc)
        {
            return _shoppingCartRepository.ListArticles(sc);

        }

        public bool Delete(ShoppingCart shoppingCart)
        {
            return _shoppingCartRepository.Delete(shoppingCart);
        }
    }
}
