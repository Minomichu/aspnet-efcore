using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using CDmoment3.Models;

namespace CDmoment3.Models
{
    public class ArtistData
    {
        //PK
        public int ArtistDataId { get; set; }

        [Required]
        [Display(Name = "Artisten heter:")]
        public string Artistnamn { get; set; }

        //Länkar till CDskivor
        public ICollection<CdData> CDskivorData { get; set; }


        public ArtistData()
        {
        }
    }
}
