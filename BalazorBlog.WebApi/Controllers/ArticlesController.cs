using BlazorBlog.Application.Services;
using BlazorBlog.Domain.Articles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BalazorBlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var articles = await _articleService.GetAllArticleAsync();
            if (articles is null)
            {
                return BadRequest();
            }
            return Ok(articles);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Article?>> GetOne(int id)
        {
            var article = await _articleService.GetArticleAsync(id);
            if (article is null) return BadRequest();
            return article;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Article article)
        {
            if (article is null)
            {
                return BadRequest();
            }
            var result = await _articleService.CreatArticleAsync(article);
            if (!result)
            {
                return BadRequest();
            }
            return Created();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Article article)
        {
            var result = await _articleService.UpdateArticleAsync(id,article);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _articleService.DeleteArticleAsync(id);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
