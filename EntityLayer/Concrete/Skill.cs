using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Skill : IEntity
    {
        [Key]
        public int SkillID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(150)]
        public string Subject { get; set; }

        [StringLength(250)]
        public string SkillImages { get; set; }

        [StringLength(50)]
        public string Skills1 { get; set; }
        [StringLength(50)]
        public string Skills2 { get; set; }
        [StringLength(50)]
        public string Skills3 { get; set; }
        [StringLength(50)]
        public string Skills4 { get; set; }
        [StringLength(50)]
        public string Skills5 { get; set; }
        [StringLength(50)]
        public string Skills6 { get; set; }
        [StringLength(50)]
        public string Skills7 { get; set; }
        [StringLength(50)]
        public string Skills8 { get; set; }
        [StringLength(50)]
        public string Skills9 { get; set; }
        [StringLength(50)]
        public string Skills10 { get; set; }
    }
}
