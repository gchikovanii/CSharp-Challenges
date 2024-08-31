

namespace AbstractFactory
{
    public class Implementation
    {
        public interface IShoppingCartPurchaseFactory
        {
            IDiscountService CreateDiscountService();
            IShippingCostsService CreateShppingCostsService();
        }

        public interface IDiscountService
        {
            int DiscountPercentage { get; }
        }
        public interface IShippingCostsService
        {
            decimal ShippingCosts { get; }
        }

        public class GerogiaDiscountService : IDiscountService
        {
            public int DiscountPercentage => 20;
        }
        public class GerogiaShippinCostsService : IShippingCostsService
        {
            public decimal ShippingCosts => 25;
        }

        public class GermanyDiscountService : IDiscountService
        {
            public int DiscountPercentage => 10;
        }
        public class GermanyShippingCostsService : IShippingCostsService
        {
            public decimal ShippingCosts => 15;
        }

        public class GerogiaShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
        {
            public IDiscountService CreateDiscountService()
            {
                return new GerogiaDiscountService();
            }

            public IShippingCostsService CreateShppingCostsService()
            {
                return new GerogiaShippinCostsService();
            }
        }

        public class GermanyShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
        {
            public IDiscountService CreateDiscountService()
            {
                return new GermanyDiscountService();
            }

            public IShippingCostsService CreateShppingCostsService()
            {
                return new GermanyShippingCostsService();
            }
        }
        public class ShoppingCart
        {
            private readonly IDiscountService _discountService;
            private readonly IShippingCostsService _shippingCostsService;
            private int _cost;
            public ShoppingCart(IShoppingCartPurchaseFactory factory)
            {
                _discountService = factory.CreateDiscountService();
                _shippingCostsService = factory.CreateShppingCostsService();
                _cost = 300;
            }

            public void CalculateTotalCost()
            {
                Console.WriteLine($"Total cost is: {_cost - (_cost / 100 * _discountService.DiscountPercentage) + _shippingCostsService.ShippingCosts}");
            }

        }

    }
}
