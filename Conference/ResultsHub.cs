using Conference.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;

namespace Conference
{
	public class ResultsHub : Hub
	{
        static string _sessionID = "1";
        static bool _stopSearch = false;
        // This method will now be available to my clients via javascript
        public void PerformSearch()
		{
            List<Product> allProducts = CreateAllProducts();
            StartSearch(allProducts, 3, 500, 1500);
        }

        public void StopSearch()
        {
            _stopSearch = true;
            //Clients.Group(_sessionID).stop();
        }

        private void StartSearch(List<Product> allProducts, int minStock, int minPrice, int maxPrice)
	    {
	        var searchResult = new SearchResults();
            searchResult.Results = new List<Product>();
            searchResult.Total = allProducts.Count;
            _stopSearch = false;

            foreach (var product in allProducts)
	        {
                Thread.Sleep(50);
	            if (product.Stock >= minStock && product.Price >= minPrice && product.Price <= maxPrice)
	            {
	                searchResult.Results.Add(product);
	            }
	            searchResult.Processed++;

	            if (searchResult.Processed%100 == 0)
	            {
                    //A way to access the Hub from another class and call update method
                    //IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ResultsHub>();
                    //   context.Clients.All.update(searchResult);

                    // Send signal to people looking at the session page
                    // The method that will be called on the client is named "update"

                    Clients.Group(_sessionID).update(searchResult);
                    searchResult.Results.Clear();
                }
	            if (_stopSearch)
	            {
	                _stopSearch = false;
	                break;
	            }
            }
        }

	    private List<Product> CreateAllProducts()
	    {
            var result = new List<Product>();

            var random = new Random(int.MaxValue);
            for (int i = 0; i < 3000; i++)
	        {
	         var newProduct = new Product();
	            newProduct.Name = "Product_" + i;
                newProduct.Price = random.Next(50,5000);
	            newProduct.Stock = random.Next(0, 10);
                result.Add(newProduct);
            }
            return result;
	    }

	    public void Register()
		{
            Groups.Add(Context.ConnectionId, _sessionID);
		}
	}
}