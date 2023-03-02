using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tecoora.DataContext;
using Tecoora.Models;
using Tecoora.API.Models;
using Tecoora.API.Responses;
using Tecoora.Iservices;
using AutoMapper;
using Tecoora.IRepository;

namespace Tecoora.API.Controllers
{
    public class EmailsController 
    {
       // private readonly TecooraContext _context;
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;

        public EmailsController(IMapper mapper, IEmailRepository emailRepository)
        {
           // _context = context;
            _emailRepository = emailRepository;
            _mapper = mapper;
        }

        // GET: Emails
        [Produces("application/json")]
        [HttpGet, Route("GetEmailList")]
        public async Task<List<Tecoora.Models.Email>> GetEmailList()
        {
            return await  _emailRepository.getEmailList();
        }

        // GET: Emails/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var email = await _context.Emails
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (email == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(email);
        //}

       

        // POST: Emails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Produces("application/json")]
        [HttpPost, Route("SendEmail")]
        public async Task<Tecoora.Models.Email> SendEmail([FromBody] Tecoora.API.Models.EmailDto emailDto)
        {
                       
                Email email= new Email();
                var mappedEmail = _mapper.Map<Email>(emailDto);
                return await _emailRepository.sendEmail(mappedEmail);            
        }

    
    }
}
