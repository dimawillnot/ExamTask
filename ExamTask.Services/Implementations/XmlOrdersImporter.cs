using DBO.Contracts;
using DBO.Repositories;
using ExamTask.Common.Models;
using ExamTask.Services.Contracts;
using ExamTask.Services.Converters;
using ExamTask.Services.Models;
using ExamTask.Services.Validators;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExamTask.Services.Implementation
{
    public class XmlOrdersImporter : IXmlOrdersImporter
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderValidator orderValidator;

        public XmlOrdersImporter(IOrderRepository orderRepository, IOrderValidator orderValidator)
        {
            this.orderRepository = orderRepository;
            this.orderValidator = orderValidator;
        }

        public async Task<GeneralResult<IList<long>>> ImportAsync(Stream stream)
        {
            var orders = Parse(stream);
            var validateResult = await orderValidator.Validate(orders);

            if (validateResult.IsSuccess)
            {
                await orderRepository.AddRangeAsync(orders.Select(o=> OrderConverter.ConvertToDB(o)).ToList());
            }

            return validateResult;
        }

        private List<OrderXmlModel> Parse(Stream stream)
        {
            List<OrderXmlModel> orders;
            using (var reader = new StreamReader(stream))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<OrderXmlModel>),
                    new XmlRootAttribute("orders"));
                orders = (List<OrderXmlModel>)deserializer.Deserialize(reader);
            }

            return orders;
        }
    }
}
