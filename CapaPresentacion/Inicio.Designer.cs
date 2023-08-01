namespace CapaPresentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuMantenedor = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuCategoria = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuProductos = new FontAwesome.Sharp.IconMenuItem();
            this.menuCliente = new FontAwesome.Sharp.IconMenuItem();
            this.menuProveedor = new FontAwesome.Sharp.IconMenuItem();
            this.menuCompra = new FontAwesome.Sharp.IconMenuItem();
            this.registrarCompraSubMenu = new FontAwesome.Sharp.IconMenuItem();
            this.detalleCompraSubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVenta = new FontAwesome.Sharp.IconMenuItem();
            this.registraVentaSubMenu = new FontAwesome.Sharp.IconMenuItem();
            this.detalleVentaSubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReporte = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuReporteCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuReporteVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfiguraciones = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuNegocio = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.btnInfo = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.subMenuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMantenedor,
            this.menuCliente,
            this.menuProveedor,
            this.menuCompra,
            this.menuVenta,
            this.menuReporte,
            this.menuConfiguraciones});
            this.menu.Location = new System.Drawing.Point(0, 94);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(977, 73);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuMantenedor
            // 
            this.menuMantenedor.AutoSize = false;
            this.menuMantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuCategoria,
            this.subMenuProductos});
            this.menuMantenedor.IconChar = FontAwesome.Sharp.IconChar.Box;
            this.menuMantenedor.IconColor = System.Drawing.Color.Black;
            this.menuMantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuMantenedor.IconSize = 50;
            this.menuMantenedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuMantenedor.Name = "menuMantenedor";
            this.menuMantenedor.Size = new System.Drawing.Size(80, 69);
            this.menuMantenedor.Text = "Mantenedor";
            this.menuMantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // subMenuCategoria
            // 
            this.subMenuCategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subMenuCategoria.IconColor = System.Drawing.Color.Black;
            this.subMenuCategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuCategoria.Name = "subMenuCategoria";
            this.subMenuCategoria.Size = new System.Drawing.Size(130, 22);
            this.subMenuCategoria.Text = "Categorias";
            this.subMenuCategoria.Click += new System.EventHandler(this.subMenuCategoria_Click);
            // 
            // subMenuProductos
            // 
            this.subMenuProductos.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subMenuProductos.IconColor = System.Drawing.Color.Black;
            this.subMenuProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuProductos.Name = "subMenuProductos";
            this.subMenuProductos.Size = new System.Drawing.Size(130, 22);
            this.subMenuProductos.Text = "Productos";
            this.subMenuProductos.Click += new System.EventHandler(this.subMenuProductos_Click);
            // 
            // menuCliente
            // 
            this.menuCliente.AutoSize = false;
            this.menuCliente.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.menuCliente.IconColor = System.Drawing.Color.Black;
            this.menuCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuCliente.IconSize = 50;
            this.menuCliente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuCliente.Name = "menuCliente";
            this.menuCliente.Size = new System.Drawing.Size(80, 69);
            this.menuCliente.Text = "Clientes";
            this.menuCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuCliente.Click += new System.EventHandler(this.menuCliente_Click);
            // 
            // menuProveedor
            // 
            this.menuProveedor.AutoSize = false;
            this.menuProveedor.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.menuProveedor.IconColor = System.Drawing.Color.Black;
            this.menuProveedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuProveedor.IconSize = 50;
            this.menuProveedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProveedor.Name = "menuProveedor";
            this.menuProveedor.Size = new System.Drawing.Size(80, 69);
            this.menuProveedor.Text = "Proveedores";
            this.menuProveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuProveedor.Click += new System.EventHandler(this.menuProveedor_Click);
            // 
            // menuCompra
            // 
            this.menuCompra.AutoSize = false;
            this.menuCompra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarCompraSubMenu,
            this.detalleCompraSubMenu});
            this.menuCompra.IconChar = FontAwesome.Sharp.IconChar.CartFlatbed;
            this.menuCompra.IconColor = System.Drawing.Color.Black;
            this.menuCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuCompra.IconSize = 50;
            this.menuCompra.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuCompra.Name = "menuCompra";
            this.menuCompra.Size = new System.Drawing.Size(122, 69);
            this.menuCompra.Text = "Compras";
            this.menuCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // registrarCompraSubMenu
            // 
            this.registrarCompraSubMenu.IconChar = FontAwesome.Sharp.IconChar.None;
            this.registrarCompraSubMenu.IconColor = System.Drawing.Color.Black;
            this.registrarCompraSubMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.registrarCompraSubMenu.Name = "registrarCompraSubMenu";
            this.registrarCompraSubMenu.Size = new System.Drawing.Size(166, 22);
            this.registrarCompraSubMenu.Text = "Registrar Compra";
            this.registrarCompraSubMenu.Click += new System.EventHandler(this.registrarCompraSubMenu_Click);
            // 
            // detalleCompraSubMenu
            // 
            this.detalleCompraSubMenu.Name = "detalleCompraSubMenu";
            this.detalleCompraSubMenu.Size = new System.Drawing.Size(166, 22);
            this.detalleCompraSubMenu.Text = "Detalle Compra";
            this.detalleCompraSubMenu.Click += new System.EventHandler(this.detalleCompraSubMenu_Click);
            // 
            // menuVenta
            // 
            this.menuVenta.AutoSize = false;
            this.menuVenta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registraVentaSubMenu,
            this.detalleVentaSubMenu});
            this.menuVenta.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuVenta.IconColor = System.Drawing.Color.Black;
            this.menuVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuVenta.IconSize = 50;
            this.menuVenta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuVenta.Name = "menuVenta";
            this.menuVenta.Size = new System.Drawing.Size(80, 69);
            this.menuVenta.Text = "Ventas";
            this.menuVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // registraVentaSubMenu
            // 
            this.registraVentaSubMenu.IconChar = FontAwesome.Sharp.IconChar.None;
            this.registraVentaSubMenu.IconColor = System.Drawing.Color.Black;
            this.registraVentaSubMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.registraVentaSubMenu.Name = "registraVentaSubMenu";
            this.registraVentaSubMenu.Size = new System.Drawing.Size(152, 22);
            this.registraVentaSubMenu.Text = "Registrar Venta";
            this.registraVentaSubMenu.Click += new System.EventHandler(this.registraVentaSubMenu_Click);
            // 
            // detalleVentaSubMenu
            // 
            this.detalleVentaSubMenu.Name = "detalleVentaSubMenu";
            this.detalleVentaSubMenu.Size = new System.Drawing.Size(152, 22);
            this.detalleVentaSubMenu.Text = "Detalle Venta";
            this.detalleVentaSubMenu.Click += new System.EventHandler(this.detalleVentaSubMenu_Click);
            // 
            // menuReporte
            // 
            this.menuReporte.AutoSize = false;
            this.menuReporte.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuReporteCompras,
            this.subMenuReporteVentas});
            this.menuReporte.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            this.menuReporte.IconColor = System.Drawing.Color.Black;
            this.menuReporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuReporte.IconSize = 50;
            this.menuReporte.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuReporte.Name = "menuReporte";
            this.menuReporte.Size = new System.Drawing.Size(122, 69);
            this.menuReporte.Text = "Reportes";
            this.menuReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // subMenuReporteCompras
            // 
            this.subMenuReporteCompras.Name = "subMenuReporteCompras";
            this.subMenuReporteCompras.Size = new System.Drawing.Size(182, 22);
            this.subMenuReporteCompras.Text = "Reporte de Compras";
            this.subMenuReporteCompras.Click += new System.EventHandler(this.subMenuReporteCompras_Click);
            // 
            // subMenuReporteVentas
            // 
            this.subMenuReporteVentas.Name = "subMenuReporteVentas";
            this.subMenuReporteVentas.Size = new System.Drawing.Size(182, 22);
            this.subMenuReporteVentas.Text = "Reporte de Ventas";
            this.subMenuReporteVentas.Click += new System.EventHandler(this.subMenuReporteVentas_Click);
            // 
            // menuConfiguraciones
            // 
            this.menuConfiguraciones.AutoSize = false;
            this.menuConfiguraciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuNegocio,
            this.permisosToolStripMenuItem,
            this.subMenuUsuarios});
            this.menuConfiguraciones.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.menuConfiguraciones.IconColor = System.Drawing.Color.Black;
            this.menuConfiguraciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuConfiguraciones.IconSize = 50;
            this.menuConfiguraciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuConfiguraciones.Name = "menuConfiguraciones";
            this.menuConfiguraciones.Size = new System.Drawing.Size(122, 69);
            this.menuConfiguraciones.Text = "Configuraciones";
            this.menuConfiguraciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // subMenuNegocio
            // 
            this.subMenuNegocio.Name = "subMenuNegocio";
            this.subMenuNegocio.Size = new System.Drawing.Size(180, 22);
            this.subMenuNegocio.Text = "Negocio";
            this.subMenuNegocio.Click += new System.EventHandler(this.subMenuNegocio_Click_1);
            // 
            // permisosToolStripMenuItem
            // 
            this.permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            this.permisosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.permisosToolStripMenuItem.Text = "Permisos";
            this.permisosToolStripMenuItem.Click += new System.EventHandler(this.permisosToolStripMenuItem_Click);
            // 
            // menuTitulo
            // 
            this.menuTitulo.AutoSize = false;
            this.menuTitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.menuTitulo.Location = new System.Drawing.Point(0, 0);
            this.menuTitulo.Name = "menuTitulo";
            this.menuTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuTitulo.Size = new System.Drawing.Size(977, 94);
            this.menuTitulo.TabIndex = 1;
            this.menuTitulo.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "AimMark Production";
            // 
            // contenedor
            // 
            this.contenedor.BackColor = System.Drawing.SystemColors.Control;
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 167);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(977, 345);
            this.contenedor.TabIndex = 3;
            this.contenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.contenedor_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(27, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario Conectado:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.SteelBlue;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(177, 62);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(54, 16);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "Usuario";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSalir.FlatAppearance.BorderSize = 3;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnSalir.IconColor = System.Drawing.Color.White;
            this.btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSalir.IconSize = 40;
            this.btnSalir.Location = new System.Drawing.Point(897, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnSalir.Size = new System.Drawing.Size(68, 66);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInfo.BackColor = System.Drawing.Color.SteelBlue;
            this.btnInfo.FlatAppearance.BorderSize = 3;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.ForeColor = System.Drawing.Color.White;
            this.btnInfo.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.btnInfo.IconColor = System.Drawing.Color.White;
            this.btnInfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInfo.IconSize = 40;
            this.btnInfo.Location = new System.Drawing.Point(813, 12);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnInfo.Size = new System.Drawing.Size(68, 66);
            this.btnInfo.TabIndex = 7;
            this.btnInfo.Text = "Info";
            this.btnInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(486, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fecha:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.SteelBlue;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(546, 62);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(45, 16);
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "Fecha";
            // 
            // subMenuUsuarios
            // 
            this.subMenuUsuarios.Name = "subMenuUsuarios";
            this.subMenuUsuarios.Size = new System.Drawing.Size(180, 22);
            this.subMenuUsuarios.Text = "Usuarios";
            this.subMenuUsuarios.Click += new System.EventHandler(this.subMenuUsuarios_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 512);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menuTitulo);
            this.MainMenuStrip = this.menu;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menuTitulo;
        private FontAwesome.Sharp.IconMenuItem menuMantenedor;
        private FontAwesome.Sharp.IconMenuItem menuCliente;
        private FontAwesome.Sharp.IconMenuItem menuVenta;
        private FontAwesome.Sharp.IconMenuItem menuReporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuario;
        private FontAwesome.Sharp.IconMenuItem subMenuCategoria;
        private FontAwesome.Sharp.IconMenuItem subMenuProductos;
        private FontAwesome.Sharp.IconMenuItem registraVentaSubMenu;
        private System.Windows.Forms.ToolStripMenuItem detalleVentaSubMenu;
        private FontAwesome.Sharp.IconMenuItem menuProveedor;
        private FontAwesome.Sharp.IconMenuItem menuCompra;
        private FontAwesome.Sharp.IconMenuItem registrarCompraSubMenu;
        private System.Windows.Forms.ToolStripMenuItem detalleCompraSubMenu;
        private System.Windows.Forms.ToolStripMenuItem subMenuReporteCompras;
        private System.Windows.Forms.ToolStripMenuItem subMenuReporteVentas;
        private FontAwesome.Sharp.IconMenuItem menuConfiguraciones;
        private System.Windows.Forms.ToolStripMenuItem subMenuNegocio;
        private FontAwesome.Sharp.IconButton btnSalir;
        private System.Windows.Forms.ToolStripMenuItem permisosToolStripMenuItem;
        private FontAwesome.Sharp.IconButton btnInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ToolStripMenuItem subMenuUsuarios;
    }
}

