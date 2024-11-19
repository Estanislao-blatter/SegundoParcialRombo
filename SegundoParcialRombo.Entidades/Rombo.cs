
namespace SegundoParcialRombo.Entidades
{
    public class Rombo
    {
        public int DiagonalMayor { get; set; }
        public int DiagonalMenor { get; set; }
        public int Contorno { get; set; }

        public int CalcArea()=>(DiagonalMayor*DiagonalMenor)/2;

        public int CalcLado()
        {
            return (int)(Math.Sqrt(DiagonalMayor / 2) + Math.Sqrt(DiagonalMenor / 2));
        }

        public int CalcPerimetro()=>CalcLado()*4;

        public object Contorno()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Rombo [Diagonal Mayor:{DiagonalMayor}, Diagonal Menor:{DiagonalMenor}, Contorno{Contorno}]";
        }
    }
}
