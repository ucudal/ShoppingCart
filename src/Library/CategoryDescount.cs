namespace Ucu.Poo.eCommerce
{
    public class CategoryDescount: Descounter
    {
        public int descount { get; private set; }
        public string category { get; private set; }
        public override double Descount()
        {
            double result = 0.0;
            foreach (ShoppingCart.CartItem item in shoppingCart.Items)
            {
                if (item.GetCategory()==category)
                {
                    result += item.GetItemTotal()*(1-descount/100);
                }
                else
                {
                    result += item.GetItemTotal();
                }
            }

            return result;
        }

        public CategoryDescount(ShoppingCart shoppingCart, int descount, string category)
        {
            this.shoppingCart = shoppingCart;
            this.descount = descount;
            this.category = category;
        }
    }
}