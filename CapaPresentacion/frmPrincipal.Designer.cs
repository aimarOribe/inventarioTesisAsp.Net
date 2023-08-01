namespace CapaPresentacion
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.menuAcercaDe = new FontAwesome.Sharp.IconButton();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.menuVenta = new FontAwesome.Sharp.IconButton();
            this.menuCompra = new FontAwesome.Sharp.IconButton();
            this.menuMantenedor = new FontAwesome.Sharp.IconButton();
            this.menuProveedor = new FontAwesome.Sharp.IconButton();
            this.menuReporte = new FontAwesome.Sharp.IconButton();
            this.menuConfiguraciones = new FontAwesome.Sharp.IconButton();
            this.menuCliente = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(640, 90);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "AimMark Production";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Location = new System.Drawing.Point(0, 90);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip2.Size = new System.Drawing.Size(640, 30);
            this.menuStrip2.TabIndex = 4;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // menuAcercaDe
            // 
            this.menuAcercaDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuAcercaDe.BackColor = System.Drawing.Color.SteelBlue;
            this.menuAcercaDe.FlatAppearance.BorderSize = 3;
            this.menuAcercaDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuAcercaDe.ForeColor = System.Drawing.Color.White;
            this.menuAcercaDe.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuAcercaDe.IconColor = System.Drawing.Color.White;
            this.menuAcercaDe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuAcercaDe.IconSize = 40;
            this.menuAcercaDe.Location = new System.Drawing.Point(550, 12);
            this.menuAcercaDe.Name = "menuAcercaDe";
            this.menuAcercaDe.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.menuAcercaDe.Size = new System.Drawing.Size(78, 66);
            this.menuAcercaDe.TabIndex = 9;
            this.menuAcercaDe.Text = "Info";
            this.menuAcercaDe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuAcercaDe.UseVisualStyleBackColor = false;
            this.menuAcercaDe.Click += new System.EventHandler(this.menuAcercaDe_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSalir.FlatAppearance.BorderSize = 3;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnSalir.IconColor = System.Drawing.Color.White;
            this.btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSalir.IconSize = 40;
            this.btnSalir.Location = new System.Drawing.Point(560, 372);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnSalir.Size = new System.Drawing.Size(68, 66);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(30, 90);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label2.Size = new System.Drawing.Size(144, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Usuario Conectado:";
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(486, 90);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.lblFecha.Size = new System.Drawing.Size(45, 23);
            this.lblFecha.TabIndex = 13;
            this.lblFecha.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(426, 90);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label3.Size = new System.Drawing.Size(54, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Fecha:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(180, 90);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.lblUsuario.Size = new System.Drawing.Size(54, 23);
            this.lblUsuario.TabIndex = 11;
            this.lblUsuario.Text = "Usuario";
            // 
            // menuVenta
            // 
            this.menuVenta.BackColor = System.Drawing.Color.SteelBlue;
            this.menuVenta.FlatAppearance.BorderSize = 3;
            this.menuVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuVenta.ForeColor = System.Drawing.Color.White;
            this.menuVenta.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuVenta.IconColor = System.Drawing.Color.White;
            this.menuVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuVenta.IconSize = 50;
            this.menuVenta.Location = new System.Drawing.Point(122, 177);
            this.menuVenta.Name = "menuVenta";
            this.menuVenta.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.menuVenta.Size = new System.Drawing.Size(99, 90);
            this.menuVenta.TabIndex = 14;
            this.menuVenta.Text = "Ventas";
            this.menuVenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuVenta.UseVisualStyleBackColor = false;
            this.menuVenta.Click += new System.EventHandler(this.menuVenta_Click);
            // 
            // menuCompra
            // 
            this.menuCompra.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.menuCompra.BackColor = System.Drawing.Color.SteelBlue;
            this.menuCompra.FlatAppearance.BorderSize = 3;
            this.menuCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuCompra.ForeColor = System.Drawing.Color.White;
            this.menuCompra.IconChar = FontAwesome.Sharp.IconChar.CartFlatbed;
            this.menuCompra.IconColor = System.Drawing.Color.White;
            this.menuCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuCompra.IconSize = 50;
            this.menuCompra.Location = new System.Drawing.Point(259, 177);
            this.menuCompra.Name = "menuCompra";
            this.menuCompra.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.menuCompra.Size = new System.Drawing.Size(99, 90);
            this.menuCompra.TabIndex = 15;
            this.menuCompra.Text = "Compras";
            this.menuCompra.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuCompra.UseVisualStyleBackColor = false;
            this.menuCompra.Click += new System.EventHandler(this.menuCompra_Click);
            // 
            // menuMantenedor
            // 
            this.menuMantenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuMantenedor.BackColor = System.Drawing.Color.SteelBlue;
            this.menuMantenedor.FlatAppearance.BorderSize = 3;
            this.menuMantenedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuMantenedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuMantenedor.ForeColor = System.Drawing.Color.White;
            this.menuMantenedor.IconChar = FontAwesome.Sharp.IconChar.Box;
            this.menuMantenedor.IconColor = System.Drawing.Color.White;
            this.menuMantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuMantenedor.IconSize = 50;
            this.menuMantenedor.Location = new System.Drawing.Point(396, 177);
            this.menuMantenedor.Name = "menuMantenedor";
            this.menuMantenedor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.menuMantenedor.Size = new System.Drawing.Size(99, 90);
            this.menuMantenedor.TabIndex = 16;
            this.menuMantenedor.Text = "Mantenedor";
            this.menuMantenedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuMantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuMantenedor.UseVisualStyleBackColor = false;
            this.menuMantenedor.Click += new System.EventHandler(this.menuMantenedor_Click);
            // 
            // menuProveedor
            // 
            this.menuProveedor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.menuProveedor.BackColor = System.Drawing.Color.SteelBlue;
            this.menuProveedor.FlatAppearance.BorderSize = 3;
            this.menuProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuProveedor.ForeColor = System.Drawing.Color.White;
            this.menuProveedor.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.menuProveedor.IconColor = System.Drawing.Color.White;
            this.menuProveedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuProveedor.IconSize = 50;
            this.menuProveedor.Location = new System.Drawing.Point(259, 300);
            this.menuProveedor.Name = "menuProveedor";
            this.menuProveedor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.menuProveedor.Size = new System.Drawing.Size(99, 90);
            this.menuProveedor.TabIndex = 17;
            this.menuProveedor.Text = "Proveedores";
            this.menuProveedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuProveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuProveedor.UseVisualStyleBackColor = false;
            this.menuProveedor.Click += new System.EventHandler(this.menuProveedor_Click);
            // 
            // menuReporte
            // 
            this.menuReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.menuReporte.BackColor = System.Drawing.Color.SteelBlue;
            this.menuReporte.FlatAppearance.BorderSize = 3;
            this.menuReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuReporte.ForeColor = System.Drawing.Color.White;
            this.menuReporte.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            this.menuReporte.IconColor = System.Drawing.Color.White;
            this.menuReporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuReporte.IconSize = 50;
            this.menuReporte.Location = new System.Drawing.Point(396, 300);
            this.menuReporte.Name = "menuReporte";
            this.menuReporte.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.menuReporte.Size = new System.Drawing.Size(99, 90);
            this.menuReporte.TabIndex = 18;
            this.menuReporte.Text = "Reportes";
            this.menuReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuReporte.UseVisualStyleBackColor = false;
            this.menuReporte.Click += new System.EventHandler(this.menuReporte_Click);
            // 
            // menuConfiguraciones
            // 
            this.menuConfiguraciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuConfiguraciones.BackColor = System.Drawing.Color.SteelBlue;
            this.menuConfiguraciones.FlatAppearance.BorderSize = 3;
            this.menuConfiguraciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuConfiguraciones.ForeColor = System.Drawing.Color.White;
            this.menuConfiguraciones.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.menuConfiguraciones.IconColor = System.Drawing.Color.White;
            this.menuConfiguraciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuConfiguraciones.IconSize = 40;
            this.menuConfiguraciones.Location = new System.Drawing.Point(444, 12);
            this.menuConfiguraciones.Name = "menuConfiguraciones";
            this.menuConfiguraciones.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.menuConfiguraciones.Size = new System.Drawing.Size(99, 66);
            this.menuConfiguraciones.TabIndex = 19;
            this.menuConfiguraciones.Text = "Configuraciones";
            this.menuConfiguraciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuConfiguraciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuConfiguraciones.UseVisualStyleBackColor = false;
            this.menuConfiguraciones.Click += new System.EventHandler(this.menuConfiguraciones_Click);
            // 
            // menuCliente
            // 
            this.menuCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.menuCliente.BackColor = System.Drawing.Color.SteelBlue;
            this.menuCliente.FlatAppearance.BorderSize = 3;
            this.menuCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuCliente.ForeColor = System.Drawing.Color.White;
            this.menuCliente.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.menuCliente.IconColor = System.Drawing.Color.White;
            this.menuCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuCliente.IconSize = 50;
            this.menuCliente.Location = new System.Drawing.Point(122, 300);
            this.menuCliente.Name = "menuCliente";
            this.menuCliente.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.menuCliente.Size = new System.Drawing.Size(99, 90);
            this.menuCliente.TabIndex = 20;
            this.menuCliente.Text = "Clientes";
            this.menuCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuCliente.UseVisualStyleBackColor = false;
            this.menuCliente.Click += new System.EventHandler(this.menuCliente_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 450);
            this.Controls.Add(this.menuCliente);
            this.Controls.Add(this.menuConfiguraciones);
            this.Controls.Add(this.menuReporte);
            this.Controls.Add(this.menuProveedor);
            this.Controls.Add(this.menuMantenedor);
            this.Controls.Add(this.menuCompra);
            this.Controls.Add(this.menuVenta);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuAcercaDe);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrincipal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private FontAwesome.Sharp.IconButton menuAcercaDe;
        private FontAwesome.Sharp.IconButton btnSalir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUsuario;
        private FontAwesome.Sharp.IconButton menuVenta;
        private FontAwesome.Sharp.IconButton menuCompra;
        private FontAwesome.Sharp.IconButton menuMantenedor;
        private FontAwesome.Sharp.IconButton menuProveedor;
        private FontAwesome.Sharp.IconButton menuReporte;
        private FontAwesome.Sharp.IconButton menuConfiguraciones;
        private FontAwesome.Sharp.IconButton menuCliente;
    }
}