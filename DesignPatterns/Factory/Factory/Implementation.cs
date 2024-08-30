namespace Factory
{
    public abstract class DiscountService
    {
        public abstract int DiscountPercentage { get; }
        public override string ToString()
        {
            return GetType().Name;
        }
    }

    public class CountryDiscountService : DiscountService
    {
        private readonly string _countryCode;
        public CountryDiscountService(string code)
        {
            _countryCode = code;
        }
        public override int DiscountPercentage
        {
            get
            {
                switch (_countryCode)
                {
                    case "GE":
                        return 50;
                    default:
                        return 10;
                }
            }
        }

    }

    public class CodeDiscountService : DiscountService
    {
        private readonly Guid _code;
        public CodeDiscountService(Guid code)
        {
            _code = code;
        }
        public override int DiscountPercentage
        {
            get
            {
                //logic here
                return 15;
            }
        }

    }

    public abstract class DiscountFactory
    {
        public abstract DiscountService CreateDiscountService();
    }


    public class CountryDiscountFactory : DiscountFactory
    {
        private readonly string _countryCode;

        public CountryDiscountFactory(string countryCode)
        {
            _countryCode = countryCode;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CountryDiscountService(_countryCode);
        }
    }
    public class CodeDiscountFactory : DiscountFactory
    {
        private readonly Guid _code;

        public CodeDiscountFactory(Guid code)
        {
            _code = code;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CodeDiscountService(_code);
        }
    }


}