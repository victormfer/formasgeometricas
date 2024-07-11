using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Classes
{
    public class Traductor
    {

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Italino = 3;

        private static Traductor _instancia;

        private Dictionary<int, Dictionary<string, string>> _dicLenguajes;

        private Traductor()
        {
            _dicLenguajes = new Dictionary<int, Dictionary<string, string>>();

            var dicCastellano =  new Dictionary<string,string>();
            dicCastellano.Add("<h1>Lista vacía de formas!</h1>", "<h1>Lista vacía de formas!</h1>");
            dicCastellano.Add("<h1>Reporte de Formas</h1>", "<h1>Reporte de Formas</h1>");
            dicCastellano.Add("Cuadrado", "Cuadrado");
            dicCastellano.Add("Cuadrados", "Cuadrados");
            dicCastellano.Add("Círculo", "Círculo");
            dicCastellano.Add("Círculos", "Círculos");
            dicCastellano.Add("Triángulo", "Triángulo");
            dicCastellano.Add("Triángulos", "Triángulos");
            dicCastellano.Add("Perimetro", "Perimetro");
            dicCastellano.Add("formas", "formas");
            dicCastellano.Add("Rectangulo", "Rectangulo");
            dicCastellano.Add("Rectangulos", "Rectangulos");

            var dicIngles = new Dictionary<string, string>();
            dicIngles.Add("<h1>Lista vacía de formas!</h1>", "<h1>Empty list of shapes!</h1>");
            dicIngles.Add("<h1>Reporte de Formas</h1>", "<h1>Shapes report</h1>");
            dicIngles.Add("Cuadrado", "Square");
            dicIngles.Add("Cuadrados", "Squares");
            dicIngles.Add("Círculo", "Circle");
            dicIngles.Add("Círculos", "Circles");
            dicIngles.Add("Triángulo", "Triangle");
            dicIngles.Add("Triángulos", "Triangles");
            dicIngles.Add("Perimetro", "Perimeter");
            dicIngles.Add("formas", "shapes");
            dicIngles.Add("Rectangulo", "Rectangle");
            dicIngles.Add("Rectangulos", "Rectangles");


            var dicItaliano = new Dictionary<string, string>();
            dicItaliano.Add("<h1>Lista vacía de formas!</h1>", "<h1>Elenco vuoto di forme</h1>");
            dicItaliano.Add("<h1>Reporte de Formas</h1>", "<h1>Rapporto sul modulo</h1>");
            dicItaliano.Add("Cuadrado", "Piazza");
            dicItaliano.Add("Cuadrados", "Piazze");
            dicItaliano.Add("Círculo", "Cerchio");
            dicItaliano.Add("Triángulo", "Triangolo");
            dicItaliano.Add("Triángulos", "Triangoli");
            dicItaliano.Add("Perimetro", "Perimetro");
            dicItaliano.Add("formas", "forme");
            dicItaliano.Add("Rectangulo", "Rettangolo");
            dicItaliano.Add("Rectangulos", "Rettangoli");


            _dicLenguajes.Add(Castellano, dicCastellano);
            _dicLenguajes.Add(Ingles, dicIngles);
            _dicLenguajes.Add(Italino, dicItaliano);

        }

        public string Traduccion(string traduccion, int lenguaje)
        {
            if (_dicLenguajes[lenguaje].ContainsKey(traduccion))
                return _dicLenguajes[lenguaje][traduccion];
            else
                return traduccion; //retorna el texto en castellano
        }

        public static Traductor Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Traductor();
                return _instancia;
            }
        }

    }
}
