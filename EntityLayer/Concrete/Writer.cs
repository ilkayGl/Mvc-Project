using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class Writer : IEntity
    {
        //[HiddenInput(DisplayValue = false)]
        [Key]
        public int WriterID { get; set; }

        [StringLength(50)]
        public string WriterName { get; set; }

        [StringLength(50)]
        public string WriterSurname { get; set; }

        [StringLength(100)]
        public string WriterAbout { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(250)]
        public string WriterImage { get; set; }

        [StringLength(200)]
        public string WriterMail { get; set; }

        [StringLength(200)]
        public string WriterPassword { get; set; }

        public bool WriterStatus { get; set; }


        public ICollection<Heading> Headings { get; set; } // Bir yazarin birden fazla basligi olabilir
        public ICollection<Content> Contents { get; set; }
    }
}
