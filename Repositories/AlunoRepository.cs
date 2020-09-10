using APIBoletim.Context;
using APIBoletim.Domains;
using APIBoletim.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Repositories
{
    public class AlunoRepository : IAluno
    {
        // Chamamos o contexto de conexao
        BoletimContext conexao = new BoletimContext();

        //Chamamos a classe que permite colocar consultas de banco
        SqlCommand cmd = new SqlCommand();
        public Aluno Alterar(Aluno a)
        {
            throw new NotImplementedException();
        }

        public Aluno BuscarPorID(int id)
        {
            // Abrimos a conexao
            cmd.Connection = conexao.Conectar();

            //Atribuimos nossa conexao
            cmd.CommandText = "SELECT * FROM Aluno WHERE IdAluno = @id";
            //Dizemos quem é o @id
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Aluno a = new Aluno();

            while (dados.Read())
            {
                a.IdAluno    = Convert.ToInt32(dados.GetValue(0));
                a.Nome       = dados.GetValue(1).ToString();
                a.RA         = dados.GetValue(2).ToString();
                a.Idade      = Convert.ToInt32(dados.GetValue(3));
            }  

            conexao.Desconectar();

            return a;
        }

        public Aluno Cadastrar(Aluno a)
        {
            throw new NotImplementedException();
        }

        public Aluno Excluir(Aluno a)
        {
            throw new NotImplementedException();
        }

        public List<Aluno> ListarTodos()
        {
            // Abrimos a conexao
            cmd.Connection = conexao.Conectar();

            //Atribuimos nossa conexao
            cmd.CommandText = "SELECT * FROM Aluno";

            //Lemos os dados
            SqlDataReader dados = cmd.ExecuteReader();

            //Criamos uma lista para ser populada
            List<Aluno> alunos = new List<Aluno>();

            //Criamos um laço para ler todas as linhas
            while (dados.Read())
            {
                alunos.Add(
                    new Aluno()
                    {
                        IdAluno = Convert.ToInt32(dados.GetValue(0)),
                        Nome = dados.GetValue(1).ToString(),
                        RA = dados.GetValue(2).ToString(),
                        Idade = Convert.ToInt32(dados.GetValue(3)),
                    }
                 );
            }

            // Fechamos a conexao
            conexao.Desconectar();

            return alunos;
        }
    }
}
