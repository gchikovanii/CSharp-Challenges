namespace Adapter
{
    public class ObjectAdapterImplementation
    {
        public class CityFromExtenralSystem
        {
            public CityFromExtenralSystem(string name, string nickName, int inhabitants)
            {
                Name = name;
                NickName = nickName;
                Inhabitants = inhabitants;
            }
            public string Name { get; private set; }
            public string NickName { get; private set; }
            public int Inhabitants { get; private set; }
        }


        public class ExternalSystem
        {
            public CityFromExtenralSystem GetCity()
            {
                return new CityFromExtenralSystem("Tbilisi", "T'bilisi", 1423520);
            }
        }

        public class City
        {
            public City(string fullName, long inhabitants)
            {
                FullName = fullName;
                Inhabitants = inhabitants;
            }

            public string FullName { get; private set; }
            public long Inhabitants { get; private set; }
        }

        public interface ICityAdapter
        {
            City GetCity();
        }
        public class CityAdapter : ICityAdapter
        {
            public ExternalSystem ExternalSystem { get; private set; } = new();
            public City GetCity()
            {
                var cityFromExternalSys = ExternalSystem.GetCity();
                return new City($"{cityFromExternalSys.Name} - {cityFromExternalSys.NickName}", cityFromExternalSys.Inhabitants);
            }
        }
    }
}
