namespace APP_de_cadastro.src
{
    public class Filme : EntidadeBase
    {
        private string categoria {get;set;}
        private string nome {get;set;}
        private string descricao {get;set;}
        private int lancamento {get;set;}
        private bool excluido {get;set;}

        public Filme(int id, string categoria, string nome, string descricao,int lancamento)
        {
            this.id = id;
            this.categoria = categoria;
            this.nome = nome;
            this.descricao = descricao;
            this.lancamento = lancamento;
            this.excluido = false;
        }
        public override string ToString()
        {
            return $" \n Id - {this.id} \n Filme - {this.nome} \n categoria - {this.categoria} \n Descrição - {this.descricao} \n Ano de lançamento - {this.lancamento} \n";
        }
        public int Id()
        {
            return this.id;
        }
        public string Nome()
        {
            return $"{this.nome}";
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