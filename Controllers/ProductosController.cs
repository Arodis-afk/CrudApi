using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudApi.Models; 
using CrudApi.Data;    
using CrudApi.DTOs;    


namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase 
    {
       
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetProductos()
        {
            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }

        [HttpPost]
        public async Task<ActionResult> PostProducto(ProductoCreateDTO dto)
        {
            var producto = new Producto 
            { 
                Nombre = dto.Nombre, 
                Precio = dto.Precio, 
                Descripcion = dto.Descripcion, 
                Stock = dto.Stock 
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return Ok(producto);
        }
    }
}