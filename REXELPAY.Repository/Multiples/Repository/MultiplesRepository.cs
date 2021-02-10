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
        private readonly ICheckerRepository _checkerRepository;
        private readonly ILogger<MultiplesRepository> _logger;

        public MultiplesRepository(ICheckerRepository checkerRepository, ILogger<MultiplesRepository> logger)
        {
            _checkerRepository = checkerRepository;
            _logger = logger;
        }

        public Task<GenericResponseModel> checkForMultiplesOfThreeAndFiveAsync(MultipleRequestModel obj)
        {
            try
            {
                //checks the number(if number is a multiple of three, five, three and five or not a multiple of three or five) 
                //and return the code associated with it to determine the response to the user
                EnumUtility.MultipleCodes enumObj = _checkerRepository.checkNumberAsync(obj.Number);

                //Multiples of both three and five
                if (enumObj == EnumUtility.MultipleCodes.Multiples_Of_Three_And_Five)
                {
                    return Task.FromResult(new GenericResponseModel { 
                        Code = System.Net.HttpStatusCode.OK, 
                        Message = "Success", 
                        Data =  new FizzBuzzResponseModel { 
                            Number = obj.Number,  
                            Word = "FizzBuzz",
                            Remark = "Multiples Of Three and Five"
                        }
                    });
                }
                //Multiples of three 
                else if (enumObj == EnumUtility.MultipleCodes.Multiples_Of_Three)
                {
                    return Task.FromResult(new GenericResponseModel
                    {
                        Code = System.Net.HttpStatusCode.OK,
                        Message = "Success",
                        Data = new FizzBuzzResponseModel
                        {
                            Number = obj.Number,
                            Word = "Fizz",
                            Remark = "Multiples Of Three"
                        }
                    });
                }
                //Multiples of five 
                else if (enumObj == EnumUtility.MultipleCodes.Multiples_Of_Five)
                {
                    return Task.FromResult(new GenericResponseModel
                    {
                        Code = System.Net.HttpStatusCode.OK,
                        Message = "Success",
                        Data = new FizzBuzzResponseModel
                        {
                            Number = obj.Number,
                            Word = "Buzz",
                            Remark = "Multiples Of Five"
                        }
                    });
                }
                //Not a Multiples of three or five
                return Task.FromResult(new GenericResponseModel
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "Success",
                    Data = new FizzBuzzResponseModel
                    {
                        Number = obj.Number,
                        Remark = "Not A Multiple Of Three or Five"
                    }
                });
            }
            catch (Exception exMessage)
            {
                //Logs Information
                var logInfo = new Logger(_logger);
                logInfo.logException(exMessage);

                //Returns Generic reposne to users
                return Task.FromResult(new GenericResponseModel { 
                    Code = System.Net.HttpStatusCode.InternalServerError, 
                    Message = "An Error Occurred" 
                });

            }
        }
    }
}
