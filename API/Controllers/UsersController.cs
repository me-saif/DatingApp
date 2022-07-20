using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class UsersController: BaseApiController
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context=context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> Get(){
            var users = await _context.Users.ToListAsync();
            if(users==null) return BadRequest("No Records are there");
            return users;
        }  

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> Get(int id){
            return await _context.Users.FindAsync(id);
        }  
    }
}