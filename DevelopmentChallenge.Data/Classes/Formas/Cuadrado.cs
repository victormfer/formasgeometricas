namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Cuadrado : FormaGeometrica
    {
        private decimal _lado;
        public Cuadrado(decimal lado)
            : base()
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }
        public override string Nombre => "Cuadrado";
    }

}
