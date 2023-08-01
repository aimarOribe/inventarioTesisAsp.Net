using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Utilidades;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void cargarEstadoYRoles()
        {
            cboEstado.Items.Add(new OpcionCombo{Texto = "Activo", Valor = 1});
            cboEstado.Items.Add(new OpcionCombo{Texto = "No Activo",Valor = 0});
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Value";
            cboEstado.SelectedIndex = 0;

            List<Rol> listaRoles = new cnRol().ListarRoles();
            foreach (Rol item in listaRoles)
            {
                cboRol.Items.Add(new OpcionCombo{Texto = item.DESCRIPCION, Valor = item.IDROL});
            }
            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Value";
            cboRol.SelectedIndex = 0;
        }

        private void cargarBusquedaColumnasTablaUsuarios()
        {
            foreach (DataGridViewColumn columna in dgvUsuarios.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cboBusqueda.Items.Add(new OpcionCombo { Texto = columna.HeaderText, Valor = columna.Name });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Value";
            cboBusqueda.SelectedIndex = 0;
        }

        private void cargarUsuariosEnTablaUsuarios()
        {
            List<Usuario> listaUsuarios = new cnUsuario().ListarUsuarios();
            foreach (Usuario item in listaUsuarios)
            {
                dgvUsuarios.Rows.Add(new object[] { "", item.IDUSUARIO, item.DOCUMENTO, item.NOMBRECOMPLETO, item.CORREO, item.CLAVE,
                    item.oROL.IDROL,
                    item.oROL.DESCRIPCION,
                    item.ESTADO == true ? 1 : 0,
                    item.ESTADO == true ? "Activo" : "No Activo"
                });
            }
        }

        private void limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtDocumento.Text = "";
            txtNombreCompleto.Text = "";
            txtCorreo.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            cboRol.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
            txtDocumento.Select();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cargarEstadoYRoles();
            cargarBusquedaColumnasTablaUsuarios();
            cargarUsuariosEnTablaUsuarios();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            if (txtClave.Text.Trim() != txtConfirmarClave.Text.Trim())
            {
                MessageBox.Show("Las claves no coinciden, vuelva a ingresarlas correctamente");
            }
            else
            {
                Usuario usuario = new Usuario
                {
                    IDUSUARIO = Convert.ToInt32(txtId.Text),
                    DOCUMENTO = txtDocumento.Text,
                    NOMBRECOMPLETO = txtNombreCompleto.Text,
                    CORREO = txtCorreo.Text,
                    CLAVE = txtClave.Text,
                    oROL = new Rol { IDROL = Convert.ToInt32(((OpcionCombo)cboRol.SelectedItem).Valor) },
                    ESTADO = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false
                };

                if (usuario.IDUSUARIO == 0)
                {
                    int idUsuarioGenerado = new cnUsuario().RegistrarUsuario(usuario, out mensaje);

                    if (idUsuarioGenerado != 0)
                    {
                        dgvUsuarios.Rows.Add(new object[] { "", idUsuarioGenerado, txtDocumento.Text, txtNombreCompleto.Text, txtCorreo.Text, txtClave.Text,
                    ((OpcionCombo)cboRol.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cboRol.SelectedItem).Texto.ToString(),
                    ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString()
                    });
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                }
                else
                {
                    bool resultado = new cnUsuario().EditarUsuario(usuario, out mensaje);
                    if (resultado)
                    {
                        DataGridViewRow row = dgvUsuarios.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["IdUsuario"].Value = txtId.Text;
                        row.Cells["Documento"].Value = txtDocumento.Text;
                        row.Cells["NombreCompleto"].Value = txtNombreCompleto.Text;
                        row.Cells["Correo"].Value = txtCorreo.Text;
                        row.Cells["Clave"].Value = txtClave.Text;
                        row.Cells["IdRol"].Value = ((OpcionCombo)cboRol.SelectedItem).Valor.ToString();
                        row.Cells["Rol"].Value = ((OpcionCombo)cboRol.SelectedItem).Texto.ToString();
                        row.Cells["EstadoValor"].Value = ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString();
                        row.Cells["Estado"].Value = ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString();
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                }
            }
        }

        private void dgvUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.check.Width;
                var h = Properties.Resources.check.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x,y,w,h));
                e.Handled = true;
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if(indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvUsuarios.Rows[indice].Cells["IdUsuario"].Value.ToString();
                    txtDocumento.Text = dgvUsuarios.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombreCompleto.Text = dgvUsuarios.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgvUsuarios.Rows[indice].Cells["Correo"].Value.ToString();
                    txtClave.Text = dgvUsuarios.Rows[indice].Cells["Clave"].Value.ToString();
                    txtConfirmarClave.Text = dgvUsuarios.Rows[indice].Cells["Clave"].Value.ToString();
                    foreach (OpcionCombo oc in cboRol.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvUsuarios.Rows[indice].Cells["IdRol"].Value.ToString()))
                        {
                            int indiceCombo = cboRol.Items.IndexOf(oc);
                            cboRol.SelectedIndex = indiceCombo;
                            break;
                        }
                    }
                    foreach (OpcionCombo oc in cboEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvUsuarios.Rows[indice].Cells["EstadoValor"].Value.ToString()))
                        {
                            int indiceCombo = cboEstado.Items.IndexOf(oc);
                            cboEstado.SelectedIndex = indiceCombo;
                            break;
                        }
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtId.Text) != 0)
            {
                if(MessageBox.Show("¿Desea eliminar al usuario?","Eliminar",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Usuario usuario = new Usuario{ IDUSUARIO = Convert.ToInt32(txtId.Text)};
                    bool respuesta = new cnUsuario().EliminarUsuario(usuario, out mensaje);
                    if(respuesta)
                    {
                        dgvUsuarios.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();
            if (dgvUsuarios.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvUsuarios.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach (DataGridViewRow row in dgvUsuarios.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnCerrarFormularioUsuarios_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
