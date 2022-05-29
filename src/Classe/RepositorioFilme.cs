namespace APP_de_cadastro.src
{
    public class RepositorioFilme : IRepositorio<Filme>
    {
        List<Filme> filmesGuardados = new List<Filme>();
        public void Alterar(int id, Filme objeto)
        {
            filmesGuardados[id] = objeto;
        }

        public void Excluir(int id)
        {
            filmesGuardados[id].Excluir();
        }

        public int GerarId()
        {
            return filmesGuardados.Count();
        }

        public void Inserir(Filme objeto)
        {
            filmesGuardados.Add(objeto);
        }

        public List<Filme> Listar()
        {
            return filmesGuardados;
        }

        public Filme Visualizar(int id)
        {
            return filmesGuardados[id];
        }
    }
}