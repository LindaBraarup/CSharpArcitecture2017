using System.Collections.Generic;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL
{
    public interface IVideoRepository
    {
        //C
        Video Create(Video vid);
        //R
        List<Video> GetAll();
        Video Get(int Id);
        //U
        /// No Update here!
        //D
        Video Delete(int Id);
    }
}
