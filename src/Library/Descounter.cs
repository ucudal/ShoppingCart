namespace Ucu.Poo.eCommerce
{
    public abstract class Descounter
    {
        public ShoppingCart shoppingCart { get; protected set; }

        public abstract double Descount();
    }
}