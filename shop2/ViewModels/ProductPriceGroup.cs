using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace shop2.ViewModels
{
    public class ProductPriceGroup
    {
        [DataType(DataType.Currency)] // working on it yet. 
        public int ProductPrice { get; set; }
        public int ProductCount { get; set; }
        
    }
}