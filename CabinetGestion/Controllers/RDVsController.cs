using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CabinetGestion.Data;
using CabinetGestion.Models;

namespace CabinetGestion.Controllers
{
    public class RDVsController : Controller
    {

        private readonly CabinetGestionContext _context;

        public RDVsController(CabinetGestionContext context)
        {
            _context = context;
        }

        // GET: RDVs
        public async Task<IActionResult> Index()
        {
            var cabinetGestionContext = _context.RDV.Include(r => r.Medecin).Include(r => r.Patient);
            return View(await cabinetGestionContext.ToListAsync());
        }

        // GET: RDVs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rDV = await _context.RDV
                .Include(r => r.Medecin)
                .Include(r => r.Patient)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (rDV == null)
            {
                return NotFound();
            }

            return View(rDV);
        }

        // GET: RDVs/Create
        public IActionResult Create()
        {
            ViewData["MedecinId"] = new SelectList(_context.Medecin, "Id", "Id");
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id");
            return View();
        }

        // POST: RDVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedecinId,PatientId,DateRDV,Ordonnance")] RDV rDV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rDV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedecinId"] = new SelectList(_context.Medecin, "Id", "Id", rDV.MedecinId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", rDV.PatientId);
            return View(rDV);
        }

        // GET: RDVs/Edit/5
        public async Task<IActionResult> Edit(int? idPatient, int? idMedecin)
        {
            
            if (idPatient == null||idMedecin==null)
            {
                return NotFound();
            }

            var rDV = await _context.RDV.FindAsync(idPatient,idMedecin);
            if (rDV == null)
            {
                return NotFound();
            }
            
            ViewData["MedecinId"] = new SelectList(_context.Medecin, "Id", "Id", rDV.MedecinId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", rDV.PatientId);
            return View(rDV);
        }

        // POST: RDVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( [Bind("MedecinId,PatientId,DateRDV,Ordonnance")] RDV rDV)
        {
           
          
            if (ModelState.IsValid)
            {

                try
                {
                    _context.RDV.Where(n => n.PatientId == rDV.PatientId);
                    _context.RDV.Where(m => m.MedecinId == rDV.MedecinId);
                    _context.Update(rDV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RDVExists(rDV.PatientId))
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
            ViewData["MedecinId"] = new SelectList(_context.Medecin, "Id", "Id", rDV.MedecinId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", rDV.PatientId);
            return View(rDV);
        }

        // GET: RDVs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rDV = await _context.RDV
                .Include(r => r.Medecin)
                .Include(r => r.Patient)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (rDV == null)
            {
                return NotFound();
            }

            return View(rDV);
        }

        // POST: RDVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rDV = await _context.RDV.FindAsync(id);
            _context.RDV.Remove(rDV);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RDVExists(int id)
        {
            return _context.RDV.Any(e => e.PatientId == id);
        }
    }
}
