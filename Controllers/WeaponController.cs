using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GenshinBuildsApi.Data;
using GenshinBuildsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace GenshinBuildsApi.Controllers
{

    /// <summary>
    /// operation with Weapon 
    /// </summary>
    [ApiController]
    [Route("Weapons")]
    public class WeaponController : Controller
    {
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Weapon>> Get([FromServices] DataContext context, int id)
        {
            var weapon = await context.Weapons.FindAsync(id);
            if (weapon != null)
            { return Ok(weapon); }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Weapon>>> Get([FromServices] DataContext context)
        {
            var weapons = await context.Weapons.ToListAsync();

            return Ok(weapons);
        }


        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Weapon>> Post([FromServices] DataContext context, [FromBody] Weapon model)
        {

            context.Weapons.Add(model);
            await context.SaveChangesAsync();

            return Created("", model);

        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Weapon>> Put([FromServices] DataContext context, [FromBody] Weapon model)
        {


            if (context.Weapons.Find(model.Id) != null)
            {
                var weapon = context.Weapons.Find(model.Id);

                //weapon.Titulo = model.Titulo;

                await context.SaveChangesAsync();
                return Ok(model);
            }
            return NotFound(model);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Weapon>> Delete([FromServices] DataContext context, int id)
        {
            var weapon = context.Weapons.Find(id);
            if (weapon != null)
            {
                context.Weapons.Remove(weapon);
                await context.SaveChangesAsync();
                return Ok("Weapon deletada");
            }
            else
            {
                return NotFound();
            }
        }


    }
}
