using ServiceStack.DataAnnotations;

namespace ServiceModel
{
    public class Document
    {
        [AutoIncrement]
        [PrimaryKey]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        // Foreign key for Article relationship
        [References(typeof(Article))]
        public int ArticleId { get; set; }
    }
}