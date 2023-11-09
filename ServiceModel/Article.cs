using System.Collections.Generic;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace ServiceModel
{
    public class Article
    {
        [AutoIncrement]
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }
        
        [Reference]
        public List<Document> Documents { get; set; }
    }
    
    public class UniqueArticle : IGet, IReturn<ArticleResponse>
    {
        public int Id { get; set; }
    }

    public class ArticleResponse
    {
        public Article Article { get; set; }
    }
}