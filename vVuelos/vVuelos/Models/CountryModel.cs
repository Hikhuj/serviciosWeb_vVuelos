using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vVuelos.Models
{
    public class CountryModel
    {
        public CountryModel(string consecutive_country_id, string name1, string image)
        {
            this.consecutive_country_id = consecutive_country_id;
            this.name1 = name1;
            this.image = image;
        }

        public string consecutive_country_id { get; set; }
        public string name1 { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string image { get; set; }

    }
}