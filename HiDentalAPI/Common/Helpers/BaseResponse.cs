using System;
using System.Collections.Generic;

namespace Common.Helpers
{
    public class ResponseContenido
    {
        public ResponseContenido()
        {
            Errores = new List<string>();
            Valores = new List<object>();
            Mensajes = new List<string>();
        }
        public bool OK { get; set; }
        public List<string> Errores { get; set; }
        public List<string> Mensajes { get; set; }
        public List<object> Valores { get; set; }
    }
}
