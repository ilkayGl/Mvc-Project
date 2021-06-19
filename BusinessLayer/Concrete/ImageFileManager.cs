using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _IImageFileDal;

        public ImageFileManager(IImageFileDal iImageFileDal)
        {
            _IImageFileDal = iImageFileDal;
        }

        public ImageFile GetByID(int id)
        {
            return _IImageFileDal.Get(x => x.ImageID == id);
        }

        public List<ImageFile> GetList()
        {
            return _IImageFileDal.List();
        }

        public void ImageFileAddBL(ImageFile imageFile)
        {
            _IImageFileDal.Insert(imageFile);
        }

        public void ImageFileDeleteBL(ImageFile imageFile)
        {
            _IImageFileDal.Delete(imageFile);
        }

        public void ImageFileUpdateBL(ImageFile imageFile)
        {
            _IImageFileDal.Update(imageFile);
        }
    }
}
