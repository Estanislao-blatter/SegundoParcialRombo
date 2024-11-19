using SegundoParcialRombo.Entidades;

namespace SegundoParcialRombo.Datos
{
    public class RepositorioRombo
    {
        private List<Rombo>? rombos;
        private String? nombreArchivo = "Rombo.txt";
        private String? rutaProyecto = Environment.CurrentDirectory;
        private String? rutaCompletaArchivo;

        public void AgregarRombo(Rombo rombo)
        {
           rombos!.Add(rombo);
        }

        public void EliminarRombo(Rombo rombo)
        {
            rombos!.Remove(rombo);
        }

        public bool Existe(Rombo rombo)
        {
            return rombos!.Any(r=>r.DiagonalMayor==rombo.DiagonalMayor && r.DiagonalMenor==rombo.DiagonalMenor);
        }

        public void GuardarDatos()
        {
            rutaCompletaArchivo = Path.Combine(rutaProyecto!, nombreArchivo!);
            using (var escritor=new StreamWriter(rutaCompletaArchivo))
            {
                foreach (var rombo in rombos!)
                {
                    string linea = ConstruirLinea(rombo);
                    escritor.WriteLine(linea);
                }
            }
        }

        public List<Rombo> ObtenerRombos()
        {
            return new List<Rombo>(rombos!);
        }

        private string ConstruirLinea(Rombo rombo)
        {
           return $"{rombo.DiagonalMayor}|{rombo.DiagonalMenor}|{rombo.Contorno().GetHashCode()}|{rombo.CalcLado()}," +
                $"{rombo.CalcPerimetro()}|{rombo.CalcArea()}";
        }
    }
}
