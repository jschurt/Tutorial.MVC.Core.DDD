using System;
using System.Globalization;
using System.Linq;

namespace CrossCutting.Extensions
{
    public static class StringExtensions
    {

        public static decimal ConvertDecimal(this string str, string mask )
        {

            return decimal.Parse(string.Format(CultureInfo.GetCultureInfo("pt-BR"), mask, str));

        } //ConvertDecimal

        public static string FormatCpfCnpj(this string str)
        {
            if (str != null && str != "")
            { 
                if(str.Length == 11)
                {
                    return str.Substring(0, 3) + '.' + str.Substring(3, 3) + '.' + str.Substring(6, 3) + "-" + str.Substring(9, 2);
                }

                if (str.Length == 14)
                {
                    return str.Substring(0, 2) + '.' + str.Substring(2, 3) + '.' + str.Substring(5, 3) + "/" + str.Substring(8, 4) + '-' + str.Substring(12, 2);
                }

            }

            return "";

        } //FormatCpfCnpj

        public static string SomenteNumeros(this string str)
        {
            if( str != null)
            {
                var somenteNumeros = new String(str.Where(c => Char.IsDigit(c)).ToArray() );
                return somenteNumeros;
            } //if

            return "";

        } //SomenteNumeros


        public static string SomenteLetras(this string str)
        {

            if (str != null)
            {
                var somenteLetras = new String(str.Where(c => Char.IsLetter(c)).ToArray());
                return somenteLetras;
            } //if

            return "";

        } //SomenteLetras



    } //class
} //namespace
