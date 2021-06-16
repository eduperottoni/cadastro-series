using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            //EntidadeBase minhaClasse = new EntidadeBase(); --> Esse comando não pode ser executado pois a classe EntidadeBase é abstrata
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                   case "2":
                        InserirSerie();
                        break;
                    case "3":
                        //AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        //VizualizaSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Valor inválido...Tente novamente!");  
                }
                opcaoUsuario = ObterOpcaoUsuario();                  
            }
        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Excluindo série");
            Console.WriteLine("Informe o ID da série a ser excluída: ");
            int id = int.Parse(Console.ReadLine());
            var lista = repositorio.Lista();
            repositorio.Exclui(id);
            Console.WriteLine($"A série {lista[id].retornaTitulo()} foi excluída com sucesso!");
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizando série");
            Console.WriteLine("Informe o ID da série a ser editada: ");
            int id = int.Parse(Console.ReadLine());
            var lista = repositorio.Lista();

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"[{i}] {Enum.GetName(typeof(Genero),i)}");
            }
            Console.WriteLine($"Digite para qual gênero você quer alterar (gênero atual: {lista[id].retornaTitulo()}):");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o novo título da série (título atual: {}): "); //Paramos aqui!!!
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o ano em que a série foi lançada: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digie a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serieAtualizada = new Serie(id:id,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(id, serieAtualizada); 

        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listando séries:");
            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série foi cadastada até o momento");
                return;
            }

            foreach (var serie in lista)
            {
                if(serie.retornaStatus() == false)
                {
                    Console.WriteLine($"ID: {serie.retornaId()} | {serie.retornaTitulo()}");
                }
                
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserindo nova série");
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"[{i}] {Enum.GetName(typeof(Genero),i)}");
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o ano em que a série foi lançada: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digie a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id:repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie); 
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("");
            Console.WriteLine("APP DE CADASTRO DE SÉRIES");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("[1] Listar séries");
            Console.WriteLine("[2] Inserir nova série");
            Console.WriteLine("[3] Atualizar série");
            Console.WriteLine("[4] Excluir Série");
            Console.WriteLine("[5] Visualizar série");
            Console.WriteLine("[C] Limpar Tela");
            Console.WriteLine("[X] Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
