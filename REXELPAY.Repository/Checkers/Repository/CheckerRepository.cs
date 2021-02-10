using Microsoft.Extensions.Logging;
using REXELPAY.Helpers.Utilities;
using REXELPAY.Models.RequestModels;
using REXELPAY.Repository.Checkers.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REXELPAY.Repository.Checkers.Repository
{
    public class CheckerRepository : ICheckerRepository
    {
        private readonly ILogger<CheckerRepository> _logger;
        public CheckerRepository(ILogger<CheckerRepository> logger)
        {
            _logger = logger;
        }
        public EnumUtility.MultipleCodes checkNumberAsync(int number)
        {
            try
            {
                EnumUtility.MultipleCodes enumObj =  EnumUtility.MultipleCodes.Not_A_Multiple_Of_Three_Or_Five;

                if (number % 3 == 0 && number % 5 == 0)
                {
                    enumObj = EnumUtility.MultipleCodes.Multiple_Of_Three_And_Five;
                }
                else if (number % 3 == 0)
                {
                    enumObj = EnumUtility.MultipleCodes.Multiple_Of_Three;
                }
                else if (number % 5 == 0)
                {
                    enumObj = EnumUtility.MultipleCodes.Multiple_Of_Five;
                }

                return enumObj;
            }
            catch (Exception exMessage)
            {
                _logger.LogInformation(string.Format("This Error: {0}, Occurred at {1}; StackTrace: {2}", exMessage.Message, exMessage.StackTrace, exMessage.Source));
                throw exMessage;
            }
        }
    }
}
