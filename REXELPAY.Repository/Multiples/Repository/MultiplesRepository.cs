using Microsoft.Extensions.Logging;
using REXELPAY.Helpers.Utilities;
using REXELPAY.Models.RequestModels;
using REXELPAY.Models.ResponseModels;
using REXELPAY.Repository.Checkers.Repository.Interface;
using REXELPAY.Repository.Multiples.Repository.Interface;
using System;
using System.Threading.Tasks;

namespace REXELPAY.Repository.Multiples.Repository
{
    public class MultiplesRepository : IMultiplesRepository
    {
        public ICheckerRepository _checkerRepository;
        private readonly ILogger<MultiplesRepository> _logger;

        public MultiplesRepository(ICheckerRepository checkerRepository, ILogger<MultiplesRepository> logger)
        {
            _checkerRepository = checkerRepository;
            _logger = logger;
        }

        public async Task<GenericResponseModel> findMultiplesAsync(MultipleRequestModel obj)
        {
            try
            {
                EnumUtility.MultipleCodes enumObj = _checkerRepository.checkNumberAsync(obj.Number);

                if (enumObj == EnumUtility.MultipleCodes.Multiple_Of_Three_And_Five)
                {
                    return new GenericResponseModel { 
                        Code = (int)System.Net.HttpStatusCode.OK, 
                        Message = "Success", 
                        Data =  new FizzBuzzResponseModel { 
                            Number = obj.Number,  
                            Word = "FizzBuzz",
                            Remark = "Multiples Of Three and Five"
                        }
                    };
                }
                else if (enumObj == EnumUtility.MultipleCodes.Multiple_Of_Three)
                {
                    return new GenericResponseModel
                    {
                        Code = (int)System.Net.HttpStatusCode.OK,
                        Message = "Success",
                        Data = new FizzBuzzResponseModel
                        {
                            Number = obj.Number,
                            Word = "Fizz",
                            Remark = "Multiples Of Three"
                        }
                    };
                }
                else if (enumObj == EnumUtility.MultipleCodes.Multiple_Of_Five)
                {
                    return new GenericResponseModel
                    {
                        Code = (int)System.Net.HttpStatusCode.OK,
                        Message = "Success",
                        Data = new FizzBuzzResponseModel
                        {
                            Number = obj.Number,
                            Word = "Buzz",
                            Remark = "Multiples Of Five"
                        }
                    };
                }

                return new GenericResponseModel
                {
                    Code = (int)System.Net.HttpStatusCode.OK,
                    Message = "Success",
                    Data = new FizzBuzzResponseModel
                    {
                        Number = obj.Number,
                        Remark = "Not A Multiple Of Three or Five"
                    }
                };
            }
            catch (Exception exMessage)
            {
                //Logs Information
                var logInfo = new Logger(_logger);
                logInfo.logError(exMessage);

                //Returns Generic reposne to users
                return new GenericResponseModel { 
                    Code = (int)System.Net.HttpStatusCode.InternalServerError, 
                    Message = "An Error Occurred" 
                };

            }
        }
    }
}
