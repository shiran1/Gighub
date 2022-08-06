using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required][FutureDate] public string Date { get; set; }

        [Required][ValidTime] public string Time { get; set; }

        // For communicate with Main Model (Gig)
        [Required] public byte Genre { get; set; }

        // For Display list of Genres which are coming from GigsController
        public IEnumerable<Genre> Genres { get; set; }


        // Information Expert = the one who has the detail is the one who should do it
        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format($"{Date} {Time}"));
        }
    }
}