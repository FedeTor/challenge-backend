using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Update.Data
{
    public class TrianguloEquilatero : FormaGeometricaBase
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea() => ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;

        public override decimal CalcularPerimetro() => _lado * 3;
    }
}
