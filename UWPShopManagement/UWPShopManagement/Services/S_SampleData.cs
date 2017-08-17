﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UWPShopManagement.Models;

namespace UWPShopManagement.Services
{
    // This class holds sample data used by some generated pages to show how they can be used.
    // TODO WTS: Delete this file once your app is using real data.
    public static class S_SampleData
    {
        public static ObservableCollection<S_ArduinoLink> AllObservableArduinoLinks()
        {
            var data = new ObservableCollection<S_ArduinoLink>
            {
                new S_ArduinoLink
                {
                    ID = 0001,
                    Name = "主料区"
                },
                new S_ArduinoLink
                {
                    ID = 0002,
                    Name = "辅料区"
                },
                new S_ArduinoLink
                {
                    ID = 0003,
                    Name = "不知道干嘛的"
                }
            };
            return data;
        }
        public static IEnumerable<S_ArduinoLink> GetAllArduinoLinkAsync()
        {
            var data = new ObservableCollection<S_ArduinoLink>
            {
                new S_ArduinoLink
                {
                    ID = 0001,
                    Name = "主料区"
                },
                new S_ArduinoLink
                {
                    ID = 0002,
                    Name = "辅料区"
                },
                new S_ArduinoLink
                {
                    ID = 0003,
                    Name = "不知道干嘛的"
                }
            };
            return data;
        }
        private static IEnumerable<Order> AllOrders()
        {
            // The following is order summary data
            var data = new ObservableCollection<Order>
            {
                new Order
                {
                    OrderId = 70,
                    OrderDate = new DateTime(2017, 05, 24),
                    Company = "Company F",
                    ShipTo = "Francisco Pérez-Olaeta",
                    OrderTotal = 2490.00,
                    Status = "Closed"
                },
                new Order
                {
                    OrderId = 71,
                    OrderDate = new DateTime(2017, 05, 24),
                    Company = "Company CC",
                    ShipTo = "Soo Jung Lee",
                    OrderTotal = 1760.00,
                    Status = "Closed"
                },
                new Order
                {
                    OrderId = 72,
                    OrderDate = new DateTime(2017, 06, 03),
                    Company = "Company Z",
                    ShipTo = "Run Liu",
                    OrderTotal = 2310.00,
                    Status = "Closed"
                },
                new Order
                {
                    OrderId = 73,
                    OrderDate = new DateTime(2017, 06, 05),
                    Company = "Company Y",
                    ShipTo = "John Rodman",
                    OrderTotal = 665.00,
                    Status = "Closed"
                },
                new Order
                {
                    OrderId = 74,
                    OrderDate = new DateTime(2017, 06, 07),
                    Company = "Company H",
                    ShipTo = "Elizabeth Andersen",
                    OrderTotal = 560.00,
                    Status = "Shipped"
                },
                new Order
                {
                    OrderId = 75,
                    OrderDate = new DateTime(2017, 06, 07),
                    Company = "Company F",
                    ShipTo = "Francisco Pérez-Olaeta",
                    OrderTotal = 810.00,
                    Status = "Shipped"
                },
                new Order
                {
                    OrderId = 76,
                    OrderDate = new DateTime(2017, 06, 11),
                    Company = "Company I",
                    ShipTo = "Sven Mortensen",
                    OrderTotal = 196.50,
                    Status = "Shipped"
                },
                new Order
                {
                    OrderId = 77,
                    OrderDate = new DateTime(2017, 06, 14),
                    Company = "Company BB",
                    ShipTo = "Amritansh Raghav",
                    OrderTotal = 270.00,
                    Status = "New"
                },
                new Order
                {
                    OrderId = 78,
                    OrderDate = new DateTime(2017, 06, 14),
                    Company = "Company A",
                    ShipTo = "Anna Bedecs",
                    OrderTotal = 736.00,
                    Status = "New"
                },
                new Order
                {
                    OrderId = 79,
                    OrderDate = new DateTime(2017, 06, 18),
                    Company = "Company K",
                    ShipTo = "Peter Krschne",
                    OrderTotal = 800.00,
                    Status = "New"
                },
            };

            return data;
        }

        // TODO WTS: Remove this once your MasterDetail pages are displaying real data
        public static async Task<IEnumerable<Order>> GetSampleModelDataAsync()
        {
            await Task.CompletedTask;

            return AllOrders();
        }

        //// TODO WTS: Remove this once your chart page is displaying real data
        //public static ObservableCollection<DataPoint> GetChartSampleData()
        //{
        //    var data = AllOrders().Select(o => new DataPoint() { Category = o.Company, Value = o.OrderTotal })
        //                          .OrderBy(dp => dp.Category);

        //    return new ObservableCollection<DataPoint>(data);
        //}

        // TODO WTS: Remove this once your grid page is displaying real data
        public static ObservableCollection<Order> GetGridSampleData()
        {
            return new ObservableCollection<Order>(AllOrders());
        }
    }
}
