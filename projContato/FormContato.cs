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

        Contato contato;
        Fone fone;
        Contatos lista;
        public DataGridView dataGridViewFones2;

        public FormContato() {
            InitializeComponent();

            contato = new Contato();
            fone = new Fone();
            lista = new Contatos();

            this.Size = new System.Drawing.Size(344, 427);
            comboBoxTipo.SelectedIndex = 0;
        }
        private void ButtonNovo_Click(object sender, EventArgs e) {
            LimparForm();
        }
            
        private void ButtonAdicionar_Click(object sender, EventArgs e) {
            this.Size = new System.Drawing.Size(572, 427);
        }

        private void ButtonPesquisar_Click(object sender, EventArgs e) {

            if(lista.MeusContatos.Contains(new Contato(textBoxEmail.Text))) {
                contato = lista.pesquisar(new Contato(textBoxEmail.Text));
         
                LimparForm();

                textBoxEmail.Text = contato.Email;
                textBoxNome.Text = contato.Nome;
                for (int i = 0; i < contato.Fones.Count; i++) {
                    dataGridViewFones.Rows.Add(contato.Fones[i].Numero, contato.Fones[i].Tipo);
                }
            } else {
                MessageBox.Show("Contato não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
   
        }

        private void FormContato_Load(object sender, EventArgs e) {
            
        }

        private void ButtonAdicionarFone_Click(object sender, EventArgs e)
        {
            dataGridViewFones.Rows.Add(textBoxNumero.Text,comboBoxTipo.SelectedItem);

            contato.adicionarFone(new Fone(textBoxNumero.Text, comboBoxTipo.Text));
            this.Size = new System.Drawing.Size(344, 427);
        }

        private void ButtonGravar_Click(object sender, EventArgs e) {
            contato.Email = textBoxEmail.Text;
            contato.Nome = textBoxNome.Text;
            
            lista.adicionar(contato);

            if (lista.MeusContatos.Contains(new Contato(textBoxEmail.Text))) {
                lista.alterar(contato);
                MessageBox.Show("Contato alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                lista.adicionar(contato);
                MessageBox.Show("Contato criado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LimparForm();

        }

        private void ButtonExcluir_Click(object sender, EventArgs e) {
            if(lista.remover(new Contato(textBoxEmail.Text))) {
                MessageBox.Show("Contato removido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparForm();
            } else {
                MessageBox.Show("Contato não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimparForm() {
            textBoxEmail.Text = "";
            textBoxNome.Text = "";
            dataGridViewFones.Rows.Clear();
            textBoxNumero.Text = "";
            comboBoxTipo.SelectedIndex = 0;
        }

    }
}
