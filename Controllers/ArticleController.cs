using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReactService.Interfaces;
using ReactService.Models;

namespace ReactService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
		private readonly IRepository _repository;

		private readonly ILogger<ArticleController> _logger;

		public ArticleController(ILogger<ArticleController> logger, IRepository repository)
		{
			_logger = logger;
			_repository = repository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Article>> Get()
		{
			IList<Article> articles = null;

			try
			{
				articles = _repository.GetAll<Article>().Result;
				_logger.LogInformation($"Полный вывод статей. Количество статей: {articles.Count}");
			}
			catch(Exception e)
			{
				_logger.LogError($"Ошибка вывода статей:" + Environment.NewLine + e.Message);
			}

			return new ObjectResult(articles);
		}


		// GET api/article/D7D052DC-CC09-443E-844C-1648829BA6A0
		[HttpGet("{id}")]
		public ActionResult<Article> Get(Guid id)
		{
			Article article = null;

			try
			{
				article = _repository.Get<Article>(id).Result;

				if (article == null)
				{
					_logger.LogWarning($"Не найдена cтатья по заданному id: {id}");
				}
				else
				{
					_logger.LogInformation($"Найдена cтатья по заданному id: {id}");
				}
			}
			catch(Exception e)
			{
				_logger.LogError($"Ошибка вывода статьи с id: {id}" + Environment.NewLine + e.Message);
			}

			return new ObjectResult(article);
		}
	}
}