using ESourcing.Products.Data.Interfaces;
using ESourcing.Products.Entities;
using ESourcing.Products.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Products.Data
{
    public class ProductContext : IProductContext
    {
        public ProductContext(IProductDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Products = database.GetCollection<Product>(settings.CollectionName);
            ProductContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
