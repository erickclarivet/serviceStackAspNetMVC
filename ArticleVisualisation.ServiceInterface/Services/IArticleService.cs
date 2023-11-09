using ServiceModel;

namespace ArticleVisualisation.ServiceInterface.Services
{
    public interface IArticleService
    {
        ArticleResponse Get(UniqueArticle request);
    }
}