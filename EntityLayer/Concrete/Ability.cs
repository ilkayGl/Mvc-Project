using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Ability : IEntity
    {
        [Key]
        public int AbilityID { get; set; }

        [StringLength(100)]
        public string AbilityName { get; set; }

        public int AbilityCount { get; set; }

        public bool AbilityStatus { get; set; }
    }
}
