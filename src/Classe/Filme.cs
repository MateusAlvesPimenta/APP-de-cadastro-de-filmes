namespace APP_de_cadastro.src
{
    public class Filme
    {
        public int Id {get; set;}
        public string Categoria {get;set;}
        public string Nome {get;set;}
        public string Descricao {get;set;}
        public int Lancamento {get;set;}
        public bool excluido {get;set;}

        public Filme(int id, string categoria, string nome, string descricao,int lancamento)
        {
            this.Id = id;
            this.Categoria = categoria;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Lancamento = lancamento;
            this.excluido = false;
        }
        public override string ToString()
        {
            return $" \n Id - {this.Id} \n Filme - {this.Nome} \n categoria - {this.Categoria} \n Descrição - {this.Descricao} \n Ano de lançamento - {this.Lancamento} \n";
        }
        public void Excluir()
        {
            this.excluido = true;
        }
        public bool ValorExcluido()
        {
            return this.excluido;
        }
    }
}