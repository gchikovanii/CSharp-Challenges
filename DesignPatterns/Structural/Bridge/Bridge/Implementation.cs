using static Bridge.Implementation;

namespace Bridge
{
    public class Implementation
    {
        public abstract class Menu
        {
            public readonly ICoupon _coupon/* = null!*/;
            protected Menu(ICoupon coupon)
            {
                _coupon = coupon;
            }

            public abstract int CalculatePrice();
        }
        public class VeganMenu : Menu
        {
            public VeganMenu(ICoupon coupon) : base(coupon) { }
            public override int CalculatePrice()
            {
                return 20 - _coupon.CouponValue;
            }
        }
        public class MeatMenu : Menu
        {
            public MeatMenu(ICoupon coupon) : base(coupon) { }
            public override int CalculatePrice()
            {
                return 40 - _coupon.CouponValue;
            }
        }
        public interface ICoupon
        {
            int CouponValue { get; }
        }
        public class OneEuroCoupon : ICoupon
        {
            public int CouponValue => 1;
        }
        public class TwoEuroCoupon : ICoupon
        {
            public int CouponValue => 20;
        }
        public class NoCoupon : ICoupon
        {
            public int CouponValue => 0;
        }
    }
}
