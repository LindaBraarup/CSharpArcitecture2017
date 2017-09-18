using System.Collections.Generic;
using System.Linq;
using VideoMenuDAL.Context;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Repositories
{
    class VideoRepositoryEFMemory : IVideoRepository
    {
        InMemoryContext _context;

        public VideoRepositoryEFMemory(InMemoryContext context)
        {
            _context = context;
        }

        public Video Create(Video vid)
        {
            _context.videos.Add(vid);
            return vid;
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            _context.videos.Remove(vid);
            return vid;
        }

        public Video Get(int Id)
        {
            return _context.videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return _context.videos.ToList();
        }
    }
}
