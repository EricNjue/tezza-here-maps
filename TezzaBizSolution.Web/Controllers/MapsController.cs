using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TezzaBizSolution.Lib;
using TezzaBizSolution.Web.Data;
using TezzaBizSolution.Web.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TezzaBizSolution.Web.Controllers
{
    public class MapsController : Controller
    {
        private HereAPI hereAPI;

        private readonly ApplicationDbContext _context;

        public MapsController(IOptions<HereAPI> hereAPIOptions, ApplicationDbContext context)
        {
            hereAPI = hereAPIOptions.Value;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["AppID"] = hereAPI.AppID;
            ViewData["AppCode"] = hereAPI.AppCode;
            ViewData["JavaScriptApiKey"] = hereAPI.JavaScriptApiKey;
            ViewData["ShowRoute"] = true;
            var collections = await _context.Collections.ToListAsync();

            LocationsAggregateViewModel viewModel = new LocationsAggregateViewModel
            {
                Collections = collections,

            };

            return View(viewModel);
        }

        public async Task<IActionResult> ViewCollectionPoints(int collectionId)
        {
            ViewData["Collection"] = await _context.Collections.FirstOrDefaultAsync(f => f.Id == collectionId);

            var coordinates = await _context.Locations.Where(w => w.CollectionId == collectionId).ToListAsync();

            return View(coordinates);
        }
    }
}
