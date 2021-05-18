using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugBakery.com.merda.BugBakery.ADO;
using System.Windows.Forms;
using System.Data;


namespace BugBakery
{
    public class Cliente : Pessoa
    {
        public string dtCadastro { get; set; }

        public bool verificaDesconto()
        {
            bool retorno = false;
            DateTime dataDia = DateTime.Now;
            DateTime dia = Convert.ToDateTime(this.dtCadastro);

            int dias = dataDia.Subtract(dia).Days;
            if (dias > 180)
            {
                retorno = true;
            }
            return retorno;
        }

        public override long Cadastrar()
        {
            long id = new long();
            try
            {
                TConnect c = new TConnect();
                c.Sql = "insert into cliente(nome,cpf,dtcadastro)values('" + this.Nome + "','" + this.Cpf + "','" + this.dtCadastro + "')";
                id = c.Inserir();
                MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao acessar Banco de dados: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return id;
        }

        public override DataTable Pesquisar(string nome)
        {
            DataTable tclientes = new DataTable();
            try
            {
                TConnect conn = new TConnect();
                conn.Sql = "select codigo,nome,cpf,dtcadastro as cadastro from cliente where nome Like '%" + nome + "%'";
                tclientes = conn.selecionar();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao acessar Banco de dados: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tclientes;
        }
        public override DataTable Pesquisar(long cpf)
        {
            DataTable tclientes = new DataTable();
            try
            {
                TConnect conn = new TConnect();
                conn.Sql = "select codigo,nome,cpf,dtcadastro as cadastro from cliente where cpf = '" + cpf + "'";
                tclientes = conn.selecionar();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao acessar Banco de dados: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tclientes;
        }

        public override DataTable UpdateGrid()
        {
            DataTable tclientes = new DataTable();
            try
            {
                TConnect conn = new TConnect();
                conn.Sql = "select codigo,nome,cpf,dtcadastro as cadastro from cliente";
                tclientes = conn.selecionar();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao acessar Banco de dados: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tclientes;
        }

        public override long Editar()
        {
            long id = new long();
            try
            {
                TConnect c = new TConnect();
                c.Sql = "update cliente set nome ='" + this.Nome + "',cpf = '" + this.Cpf + "',dtcadastro ='" + this.dtCadastro + "' where codigo = '" + this.Codigo + "'";
                id = c.UpdateSql();
                MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao acessar Banco de dados: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return id;
        }
    }
}