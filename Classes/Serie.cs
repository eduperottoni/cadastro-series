using System;
namespace Series
{
    public class Serie : EntidadeBase //Classe Serie está herdando da EntidadeBase
    {
        //ATRIBUTOS
        private Genero Genero {get;set;}
        private string Titulo {get;set;}
        private string Descricao {get;set;}
        private int Ano {get;set;}
        private bool Excluido {get;set;}
    
        
        //MÉTODOS
        //Método construtor
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        //Método que retorna os atributos da série por meio de string
        public override string ToString()
        {
            //Environment.NewLine: https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += $"Gênero: {this.Genero + Environment.NewLine}";
            retorno += $"Titulo: {this.Titulo + Environment.NewLine}";
            retorno += $"Descricao: {this.Descricao + Environment.NewLine}";
            retorno += $"Ano de Início: {this.Ano + Environment.NewLine}";
            retorno += $"Status; {this.Excluido}";
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaStatus()
        {
            return this.Excluido;
        }    
        public void Excluir()
        {
            this.Excluido = true;
        }
        
    }
}