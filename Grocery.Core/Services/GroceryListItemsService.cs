using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class GroceryListItemsService : IGroceryListItemsService
    {
        private readonly IGroceryListItemsRepository _groceriesRepository;
        private readonly IProductRepository _productRepository;

        public GroceryListItemsService(IGroceryListItemsRepository groceriesRepository, IProductRepository productRepository)
        {
            _groceriesRepository = groceriesRepository;
            _productRepository = productRepository;
        }

        public List<GroceryListItem> GetAll()
        {
            List<GroceryListItem> groceryListItems = _groceriesRepository.GetAll();
            FillService(groceryListItems);
            return groceryListItems;
        }

        public List<GroceryListItem> GetAllOnGroceryListId(int groceryListId)
        {
            List<GroceryListItem> groceryListItems = _groceriesRepository.GetAll().Where(g => g.GroceryListId == groceryListId).ToList();
            FillService(groceryListItems);
            return groceryListItems;
        }

        public GroceryListItem Add(GroceryListItem item)
        {
            return _groceriesRepository.Add(item);
        }

        public GroceryListItem? Delete(GroceryListItem item)
        {
            throw new NotImplementedException();
        }

        public GroceryListItem? Get(int id)
        {
            return _groceriesRepository.Get(id);
        }

        public GroceryListItem? Update(GroceryListItem item)
        {
            return _groceriesRepository.Update(item);
        }

        public List<BestSellingProducts> GetBestSellingProducts(int topX = 5)
        {
            var bestSellingProducts = new List<BestSellingProducts>();
            var existingproducts = _groceriesRepository.GetAll();
            
            foreach (GroceryListItem g in existingproducts)
            {
                var productamount = g.Amount;
                var product = _productRepository.Get(g.ProductId);
                
                if (product != null)
                {
                    var bestSellingProduct = new BestSellingProducts(
                        productId: product.Id,
                        name: product.Name,
                        stock: product.Stock,
                        nrOfSells: productamount,
                        ranking: 0
                    );
                    bestSellingProducts.Add(bestSellingProduct);
                }
            }
            
            bestSellingProducts = bestSellingProducts.OrderByDescending(p => p.NrOfSells).Take(topX).ToList();
            
            for (int i = 0; i < bestSellingProducts.Count; i++)
            {
                bestSellingProducts[i].Ranking = i + 1;
            }
            
            return bestSellingProducts;
        }

        private void FillService(List<GroceryListItem> groceryListItems)
        {
            foreach (GroceryListItem g in groceryListItems)
            {
                g.Product = _productRepository.Get(g.ProductId) ?? new(0, "", 0);
            }
        }
    }
}
