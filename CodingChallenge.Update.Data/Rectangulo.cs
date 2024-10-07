using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Update.Data
{
    public class Rectangulo : FormaGeometricaBase
    {
        private readonly decimal _ancho;
        private readonly decimal _alto;

        public Rectangulo(decimal ancho, decimal alto)
        {
            _ancho = ancho;
            _alto = alto;
        }

        public override decimal CalcularArea() => _ancho * _alto;

        public override decimal CalcularPerimetro() => 2 * (_ancho + _alto);
    }
}
