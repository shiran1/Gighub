
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GigHub.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GigHub.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}