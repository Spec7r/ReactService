using ReactService.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReactService.Models
{
	public class Article : IEntity
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[Required]
		[Column(TypeName = "varchar(200)")]
		public string Title { get; set; }

		[Required]
		public string Text { get; set; }

		[Required]
		public DateTime Date { get; set; }
	}
}
