using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMotors.Core.Data;
using WebMotors.Core.Entities;
using WebMotors.WebMotorsWeb.Models;

namespace WebMotors.WebMotorsWeb.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        private readonly WebMotorsDatabaseContext _context;
        private readonly IMapper _mapper;

        public AnuncioController(WebMotorsDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/AnuncioModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnuncioViewModel>>> GetAnuncioModel()
        {
            var result = await _context.Anuncio.ToListAsync();            
            var anuncios = _mapper.Map<List<AnuncioViewModel>>(result);
            return anuncios;
        }

        // GET: api/AnuncioModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnuncioViewModel>> GetAnuncioModel(int id)
        {
            var anuncio = await _context.Anuncio.FindAsync(id);

            if (anuncio == null)
            {
                return NotFound();
            }
            var anuncioModel = _mapper.Map<AnuncioViewModel>(anuncio);

            return anuncioModel;
            
        }

        // PUT: api/AnuncioModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnuncioModel(int id, AnuncioViewModel anuncioModel)
        {
            if (id != anuncioModel.Id)
            {
                return BadRequest();
            }

            var anuncio = _mapper.Map<Anuncio>(anuncioModel);

            _context.Entry(anuncio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnuncioModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AnuncioModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnuncioViewModel>> PostAnuncioModel(AnuncioViewModel anuncioModel)
        {
            var anuncio = _mapper.Map<Anuncio>(anuncioModel);
            _context.Anuncio.Add(anuncio);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAnuncioModel", new { id = anuncio.Id }, anuncioModel);
        }

        // DELETE: api/AnuncioModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnuncioViewModel>> DeleteAnuncioModel(int id)
        {
            var anuncio = await _context.Anuncio.FindAsync(id);
            if (anuncio == null)
            {
                return NotFound();
            }

            _context.Anuncio.Remove(anuncio);
            await _context.SaveChangesAsync();

            var anuncioModel = _mapper.Map<AnuncioViewModel>(anuncio);

            return anuncioModel;
        }

        private bool AnuncioModelExists(int id)
        {
            return _context.Anuncio.Any(e => e.Id == id);            
        }
    }
}
