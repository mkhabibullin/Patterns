using HightechStrategy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HightechStrategy
{
    public interface IHasState<TStateCode, TEntity>
        where TEntity : class
    {
        TStateCode StateCode { get; }
        State<TEntity> State { get; }
    }

    public partial class Cart : IHasState<Cart.CartStateCode, Cart>
    {
        public User User { get; protected set; }

        public CartStateCode StateCode { get; protected set; }

        public State<Cart> State { get; set; }

        public decimal Total { get; protected set; }

        protected virtual ICollection<Product> Products { get; set; }
            = new List<Product>();

        // ORM Only
        protected Cart()
        {
            this.State = StateCode.ToState<Cart>(this);
        }

        public Cart(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            StateCode = StateCode = CartStateCode.Empty;
        }

        public Cart(User user, IEnumerable<Product> products)
            : this(user)
        {
            StateCode = StateCode = CartStateCode.Empty;
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

        public Cart(User user, IEnumerable<Product> products, decimal total)
            : this(user, products)
        {
            if (total <= 0)
            {
                throw new ArgumentException(nameof(total));
            }

            Total = total;
        }

        public enum CartStateCode : byte
        {
            [State(typeof(EmptyCartState))] Empty,
            [State(typeof(ActiveCartState))] Active,
            [State(typeof(PaidCartState))] Paid
        }

        public interface IAddableCartState
        {
            ActiveCartState Add(Product product);
            IEnumerable<Product> Products { get; }
        }

        public interface INotEmptyCartState
        {
            IEnumerable<Product> Products { get; }
            decimal Total { get; }
        }

        public abstract class AddableCartState : State<Cart>, IAddableCartState
        {
            protected AddableCartState(Cart entity) : base(entity)
            {
            }

            public ActiveCartState Add(Product product)
            {
                Entity.Products.Add(product);
                Entity.StateCode = CartStateCode.Active;
                return (ActiveCartState)Entity.State;
            }

            public IEnumerable<Product> Products => Entity.Products;
        }

        public class EmptyCartState : AddableCartState
        {
            public EmptyCartState(Cart entity) : base(entity)
            {
            }

        }

        public class ActiveCartState : AddableCartState, INotEmptyCartState
        {
            public ActiveCartState(Cart entity) : base(entity)
            {
            }


            public PaidCartState Pay(decimal total)
            {
                Entity.Total = total;
                Entity.StateCode = CartStateCode.Paid;
                return (PaidCartState)Entity.State;
            }

            public State<Cart> Remove(Product product)
            {
                Entity.Products.Remove(product);
                if (!Entity.Products.Any())
                {
                    Entity.StateCode = CartStateCode.Empty;
                }

                return Entity.State;
            }

            public EmptyCartState Clear()
            {
                Entity.Products.Clear();
                Entity.StateCode = CartStateCode.Empty;
                return (EmptyCartState)Entity.State;
            }

            public decimal Total => Products.Sum(x => x.Price);
        }


        public class PaidCartState : State<Cart>, INotEmptyCartState
        {
            public IEnumerable<Product> Products => Entity.Products;

            public decimal Total => Entity.Total;

            public PaidCartState(Cart entity) : base(entity)
            {
            }
        }
    }
}
