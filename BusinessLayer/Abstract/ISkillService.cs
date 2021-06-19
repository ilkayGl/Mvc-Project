using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISkillService
    {
        List<Skill> GetList();
        void SkillAddBL(Skill skill);
        void SkillDeleteBL(Skill skill);
        void SkillUpdateBL(Skill skill);
        Skill GetByID(int id);
    }
}
