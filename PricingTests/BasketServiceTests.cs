using Pricing;
using Pricing.Discounts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PricingTests
{
    public class BasketServiceTests
    {
        [Fact]
        public void BasketService_WithNoDiscount_ReturnCorrectPrice()
        {
            List<Item> items = new()
            {
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 13",
                    Price = 1000,
                    Description = "some description",
                    Categoty = ItemCategoty.Phone,   //this can be an array of guids where every guid is stored in one place in DB
                    Options = new ItemOptions[] { ItemOptions.GB256, ItemOptions.Red }  //this can be an array of guids where every guid is stored in one place in DB
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 13",
                    Price = 1000,
                    Description = "some description",
                    Categoty = ItemCategoty.Phone,   //this can be an array of guids where every guid is stored in one place in DB
                    Options = new ItemOptions[] { ItemOptions.GB256, ItemOptions.Red }  //this can be an array of guids where every guid is stored in one place in DB
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 12",
                    Price = 100,
                    Description = "some description",
                    Categoty = ItemCategoty.Phone,   //this can be an array of guids where every guid is stored in one place in DB
                    Options = new ItemOptions[] { ItemOptions.GB1T, ItemOptions.Red }  //this can be an array of guids where every guid is stored in one place in DB
                }
            };


            IPriceService priceService = new BasketService();

            var totalPrice = priceService.CalculatePrice(items, null);

            Assert.Equal(2100, totalPrice);
        }

        [Fact]
        public void BasketService_WithTenPercentDiscount_ReturnCorrectPrice()
        {
            List<Item> items = new()
            {
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 13",
                    Price = 1000,
                    Description = "some description",
                    Categoty = ItemCategoty.Phone,   //this can be an array of guids where every guid is stored in one place in DB
                    Options = new ItemOptions[] { ItemOptions.GB256, ItemOptions.Red }  //this can be an array of guids where every guid is stored in one place in DB
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 13",
                    Price = 1000,
                    Description = "some description",
                    Categoty = ItemCategoty.Phone,   //this can be an array of guids where every guid is stored in one place in DB
                    Options = new ItemOptions[] { ItemOptions.GB256, ItemOptions.Red }  //this can be an array of guids where every guid is stored in one place in DB
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 12",
                    Price = 100,
                    Description = "some description",
                    Categoty = ItemCategoty.Phone,   //this can be an array of guids where every guid is stored in one place in DB
                    Options = new ItemOptions[] { ItemOptions.GB1T, ItemOptions.Red }  //this can be an array of guids where every guid is stored in one place in DB
                }
            };

            List<IDiscount> discounts = new()
            {
                new TenPercentDiscount() { Id = Guid.NewGuid() }
            };

            IPriceService priceService = new BasketService();

            var totalPrice = priceService.CalculatePrice(items, discounts);

            Assert.Equal(1890, totalPrice);
        }


        [Fact]
        public void BasketService_WithGeneralTwoAtOneDiscount_ReturnCorrectPrice()
        {
            List<IDiscount> generalDiscounts = new()
            {
                new TwoAtOneDiscount() { Id = Guid.NewGuid() }
            };

            List<Item> items = new()
            {
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 13",
                    Price = 100,
                    Description = "some description",
                    Categoty = ItemCategoty.Phone,   //this can be an array of guids where every guid is stored in one place in DB
                    Options = new ItemOptions[] { ItemOptions.GB256, ItemOptions.Red },  //this can be an array of guids where every guid is stored in one place in DB

                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 13",
                    Price = 100,
                    Description = "some description",
                    Categoty = ItemCategoty.Phone,   
                    Options = new ItemOptions[] { ItemOptions.GB256, ItemOptions.Red }  
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 12",
                    Price = 100,
                    Description = "some description",
                    Categoty = ItemCategoty.Phone,
                    Options = new ItemOptions[] { ItemOptions.GB1T, ItemOptions.Red }
                },  
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 12",
                    Price = 100,
                    Description = "some description",
                    Categoty = ItemCategoty.Phone,   
                    Options = new ItemOptions[] { ItemOptions.GB1T, ItemOptions.Red }  
                                                                                       
                }
            };

            IPriceService priceService = new BasketService();
            var totalPrice = priceService.CalculatePrice(items, generalDiscounts);

            Assert.Equal(200, totalPrice);
        }


        [Fact]
        public void BasketService_WithGeneralMultipleDiscount_ReturnCorrectPrice()
        {
            List<IDiscount> generalDiscounts = new()
            {
                new TenPercentDiscount() { Id = Guid.NewGuid() },
                new ThreeAtTwoDiscount() { Id = Guid.NewGuid() }
            };

            List<Item> items = new()
            {
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 13",
                    Price = 100,
                    Description = "some description",
                    Categoty = ItemCategoty.Phone,   //this can be an array of guids where every guid is stored in one place in DB
                    Options = new ItemOptions[] { ItemOptions.GB256, ItemOptions.Red },  //this can be an array of guids where every guid is stored in one place in DB

                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 13",
                    Price = 100,
                    Description = "some description",
                    Categoty = ItemCategoty.Phone,   
                    Options = new ItemOptions[] { ItemOptions.GB256, ItemOptions.Red }  
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 12",
                    Price = 100,
                    Description = "some description",
                    Categoty = ItemCategoty.Phone,
                    Options = new ItemOptions[] { ItemOptions.GB1T, ItemOptions.Red }
                },  
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 12",
                    Price = 100,
                    Description = "some description",
                    Categoty = ItemCategoty.Phone,   
                    Options = new ItemOptions[] { ItemOptions.GB1T, ItemOptions.Red }  
                                                                                       
                }
            };

            IPriceService priceService = new BasketService();
            var totalPrice = priceService.CalculatePrice(items, generalDiscounts);

            Assert.Equal(270, totalPrice);
        }

        [Fact]
        public void BasketService_WithMultipleItemDiscount_ReturnCorrectPrice()
        {
            List<IDiscount> discounts = new()
            {
                new TenPercentDiscount() { Id = Guid.NewGuid() },
                new ThreeAtTwoDiscount() { Id = Guid.NewGuid() }
            };

            List<Item> items = new()
            {
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 13",
                    Price = 100,
                    Description = "some description",
                    Discounts = new [] { discounts[1], discounts[0] },
                    Categoty = ItemCategoty.Phone,   //this can be an array of guids where every guid is stored in one place in DB
                    Options = new ItemOptions[] { ItemOptions.GB256, ItemOptions.Red },  //this can be an array of guids where every guid is stored in one place in DB

                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 13",
                    Price = 100,
                    Description = "some description",
                    Discounts = new[] { discounts[1] },
                    Categoty = ItemCategoty.Phone,   //this can be an array of guids where every guid is stored in one place in DB
                    Options = new ItemOptions[] { ItemOptions.GB256, ItemOptions.Red }  //this can be an array of guids where every guid is stored in one place in DB
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 12",
                    Price = 100,
                    Description = "some description",
                    Discounts = new[] { discounts[1] },
                    Categoty = ItemCategoty.Phone,   //this can be an array of guids where every guid is stored in one place in DB
                    Options = new ItemOptions[] { ItemOptions.GB1T, ItemOptions.Red }  //this can be an array of guids where every guid is stored in one place in DB
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 12",
                    Price = 100,
                    Description = "some description",
                    Categoty = ItemCategoty.Phone,   //this can be an array of guids where every guid is stored in one place in DB
                    Options = new ItemOptions[] { ItemOptions.GB1T, ItemOptions.Red }  //this can be an array of guids where every guid is stored in one place in DB
                                                                                       //}
                }
            };


            IPriceService priceService = new BasketService();

            var totalPrice = priceService.CalculatePrice(items, null);

            Assert.Equal(290, totalPrice);
        }

        [Fact]
        public void BasketService_WithGeneralAndItemDiscounts_ReturnCorrectPrice()
        {
            List<IDiscount> discounts = new()
            {
                new TenPercentDiscount() { Id = Guid.NewGuid() },
                new ThreeAtTwoDiscount() { Id = Guid.NewGuid() }
            };

            List<IDiscount> generalDiscounts = new()
            {
                new TenPercentDiscount() { Id = Guid.NewGuid() },
                new ThreeAtTwoDiscount() { Id = Guid.NewGuid() }
            };

            List<Item> items = new()
            {
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 13",
                    Price = 100,
                    Description = "some description",
                    Discounts = new [] { discounts[1], discounts[0] },
                    Categoty = ItemCategoty.Phone,   //this can be an array of guids where every guid is stored in one place in DB
                    Options = new ItemOptions[] { ItemOptions.GB256, ItemOptions.Red },  //this can be an array of guids where every guid is stored in one place in DB

                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 13",
                    Price = 100,
                    Description = "some description",
                    Discounts = new[] { discounts[1] },
                    Categoty = ItemCategoty.Phone,   //this can be an array of guids where every guid is stored in one place in DB
                    Options = new ItemOptions[] { ItemOptions.GB256, ItemOptions.Red }  //this can be an array of guids where every guid is stored in one place in DB
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 12",
                    Price = 100,
                    Description = "some description",
                    Categoty = ItemCategoty.Phone,   //this can be an array of guids where every guid is stored in one place in DB
                    Options = new ItemOptions[] { ItemOptions.GB1T, ItemOptions.Red }  //this can be an array of guids where every guid is stored in one place in DB
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone 12",
                    Price = 100,
                    Description = "some description",
                    Discounts = new[] { discounts[1] },
                    Categoty = ItemCategoty.Phone,   //this can be an array of guids where every guid is stored in one place in DB
                    Options = new ItemOptions[] { ItemOptions.GB1T, ItemOptions.Red }  //this can be an array of guids where every guid is stored in one place in DB
                                                                                       //}
                }
            };


            IPriceService priceService = new BasketService();

            var totalPrice = priceService.CalculatePrice(items, discounts);

            Assert.Equal(171, totalPrice);
        }
    }
}