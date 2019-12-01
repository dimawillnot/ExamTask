using DBO.Entities;
using ExamTask.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamTask.Services.Converters
{
    public static class BillingAddressConverter
    {
        public static BillingAddress ConvertToDb(BillingAddressXmlModel xmlModel)
        {
            var dbBillingAddress = new BillingAddress()
            {
                City = xmlModel.City,
                Country = xmlModel.Country.Geo,
                Email = xmlModel.Email,
                Fullname = xmlModel.Name,
                HomeNumber = xmlModel.Streetnr,
                Street = xmlModel.Street,
                Zip = xmlModel.Zip
            };

            return dbBillingAddress;
        }

        public static BillingAddressVM ConvertToVM(BillingAddress billingAddress)
        {
            if (billingAddress == null)
            {
                return null;
            }

            var billingAddressModel = new BillingAddressVM()
            {
                City = billingAddress.City,
                Country = new CountryVM() { Geo = billingAddress.Country },
                Email = billingAddress.Email,
                Name = billingAddress.Fullname,
                Street = billingAddress.Street,
                Streetnr = billingAddress.HomeNumber,
                Zip = billingAddress.Zip
            };

            return billingAddressModel;
        }
    }
}
