using System.Configuration;
using System.Web.Mvc;
using ArticleVisualisation.ServiceInterface;
using ArticleVisualisation.ServiceInterface.Services;
using Funq;
using ServiceModel;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.Mvc;
using ServiceStack.OrmLite;

namespace ArticleVisualisation.WebMvc
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("MVC", typeof(ArticleService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                HandlerFactoryPath = "api"
            });

            var dbFactory = new OrmLiteConnectionFactory(
                ConfigurationManager.ConnectionStrings["article-visualisation"].ConnectionString,
                SqlServer2008Dialect.Provider);
            Container.AddSingleton<IDbConnectionFactory>(
                c => dbFactory);

            // Warning if DATABASE NOT EXIST NEED TO CREATE IT WITH SSMS
            using (var db = container.Resolve<IDbConnectionFactory>().Open())
            {
                //Create the Customer POCO table if it doesn't already exist
                db.CreateTableIfNotExists<Article>();
                db.CreateTableIfNotExists<Document>();
            }

            ControllerBuilder.Current.SetControllerFactory(
                new FunqControllerFactory(container));
        }
    }
}