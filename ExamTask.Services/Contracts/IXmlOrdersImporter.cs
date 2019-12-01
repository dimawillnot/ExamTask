using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ExamTask.Common.Models;

namespace ExamTask.Services.Contracts
{
    public interface IXmlOrdersImporter
    {
        Task<GeneralResult<IList<long>>> ImportAsync(Stream stream);
    }
}