using System;
using System.Linq;

namespace CodingChallenge.Data.Classes
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
