namespace Editor_de_texto
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaVentanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardaeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ediciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cortarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deshacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repetirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fuenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDeFuenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.análisisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lexicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvErrores = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvPalabras = new System.Windows.Forms.DataGridView();
            this.dgvSintactico = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvVariables = new System.Windows.Forms.DataGridView();
            this.listBLista = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalabras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSintactico)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariables)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ediciónToolStripMenuItem,
            this.formatoToolStripMenuItem,
            this.análisisToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1071, 42);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaVentanaToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardaeToolStripMenuItem,
            this.sToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(110, 36);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevaVentanaToolStripMenuItem
            // 
            this.nuevaVentanaToolStripMenuItem.Name = "nuevaVentanaToolStripMenuItem";
            this.nuevaVentanaToolStripMenuItem.Size = new System.Drawing.Size(280, 40);
            this.nuevaVentanaToolStripMenuItem.Text = "Nueva Ventana";
            this.nuevaVentanaToolStripMenuItem.Click += new System.EventHandler(this.nuevaVentanaToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(280, 40);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardaeToolStripMenuItem
            // 
            this.guardaeToolStripMenuItem.Name = "guardaeToolStripMenuItem";
            this.guardaeToolStripMenuItem.Size = new System.Drawing.Size(280, 40);
            this.guardaeToolStripMenuItem.Text = "Guardar";
            this.guardaeToolStripMenuItem.Click += new System.EventHandler(this.guardaeToolStripMenuItem_Click);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(280, 40);
            this.sToolStripMenuItem.Text = "Cerrar ventana";
            this.sToolStripMenuItem.Click += new System.EventHandler(this.CerrarVentanaToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(280, 40);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ediciónToolStripMenuItem
            // 
            this.ediciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cortarToolStripMenuItem,
            this.copiarToolStripMenuItem,
            this.pegarToolStripMenuItem,
            this.deshacerToolStripMenuItem,
            this.repetirToolStripMenuItem});
            this.ediciónToolStripMenuItem.Name = "ediciónToolStripMenuItem";
            this.ediciónToolStripMenuItem.Size = new System.Drawing.Size(107, 36);
            this.ediciónToolStripMenuItem.Text = "Edición";
            // 
            // cortarToolStripMenuItem
            // 
            this.cortarToolStripMenuItem.Name = "cortarToolStripMenuItem";
            this.cortarToolStripMenuItem.Size = new System.Drawing.Size(216, 40);
            this.cortarToolStripMenuItem.Text = "Cortar";
            this.cortarToolStripMenuItem.Click += new System.EventHandler(this.cortarToolStripMenuItem_Click);
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(216, 40);
            this.copiarToolStripMenuItem.Text = "Copiar";
            this.copiarToolStripMenuItem.Click += new System.EventHandler(this.copiarToolStripMenuItem_Click);
            // 
            // pegarToolStripMenuItem
            // 
            this.pegarToolStripMenuItem.Name = "pegarToolStripMenuItem";
            this.pegarToolStripMenuItem.Size = new System.Drawing.Size(216, 40);
            this.pegarToolStripMenuItem.Text = "Pegar";
            this.pegarToolStripMenuItem.Click += new System.EventHandler(this.pegarToolStripMenuItem_Click);
            // 
            // deshacerToolStripMenuItem
            // 
            this.deshacerToolStripMenuItem.Name = "deshacerToolStripMenuItem";
            this.deshacerToolStripMenuItem.Size = new System.Drawing.Size(216, 40);
            this.deshacerToolStripMenuItem.Text = "Deshacer";
            this.deshacerToolStripMenuItem.Click += new System.EventHandler(this.deshacerToolStripMenuItem_Click);
            // 
            // repetirToolStripMenuItem
            // 
            this.repetirToolStripMenuItem.Name = "repetirToolStripMenuItem";
            this.repetirToolStripMenuItem.Size = new System.Drawing.Size(216, 40);
            this.repetirToolStripMenuItem.Text = "Repetir";
            this.repetirToolStripMenuItem.Click += new System.EventHandler(this.repetirToolStripMenuItem_Click);
            // 
            // formatoToolStripMenuItem
            // 
            this.formatoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fuenteToolStripMenuItem,
            this.colorDeFuenteToolStripMenuItem});
            this.formatoToolStripMenuItem.Name = "formatoToolStripMenuItem";
            this.formatoToolStripMenuItem.Size = new System.Drawing.Size(119, 36);
            this.formatoToolStripMenuItem.Text = "Formato";
            // 
            // fuenteToolStripMenuItem
            // 
            this.fuenteToolStripMenuItem.Name = "fuenteToolStripMenuItem";
            this.fuenteToolStripMenuItem.Size = new System.Drawing.Size(286, 40);
            this.fuenteToolStripMenuItem.Text = "Fuente";
            this.fuenteToolStripMenuItem.Click += new System.EventHandler(this.fuenteToolStripMenuItem_Click);
            // 
            // colorDeFuenteToolStripMenuItem
            // 
            this.colorDeFuenteToolStripMenuItem.Name = "colorDeFuenteToolStripMenuItem";
            this.colorDeFuenteToolStripMenuItem.Size = new System.Drawing.Size(286, 40);
            this.colorDeFuenteToolStripMenuItem.Text = "Color de fuente";
            this.colorDeFuenteToolStripMenuItem.Click += new System.EventHandler(this.colorDeFuenteToolStripMenuItem_Click);
            // 
            // análisisToolStripMenuItem
            // 
            this.análisisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lexicoToolStripMenuItem});
            this.análisisToolStripMenuItem.Name = "análisisToolStripMenuItem";
            this.análisisToolStripMenuItem.Size = new System.Drawing.Size(109, 36);
            this.análisisToolStripMenuItem.Text = "Análisis";
            // 
            // lexicoToolStripMenuItem
            // 
            this.lexicoToolStripMenuItem.Name = "lexicoToolStripMenuItem";
            this.lexicoToolStripMenuItem.Size = new System.Drawing.Size(184, 40);
            this.lexicoToolStripMenuItem.Text = "Lexico";
            this.lexicoToolStripMenuItem.Click += new System.EventHandler(this.lexicoToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(97, 36);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(222, 40);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 42);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1071, 523);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Peru;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(531, 307);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(540, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(528, 307);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvErrores);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 316);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 204);
            this.panel1.TabIndex = 4;
            // 
            // dgvErrores
            // 
            this.dgvErrores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvErrores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvErrores.Location = new System.Drawing.Point(0, 0);
            this.dgvErrores.Margin = new System.Windows.Forms.Padding(4);
            this.dgvErrores.Name = "dgvErrores";
            this.dgvErrores.RowHeadersVisible = false;
            this.dgvErrores.RowHeadersWidth = 62;
            this.dgvErrores.RowTemplate.Height = 28;
            this.dgvErrores.Size = new System.Drawing.Size(531, 204);
            this.dgvErrores.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(540, 316);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(528, 204);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvPalabras);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(522, 147);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvSintactico);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 156);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(522, 148);
            this.panel5.TabIndex = 1;
            // 
            // dgvPalabras
            // 
            this.dgvPalabras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPalabras.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPalabras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPalabras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPalabras.Location = new System.Drawing.Point(0, 0);
            this.dgvPalabras.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPalabras.Name = "dgvPalabras";
            this.dgvPalabras.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPalabras.RowHeadersVisible = false;
            this.dgvPalabras.RowHeadersWidth = 62;
            this.dgvPalabras.RowTemplate.Height = 28;
            this.dgvPalabras.Size = new System.Drawing.Size(522, 147);
            this.dgvPalabras.TabIndex = 6;
            // 
            // dgvSintactico
            // 
            this.dgvSintactico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSintactico.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSintactico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSintactico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSintactico.Location = new System.Drawing.Point(0, 0);
            this.dgvSintactico.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSintactico.Name = "dgvSintactico";
            this.dgvSintactico.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSintactico.RowHeadersVisible = false;
            this.dgvSintactico.RowHeadersWidth = 62;
            this.dgvSintactico.RowTemplate.Height = 28;
            this.dgvSintactico.Size = new System.Drawing.Size(522, 148);
            this.dgvSintactico.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvVariables);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(205, 198);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listBLista);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(214, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(311, 198);
            this.panel3.TabIndex = 1;
            // 
            // dgvVariables
            // 
            this.dgvVariables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvVariables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVariables.Location = new System.Drawing.Point(0, 0);
            this.dgvVariables.Margin = new System.Windows.Forms.Padding(4);
            this.dgvVariables.Name = "dgvVariables";
            this.dgvVariables.RowHeadersVisible = false;
            this.dgvVariables.RowHeadersWidth = 62;
            this.dgvVariables.RowTemplate.Height = 28;
            this.dgvVariables.Size = new System.Drawing.Size(205, 198);
            this.dgvVariables.TabIndex = 7;
            // 
            // listBLista
            // 
            this.listBLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBLista.FormattingEnabled = true;
            this.listBLista.ItemHeight = 29;
            this.listBLista.Location = new System.Drawing.Point(0, 0);
            this.listBLista.Name = "listBLista";
            this.listBLista.Size = new System.Drawing.Size(311, 198);
            this.listBLista.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(80)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1071, 565);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.Text = "Editor de texto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalabras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSintactico)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaVentanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardaeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ediciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cortarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pegarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deshacerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repetirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fuenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorDeFuenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem análisisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem lexicoToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvSintactico;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvPalabras;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvErrores;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBLista;
        private System.Windows.Forms.DataGridView dgvVariables;
    }
}

