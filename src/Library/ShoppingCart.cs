using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Ucu.Poo.eCommerce
{
    public class ShoppingCart
    {
        public class CartItem
        {
            public Product Product { get; }
            public int Quantity { get; internal set; }

            public CartItem(Product product)
            {
                this.Product = product;
                this.Quantity = 1;
            }

            public double GetItemTotal()
            {
                return this.Product.Price * this.Quantity;
            }

            public string GetCategory()
            {
                return this.Product.Category;
            }
        }

        private List<Descounter> descounts = new List<Descounter>();
        private List<CartItem> items = new List<CartItem>();

        public IReadOnlyList<CartItem> Items
        {
            get { return this.items.AsReadOnly(); }
        }

        private CartItem GetItemWithProduct(Product product)
        {
            foreach (CartItem item in this.items)
            {
                if (item.Product == product)
                {
                    return item;
                }
            }

            return null;
        }

        public void AddToCart(Product product)
        {
            CartItem item = this.GetItemWithProduct(product);
            if (item != null)
            {
                item.Quantity += 1;
            }
            else
            {
                this.items.Add(new CartItem(product));
            }
        }

        public void RemoveFromCart(Product product)
        {
            CartItem item = this.GetItemWithProduct(product);
            if (item != null)
            {
                if (item.Quantity == 1)
                {
                    this.items.Remove(item);
                }
                else
                {
                    item.Quantity -= 1;
                }
            }
        }

        public double GetTotal()
        {
            double result = 0.0;
            if (this.descounts.Count == 0)
            {
                foreach (CartItem item in this.items)
                {
                    result += item.GetItemTotal();
                }

                return result;
            }
            else
            {
                foreach (Descounter descounter in this.descounts)
                {
                    result = descounter.Descount();
                }
            }
            return result;
        }

    public void AplicateDescount(Descounter descount)
        {
            bool noacumulabe = false;
            foreach (Descounter descounte in descounts)
            {
                if (descounts is INoAcumulable)
                {
                    noacumulabe = true;
                }
            }
            if (noacumulabe)
            {
                Console.WriteLine("no se pude acumular");
            }
            else if (!(noacumulabe) && descount is INoAcumulable && this.descounts.Count!=0)
            {
                Console.WriteLine("no se pude acumular");
            }
            else if (!noacumulabe)
            {
                descounts.Add(descount);
            }
            
        }
    }
}
