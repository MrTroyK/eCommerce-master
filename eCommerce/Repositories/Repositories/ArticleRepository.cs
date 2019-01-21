using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Model.Model;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ECommerceDbContext _context;
        public ArticleRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        //Create 
        public Article Add(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
            return article;
        }

        //Read
        public List<Article> GetArticles(string recherche)
        {
            return _context.Articles.Where(x => x.Wording.Contains(recherche)).ToList();
        }
        public List<Article> GetArticles()
        {
            return _context.Articles.ToList();
        }

        /*public int GetQuantity(Guid article)
        {
            
        }*/

        //Update
        public Article Update(Guid articleId, Article article)
        {
            var old = _context.Articles.Find(articleId);
            var newA = _context.Articles.Update(old);


            if (newA.Entity.Id == articleId)
            {
                newA.Entity.Active = article.Active;
                newA.Entity.Wording = article.Wording;
                newA.Entity.Description = article.Description;
                newA.Entity.Picture = article.Picture;
                newA.Entity.PriceET = article.PriceET;
                newA.Entity.Category = article.Category;
                newA.Entity.Tax = article.Tax;
                newA.Entity.Quantity = article.Quantity;
                newA.Entity.DeliveryTime = article.DeliveryTime;
                newA.Entity.Active = article.Active;
                newA.Entity.Top = article.Top;
                _context.SaveChanges();
                return newA.Entity;
            }
            return null;
        }
        public Article ActiveArticle(Guid articleId, bool active)
        {
            var old = _context.Articles.Find(articleId);
            var newA = _context.Articles.Update(old);


            if (newA.Entity.Id == articleId)
            {
                newA.Entity.Active = active;
                _context.SaveChanges();
                return newA.Entity;
            }
            return null;
        }

        public Article TopArticle(Guid articleId, bool top)
        {
            return null;
        }
        public Movement UpdateQuantityArticle(Movement movement)
        {
            var old = _context.Articles.Find(movement.Article);
            var newA = _context.Articles.Update(old);


            if (newA.Entity.Id == movement.Article.Id)
            {
                _context.Movements.Add(movement);
                _context.SaveChanges();
                return movement;
            }

            return null;
        }
        public Article UpdatePrice(Guid articleId, decimal priceET)
        {
            var old = _context.Articles.Find(articleId);
            var newA = _context.Articles.Update(old);


            if (newA.Entity.Id == articleId)
            {
                newA.Entity.PriceET = priceET;
                _context.SaveChanges();
                return newA.Entity;
            }
            return null;
        }
        public Article UpdatePicture(Guid articleId, string picture)
        {
            var old = _context.Articles.Find(articleId);
            var newA = _context.Articles.Update(old);


            if (newA.Entity.Id == articleId)
            {
                newA.Entity.Picture = picture;
                _context.SaveChanges();
                return newA.Entity;
            }
            return null;
        }

        //Delete
        public bool Delete(Guid id)
        {
            if (this._context.Addresses.Find(id) != null)
            {
                _context.Addresses.Remove(_context.Addresses.Find(id));
                _context.SaveChanges();
                return true;
            }
            return false;
        } 
    }
}
