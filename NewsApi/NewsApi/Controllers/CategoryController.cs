using Microsoft.AspNetCore.Mvc;
using NewsApi.Models;
using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations;
using NewsApi.Services;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        ICategoryCollectionService _categoryCollectionService;
        public CategoryController(ICategoryCollectionService categoryCollectionService)
        {
            _categoryCollectionService = categoryCollectionService ?? throw new ArgumentNullException(nameof(CategoryCollectionService));
        }

        /// <summary>
        /// This is a method used to get all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryCollectionService.GetAll());
        }
        /// <summary>
        /// This is method used to get categories by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var announcement = await _categoryCollectionService.Get(id);
            if (announcement == null)
            {
                return NotFound("Category not found");
            }
            return Ok(announcement);
        }
        
        /// <summary>
        /// This is a method used to add a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> CreateAnnouncement([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Category can't be null");
            }
            await _categoryCollectionService.Create(category);
            return Ok(category);
        }
        /// <summary>
        /// This is a method used to update a category
        /// </summary>
        /// <param name="category"></param>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category, [Required] Guid Id)
        {
            if (category == null)
            {
                return BadRequest("Category can't be null");
            }
            var isUpdated = await _categoryCollectionService.Update(Id, category);
            if (isUpdated == false)
            {
                return NotFound("Category was not found");
            }

            return Ok("The category was updated");

        }
        /// <summary>
        /// This is a method used to delete a category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] Guid id)
        {
            var isDeleted = await _categoryCollectionService.Delete(id);
            if (isDeleted == false)
            {
                return NotFound("The category was not found");
            }
            return Ok("Category deleted");
        }
    }
}
