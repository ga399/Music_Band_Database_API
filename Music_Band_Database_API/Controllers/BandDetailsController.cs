using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music_Band_Database_API.Data;
using Music_Band_Database_API.Models;

namespace Music_Band_Database_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandDetailsController : ControllerBase
    {
        private readonly Music_Band_Database_APIContext _context;

        public BandDetailsController(Music_Band_Database_APIContext context)
        {
            _context = context;
        }

        // GET: api/BandDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BandDetails>>> GetBandDetails()
        {
            return await _context.BandDetails.ToListAsync();
        }

        // GET: api/BandDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BandDetails>> GetBandDetails(int id)
        {
            var bandDetails = await _context.BandDetails.FindAsync(id);

            if (bandDetails == null)
            {
                return NotFound();
            }

            return bandDetails;
        }

        // PUT: api/BandDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBandDetails(int id, BandDetails bandDetails)
        {
            if (id != bandDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(bandDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BandDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BandDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BandDetails>> PostBandDetails(BandDetails bandDetails)
        {
            _context.BandDetails.Add(bandDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBandDetails", new { id = bandDetails.Id }, bandDetails);
        }

        // DELETE: api/BandDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BandDetails>> DeleteBandDetails(int id)
        {
            var bandDetails = await _context.BandDetails.FindAsync(id);
            if (bandDetails == null)
            {
                return NotFound();
            }

            _context.BandDetails.Remove(bandDetails);
            await _context.SaveChangesAsync();

            return bandDetails;
        }

        private bool BandDetailsExists(int id)
        {
            return _context.BandDetails.Any(e => e.Id == id);
        }
    }
}
