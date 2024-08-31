using static AbstractFactory.Implementation;

var geoShoppingCartPurchaseFactory = new GerogiaShoppingCartPurchaseFactory();
var geoShoppingCart = new ShoppingCart(geoShoppingCartPurchaseFactory);
geoShoppingCart.CalculateTotalCost();

var germanyShoppingCartPurchaseFactory = new GermanyShoppingCartPurchaseFactory();
var germanyShoppingCart = new ShoppingCart(germanyShoppingCartPurchaseFactory);
germanyShoppingCart.CalculateTotalCost();