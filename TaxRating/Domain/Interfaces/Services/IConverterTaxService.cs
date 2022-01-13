using Domain.Entities;
using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IConverterTaxService
    {
        Task<ApiResponse<ConverterTax>> Converter(ConverterTax convert);
    }
}
