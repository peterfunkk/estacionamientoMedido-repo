using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Helpers
{
    class GestorRespuesta<Tipo, T2>
    {

        public Tipo Resultado;
        public T2 Error;
        public bool HayError;
        public GestorRespuesta(bool hayError, T2 mensajeError)
        {
            HayError = hayError;
            Error = mensajeError;
        }

        public GestorRespuesta(bool hayError, Tipo resultado)
        {
            HayError = hayError;
            Resultado = resultado;
        }

    }
}
