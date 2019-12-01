using System.Collections.Generic;
using System.Threading.Tasks;
using ExamTask.Common.Models;
using ExamTask.Services.Models;

namespace ExamTask.Services.Contracts
{
    public interface IOrderValidator
    {
        Task<GeneralResult<IList<long>>> Validate(ICollection<OrderXmlModel> orders);
    }
}