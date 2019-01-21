using System;
using System.Collections.Generic;
using Model;
using Model.Model;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ECommerceDbContext _context;

        public ShoppingCartRepository(ECommerceDbContext context)
        {
            this._context = context;
        }

        //Create
        public ShoppingCart AddArticle(ShoppingCart shoppingCart, Article article)
        {
            shoppingCart.Articles.Add(article);
            _context.ShoppingCarts.Update(shoppingCart);
            _context.SaveChanges();
            return shoppingCart;
        }

        //Read
        public ICollection<Article> ListArticles(ShoppingCart shoppingCart)
        {
            return shoppingCart.Articles;
        }

        public bool Find(ShoppingCart shoppingCart)
        {
            if (_context.ShoppingCarts.Find(shoppingCart) is null)
            {
                return false;
            }
            return true;
        } 

        //Update
        public ShoppingCart Update(Guid basketId, ShoppingCart ShoppingCart)
        {
            return null;
        }

        public int GetQuantity(ShoppingCart shoppingCart)
        {
            return shoppingCart.Articles.Count;
        }

        //Delete
        public bool DeleteArticle(ShoppingCart shoppingCart, Article article)
        {
            var quantity = shoppingCart.Articles.Count;
            shoppingCart.Articles.Remove(article);

            if (quantity != shoppingCart.Articles.Count)
            {
                _context.ShoppingCarts.Update(shoppingCart);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(ShoppingCart shoppingCart)
        {
            if (this._context.ShoppingCarts.Find(shoppingCart) != null)
            {
                _context.ShoppingCarts.Remove(_context.ShoppingCarts.Find(shoppingCart.Id));
                _context.SaveChanges();
                return true;
            }
            return false;

        }

    }
}
