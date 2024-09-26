using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.Design;
using BuildYourBowl.Data;
using BuildYourBowl.Data.Enums;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// The SearchTerms for the form
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string? SearchTerms { get; set; }
         
        /// <summary>
        /// The minimum price
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public decimal? PriceMin { get; set; }

        /// <summary>
        /// The maximum price
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public decimal? PriceMax { get; set; }

        /// <summary>
        /// The minimum calories
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMin { get; set; }

        /// <summary>
        /// The maximum calories
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMax { get; set; }

        /// <summary>
        /// Called when a form is submitted
        /// </summary>
        public void OnGet()
        {
            FullMenu = Menu.Search(FullMenu, SearchTerms);
            FullMenu = Menu.FilterByPrice(FullMenu, PriceMax, PriceMin);
            FullMenu = Menu.FilterByCalories(FullMenu, CaloriesMax, CaloriesMin);
        }

        /// <summary>
        /// The entrees on the menu
        /// </summary>
        public IEnumerable<IMenuItem> Entrees => Menu.Entrees;

        /// <summary>
        /// The sides on the menu
        /// </summary>
        public IEnumerable<IMenuItem> Sides => Menu.Sides;

        /// <summary>
        /// The drinks on the menu
        /// </summary>
        public IEnumerable<IMenuItem> Drinks => Menu.Drinks;

        /// <summary>
        /// The kids meals on the menu
        /// </summary>
        public IEnumerable<IMenuItem> KidsMeals => Menu.KidsMeals;

        /// <summary>
        /// All the items on the menu
        /// </summary>
        public IEnumerable<IMenuItem> FullMenu { get; set; } = Menu.FullMenu;

        /// <summary>
        /// The ingredient options
        /// </summary>
        public IEnumerable<IngredientItem> Ingredients => Menu.Ingredients;

        /// <summary>
        /// The salsa options
        /// </summary>
        public IEnumerable<Salsa> Salsas => Menu.Salsas;
    }
}
