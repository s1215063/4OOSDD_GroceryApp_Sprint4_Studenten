using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class BoughtProductsService : IBoughtProductsService
    {
        private readonly IGroceryListItemsRepository _groceryListItemsRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;
        private readonly IGroceryListRepository _groceryListRepository;
        public BoughtProductsService(IGroceryListItemsRepository groceryListItemsRepository, IGroceryListRepository groceryListRepository, IClientRepository clientRepository, IProductRepository productRepository)
        {
            _groceryListItemsRepository=groceryListItemsRepository;
            _groceryListRepository=groceryListRepository;
            _clientRepository=clientRepository;
            _productRepository=productRepository;
        }
        public List<BoughtProducts> Get(int? productId)
        {
            var boughtProductsList = new List<BoughtProducts>();
            
            // Return empty list if productId is null
            if (productId == null)
                return boughtProductsList;
            
            // Get the product
            var product = _productRepository.Get(productId.Value);
            if (product == null)
                return boughtProductsList;
            
            // Get all grocery list items that contain this product
            var groceryListItems = _groceryListItemsRepository.GetAll()
                .Where(item => item.ProductId == productId.Value)
                .ToList();
            
            foreach (var groceryListItem in groceryListItems)
            {
                // Get the grocery list for this item
                var groceryList = _groceryListRepository.Get(groceryListItem.GroceryListId);
                if (groceryList == null) continue;
                
                // Get the client who owns this grocery list
                var client = _clientRepository.Get(groceryList.ClientId);
                if (client == null) continue;
                
                // Create BoughtProducts object
                var boughtProduct = new BoughtProducts(client, groceryList, product);
                boughtProductsList.Add(boughtProduct);
            }
            
            return boughtProductsList;
        }
    }
}
