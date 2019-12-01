using DBO.Entities;
using ExamTask.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamTask.Services.Converters
{
    public static class OrderConverter
    {
        public static Order ConvertToDB(OrderXmlModel order)
        {
            if (order == null)
            {
                return null;
            }

            Order dbOrder = new Order()
            {
                OrderDatetime = order.OrderDate,
                OxId = order.Id,
            };

            List<Article> dbArticles = new List<Article>();


            foreach (var art in order.Articles)
            {
                var dbArt = ArticleConverter.ConvertToDB(art);
                dbArt.OrderOxId = order.Id;
                dbArticles.Add(dbArt);
            }

            List<Payment> dbPayments = new List<Payment>();
            foreach (var paym in order.Payments)
            {
                var dbPaym = PaymentConverter.ConvertToDb(paym);
                dbPaym.OrderOxId = order.Id;
                dbPayments.Add(dbPaym);
            }

            var dbAddress = BillingAddressConverter.ConvertToDb(order.BillingAddress);
            dbAddress.OrderOxId = order.Id;

            dbOrder.Articles = dbArticles;
            dbOrder.BillingAddresses = dbAddress;
            dbOrder.Payments = dbPayments;

            return dbOrder;
        }

        public static OrderVM ConvertToVM(Order order)
        {
            OrderVM orderModel = new OrderVM()
            {
                OrderDate = order.OrderDatetime,
                Id = order.OxId,
                OrderStatusID = order.OrderStatus,
            };

            orderModel.Articles = order.Articles.Select(a => ArticleConverter.ConvertToVM(a)).ToList();
            orderModel.Payments = order.Payments.Select(p => PaymentConverter.ConvertToVM(p)).ToList();
            orderModel.BillingAddress = BillingAddressConverter.ConvertToVM(order.BillingAddresses);

            return orderModel;
        }
    }
}
