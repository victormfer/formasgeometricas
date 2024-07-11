namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Rectangulo : FormaGeometrica
    {
        private decimal _lado1;
        private decimal _lado2;
        public Rectangulo(decimal lado1, decimal lado2)
            : base()
        {
            _lado1 = lado1;
            _lado2 = lado2; 
        }

        public override decimal CalcularArea()
        {
            return _lado1*_lado2;
        }
        public override decimal CalcularPerimetro()
        {
            return _lado1 * 2 + _lado2 * 2;
        }
        public override string Nombre => "Rectangulo";
    }
}
