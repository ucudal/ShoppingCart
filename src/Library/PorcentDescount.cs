using System;
using System.Dynamic;

namespace Ucu.Poo.eCommerce
{
    public class PorcentDescount: Descounter, INoAcumulable
    {
        public int descount { get; private set; }
        public int result { get; private set; }
        
        public override double Descount()
        {
            return result * (1-descount/100);
        }
        public PorcentDescount(ShoppingCart shoppingCart, int descount, int result)
        {
            this.shoppingCart = shoppingCart;
            this.descount = descount;
        }
    }
}