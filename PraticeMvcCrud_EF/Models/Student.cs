using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PraticeMvcCrud_EF.Models
{
    public class Student
    {
        [Key]
        [Required(ErrorMessage ="This Field is Required")]
        public int Sno { get; set; }
        [Required(ErrorMessage ="Name is required ")]

        public string Name { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Range(0,10000,ErrorMessage ="Fee must be between 0 to 10000")]
        public decimal Fee {  get; set; }   
    }
}