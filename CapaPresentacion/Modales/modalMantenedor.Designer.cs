namespace CapaPresentacion.Modales
{
    partial class modalMantenedor
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
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.btnCerrarModalMantenedor = new FontAwesome.Sharp.IconButton();
            this.label6 = new System.Windows.Forms.Label();
            this.btnModalProductos = new FontAwesome.Sharp.IconButton();
            this.btnModalCategorias = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.SteelBlue;
            this.iconButton2.Enabled = false;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.ForeColor = System.Drawing.Color.Coral;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Box;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.Location = new System.Drawing.Point(5, 8);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(67, 63);
            this.iconButton2.TabIndex = 81;
            this.iconButton2.UseVisualStyleBackColor = false;
            // 
            // btnCerrarModalMantenedor
            // 
            this.btnCerrarModalMantenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarModalMantenedor.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCerrarModalMantenedor.FlatAppearance.BorderSize = 0;
            this.btnCerrarModalMantenedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarModalMantenedor.ForeColor = System.Drawing.Color.Coral;
            this.btnCerrarModalMantenedor.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.btnCerrarModalMantenedor.IconColor = System.Drawing.Color.White;
            this.btnCerrarModalMantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrarModalMantenedor.Location = new System.Drawing.Point(325, 14);
            this.btnCerrarModalMantenedor.Name = "btnCerrarModalMantenedor";
            this.btnCerrarModalMantenedor.Size = new System.Drawing.Size(67, 50);
            this.btnCerrarModalMantenedor.TabIndex = 80;
            this.btnCerrarModalMantenedor.UseVisualStyleBackColor = false;
            this.btnCerrarModalMantenedor.Click += new System.EventHandler(this.btnCerrarModalConfiguraciones_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, -2);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(66, 0, 0, 0);
            this.label6.Size = new System.Drawing.Size(405, 75);
            this.label6.TabIndex = 79;
            this.label6.Text = "Mantenedor";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnModalProductos
            // 
            this.btnModalProductos.BackColor = System.Drawing.Color.SteelBlue;
            this.btnModalProductos.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnModalProductos.FlatAppearance.BorderSize = 2;
            this.btnModalProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModalProductos.ForeColor = System.Drawing.Color.White;
            this.btnModalProductos.IconChar = FontAwesome.Sharp.IconChar.BoxesAlt;
            this.btnModalProductos.IconColor = System.Drawing.Color.White;
            this.btnModalProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnModalProductos.Location = new System.Drawing.Point(122, 195);
            this.btnModalProductos.Name = "btnModalProductos";
            this.btnModalProductos.Size = new System.Drawing.Size(169, 55);
            this.btnModalProductos.TabIndex = 77;
            this.btnModalProductos.Text = "Productos";
            this.btnModalProductos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModalProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModalProductos.UseVisualStyleBackColor = false;
            this.btnModalProductos.Click += new System.EventHandler(this.btnModalProductos_Click);
            // 
            // btnModalCategorias
            // 
            this.btnModalCategorias.BackColor = System.Drawing.Color.SteelBlue;
            this.btnModalCategorias.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnModalCategorias.FlatAppearance.BorderSize = 2;
            this.btnModalCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModalCategorias.ForeColor = System.Drawing.Color.White;
            this.btnModalCategorias.IconChar = FontAwesome.Sharp.IconChar.Clipboard;
            this.btnModalCategorias.IconColor = System.Drawing.Color.White;
            this.btnModalCategorias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnModalCategorias.Location = new System.Drawing.Point(122, 119);
            this.btnModalCategorias.Name = "btnModalCategorias";
            this.btnModalCategorias.Size = new System.Drawing.Size(169, 55);
            this.btnModalCategorias.TabIndex = 76;
            this.btnModalCategorias.Text = "Categorias";
            this.btnModalCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModalCategorias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModalCategorias.UseVisualStyleBackColor = false;
            this.btnModalCategorias.Click += new System.EventHandler(this.btnModalCategorias_Click);
            // 
            // modalMantenedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 298);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.btnCerrarModalMantenedor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnModalProductos);
            this.Controls.Add(this.btnModalCategorias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "modalMantenedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.modalMantenedor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton btnCerrarModalMantenedor;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton btnModalProductos;
        private FontAwesome.Sharp.IconButton btnModalCategorias;
    }
}