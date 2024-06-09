using System;
using System.ComponentModel.DataAnnotations;

namespace PFMA_Website.Model
{
    public class Descriptif
    {
        public int DescriptifID { get; set; }
        [Required]
        public string titre { get; set; }
        [Required]
        public string text { get; set; }
        public string tag { get; set; }
        public string date = DateTime.Now.ToString("dd/MM/yyyy");
    }
}
