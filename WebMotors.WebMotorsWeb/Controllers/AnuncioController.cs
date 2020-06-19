using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebMotors.Core.Data;
using WebMotors.Core.Entities;
using WebMotors.WebMotorsWeb.Models;

namespace WebMotors.WebMotorsWeb.Controllers
{
    public class AnuncioController : Controller
    {
        private readonly WebMotorsDatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly HttpClient _client;
        
        public AnuncioController(WebMotorsDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44340/");
        }

        // GET: AnuncioModels
        public async Task<IActionResult> Index()
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage Res = await _client.GetAsync("api/Anuncio");

            var EmpResponse = Res.Content.ReadAsStringAsync().Result;
            var anuncio = JsonConvert.DeserializeObject<List<Anuncio>>(EmpResponse);

            return View(_mapper.Map<IList<AnuncioViewModel>>(anuncio));
        }

        // GET: AnuncioModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncio
                .FirstOrDefaultAsync(m => m.Id == id);

            if (anuncio == null)
            {
                return NotFound();
            }

            var anuncioModel = _mapper.Map<AnuncioViewModel>(anuncio);

            return View(anuncioModel);
        }

        // GET: AnuncioModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnuncioModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Versao,Ano,Quilometragem,Observacao")] AnuncioViewModel anuncioModel)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync("api/Anuncio", anuncioModel);
                return RedirectToAction(nameof(Index));
            }
            return View(anuncioModel);
        }

        // GET: AnuncioModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncio.FindAsync(id);
            if (anuncio == null)
            {
                return NotFound();
            }

            var anuncioModel = _mapper.Map<AnuncioViewModel>(anuncio);

            return View(anuncioModel);
        }

        // POST: AnuncioModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Versao,Ano,Quilometragem,Observacao")] AnuncioViewModel anuncioModel)
        {
            if (id != anuncioModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage response = await _client.PutAsJsonAsync("api/Anuncio/" + id.ToString().Trim(), anuncioModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnuncioModelExists(anuncioModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(anuncioModel);
        }

        // GET: AnuncioModels/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncio
                .FirstOrDefaultAsync(m => m.Id == id);

            if (anuncio == null)
            {
                return NotFound();
            }

            var anuncioModel = _mapper.Map<AnuncioViewModel>(anuncio);

            return View(anuncioModel);
        }

        // POST: AnuncioModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync("api/Anuncio/" + id.ToString().Trim());
            return RedirectToAction(nameof(Index));
        }

        private bool AnuncioModelExists(int id)
        {
            return _context.Anuncio.Any(e => e.Id == id);
        }
    }
}
