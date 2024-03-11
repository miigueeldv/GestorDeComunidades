using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidades.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class GeneradorDNI
    {
        /// <summary>
        /// The random
        /// </summary>
        private Random random = new Random();
        /// <summary>
        /// The dnies generados
        /// </summary>
        private HashSet<string> dniesGenerados = new HashSet<string>();

        /// <summary>
        /// Generars the dni.
        /// </summary>
        /// <returns></returns>
        private string GenerarDNI()
        {
            int numero = random.Next(10000000, 99999999);
            char letra = ObtenerLetraDNI(numero);
            return $"{numero}{letra}";
        }
        /// <summary>
        /// Obteners the letra dni.
        /// </summary>
        /// <param name="dni">The dni.</param>
        /// <returns></returns>
        private char ObtenerLetraDNI(int dni)
        {
            string juegoCaracteres = "TRWAGMYFPDXBNJZSQVHLCKE";
            int modulo = dni % 23;
            return juegoCaracteres[modulo];
        }
        /// <summary>
        /// Generars the dni nuevo.
        /// </summary>
        /// <returns></returns>
        public string GenerarDNINuevo()
        {
            string nuevoDNI;

            do
            {
                nuevoDNI = GenerarDNI();
            }
            while (dniesGenerados.Contains(nuevoDNI));

            dniesGenerados.Add(nuevoDNI);
            return nuevoDNI;
        }
    }
}
