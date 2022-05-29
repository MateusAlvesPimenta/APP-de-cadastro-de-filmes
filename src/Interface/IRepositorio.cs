namespace APP_de_cadastro.src
{
    public interface IRepositorio<T>
    {
        void Inserir(T objeto);
        void Alterar(int id, Filme objeto);
        void Excluir(int id);
        Filme Visualizar(int id);
        List<T> Listar();
        int GerarId();
    }
}