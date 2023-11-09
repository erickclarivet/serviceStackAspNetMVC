using System.Web.Mvc;
using ServiceModel;
using ServiceStack.Mvc;

namespace ArticleVisualisation.WebMvc.Controllers
{
    public class ArticleController : ServiceStackController 
    {
        // GET
        public ViewResult Index()
        {
            var result = base.Gateway.Send<ArticleResponse>(new UniqueArticle { Id = 1 });
            ViewBag.HelloResult = result.Article.Name;
            return View();
        } 
    }
}