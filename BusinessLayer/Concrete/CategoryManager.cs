using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;


        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        public List<Category> GetList()
        {
            return _categoryDal.List();

        }
        public void CategoryAddBL(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDeleteBL(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);
        }

        public void CategoryUpdateBL(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}









//GenericRepository<Category> repo = new GenericRepository<Category>();

//public List<Category> GetAllBl()
//{
//    return repo.List();
//}

//public void CategoryAddBl(Category p)
//{

//    if (p.CategoryName == "" || p.CategoryName.Length <= 3 || p.CategoryDescription == "" || p.CategoryName.Length >= 51)
//    {
//        //hata mesajı gelicek
//    }
//    else
//    {
//        repo.Insert(p);
//    }

//}