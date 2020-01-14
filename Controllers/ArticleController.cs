using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReactService.Models;

namespace ReactService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
		private IList<Article> _articles;

		private readonly ILogger<ArticleController> _logger;

		public ArticleController(ILogger<ArticleController> logger)
		{
			_logger = logger;
			_articles = new List<Article>() 
			{ 
				new Article() 
				{ 
					Id = 1, Title = "Пушкин", Text = "Поэзия, прости господи, должна быть глуповата.", Date = new DateTime(2020, 01, 12) 
				},
				new Article()
				{
					Id = 2, Title = "Есенин", Text = "Жить нужно легче, жить нужно проще, все принимая, что есть на свете.", Date = new DateTime(2020, 01, 11)
				},
				new Article()
				{
					Id = 3, Title = "Горький", Text = "Жизнь всегда будет достаточно плоха для того, чтоб желание лучшего не угасало в человеке.", Date = new DateTime(2020, 01, 10)
				},
			};
		}

		[HttpGet]
		public ActionResult<IEnumerable<Article>> Get() => new ObjectResult(_articles);


		// GET api/article/1
		[HttpGet("{id}")]
		public ActionResult<Article> Get(int id)
		{
			Article article = _articles.FirstOrDefault(x => x.Id == id);

			if (article == null) return NotFound();

			return new ObjectResult(article);
		}
	}
}