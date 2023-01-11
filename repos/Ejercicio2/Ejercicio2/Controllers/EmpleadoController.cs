using Ejercicio2.Config;
using Ejercicio2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio2.Controllers
{
    public class EmpleadoController : Controller //la herencia en c# es con los ':'
    {
        private readonly DBEmpleadoContext context;
        public EmpleadoController(DBEmpleadoContext context)
        {
            this.context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<Empleado>>> Get()
        {
            return await this.context.Empleados.ToListAsync();
        }

        [HttpPost("save")]
        public async Task<ActionResult> Post(Empleado empleado) {
            this.context.Add(empleado);
            await this.context.SaveChangesAsync();

            return Ok();
                }
    }
}
