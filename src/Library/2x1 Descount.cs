namespace Ucu.Poo.eCommerce
{
    public class TwoforOneDescount : Descounter
    {
        public override double Descount()
        {
            double result = 0.0;
            foreach (ShoppingCart.CartItem item in shoppingCart.Items)
            {
                if (item.Quantity % 2 == 0)
                {
                    result += item.GetItemTotal() / 2;
                }
                else
                {
                    result += ((item.GetItemTotal() - item.Product.Price) / 2) + item.Product.Price;
                }
            }

            return result;
        }

        public TwoforOneDescount(ShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }
    }
}