using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About : IEntity
    {
        [Key]
        public int AboutID { get; set; }

        [StringLength(100)]
        public string AboutDetails1 { get; set; }

        [StringLength(100)]
        public string AboutDetails2 { get; set; }

        [StringLength(100)]
        public string AboutImage1 { get; set; }

        [StringLength(100)]
        public string AboutImage2 { get; set; }

        public bool Status { get; set; }
    }
}
