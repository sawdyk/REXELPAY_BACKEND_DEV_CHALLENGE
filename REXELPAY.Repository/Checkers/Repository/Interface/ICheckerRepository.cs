using REXELPAY.Helpers.Utilities;
using REXELPAY.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REXELPAY.Repository.Checkers.Repository.Interface
{
    public interface ICheckerRepository
    {
        EnumUtility.MultipleCodes checkNumberAsync(int number);
    }
}
