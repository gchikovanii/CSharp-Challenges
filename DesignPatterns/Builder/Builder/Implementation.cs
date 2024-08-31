using System.Text;

namespace Builder
{
    public class Implementation
    {

        public class Car
        {
            private readonly List<string> _parts = new();
            private readonly string _CarType;
            public Car(string carType)
            {
                _CarType = carType;
            }
            public void AddCar(string part)
            {
                _parts.Add(part);
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                foreach (var part in _parts)
                {
                    sb.Append($"Car of type {_CarType} has implemented a {part}.");
                }
                return sb.ToString();
            }
        }

        public abstract class CarBuilder
        {
            public Car Car { get; private set; }
            public CarBuilder(string carType)
            {
                Car = new Car(carType);
            }
            public abstract void BuildEngine();
            public abstract void BuildFrame();
        }

        public class Audi : CarBuilder
        {
            public Audi() : base("Audi")
            {
            }
            public override void BuildEngine()
            {
                Car.AddCar("Enginge v8");
            }

            public override void BuildFrame()
            {
                Car.AddCar("Red Carpet inside");
            }
        }
        public class Chevrolet : CarBuilder
        {
            public Chevrolet() : base("Chevy")
            {
            }
            public override void BuildEngine()
            {
                Car.AddCar("Enginge v15");
            }

            public override void BuildFrame()
            {
                Car.AddCar("White Ceramic Poly");
            }
        }


        public class Garage
        {
            private CarBuilder? _carBuilder;
            public Garage()
            {
            }
            public void Construct(CarBuilder carBuilder) 
            {
                _carBuilder = carBuilder;
                _carBuilder.BuildEngine();
                _carBuilder.BuildFrame();

            }
            public void ShowCar()
            {
                Console.WriteLine(_carBuilder?.Car.ToString());
            }
        }

    }
}
