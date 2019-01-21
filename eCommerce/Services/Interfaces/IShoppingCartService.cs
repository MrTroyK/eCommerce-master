using System.Collections.Generic;
using Model.Model;

namespace eCommerce.Services
{
    public interface IShoppingCartService
    {
        ShoppingCart AddArticle(ShoppingCart sc, Article article, int quantity);
        bool DeleteArticle(ShoppingCart sc, Article article);
        bool DeleteShoppingCart(ShoppingCart sc);
        ICollection<Article> GetAllArticles(ShoppingCart sc);
    }
}

