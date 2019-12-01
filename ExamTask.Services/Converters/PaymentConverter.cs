using DBO.Entities;
using ExamTask.Services.Models;

namespace ExamTask.Services.Converters
{
    public static class PaymentConverter
    {
        public static Payment ConvertToDb(PaymentXmlModel xmlModel)
        {
            var dbPayment = new Payment()
            {
                Amount = xmlModel.Amount,
                MethodName = xmlModel.MethodName
            };

            return dbPayment;
        }

        public static PaymentVM ConvertToVM(Payment payment)
        {
            var paymentModel = new PaymentVM()
            {
                Amount = payment.Amount,
                MethodName = payment.MethodName
            };

            return paymentModel;
        }
    }
}
