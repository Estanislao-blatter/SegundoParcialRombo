using SegundoParcialRombo.Datos;
using SegundoParcialRombo.Entidades;

namespace SegundoParcialRombo.Windows
{
    public partial class frmRombos : Form
    {
        private RepositorioRombo repo = null!;
        private List<Rombo> rombos;
        public frmRombos(RepositorioRombo repo)
        {
            InitializeComponent();
            repo = new RepositorioRombo();
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmRomboAE frm = new frmRomboAE(repo) { Text = "Agregar Rombo" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            Rombo rombo = frm.GetRombo();
            try
            {
                if (!repo.Existe(rombo))
                {
                    repo.AgregarRombo(rombo);
                    DataGridViewRow r = ConstruirFila(dgvDatos);
                    SetearFila(r, rombo);
                    AgregarFila(r, dgvDatos);
                    MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Registro Existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Algún Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetearFila(DataGridViewRow r, Rombo obj)
        {
            r.Cells[0].Value = obj.DiagonalMayor;
            r.Cells[1].Value = obj.DiagonalMenor;
            r.Cells[2].Value = obj.Contorno().ToString();
            r.Cells[3].Value = obj.CalcLado().ToString();
            r.Cells[4].Value = obj.CalcPerimetro().ToString();
            r.Cells[5].Value = obj.CalcArea().ToString();

            r.Tag = obj;
        }

        private void AgregarFila(DataGridViewRow r, DataGridView dgv)
        {
            dgv.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila(DataGridView grid)
        {
            var r = new DataGridViewRow();
            r.CreateCells(grid);
            return r;
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0) { return; }
            DataGridViewRow r = dgvDatos.SelectedRows[0];
            Rombo rombo = (Rombo)r.Tag!;
            DialogResult dr = MessageBox.Show("¿Desea Eliminar El Rombo?", "Confirmar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                repo.EliminarRombo(rombo);
                EliminarFila(dgvDatos, r);
                MessageBox.Show("Registro Borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Algún Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarFila(DataGridView grid, DataGridViewRow r)
        {
            grid.Rows.Remove(r);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0) { return; }
            DataGridViewRow r = dgvDatos.SelectedRows[0];
            frmRomboAE frm = new frmRomboAE(repo) { Text = "Editar Rombo" };
            frm.SetRombo(rombos);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                Rombo rombo = frm.GetRombo();
                SetearFila(r, rombo);
                MessageBox.Show("Registro Editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Algún Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarComboContornos(ref ToolStripComboBox tsCboBordes)
        {
            var listaBordes = Enum.GetValues(typeof(Contorno));
            foreach (var item in listaBordes)
            {
                tsCboBordes.Items.Add(item);
            }
            tsCboBordes.DropDownStyle = ComboBoxStyle.DropDownList;
            tsCboBordes.SelectedIndex = 0;

        }


        private void lado09ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void lado90ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            rombos = repo.ObtenerRombos();
            MostrarDatosGrilla();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            repo.GuardarDatos();
            MessageBox.Show("Fin del programa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void frmElipses_Load(object sender, EventArgs e)
        {
            CargarComboContornos(ref tsCboContornos);

        }

        private void tsbNuevo_Click_1(object sender, EventArgs e)
        {

        }
        private void MostrarDatosGrilla()
        {
            limpiarGrilla(dgvDatos);
            foreach (var item in rombos)
            {
                var r = ConstruirFila(dgvDatos);
                SetearFila(r, item);
                AgregarFila(r, dgvDatos);
            }
        }

        private void limpiarGrilla(DataGridView grid)
        {
            grid.Rows.Clear();
        }
    }
}
