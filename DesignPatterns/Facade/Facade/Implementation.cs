namespace Facade
{
    public class OrderService
    {
        public bool HasEnoughOrders(int customerId)
        {
            //Real calculation goes here
            return customerId > 10;
        }
        

    }
    public class CustomerDiscoutBaseService
    {
        public double CalculateDiscountBase(int customerId)
        {
            //Real calculation here
            return (customerId > 5) ? 20 : 10;
        }
    }
   
    public class DayOfWeekFactorService
    {
        public double CalculateByDayOfTheWeekFactor()
        {
            switch (DateTime.UtcNow.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return 0.2;
                case DayOfWeek.Sunday:
                    return 0.5;
                default:
                    return 1.2;
            }
        }
    }

    public class DiscountFacade
    {
        private readonly OrderService _orderService = new();
        private readonly CustomerDiscoutBaseService _customerBaseService = new();
        private readonly DayOfWeekFactorService _dayOfWeekService = new();

        public double GetDiscount(int customerId)
        {
            if (!_orderService.HasEnoughOrders(customerId))
                return 0;
            return _customerBaseService.CalculateDiscountBase(customerId) * _dayOfWeekService.CalculateByDayOfTheWeekFactor();
        }   

    }

}
