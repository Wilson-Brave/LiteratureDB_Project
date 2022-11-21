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
    public class BookController : ODataController
    {
        private Library_DbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookController(Library_DbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _db = context;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 4)]

        public IQueryable<Book> Get()
        {
            var result = _db.Book;
            return result;
        }

        [EnableQuery(MaxExpansionDepth = 4)]
        public SingleResult<Book> Get([FromODataUri] int key)
        {
            IQueryable<Book> result = _db.Book.Where(s => s.Book_index == key);
            return SingleResult.Create(result);
        }

        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] Book update)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Book_index)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Book_index)
            {
                return BadRequest();
            }

            Book b = _db.Book.FirstOrDefault(x => x.Book_index == update.Book_index);
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


        public async Task<IActionResult> Post([FromBody] Book insert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Book.Add(insert);
            await _db.SaveChangesAsync();

            return Created(insert);
        }


        [EnableQuery]
        public async Task<IActionResult> Delete([FromODataUri] int key)
        {

            IQueryable<Book> result = _db.Book.Where(p => p.Book_index == key);
            _db.Book.Remove(result.FirstOrDefault());
            await _db.SaveChangesAsync();
            return Updated(result);
        }
        bool Exists(int key)
        {
            return _db.Book.Find(key) != null;
        }
    }
}
