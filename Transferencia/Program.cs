using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transferencia
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public class Cuenta
        {
            public decimal Fondos { get; set; }
        }

        public class ServicioDeTransferencias
        {

            public void TransferirEntreCuentas(Cuenta origen, Cuenta destino, decimal
            montoATransferir)
            {
                if (montoATransferir > origen.Fondos)
                {
                    throw new ApplicationException("La cuenta origen no tiene fondos suficientes para realizar la operación");
                }

                origen.Fondos -= montoATransferir;
                destino.Fondos += montoATransferir;
            }
        }
    }
}
