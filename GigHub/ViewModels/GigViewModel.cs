using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class GigViewModel
    {
        public IEnumerable<Gig> UpComingGigs { get; set; }
        public bool ShowAction { get; set; }
    }
}