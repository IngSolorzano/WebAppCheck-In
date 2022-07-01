using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCheck_In.Models;


namespace WebAppCheck_In.Controllers
{
    public class TimeRecordsController : Controller
    {
        private readonly AppDbContext _context;

        //public object CheckInTime { get; private set; }

        public TimeRecordsController(AppDbContext context)
        {
            _context = context;
        }

        //GET: TimeRecords
        //[HttpPost]
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate)
           
        {
            //Linq
            var records = from r in _context.TimeRecords.Include(e => e.Employees)
                          select r;
            
            if (startDate != null && endDate != null)
            {  
                records = records.Where(r => r.CheckInTime >= startDate  && r.CheckInTime <= endDate);
                return View(await records.ToListAsync());
                
            }
            return View(await records.ToListAsync());
        }

        // GET: TimeRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TimeRecords == null)
            {
                return NotFound();
            }

            var timeRecord = await _context.TimeRecords
                .Include(t => t.Employees)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeRecord == null)
            {
                return NotFound();
            }

            return View(timeRecord);
        }


        // GET: TimeRecords/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Recibiendo el parametro de número de empleado
        public async Task<IActionResult> Create(int employeeNumber)
        {
            if (ModelState.IsValid)
            {
                //Con el parametro de número de empleado, buscas en la base de datos si existe ese empleado
                var employee = _context.Employees.FirstOrDefault(m => m.EmployeeNumber == employeeNumber);

                //Si sí existe, entonces continuas con la busqueda del time record
                if (employee != null)
                {
                    //Buscas si existe un time record para el empleado que buscaste arriba, pero con la condición de que no tenga hora de salida
                    var timeRecord = _context.TimeRecords?.FirstOrDefault(t => t.EmployeeId == employee.Id && t.CheckOutTime == null);

                    //Si sí existe, entonces actualizas con la hora de salida y lo guardas en la base de datos
                    if(timeRecord != null)
                    {
                        timeRecord.CheckOutTime = DateTime.Now;
                        _context.Update(timeRecord);
                    }
                    else
                    {
                        //Si no existe, entonces creas uno nuevo con la hora de entrada y el ID del empleado que encontraste arriba
                        var newTimeRecord = new TimeRecord();
                        newTimeRecord.CheckInTime = DateTime.Now;
                        newTimeRecord.EmployeeId = employee.Id;
                        _context.Add(newTimeRecord);
                    }
                    //Esto guarda todos los cambios que hiciste arriba
                    await _context.SaveChangesAsync();
                }

                //Esto retorna a la Vista de Index de TimeRecords, si quieres ir a otra vista de otro controlador, solamente tienes que especificar el nombre del controlador después de la acción
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TimeRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TimeRecords == null)
            {
                return NotFound();
            }

            var timeRecord = await _context.TimeRecords.FindAsync(id);
            if (timeRecord == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", timeRecord.EmployeeId);
            return View(timeRecord);
        }

        // POST: TimeRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TimeRecord timeRecord)
        {
            if (id != timeRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeRecordExists(timeRecord.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", timeRecord.EmployeeId);
            return View(timeRecord);
        }

        // GET: TimeRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TimeRecords == null)
            {
                return NotFound();
            }

            var timeRecord = await _context.TimeRecords
                .Include(t => t.Employees)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeRecord == null)
            {
                return NotFound();
            }

            return View(timeRecord);
        }

        // POST: TimeRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TimeRecords == null)
            {
                return Problem("Entity set 'AppDbContext.TimeRecords'  is null.");
            }
            var timeRecord = await _context.TimeRecords.FindAsync(id);
            if (timeRecord != null)
            {
                _context.TimeRecords.Remove(timeRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeRecordExists(int id)
        {
          return (_context.TimeRecords?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
