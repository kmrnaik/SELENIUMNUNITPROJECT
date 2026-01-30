using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;
using SeleniumNUnitProject.Utilities;

namespace SeleniumNUnitProject.Models
{
    public class fakestoreapiModel
    {
        public class Product
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public string Image { get; set; }
            public Rating Rating { get; set; }
        }

        public class Rating
        {
            public decimal Rate { get; set; }
            public int Count { get; set; }
        }
    }
}