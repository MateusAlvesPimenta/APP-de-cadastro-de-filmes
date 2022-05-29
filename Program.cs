using APP_de_cadastro.src;
using static APP_de_cadastro.src.Genero;

using static System.Console;
class program
{

    public static RepositorioFilme filmeSalvo = new RepositorioFilme();

    public const string textoInicial = 
@"DevFilmes iniciado!!!
Digite a opção desejada:
1- Cadastrar Filme.
2- Listar filmes cadastrados.
3- Visualizar filme.
4- Alterar filme.
5- Excluir filme.
C- Limpar tela.
X- Sair.
";

    static void Main(string[] Args)
    {

        string entrada = string.Empty;

        OpcaoUsuario(ref entrada);

        while(entrada != "X")
        {
            switch(entrada)
            {
                case "1":
                    CadastrarFilme(-1);
                    break;
                case "2":
                    ListarFilmes();
                    break;
                case "3":
                    VisualizarFilme();
                    break;
                case "4":
                    AlterarFilme();
                    break;
                case "5":
                    ExcluirFilme();
                    break;
                case "C":
                    Console.Clear();
                    break;
                default: throw new ArgumentOutOfRangeException("Valor Invalido");
            }
            OpcaoUsuario(ref entrada);
        }
        WriteLine("Foi um prazer atender você, até a proxima!!!");
    }

    private static void OpcaoUsuario(ref string entrada)
    {

        WriteLine(textoInicial);
        entrada = ReadLine().ToUpper();

    }

    private static void CadastrarFilme(int id)
    {
        WriteLine("Gênero do filme");
        for (int i=0; i < generos.Length;i++)
        {
            WriteLine($"{i} {generos[i]}");
        }
        int generoFilme = int.Parse(ReadLine());

        WriteLine("Qual o nome do filme?");
        string nomeFilme = ReadLine();
        
        WriteLine("Qual a descrição do filme?");
        string descricaoFilme = ReadLine();

        WriteLine("Qual o ano de lançamento do filme?");
        int lancamentoFilme = int.Parse(ReadLine());

        if(id == -1)
        {
            Filme novoFilme = new Filme(filmeSalvo.GerarId(),generos[generoFilme],nomeFilme,descricaoFilme,lancamentoFilme);
            filmeSalvo.Inserir(novoFilme);
        }
        else
        {
            Filme novoFilme = new Filme(id,generos[generoFilme],nomeFilme,descricaoFilme,lancamentoFilme);
            filmeSalvo.Alterar(id,novoFilme);
        }
    }

    private static void ListarFilmes()
    {
        var filmes = filmeSalvo.Listar();

        if(filmes.Count() < 1)
        {
            WriteLine("\n Não há filmes cadastrados \n");
        }
        else
        {
            foreach( var item in filmes)
            {
                string excluido = item.ValorExcluido() ? "---excluido---" : string.Empty;
                WriteLine($" Id {item.Id()} Nome {item.Nome()} {excluido} \n");
            }
        }
    }

    private static void VisualizarFilme()
    {
        WriteLine("Insira o Id do filme que deseja visualizar");
        int idVisualizar = int.Parse(ReadLine());

        WriteLine(filmeSalvo.Visualizar(idVisualizar));
    }

    private static void AlterarFilme()
    {
        WriteLine("Insira o Id do filme que deseja alterar");
        int idAlterar = int.Parse(ReadLine());

        CadastrarFilme(idAlterar);
    }

    private static void ExcluirFilme()
    {
        WriteLine("Insira o Id do filme que deseja excluir");
        int idExcluir = int.Parse(ReadLine());
        filmeSalvo.Excluir(idExcluir);
    }

}