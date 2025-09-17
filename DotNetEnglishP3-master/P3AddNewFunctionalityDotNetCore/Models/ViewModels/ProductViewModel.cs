using System;
using System.Resources;
using System.Reflection;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using P3AddNewFunctionalityDotNetCore.Resources.Models.Services;


namespace P3AddNewFunctionalityDotNetCore.Models.ViewModels
{
    public class ProductViewModel
    {
        private static ResourceManager resourceManager = new ResourceManager("P3AddNewFunctionalityDotNetCore.Resources.Models.Services.ProductServicesRessources", Assembly.GetExecutingAssembly());
        private static CultureInfo resourceCulture;

        [BindNever]
        public int Id { get; set; }
        [Required(
            ErrorMessageResourceType = typeof(ProductService),
            ErrorMessageResourceName = nameof(ProductService.MissingName))]
        public string Name { get; set; }
   
        public string Description { get; set; }

        public string Details { get; set; }
        [Required(
          ErrorMessageResourceType = typeof(ProductService),
          ErrorMessageResourceName = nameof(ProductService.MissingStock))]
        [Range(
            1, int.MaxValue,
            ErrorMessageResourceType = typeof(ProductService),
            ErrorMessageResourceName = nameof(ProductService.StockNotGreaterThanZero))]
        [RegularExpression(
            @"^-?\d+$",// expession pour tester un entier
            ErrorMessageResourceType = typeof(ProductService),
            ErrorMessageResourceName = nameof(ProductService.StockNotAnInteger))]
        public string Stock { get; set; }
        [Required(
          ErrorMessageResourceType = typeof(ProductService),
          ErrorMessageResourceName = nameof(ProductService.MissingPrice))]
        [Range(
            1, int.MaxValue,
            ErrorMessageResourceType = typeof(ProductService),
            ErrorMessageResourceName = nameof(ProductService.PriceNotGreaterThanZero))]
        [RegularExpression(
           @"^-?\d+([.,]\d+)?$",// expression pour tester un nombre
            ErrorMessageResourceType = typeof(ProductService),
            ErrorMessageResourceName = nameof(ProductService.PriceNotANumber))]
        public string Price { get; set; }
    }
}
