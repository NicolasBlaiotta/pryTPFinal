using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pryTPFinal;
using pryTPFinal.Clases;

namespace pryTPFinal
{
    public partial class Form1 : Form
    {
        verduleros Verduleros = new verduleros();
        public Form1()
        {
            Verduleros.Conectar();
            InitializeComponent();
            Verduleros.mostrar(dataGridView1);
            lblConectado.Text = Verduleros.estadoconexion;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Verduleros.Buscar(textBox1, dataGridView1);

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Verduleros.modificar(textBox1, textBox2);
        }

        private void btnEspacios_Click(object sender, EventArgs e)
        {
            textBox1.Text.Trim();
            textBox2.Text.Trim();
        }
    }
}
