using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seuphone.Api.Data;
using Seuphone.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Seuphone.Api.Controllers
{
    [Route("api/roles/admin")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly SeuphoneApiContext _context;

        public RolesController(SeuphoneApiContext context)
        {
            _context = context;
        }

        // GET: api/roles/admin
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await _context.Role.ToListAsync();
        }

       
    }
}
