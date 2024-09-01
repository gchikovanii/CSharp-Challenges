//using static Adapter.ObjectAdapterImplementation;

using static Adapter.ClassAdapterImplementation;

ICityAdapter adapter = new CityAdapter();
var city = adapter.GetCity();
Console.WriteLine(city.FullName + " " + city.Inhabitants);