using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using GigHub.Controllers;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Venue { get; set; }

        [Required][FutureDate] 
        public string Date { get; set; }

        [Required][ValidTime]
        public string Time { get; set; }

        // For communicate with Main Model (Gig)
        [Required]
        public byte Genre { get; set; }

        // For Display list of Genres which are coming from GigsController
        public IEnumerable<Genre> Genres { get; set; }
        
        public string Heading { get; set; }

        public String Action
        {
            get
            {
                // TODO: check this more in details = Mosh-Asp.net mvc p-2-sec-2-lec-08
                Expression<Func<GigsController, ActionResult>> update =
                    (c => c.Update(this));
                Expression<Func<GigsController, ActionResult>> create = 
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;

                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        // Information Expert = the one who has the detail is the one who should do it
        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format($"{Date} {Time}"));
        }
    }
}