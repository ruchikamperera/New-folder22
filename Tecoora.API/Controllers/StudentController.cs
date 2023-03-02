using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tecoora.Iservices;
using AutoMapper;
using Tecoora.Models;
using Tecoora.API.Models;
using Microsoft.AspNetCore.Http;
using Tecoora.API.Responses;

namespace Tecoora.API.Controllers
{

    public class StudentController : Controller
    {
        IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [Produces("application/json")]
        [HttpGet, Route("students")]
        public async Task<ApiResponse> students()
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var result = await _studentService.getStudents();
                var mappedResult = _mapper.Map<List<StudentDto>>(result);
                apiResponse.Data = mappedResult;
                apiResponse.Success = true;
            }
            catch (Exception ex)
            {
                apiResponse.Error = ex.Message;
                apiResponse.Success = false;
            }

            return apiResponse;
        }

        //// GET: Tests/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var test = await _context.Test
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (test == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(test);
        //}

        //// GET: Tests/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Tests/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] Test test)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(test);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(test);
        //}

        //// GET: Tests/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var test = await _context.Test.FindAsync(id);
        //    if (test == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(test);
        //}

        //// POST: Tests/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Test test)
        //{
        //    if (id != test.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(test);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TestExists(test.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(test);
        //}

        //// GET: Tests/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var test = await _context.Test
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (test == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(test);
        //}

        //// POST: Tests/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var test = await _context.Test.FindAsync(id);
        //    _context.Test.Remove(test);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool TestExists(int id)
        //{
        //    return _context.Test.Any(e => e.Id == id);
        //}
    }
}
