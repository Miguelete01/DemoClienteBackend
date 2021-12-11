using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Model
{

	[Table("Cliente")]
	public class Cliente
	{
		[Key]
		public int Id { get; set; }

		public string nombre { get; set; }

		public string apellido { get; set; }

		public int edad { get; set; }

		public string direccion { get; set; }

	}
}
