using System.Collections.Generic;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL
{
    public interface IVideoService
    {
        //C
        VideoBO Create(VideoBO vid);
        //R
        List<VideoBO> GetAll();
        VideoBO Get(int Id);
        //U
        VideoBO Update(VideoBO vid);
        //D
        VideoBO Delete(int Id);
    }
}
