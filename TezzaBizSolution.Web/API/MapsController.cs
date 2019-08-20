using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TezzaBizSolution.Lib.DTOS;
using TezzaBizSolution.Web.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TezzaBizSolution.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MapsController(ApplicationDbContext context)
            => _context = context;

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Coordinate>>> GetLocationCoordinates(int id)
        {
            var collection = await _context.Collections.FirstOrDefaultAsync(f => f.Id == id);

            if (collection is null)
            {
                return NotFound(new { message = $"Collection with Id: {id} does not exist." });
            }

            var locations = await _context.Locations.Where(w => w.CollectionId == collection.Id).ToListAsync();

            if (locations is null || locations.Count() == 0)
            {
                return NotFound(new { message = $"No set locations found for collection id: {id}" });
            }

            var data = locations.Select(s => new Coordinate() { Latitude = s.Latitude, Longitude = s.Longitude, Description = s.Description, Name = s.Name }).ToList();

            return Ok(data);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Route>> GetRoute(int id)
        {
            var collection = await _context.Collections.FirstOrDefaultAsync(f => f.Id == id);

            if (collection is null)
            {
                return NotFound(new { message = $"Collection with Id: {id} does not exist." });
            }

            var locations = await _context.Locations.Where(w => w.CollectionId == collection.Id).ToListAsync();
            if (locations is null || locations.Count() == 0)
            {
                return NotFound(new { message = $"No set locations found for collection id: {id}" });
            }

            var sourceLocation = locations.FirstOrDefault();
            Coordinate source = new Coordinate
            {
                Latitude = sourceLocation?.Latitude,
                Longitude = sourceLocation?.Longitude,
                Description = sourceLocation?.Description,
                Name = sourceLocation?.Name
            };

            var destinationLocation = locations.LastOrDefault();
            Coordinate destination = new Coordinate
            {
                Latitude = destinationLocation?.Latitude,
                Longitude = destinationLocation?.Longitude,
                Description = destinationLocation?.Description,
                Name = destinationLocation?.Name
            };

            Route route = new Route
            {
                Destination = destination,
                Source = source
            };
            return Ok(route);
        }

      
    }
}
