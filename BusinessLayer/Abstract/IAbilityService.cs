using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAbilityService
    {
        List<Ability> GetList();
        void AbilityAddBL(Ability ability);
        void AbilityDeleteBL(Ability ability);
        void AbilityUpdateBL(Ability ability);
        Ability GetByID(int id);
    }
}
