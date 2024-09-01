using static Bridge.Implementation;

var one = new OneEuroCoupon();
var two = new TwoEuroCoupon();
var no = new NoCoupon();

var meatBasedMenu = new MeatMenu(two);
var vegans = new VeganMenu(no);
Console.WriteLine(meatBasedMenu.CalculatePrice());
Console.WriteLine(vegans.CalculatePrice());
