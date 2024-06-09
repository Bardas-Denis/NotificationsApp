using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Models;
using NewsApi.Services;
using System.ComponentModel.DataAnnotations;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        
        IAnnouncementCollectionService _announcementCollectionService;
        public AnnouncementController(IAnnouncementCollectionService announcementCollectionService)
        {
            _announcementCollectionService = announcementCollectionService ?? throw new ArgumentNullException(nameof(AnnouncementCollectionService));
        }


        /// <summary>
        /// This is a method used to get all announcements
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAnnouncements()
        {
            return Ok(await _announcementCollectionService.GetAll());
        }
        /// <summary>
        /// This is method used to get announcements by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncementById(Guid id)
        {
            var announcement=await _announcementCollectionService.Get(id);
            if(announcement == null)
            {
                return NotFound("Announcement not found");
            }
            return Ok(announcement);
        }
        /// <summary>
        /// This is a method to get announcements by their category 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("getBycategoryId{categoryId}")]
        public async Task<IActionResult> GetAnnouncementsByCategoryId(string categoryId)
        {
            var announcements =await _announcementCollectionService.GetAnnouncementsByCategoryId(categoryId);
            if (announcements == null)
            {
                return NotFound("No announcement was found");
            }
            return Ok(announcements);
        }

        /// <summary>
        /// This is a method used to add an announcement
        /// </summary>
        /// <param name="announcement"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> CreateAnnouncement([FromBody] Announcement announcement)
        {
            if (announcement == null)
            {
                return BadRequest("Announcement can't be null");
            }
            await _announcementCollectionService.Create(announcement);
            return Ok(announcement);
        }
        /// <summary>
        /// This is a method used to update an announcement
        /// </summary>
        /// <param name="announcement"></param>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpPut("{Id}")]
        public  async Task<IActionResult> UpdateAnnouncement([FromBody] Announcement announcement, [Required] Guid Id)
        {
            if (announcement == null)
            {
                return BadRequest("Announcement can't be null");
            }
            var isUpdated =await _announcementCollectionService.Update(Id, announcement);
            if (isUpdated==false)
            {
                return NotFound("Announcement was not found");
            }

            return Ok("The announcement was updated");
           
        }
        /// <summary>
        /// This is a method used to delete an announcement
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] Guid id)
        {
            var isDeleted =await _announcementCollectionService.Delete(id);
            if (isDeleted==false)
            {
                return NotFound("The announcement was not found");
            }
            return Ok("Announcement deleted");
        }
    }
}
