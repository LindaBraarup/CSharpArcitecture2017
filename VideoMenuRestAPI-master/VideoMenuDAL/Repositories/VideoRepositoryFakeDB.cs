using System.Collections.Generic;
using System.Linq;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Repositories
{
    class VideoRepositoryFakeDB : IVideoRepository
    {

        #region FakeDB

        private static int Id = 1;
        private static List<Video> videos = new List<Video>();

        #endregion //FakeDB

        public Video Create(Video vid)
        {
            #region Add Videos

            Video newVid;

            videos.Add(newVid = new Video()
            {
                Title = vid.Title,
                Id = Id++
            });

            return newVid;

            #endregion //Add Videos
        }

        public Video Delete(int Id)
        {
            //var vid = Get(Id);
            //videos.Remove(vid);
            return null;
        }

        public Video Get(int Id)
        {
            return videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return new List<Video>(videos);
        }
    }
}
