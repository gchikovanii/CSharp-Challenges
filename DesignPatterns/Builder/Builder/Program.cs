using static Builder.Implementation;

Garage garage = new Garage();
var audi = new Audi();
var chevy = new Chevrolet();
garage.Construct(audi);
garage.ShowCar();
garage.Construct(chevy);
garage.ShowCar();