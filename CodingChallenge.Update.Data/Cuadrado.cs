using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Update.Data
{
    public class Cuadrado : FormaGeometricaBase
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea() => _lado * _lado;

        public override decimal CalcularPerimetro() => _lado * 4;
    }
}
