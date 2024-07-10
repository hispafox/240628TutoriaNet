using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiProductos.Contexto;
using ApiProductos.Models;

namespace ApiProductos.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public ProductsController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            // Resolver error A possible object cycle was detected. This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32. Consider using ReferenceHandler.Preserve on JsonSerializerOptions to support cycles.


            return await _context.Products.ToListAsync();
        }


        //// GET: api/Products
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        //{
        //    var options = new JsonSerializerOptions
        //    {
        //        ReferenceHandler = ReferenceHandler.Preserve
        //    };

        //    var products = await _context.Products.Include(products => products.Category).ToListAsync();

        //    return new ContentResult
        //    {
        //        Content = JsonSerializer.Serialize(products, options),
        //        ContentType = "application/json",
        //        StatusCode = 200
        //    };
        //}


        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsDto>> GetProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            // Crear el Dto de Products
            var productsDto = new ProductsDto
            {
                ProductID = products.ProductID,
                ProductName = products.ProductName,
                //SupplierID = products.SupplierID,
                //CategoryID = products.CategoryID,
                QuantityPerUnit = products.QuantityPerUnit,
                UnitPrice = products.UnitPrice,
                UnitsInStock = products.UnitsInStock,
                UnitsOnOrder = products.UnitsOnOrder,
                ReorderLevel = products.ReorderLevel,
                Discontinued = products.Discontinued
            };

            return productsDto;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products products)
        {
            if (id != products.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = products.ProductID }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Implementar patch
        /*        Para implementar correctamente el método PATCH en ProductsController.cs, 
         *        necesitamos cambiar la forma en que se actualizan las propiedades del producto. 
         *        En lugar de actualizar todo el objeto Products, debemos aplicar solo los cambios proporcionados en la solicitud PATCH. 
         *        Esto se puede hacer utilizando el método Patch de EF Core, 
         *        pero primero necesitamos instalar el paquete Microsoft.AspNetCore.JsonPatch 
         *        y luego aplicar los cambios parciales.Aquí está el código corregido:
                  Primero, asegúrate de tener instalado el paquete Microsoft.AspNetCore.JsonPatch en tu proyecto.
        Explicación:
•	JsonPatchDocument: Este es el tipo de parámetro que acepta las operaciones de parcheo 
        definidas en el estándar JSON Patch (RFC 6902). 
        Permite aplicar cambios parciales a un objeto Products.
•	[FromBody]: Este atributo indica que el parámetro patchDoc debe ser deserializado
        desde el cuerpo de la solicitud.
•	patchDoc.ApplyTo(productFromDb, ModelState): Aplica las operaciones de parcheo al objeto 
        productFromDb. Si hay problemas al aplicar el parche (por ejemplo, 
        referencias a propiedades no existentes), estos se agregan al ModelState.
•	ModelState.IsValid: Verifica si el modelo resultante después de aplicar el parche es válido 
        según las anotaciones de validación definidas en el modelo Products.
        Este enfoque permite actualizar parcialmente un recurso, 
        lo cual es el propósito de un método HTTP PATCH.

        [
  {
    "op": "replace",
    "path": "/ProductName",
    "value": "Nuevo Nombre del Producto"
  }
]

        Las seis operaciones definidas en el estándar JSON Patch (RFC 6902) que se pueden utilizar en un documento JSON Patch son:
1.	add: Añade un valor a un objeto o inserta un valor en un array. Si el objetivo es un array, este valor se inserta antes del índice especificado o al final si el índice es mayor que la longitud del array.
2.	remove: Elimina el valor en el objetivo especificado. En el caso de un array, esto puede alterar los índices de los elementos posteriores.
3.	replace: Reemplaza el valor en el objetivo especificado. Esencialmente, es una operación "remove" seguida de una "add".
4.	move: Mueve un valor de una parte del documento a otra. Funciona extrayendo el valor de una ubicación y añadiéndolo a otra.
5.	copy: Copia un valor de una parte del documento a otra. A diferencia de "move", la operación "copy" deja una copia del valor en la ubicación original.
6.	test: Prueba que un valor en una ubicación especificada es igual al valor proporcionado. Esta operación se utiliza para asegurar que el documento no ha cambiado antes de aplicar una actualización.
Cada operación en un documento JSON Patch debe especificar al menos los campos op (tipo de operación) y path (la ubicación dentro del documento al que se aplica la operación). Dependiendo de la operación, también pueden ser necesarios campos adicionales como value (el valor a añadir, reemplazar o con el que comparar), from (para las operaciones move y copy, indica la ubicación desde la que se mueve o copia el valor).


 */

        // PATCH: api/Products/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchProducts(int id, [FromBody] JsonPatchDocument<Products> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var productFromDb = await _context.Products.FindAsync(id);

            if (productFromDb == null)
            {
                return NotFound();
            }

            // Corrección aquí: Manejar el error de JsonPatch usando una acción
            patchDoc.ApplyTo(productFromDb, error =>
            {
                ModelState.AddModelError(error.Operation.path, error.ErrorMessage);
            });

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(productFromDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
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

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
