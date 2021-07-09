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
    public class AbilityManager : IAbilityService
    {
        IAbilityDal _abilityDal;

        public AbilityManager(IAbilityDal abilityDal)
        {
            _abilityDal = abilityDal;
        }

        public void AbilityAddBL(Ability ability)
        {
            _abilityDal.Insert(ability);
        }

        public void AbilityDeleteBL(Ability ability)
        {
            _abilityDal.Delete(ability);
        }

        public void AbilityUpdateBL(Ability ability)
        {
            _abilityDal.Update(ability);
        }

        public Ability GetByID(int id)
        {
            return _abilityDal.Get(x => x.AbilityID == id);
        }

        public List<Ability> GetList()
        {
            return _abilityDal.List();
        }
    }
}
