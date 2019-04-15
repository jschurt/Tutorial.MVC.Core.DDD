using System.Globalization;

namespace CrossCutting.Extensions
{
    public static class DecimalExtensions
    {

        public static string Formatado(this decimal dec, string mask)
        {

            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), mask, dec);
        } //Formatado

    } //class

} //namespace
