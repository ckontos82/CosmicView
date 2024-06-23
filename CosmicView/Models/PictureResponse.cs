using CosmicViewSharedLib.Models;

namespace CosmicView.Models
{
    public class PictureResponse
    {
        public List<Picture> Pictures { get; set; }
        public Picture SinglePicture { get; set; }

        public List<Picture> GetPictures()
        {
            if (Pictures != null)
            {
                return Pictures;
            }
            if (SinglePicture != null)
            {
                return new List<Picture> { SinglePicture };
            }
            return new List<Picture>();
        }
    }
}
