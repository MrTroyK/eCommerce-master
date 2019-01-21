using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface IArticleRepository
    {
        //Create 
        Article Add(Article article);

        //Read
        List<Article> GetArticles(string recherche);
        List<Article> GetArticles();
        //int GetQuantity(Guid article);

        //Update
        Article Update(Guid articleId, Article article);
        Article ActiveArticle(Guid articleId, bool active);
        Article TopArticle(Guid articleId, bool top);
        Movement UpdateQuantityArticle(Movement movement);
        Article UpdatePrice(Guid articleId, decimal priceET);
        Article UpdatePicture(Guid articleId, string picture);

        //Delete
        bool Delete(Guid id);
    }
}
