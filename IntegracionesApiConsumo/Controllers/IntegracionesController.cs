using IntegracionesApiConsumo.Models;
using IntegracionesApiConsumo.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntegracionesApiConsumo.Controllers
{
    public class IntegracionesController : Controller
    {
       private readonly IntegracionService _integracionService;

        public IntegracionesController(IntegracionService integracionService)
        { 
           _integracionService = integracionService;
        }

        public async Task<ActionResult> Index()
        { 
        
            var integraciones = await _integracionService.GetAllIntegraciones();
            return View(integraciones);
        }

        public async Task<IActionResult> Details(int id)
        {
            var integracion = await _integracionService.GetIntegracion(id);
            if (integracion == null) 
            {
            
              return NotFound();
            }
            return View(integracion);
        }//

        public IActionResult Create() 
        {
            return View();
        
        }

        [HttpPost]
        public async Task<IActionResult> Create(Integracion integracion)
        {
            if (ModelState.IsValid)
            {
                await _integracionService.CreateIntegracion(integracion);
                return RedirectToAction(nameof(Index));
            
            }
            return View(integracion);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var integracion = await _integracionService.GetIntegracion(id);
            if (integracion == null)
            {
                return NotFound();
            }
            return View(integracion);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Integracion integracion)
        {
            if (ModelState.IsValid)
            {
                await _integracionService.UpdateIntegracion(integracion);
                return RedirectToAction(nameof(Index));
            }
            return View(integracion);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var integracion = await _integracionService.GetIntegracion(id);
            if (integracion == null)
            {
                return NotFound();
            }
            return View(integracion);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _integracionService.DeleteIntegracion(id);
            return RedirectToAction(nameof(Index));
        }

    }//end controller
}
