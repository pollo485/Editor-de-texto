using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor_de_texto
{
    public partial class TablaLexico : Form
    {
        string editor;

        public TablaLexico(string texto)
        {
            InitializeComponent();
            editor = texto;
        }

        private void TablaLexico_Load(object sender, EventArgs e)
        {
            ClsLexico objLexico =  new ClsLexico();
            dataGridView1.DataSource = objLexico.RecorrerCodigo(editor);

        }
    }
}
