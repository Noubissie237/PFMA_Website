using System;
using System.ComponentModel.DataAnnotations;

namespace PFMA_Website.Model
{
    public class Actualite
    {
        public int ActualiteID { get; set; }
        [Required]
        public string text { get; set; }
        public string tag { get; set; }
        public string date = DateTime.Now.ToString("dd/MM/yyyy");
    }
}
