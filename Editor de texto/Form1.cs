using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor_de_texto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void nuevaVentanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 nueva = new Form1();
            nueva.Show();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                richTextBox1.Text = File.ReadAllText(ofd.FileName);
        }

        private void guardaeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
                File.WriteAllText(sfd.FileName, richTextBox1.Text);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CerrarVentanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deshacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void repetirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void fuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = richTextBox1.Font;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void colorDeFuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version beta" + "\n" + "Hecho por: Jesus Alonso");
        }

        private void lexicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsLexico objLexico = new ClsLexico();
            objLexico.RecorrerCodigo(richTextBox1.Text);
            TablaLexico forma = new TablaLexico(richTextBox1.Text);
            forma.ShowDialog();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            ClsSintacitico objSintactico = new ClsSintacitico();

            var tablas = objSintactico.RecorrerCodigo(richTextBox1.Text);
            DataTable tablaTokens = tablas.Item1;
            DataTable tablaErrores = tablas.Item2;

            var tablasSint = objSintactico.RecorrerSintactico(tablaTokens, tablaErrores);
            DataTable tablaSintactica = tablasSint.Item1;
            tablaErrores = tablasSint.Item2;

            dgvPalabras.DataSource = tablaTokens;    
            dgvErrores.DataSource = tablaErrores;   
            dgvSintactico.DataSource = tablaSintactica; 
        }
    }
}
