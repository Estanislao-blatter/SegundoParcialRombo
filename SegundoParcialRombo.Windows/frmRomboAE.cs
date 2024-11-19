using SegundoParcialRombo.Datos;
using SegundoParcialRombo.Entidades;

namespace SegundoParcialRombo.Windows
{
    public partial class frmRomboAE : Form
    {
        public frmRomboAE(RepositorioRombo repo)
        {
            InitializeComponent();
        }

        internal Rombo GetRombo()
        {
            throw new NotImplementedException();
        }

        internal void SetRombo(List<Rombo> rombos)
        {
            throw new NotImplementedException();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
        }


    }
}
