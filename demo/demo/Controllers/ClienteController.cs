using demo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteController : ControllerBase
	{
		private readonly ModelContext _model;

		public ClienteController(ModelContext model)
		{
			_model = model;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			var obj = await _model.Clientes.Where(a => a.Id == id).FirstOrDefaultAsync();

			if (obj == null)
				return NotFound();

			return Ok(obj);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var obj = await _model.Clientes.ToListAsync();

			return Ok(obj);
		}

		[HttpPost]
		public async Task<IActionResult> Save([FromBody] Cliente obj)
		{
			try
			{
				if (obj == null)
					return BadRequest("El cliente no existe");

				var result = await _model.Clientes.AddAsync(obj);
				await _model.SaveChangesAsync();

				return Ok();

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw new Exception("Toy roto");
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Cliente obj)
		{
			if (obj.Id == 0)
				return BadRequest("El cliente no existe");

			var cliente = await _model.Clientes.Where(a => a.Id == id).FirstOrDefaultAsync();

			if (cliente == null)
				return BadRequest("El cliente no existe");

			cliente.nombre = obj.nombre;
			cliente.apellido = obj.apellido;
			cliente.direccion = obj.direccion;
			cliente.edad = obj.edad;

			await _model.SaveChangesAsync();

			return Ok(cliente);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			if (id == 0)
				return BadRequest("El cliente no existe");

			var cliente = await _model.Clientes.Where(a => a.Id == id).FirstOrDefaultAsync();

			if (cliente == null)
				return BadRequest("El cliente no existe");

			_model.Clientes.Remove(cliente);
			await _model.SaveChangesAsync();

			return Ok(cliente);
		}
	}
}
