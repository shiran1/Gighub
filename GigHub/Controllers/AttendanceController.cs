using System.Linq;
using System.Web.Http;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    [Authorize]
    public class AttendanceController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController()
        {
            _context = new ApplicationDbContext();
        }
        
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Attendaces.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
            {
                return BadRequest("Attendance Already exists");
            }
            
            var attendance = new Attendace
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            
            _context.Attendaces.Add(attendance);
            _context.SaveChanges();

            return Ok("Attendance Created!");
        }
    }
}