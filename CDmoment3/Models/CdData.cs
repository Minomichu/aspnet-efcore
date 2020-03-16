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
    public class CdData
    {
        //PK
        public int CdDataId { get; set; }

        [Required]
        [Display(Name = "CDskiva:")]
        public string Skivnamn { get; set; }

        [Required]
        [Display(Name = "Detaljer om skivan:")]
        public string Detaljer { get; set; }

        //FK
        public int ArtistDataId { get; set; }
        //Navigering
        [Display(Name = "Artist:")]
        public ArtistData ArtistData { get; set; }


        public CdData()
        {
        }
    }
}