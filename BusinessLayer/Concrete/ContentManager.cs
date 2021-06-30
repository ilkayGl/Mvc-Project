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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAddBL(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentDeleteBL(Content content)
        {
            _contentDal.Delete(content);
        }

        public void ContentUpdateBL(Content content)
        {
            _contentDal.Update(content);
        }


        public Content GetByID(int id)
        {
            return _contentDal.Get(x => x.ContentID == id);
        }

        public List<Content> GetList()
        {
            return _contentDal.List();
        }

        public List<Content> GetListByHeadingID(int id)
        {
            return _contentDal.FilterList(x => x.HeadingID == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.FilterList(x => x.WriterID == id); //session 
        }

        public List<Content> GetListContent(string p)
        {
            if (string.IsNullOrEmpty(p))
            {
                return _contentDal.List();
            }
            else
            {
                return _contentDal.FilterList(x => x.ContentValue.Contains(p));
            }

        }
    }
}
