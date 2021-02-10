using REXELPAY.Helpers.TagHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace REXELPAY.Models.RequestModels
{
    public class MultipleRequestModel
    {
        [Required]
        [MinMaxNumber]
        public int Number { get; set; }
    }
}
