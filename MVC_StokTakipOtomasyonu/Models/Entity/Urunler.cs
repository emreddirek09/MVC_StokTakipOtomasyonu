//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_StokTakipOtomasyonu.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class Urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urunler()
        {
            this.Satislar = new HashSet<Satislar>();
            this.Sepet = new HashSet<Sepet>();
            this.MarkaListesi = new List<SelectListItem>();
            MarkaListesi.Insert(0, new SelectListItem { Text = "�nce Kategori Se�ilmelidir", Value = "" });
        }
    
        public int ID { get; set; }
        [Required(ErrorMessage ="Kategori Alan� Bo� Ge�ilemez..")]
        public int KategoriID { get; set; }

        [Required(ErrorMessage = "Marka Alan� Bo� Ge�ilemez..")]
        public int MarkaID { get; set; }

        [Required(ErrorMessage = "Urun Adi Alan� Bo� Ge�ilemez..")]
        [Display(Name = "�r�n Ad�")]
        public string UrunAdi { get; set; }

        [Required(ErrorMessage = "Barkod No Alan� Bo� Ge�ilemez..")]
        [Display(Name = "Barkod No")]
        public string BarkodNo { get; set; }

        [Required(ErrorMessage = "Alis Fiyati Alan� Bo� Ge�ilemez..")]
        [Display(Name = "Al�� Fiyat�")]
        public decimal? AlisFiyati { get; set; }

        [Required(ErrorMessage = "Satis Fiyati Alan� Bo� Ge�ilemez..")]
        [Display(Name = "Sat�� Fiyat�")]
        public decimal? SatisFiyati { get; set; }

        [Required(ErrorMessage = "K.D.V Alan� Bo� Ge�ilemez..")]
        [Range(0,100, ErrorMessage ="0-100 aras� rakam girilmelidir.")]
        [Display(Name = "K.D.V.")]
        public int? KDV { get; set; }

        [Required(ErrorMessage = "Birim Alan� Bo� Ge�ilemez..")]
        public int BirimID { get; set; }

        [Required(ErrorMessage = "Tarih Alan� Bo� Ge�ilemez..")]
        public System.DateTime Tarih { get; set; }

        [Required(ErrorMessage = "A��klama Alan� Bo� Ge�ilemez..")]
        [Display(Name ="A��klama")]
        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Miktar Alan� Bo� Ge�ilemez..")]
        [Display(Name = "Miktar�")]
        public decimal? Miktari { get; set; }
    
        public virtual Birimler Birimler { get; set; }
        public virtual Kategoriler Kategoriler { get; set; }
        public virtual Markalar Markalar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satislar> Satislar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sepet> Sepet { get; set; }

        public List<SelectListItem> KategoriListesi { get; set; }
        public List<SelectListItem> MarkaListesi { get; set; }
        public List<SelectListItem> BirimListesi { get; set; }
    }
}
