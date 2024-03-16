using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class SalariesController : Controller

    {
        private SqlConnection connect = null;
        public string connectionstring = "Data Source=DESKTOP-28KMSTV\\SQLEXPRESS;Initial Catalog=СУБД;Integrated Security=True";

        private readonly SUBDContext _context;

        public SalariesController(SUBDContext context)
        {
            _context = context;
        }

        // GET: Salaries
        public async Task<IActionResult> Index()
        {
            var sUBDContext = _context.Salary.Include(s => s.EmployeeNavigation).Include(s => s.MonthNavigation).Include(s => s.YearNavigation);
            return View(await sUBDContext.ToListAsync());
        }

        // GET: Salaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await _context.Salary
                .Include(s => s.EmployeeNavigation)
                .Include(s => s.MonthNavigation)
                .Include(s => s.YearNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // GET: Salaries/Create
        public IActionResult Create()
        {
            ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Id");
            ViewData["Month"] = new SelectList(_context.Months, "Id", "Id");
            ViewData["Year"] = new SelectList(_context.Years, "YearName", "YearName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Year,Month,Employee,ParticipationPurchase,ParticipationSale,ParticipationProduction,CountParticipation,SalaryEmployee,TotalAmount,Issued,Bonus")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Id", salary.Employee);
            ViewData["Month"] = new SelectList(_context.Months, "Id", "Id", salary.Month);
            ViewData["Year"] = new SelectList(_context.Years, "YearName", "YearName", salary.Year);
            return View(salary);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await _context.Salary.FindAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Id", salary.Employee);
            ViewData["Month"] = new SelectList(_context.Months, "Id", "Id", salary.Month);
            ViewData["Year"] = new SelectList(_context.Years, "YearName", "YearName", salary.Year);
            return View(salary);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Year,Month,Employee,ParticipationPurchase,ParticipationSale,ParticipationProduction,CountParticipation,SalaryEmployee,TotalAmount,Issued,Bonus")] Salary salary)
        {
            if (id != salary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryExists(salary.Id))
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
            ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Id", salary.Employee);
            ViewData["Month"] = new SelectList(_context.Months, "Id", "Id", salary.Month);
            ViewData["Year"] = new SelectList(_context.Years, "YearName", "YearName", salary.Year);
            return View(salary);
        }

        // GET: Salaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await _context.Salary
                .Include(s => s.EmployeeNavigation)
                .Include(s => s.MonthNavigation)
                .Include(s => s.YearNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salary = await _context.Salary.FindAsync(id);
            _context.Salary.Remove(salary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryExists(int id)
        {
            return _context.Salary.Any(e => e.Id == id);
        }
    }
}
