
using Clase_2.Data;
using Clase_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class CentroRevisionesController : Controller
{
    private readonly ApplicationDbContext _context;

    public CentroRevisionesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: CENTROREVISIONS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.CentroRevisiones.ToListAsync());
    }

    // GET: CENTROREVISIONS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var centrorevision = await _context.CentroRevisiones
            .FirstOrDefaultAsync(m => m.Id == id);
        if (centrorevision == null)
        {
            return NotFound();
        }

        return View(centrorevision);
    }

    // GET: CENTROREVISIONS/Create
    public IActionResult Create()
    {
        var provincias = _context.Provincias.OrderBy(p => p.Nombre)
     .Select(
         p => new SelectListItem
         {
             Value = p.Id.ToString(),
             Text = p.Nombre,
         }
     );

        ViewBag.ListaProvincias = provincias;
        return View();
    }

    // POST: CENTROREVISIONS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,ProvinciaId")] CentroRevision centrorevision)
    {
        ModelState.Remove("Provincia");
        if (ModelState.IsValid)
        {
            _context.Add(centrorevision);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(centrorevision);
    }

    // GET: CENTROREVISIONS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var centrorevision = await _context.CentroRevisiones.FindAsync(id);
        if (centrorevision == null)
        {
            return NotFound();
        }
        return View(centrorevision);
    }

    // POST: CENTROREVISIONS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,ProvinciaId,Provincia")] CentroRevision centrorevision)
    {
        if (id != centrorevision.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(centrorevision);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CentroRevisionExists(centrorevision.Id))
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
        return View(centrorevision);
    }

    // GET: CENTROREVISIONS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var centrorevision = await _context.CentroRevisiones
            .FirstOrDefaultAsync(m => m.Id == id);
        if (centrorevision == null)
        {
            return NotFound();
        }

        return View(centrorevision);
    }

    // POST: CENTROREVISIONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var centrorevision = await _context.CentroRevisiones.FindAsync(id);
        if (centrorevision != null)
        {
            _context.CentroRevisiones.Remove(centrorevision);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CentroRevisionExists(int? id)
    {
        return _context.CentroRevisiones.Any(e => e.Id == id);
    }
}
