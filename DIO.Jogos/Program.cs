using System;

namespace DIO.Jogos
{
    class Program
    {
        static JogoRepositorio repositorio = new JogoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                    ListarJogos();
                    break;
                    case "2":
                    InserirJogo();
                    break;
                    case "3":
                    AtualizarJogo();
                    break;
                    case "4":
                    ExcluirJogo();
                    break;
                    case "5":
                    VisualizarJogo();
                    break;
                    case "C":
                    Console.Clear();
                    break;

                    default: 
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por utilizar nossos serviços");
            System.Console.ReadLine();
        }

        private static void ListarJogos()
        {
            System.Console.WriteLine("Listar jogos");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma jogo cadastrado");
            }
            foreach (var jogo in lista)
            {
                var excluido = jogo.retornaExcluido();
                
                System.Console.WriteLine("#ID {0}: - {1} {2}", jogo.retornaId(), jogo.retornaTitulo(), (excluido ? "*Excluido*": ""));
            }
        }

        private static void InserirJogo()
        {
            System.Console.WriteLine("Inserir novo jogo");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o Título do Jogo: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o Ano de Lançamento do Jogo: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a Descrição do Jogo: ");
            string entradaDescricao = Console.ReadLine();
            
            System.Console.Write("Digite o nome do Estúdio que fez o Jogo: ");
            string entradaEstudio = Console.ReadLine();

            System.Console.Write("Digite o Preço do Jogo: ");
            decimal entradaPreco = decimal.Parse(Console.ReadLine());

            Jogo novoJogo = new Jogo(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao,
                                    estudio: entradaEstudio,
                                    preco: entradaPreco);

            repositorio.Insere(novoJogo);
        }

        public static void AtualizarJogo()
        {
            System.Console.Write("Digite o id da série: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o Título do Jogo: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o Ano de Lançamento do Jogo: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a Descrição do Jogo: ");
            string entradaDescricao = Console.ReadLine();
            
            System.Console.Write("Digite o nome do Estúdio que fez o Jogo: ");
            string entradaEstudio = Console.ReadLine();

            System.Console.Write("Digite o Preço do Jogo: ");
            decimal entradaPreco = decimal.Parse(Console.ReadLine());

            Jogo atualizaJogo = new Jogo(id: indiceJogo,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao,
                                    estudio: entradaEstudio,
                                    preco: entradaPreco);

            repositorio.Atualiza(indiceJogo, atualizaJogo);
        }

        private static void ExcluirJogo()
        {
            System.Console.Write("Digite o id do jogo: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceJogo);
        }

        private static void VisualizarJogo()
        {
            System.Console.Write("Digite o id do jogo: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            var jogo = repositorio.RetornaPorId(indiceJogo);

            System.Console.WriteLine(jogo);
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("DIO Jogos!");
            System.Console.WriteLine("Informe a opção desejada: ");

            System.Console.WriteLine("1 - Listar jogos");
            System.Console.WriteLine("2 - Inserir novo jogo");
            System.Console.WriteLine("3 - Atualizar jogo");
            System.Console.WriteLine("4 - Excluir jogo");
            System.Console.WriteLine("5 - Visualizar jogo");
            System.Console.WriteLine("C - Limpar tela");
            System.Console.WriteLine("X - Sair");

            System.Console.WriteLine();
            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
