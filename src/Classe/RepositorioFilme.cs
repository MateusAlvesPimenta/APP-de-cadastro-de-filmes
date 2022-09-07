namespace APP_de_cadastro.src
{
    public class RepositorioFilme : IRepositorio<Filme>
    {
        List<Filme> FilmesGuardados = new List<Filme>();
        public void Alterar(int id, Filme objeto)
        {
            FilmesGuardados[id] = objeto;
        }

        public void Excluir(int id)
        {
            FilmesGuardados[id].Excluir();
        }

        public int GerarId()
        {
            return FilmesGuardados.Count();
        }

        public void Inserir(Filme objeto)
        {
            FilmesGuardados.Add(objeto);
        }

        public List<Filme> Listar()
        {
            return FilmesGuardados;
        }

        public Filme Visualizar(int id)
        {
            return FilmesGuardados[id];
        }
    }
}