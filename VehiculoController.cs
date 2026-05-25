
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clase_2.Data;

public class VehiculoController : Controller
{
    private readonly ApplicationDbContext _context;

    public VehiculoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: VEHICULOSMODELS
    public async Task<IActionResult> Index()
    {
        var lista = await _context.Vehiculos.ToListAsync();
        return View("~/Views/Vehiculo/Index.cshtml", lista);
    }

    // GET: VEHICULOSMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehiculosmodel = await _context.Vehiculos
            .FirstOrDefaultAsync(m => m.Id == id);
        if (vehiculosmodel == null)
        {
            return NotFound();
        }

        return View(vehiculosmodel);
    }

    // GET: VEHICULOSMODELS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: VEHICULOSMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Placa,Anio_Fabricacion,Kilometraje")] VehiculosModel vehiculosmodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(vehiculosmodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(vehiculosmodel);
    }

    // GET: VEHICULOSMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehiculosmodel = await _context.Vehiculos.FindAsync(id);
        if (vehiculosmodel == null)
        {
            return NotFound();
        }
        return View(vehiculosmodel);
    }

    // POST: VEHICULOSMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Marca,Modelo,Placa,Anio_Fabricacion,Kilometraje")] VehiculosModel vehiculosmodel)
    {
        if (id != vehiculosmodel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(vehiculosmodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculosModelExists(vehiculosmodel.Id))
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
        return View(vehiculosmodel);
    }

    // GET: VEHICULOSMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehiculosmodel = await _context.Vehiculos
            .FirstOrDefaultAsync(m => m.Id == id);
        if (vehiculosmodel == null)
        {
            return NotFound();
        }

        return View(vehiculosmodel);
    }

    // POST: VEHICULOSMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var vehiculosmodel = await _context.Vehiculos.FindAsync(id);
        if (vehiculosmodel != null)
        {
            _context.Vehiculos.Remove(vehiculosmodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool VehiculosModelExists(int? id)
    {
        return _context.Vehiculos.Any(e => e.Id == id);
    }
}
