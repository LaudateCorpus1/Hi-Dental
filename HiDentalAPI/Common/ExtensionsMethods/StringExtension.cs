using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ExtensionsMethods
{
    public static class StringExtension
    {
        /// <summary>
        /// Valida si un string es null o esta vacio
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNull(this string text) => string.IsNullOrEmpty(text);
        /// <summary>
        /// Evalua un string y en caso de ser null toma el valor pasado por parametro
        /// </summary>
        /// <param name="text">string a evaluar</param>
        /// <param name="valueTaked">Valor que tomara el string en caso de ser null</param>
        /// <returns></returns>
        public static string Evaluate(this string text, string valueTaked) => IsNull(text) ? valueTaked : text;
        
    }
}
