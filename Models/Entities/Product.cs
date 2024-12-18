﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _50_Ders_MVC_Projesi.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }
    
        public int URUNID { get; set; }
        [Required(ErrorMessage ="Ürün Adı boş geçirilemez")]
        public string URUNAD { get; set; }
        [Required(ErrorMessage = "Ürün Markası boş geçirilemez")]
        public string MARKA { get; set; }
        [Required(ErrorMessage = "Lütfen, Ürün Kategori Seçiniz")]
        public Nullable<short> URUNKATEGORI { get; set; }
        [Required(ErrorMessage = "Lütfen, Fıyatı Belirleyiniz")]
        public Nullable<decimal> FIYAT { get; set; }
        public Nullable<byte> STOK { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
