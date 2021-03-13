using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transferencia;

namespace TransferenciaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TransferenciaEntreCuentasConFondosInsuficientesArrojaUnError()
        {
            // Preparación
            Exception expectedException = null;
            Cuenta origen = new Cuenta() { Fondos = 0 };
            Cuenta destino = new Cuenta() { Fondos = 0 };
            decimal montoATransferir = 5m;
            var servicio = new ServicioDeTransferencias();

            // Prueba
            try
            {
                servicio.TransferirEntreCuentas(origen, destino, montoATransferir);
                Assert.Fail("Un error debió ser arrojado");
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            // Verificación
            Assert.IsTrue(expectedException is ApplicationException);
            Assert.AreEqual("La cuenta origen no tiene fondos suficientes para realizar la operación", expectedException.Message);
        }
        [TestMethod]
        public void TransferenciaEntrecuentasValidarFondos()
        {
            // Preparación
            Cuenta origen = new Cuenta() { Fondos = 10 };
            Cuenta destino = new Cuenta() { Fondos = 5 };
            decimal cantidadAtranferir = 3m;
            ServicioDeTransferencias servicio = new ServicioDeTransferencias();

            // Prueba
            servicio.TransferirEntreCuentas(origen, destino, cantidadAtranferir);
            // Verificación
            Assert.AreEqual(7, origen.Fondos);
            Assert.AreEqual(8, destino.Fondos);
        }
    }
}
