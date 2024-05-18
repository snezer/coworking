using Coworking.FileConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.FileConverter.Interfaces
{
    public interface ISvgConverter
    {
        FileConvertResultDTO Convert(ConvertRequestDTO requestDTO);
    }
}
