using APP_de_cadastro.src;
using static APP_de_cadastro.src.Genero;

using static System.Console;
class Program
{

    public static RepositorioFilme FilmeSalvo = new RepositorioFilme();
    public const string TextoInicial = 
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

        string Entrada = string.Empty;

        OpcaoUsuario(ref Entrada);

        while(Entrada != "X")
        {
            switch(Entrada)
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
            OpcaoUsuario(ref Entrada);
        }
        WriteLine("Foi um prazer atender você, até a proxima!!!");
    }

    private static void OpcaoUsuario(ref string entrada)
    {

        WriteLine(TextoInicial);
        entrada = ReadLine().ToUpper();

    }

    private static void CadastrarFilme(int id)
    {
        WriteLine("Gênero do filme");
        for (int i=0; i < Generos.Length;i++)
        {
            WriteLine($"{i} {Generos[i]}");
        }
        int GeneroFilme = int.Parse(ReadLine());

        WriteLine("Qual o nome do filme?");
        string nomeFilme = ReadLine();
        
        WriteLine("Qual a descrição do filme?");
        string descricaoFilme = ReadLine();

        WriteLine("Qual o ano de lançamento do filme?");
        int lancamentoFilme = int.Parse(ReadLine());

        if(id == -1)
        {
            Filme novoFilme = new Filme(FilmeSalvo.GerarId(),Generos[GeneroFilme],nomeFilme,descricaoFilme,lancamentoFilme);
            FilmeSalvo.Inserir(novoFilme);
        }
        else
        {
            Filme novoFilme = new Filme(id,Generos[GeneroFilme],nomeFilme,descricaoFilme,lancamentoFilme);
            FilmeSalvo.Alterar(id,novoFilme);
        }
    }

    private static void ListarFilmes()
    {
        // var Filmes = FilmeSalvo.Listar();

        if(FilmeSalvo.Listar().Count() < 1)
        {
            WriteLine("\n Não há filmes cadastrados \n");
        }
        else
        {
            foreach( var item in FilmeSalvo.Listar())
            {
                string excluido = item.ValorExcluido() ? "---excluido---" : string.Empty;
                WriteLine($" Id {item.Id} Nome {item.Nome} {excluido} \n");
            }
        }
    }

    private static void VisualizarFilme()
    {
        WriteLine("Insira o Id do filme que deseja visualizar");
        int IdVisualizar = int.Parse(ReadLine());

        WriteLine(FilmeSalvo.Visualizar(IdVisualizar));
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
        FilmeSalvo.Excluir(idExcluir);
    }

}