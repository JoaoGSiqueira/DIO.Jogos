using System;

namespace DIO.Jogos
{
    public class Jogo : EntidadeBase 
    {
        // Atributos
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private string Estudio { get; set; }
        private int Ano { get; set; }
        private decimal Preco { get; set; }

        private bool Excluido { get; set; }

        // Métodos
        public Jogo(int id, Genero genero, string titulo, string descricao, string estudio, int ano, decimal preco)
        {
            this.id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Estudio = estudio;
            this.Ano = ano;
            this.Preco = preco;
            this.Excluido = false; 
        }

        public override string ToString()
        {
            string retorno ="";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Estúdio: " + this.Estudio + Environment.NewLine;
            retorno += "Data de Lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Preço: R$" + this.Preco + Environment.NewLine;
            retorno += "Excluido " + this.Excluido;

            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        internal int retornaId()
        {
            return this.id;
        }

        internal bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true; 
        }

    }

}