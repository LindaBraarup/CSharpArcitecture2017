using System;
namespace VideoMenuDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }

        int Complete();
    }
}
