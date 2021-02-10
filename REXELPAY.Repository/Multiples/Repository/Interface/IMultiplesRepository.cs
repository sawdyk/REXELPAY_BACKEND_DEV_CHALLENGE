using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using REXELPAY.Models.RequestModels;
using REXELPAY.Models.ResponseModels;

namespace REXELPAY.Repository.Multiples.Repository.Interface
{
    public interface IMultiplesRepository
    {
        Task<GenericResponseModel> checkForMultiplesOfThreeAndFiveAsync(MultipleRequestModel obj);
    }
}
