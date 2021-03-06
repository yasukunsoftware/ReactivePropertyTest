﻿using System.ComponentModel.DataAnnotations;

namespace WpfMvvm
{
    public class DoubleValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            double d;
            return double.TryParse(value.ToString(), out d);
        }
    }
}
