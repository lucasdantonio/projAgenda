using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projContato {
    public partial class FormContato : Form {

        Contato cont;
        Fone fone;
        Contatos listaContatos = new Contatos();
        public DataGridView dataGridViewFones2;

        public FormContato() {
            InitializeComponent();
            this.Size = new System.Drawing.Size(344, 427);
        }
        private void ButtonNovo_Click(object sender, EventArgs e) {
            textBoxEmail.Text = "";
            textBoxNome.Text = "";
            dataGridViewFones.Rows.Clear();
        }
            
        private void ButtonAdicionar_Click(object sender, EventArgs e) {
            this.Size = new System.Drawing.Size(572, 427);
        }

        private void ButtonPesquisar_Click(object sender, EventArgs e) {

        }

        private void FormContato_Load(object sender, EventArgs e) {
            
        }

        private void ButtonAdicionarFone_Click(object sender, EventArgs e)
        {
            dataGridViewFones.Rows.Add(textBoxNumero.Text,comboBoxTipo.SelectedItem);
            //cont.adicionarFone(new Fone(textBoxNumero.Text, comboBoxTipo.Text));
            this.Size = new System.Drawing.Size(344, 427);
        }

        private void ButtonGravar_Click(object sender, EventArgs e) {
            cont.Email = textBoxEmail.Text;
            cont.Nome = textBoxNome.Text;

            listaContatos.adicionar(cont);

        }
    }
}
