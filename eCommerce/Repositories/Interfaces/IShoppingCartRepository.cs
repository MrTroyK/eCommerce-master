using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        //Create
        ShoppingCart AddArticle(ShoppingCart shoppingCart, Article article);
        
        //Read
        ICollection<Article> ListArticles(ShoppingCart shoppingCart);
        bool Find(ShoppingCart shoppingCart);

        //Update
        ShoppingCart Update(Guid shoppingCartId, ShoppingCart shoppingCart);

        int GetQuantity(ShoppingCart shoppingCart);

        //Delete
        bool DeleteArticle(ShoppingCart shoppingCart, Article article);
        bool Delete(ShoppingCart shoppingCart);

    }
}
