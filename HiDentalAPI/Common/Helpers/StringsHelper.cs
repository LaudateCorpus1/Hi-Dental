using System;

namespace Common.Helpers
{
    public static class StringsHelper
    {
        /// <summary>
        /// Genera un string ramdon basado en un GUID como maximo 20 digitos
        /// </summary>
        /// <param name="length">Cantidad de letras a retornar</param>
        /// <returns></returns>
        public static string GenerateRandomString(int length)
            => length >= 20 ? GenerateGuidStr().Substring(0, 20).Replace("-", "") : GenerateGuidStr().Substring(0, length).Replace("-", "");

        private static string GenerateGuidStr() => Guid.NewGuid().ToString();
    }
}
