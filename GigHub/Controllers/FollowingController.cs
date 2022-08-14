using System.Linq;
using System.Web.Http;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowingController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowingController()
        {
            _context = new ApplicationDbContext();
        }
        
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == userId))
            {
                return BadRequest("Following already exists");
            }
            
            var following = new Following
            {
                FolloweeId = userId,
                FollowerId = dto.FolloweeId
                
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}