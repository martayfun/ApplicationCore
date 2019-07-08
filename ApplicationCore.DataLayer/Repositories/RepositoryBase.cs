using ApplicationCore.DataLayer.EntityFramework;

namespace ApplicationCore.DataLayer.Repositories
{
    public class RepositoryBase
    {
        internal readonly ApplicationCoreContext _dbContext;
        public RepositoryBase(ApplicationCoreContext pContext)
        {
            this._dbContext = pContext;
        }
    }
}