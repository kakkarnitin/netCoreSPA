using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Api.Controllers
{
    [ApiController]
    [Route(BaseRoute)]
    public class ValuesController : ControllerBase
    {
        private const string BaseRoute = "Api/[Controller]";
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> GetValue(int id)
        {
            var value = await _context.Values.FindAsync(id);
            return Ok(value);
        }
    }
}