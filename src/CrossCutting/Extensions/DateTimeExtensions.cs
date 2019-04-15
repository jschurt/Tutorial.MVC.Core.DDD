using System;
using System.Globalization;

namespace CrossCutting.Extensions
{
    public static class DateTimeExtensions
    {

        public static string Formatado(this DateTime dt, string mask)
        {

            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), mask, dt);

        } //Formatado

        public static string Formatado(this DateTime? dt, string mask)
        {

            if (dt != null)
                return string.Format(CultureInfo.GetCultureInfo("pt-BR"), mask, dt);
            else
                return "";
           
        } //Formatado

    } //class
} //namespace
