using System.Data;
using System.Diagnostics;
using ServiceStack;
using ServiceStack.Data;

namespace ArticleVisualisation.ServiceInterface.Services
{
    public abstract class DbServiceBase : Service
    {
        private IDbConnection _db;
        public IDbConnectionFactory DbFactory { get; set; }
        public override IDbConnection Db => OpenDb(ref _db);

        private IDbConnection OpenDb(ref IDbConnection db)
        {
            if (db != null) return db;
            db = DbFactory.OpenDbConnection();
            Debug.Print($@"{GetType().Name} called IDbConnection.OpenDbConnection(""{db.Database}"").");
            return db;
        }
    }
}