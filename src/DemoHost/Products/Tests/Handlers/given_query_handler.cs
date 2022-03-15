using Core;
using Core.EventSourcing;
using DemoHost.Products.Events;
using DemoHost.Products.ReadModel;
using DemoHost.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoHost.Products.Tests.Handlers
{
    public class given_query_handler
    {
        protected readonly ProductsQryHandler sut;
        protected readonly ProductsReadModelProjection projection;

        public given_query_handler()
        {
            RelationalDb db = new RelationalDb();
            this.projection = new ProductsReadModelProjection(db);
            this.sut = new ProductsQryHandler(db);
        }
    }

    public class given_products : given_query_handler
    {
        public given_products()
        {
            this.projection.Handle(new ProductCreated("1", "Chocolate"));
            this.projection.Handle(new ProductCreated("2", "Sandia"));
            // Producto con mas cantidad
            this.projection.Handle(new ProductCreated("3", "Torta"));
            this.projection.Handle(new ProductIncreased("3","Torta"));
            this.projection.Handle(new ProductIncreased("3", "Torta"));
        }

        [Fact]
        public void when_the_db_is_consulted_then_the_list_of_products_comes()
        {
            var products = this.sut.GetAllProducts();

            Assert.Equal(3, products.Count);
        }

        [Fact]
        public void when_product_is_consulted_it_returns_its_quantity()
        {
            var quantity = this.sut.GetQuantity("3");

            Assert.Equal(3, quantity);
        }
    }
}
