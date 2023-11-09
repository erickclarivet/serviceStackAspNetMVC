using ArticleVisualisation.ServiceInterface.Repositories;
using ServiceModel;
using ServiceStack;

namespace ArticleVisualisation.ServiceInterface.Services
{
    public class ArticleService : DbServiceBase, IArticleService
    {
        public ArticleResponse Get(UniqueArticle request)
        {
            return new ArticleResponse { Article = Db.Get(request) };
        }
    }
}