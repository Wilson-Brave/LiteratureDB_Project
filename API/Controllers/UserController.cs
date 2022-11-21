using System;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Arts_Council_Db.Controllers
{
    public class UserController : ODataController
    {
        private Library_DbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(Library_DbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _db = context;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 4)]

        public IQueryable<User> Get()
        {
            var result = _db.User;
            return result;
        }

        [EnableQuery(MaxExpansionDepth = 4)]
        public SingleResult<User> Get([FromODataUri] int key)
        {
            IQueryable<User> result = _db.User.Where(s => s.User_index == key);
            return SingleResult.Create(result);
        }

        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] User update)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.User_index)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.User_index)
            {
                return BadRequest();
            }

            User b = _db.User.FirstOrDefault(x => x.User_index == update.User_index);
            try
            {
                b = update;

                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(key))

                { return NotFound(); }

                else

                { throw; }
            }

            catch (Exception)

            { throw; }

            return Updated(update);
        }


        public async Task<IActionResult> Post([FromBody] User insert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.User.Add(insert);
            await _db.SaveChangesAsync();

            return Created(insert);
        }


        [EnableQuery]
        public async Task<IActionResult> Delete([FromODataUri] int key)
        {

            IQueryable<User> result = _db.User.Where(p => p.User_index == key);
            _db.User.Remove(result.FirstOrDefault());
            await _db.SaveChangesAsync();
            return Updated(result);
        }
        bool Exists(int key)
        {
            return _db.User.Find(key) != null;
        }
    }
}
