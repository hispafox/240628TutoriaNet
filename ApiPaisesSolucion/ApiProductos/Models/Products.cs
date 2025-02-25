﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ApiProductos.Models;

[Index("CategoryID", Name = "CategoriesProducts")]
[Index("CategoryID", Name = "CategoryID")]
[Index("ProductName", Name = "ProductName")]
[Index("SupplierID", Name = "SupplierID")]
[Index("SupplierID", Name = "SuppliersProducts")]
public partial class Products
{
    [Key]
    public int ProductID { get; set; }

    [Required]
    [StringLength(40)]
    //[JsonPropertyName("ProductName")]
    public string ProductName { get; set; }

    public int? SupplierID { get; set; }

    public int? CategoryID { get; set; }

    [StringLength(20)]
    public string QuantityPerUnit { get; set; }

    [Column(TypeName = "money")]
    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    [ForeignKey("CategoryID")]
    [InverseProperty("Products")]
    public virtual Categories Category { get; set; }
}