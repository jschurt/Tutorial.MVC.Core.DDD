using System;
using System.Linq;

namespace CrossCutting.Extensions
{
    public static class StringExtensions
    {

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
