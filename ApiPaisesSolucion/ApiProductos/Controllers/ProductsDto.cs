using ApiProductos.Models;

namespace ApiProductos.Controllers
{
    // Dto = Data Transfer Object
    // Explicación de Dto en https://www.campusmvp.es/recursos/post/que-es-un-dto-y-para-que-se-utiliza.aspx
    // En este caso, se crea un Dto para Products
    // Se crea un Dto para Products porque se necesita devolver un objeto de Products con un formato diferente al original
    // En este caso, se necesita devolver un objeto de Products sin la propiedad Category
    public class ProductsDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        //public int? SupplierID { get; set; }
        //public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        //public Categories Category { get; set; }
    }
}