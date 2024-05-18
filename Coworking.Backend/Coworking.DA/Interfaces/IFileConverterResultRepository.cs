using Coworking.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.DA.Interfaces
{
    public interface IFileConverterResultRepository
    {
        Task<bool> SaveConvertResult(FileConverterResult converterResult);
        Task<FileConverterResult> LoadConvertionResultByFloorId(int floorId);
    }
}
