﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Product")]
    public class Product : CommonAbstract
    {
        public Product()
        {
            this.ProductImage = new HashSet<ProductImage>();
            this.OrderDetails = new HashSet<OrderDetail>();
            this.Reviews = new HashSet<ReviewProduct>();
            this.Wishlist = new HashSet<Wishlist>();
            //this.Colors = new HashSet<Color>();
            //this.Sizes = new HashSet<Size>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //tham số tự tăng 1,2,3...
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Alias { get; set; }

        [StringLength(100)]
        public string ProductCode { get; set; }
        public string Description { get; set; }

        [AllowHtml]
        public string Detail { get; set; }

        [StringLength(250)]
        public string Image { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceSale { get; set; }
        public int Quantity { get; set; }
        public bool IsHome { get; set; }
        public bool IsSale { get; set; }
        public bool IsFeature { get; set; }
        public bool IsNew { get; set; }
        public bool IsActive { get; set; }
        public int ProductCategoryId { get; set; }

        public List<string> Colors { get; set; }
        public string ColorsString { get; set; }
        public List<string> Sizes { get; set; }
        public string SizesString { get; set; }


        [StringLength(250)]
        public string SeoTitle { get; set; }

        [StringLength(500)]
        public string SeoDescription { get; set; }

        [StringLength(250)]
        public string SeoKeywords { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ReviewProduct> Reviews { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
        //public virtual ICollection<Color> Colors { get; set; }
        //public virtual ICollection<Size> Sizes { get; set; }
    }
}