using System.Data;
using System.Linq;
using ArticleVisualisation.ServiceInterface.Repositories;
using ServiceModel;
using ServiceStack.OrmLite;
using ServiceStack.Redis;

namespace ArticleVisualisation.ServiceInterface.Extensions
{
    public static class LoadExtensions
    {
        public static void Load(this Article self, IDbConnection db, UniqueArticle request)
        {
            if (self == null)
                return;
            var documents = db.Select<Document>(d => d.ArticleId == request.Id);
            self.Documents = documents;
        }
    }
}