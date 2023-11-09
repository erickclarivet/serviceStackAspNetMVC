using System.Data;
using ArticleVisualisation.ServiceInterface.Extensions;
using ServiceModel;
using ServiceStack.OrmLite;

namespace ArticleVisualisation.ServiceInterface.Repositories
{
    public static class ArticleExtensions
    {
        public static Article Get(this IDbConnection db, UniqueArticle request)
        {
            var article = db.SingleById<Article>(request.Id);
            article.Load(db, request);
            return article;
        }
        
        // public static List<Article> Get(this IDbConnection db, AllArticles request)
        // {
        //     var ev = db.From<Article>()
        //         .OrderBy(p => p.Id);
        //     var articles = db.Select(ev);
        //     articles.Load(db, false, false, false, false, false, false, false);
        //     return articles;
        // }
    }
}