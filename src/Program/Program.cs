//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using Ucu.Poo.eCommerce;

namespace ConsoleApplication
{
    public static class Program
    {
        public static void Main()
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            Product product = new Product("nose", 10, "nada");
            shoppingCart.AddToCart(product);
            shoppingCart.AddToCart(product);
            shoppingCart.AddToCart(product);
            shoppingCart.AddToCart(product);
            Descounter descounter = new CategoryDescount(shoppingCart, 10, "nada");
            Descounter descounterr = new TwoforOneDescount(shoppingCart);
            shoppingCart.AplicateDescount(descounter);
            shoppingCart.AplicateDescount(descounterr);
            Console.WriteLine(shoppingCart.GetTotal());
        }
    }
}