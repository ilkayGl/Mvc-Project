using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListContent(string p);
        List<Content> GetListByWriter(int id);
        List<Content> GetListByHeadingID(int id); //başlık id si kaçsa ona göre içerikleri listele
        void ContentAddBL(Content content);
        void ContentDeleteBL(Content content);
        void ContentUpdateBL(Content content);
        Content GetByID(int id);
    }
}
