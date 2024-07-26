using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebStore.Data;
using WebStore.Models;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository companyRepository;

        public CompanyController(ICompanyRepository company)
        {
            companyRepository = company;
        }

        // GET: Admin/Company
        public IActionResult Index()
        {
            return View(companyRepository.GetAll());
        }

        // GET: Admin/Company/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = companyRepository.GetById(x=>x.Id==id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Admin/Company/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Company/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {
            if (ModelState.IsValid)
            {
                companyRepository.Add(company);
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Admin/Company/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = companyRepository.GetById(x=>x.Id==id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Admin/Company/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    companyRepository.Update(company, id);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
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
            return View(company);
        }

        // GET: Admin/Company/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = companyRepository.GetById(x=>x.Id==id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Admin/Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var company = companyRepository.GetById(x=>x.Id == id);
            if (company == null)
                return NotFound();
            companyRepository.Remove(company);
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return companyRepository.GetAll().Any(e => e.Id == id);
        }
    }
}
