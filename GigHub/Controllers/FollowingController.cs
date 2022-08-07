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
        public IHttpActionResult Index(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (userId == dto.ArtistId)
            {
                return BadRequest("You can not follow you");
            }
            
            var following = new Following
            {
                ArtistId = dto.ArtistId,
                FollowerId = userId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}