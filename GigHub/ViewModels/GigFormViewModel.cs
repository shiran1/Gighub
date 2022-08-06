using System.Collections;
using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public string Venue { get; set; }
        
        public string Date { get; set; }
        
        public string Time { get; set; }
        
        // For communicate with Main Model (Gig)
        public byte Genre { get; set; }
        // For Display list of Genres which are coming from GigsController
        public IEnumerable<Genre> Genres { get; set; }
    }
}