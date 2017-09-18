using System;
using VideoMenuDAL.Repositories;
using VideoMenuDAL.UOW;

namespace VideoMenuDAL
{
    public class DALFacade
    {
        public IVideoRepository VideoRepository
        {
            //get { return new VideoRepositoryFakeDB(); }

            get
            {
                return new VideoRepositoryEFMemory(new Context.InMemoryContext());
            }
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWorkMem();
            }
        }
    }
}
