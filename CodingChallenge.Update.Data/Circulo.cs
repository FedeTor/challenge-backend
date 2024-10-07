using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Update.Data
{
    public class Circulo : FormaGeometricaBase
    {
        private readonly decimal _radio;

        public Circulo(decimal radio)
        {
            _radio = radio;
        }

        public override decimal CalcularArea() => (decimal)Math.PI * (_radio * _radio);

        public override decimal CalcularPerimetro() => 2 * (decimal)Math.PI * _radio;
    }
}
