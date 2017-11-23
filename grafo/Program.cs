using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace grafo
{
    class Program
    {

        static void Main(string[] args)
        {
            int vertice = 0;


            Console.SetWindowSize(Console.WindowWidth + 45, Console.WindowHeight + 10);

            while (vertice <= 0)
            {
                Console.Clear();
                try
                {
                    Console.Write("Digite o número de vértices : ");
                    vertice = int.Parse(Console.ReadLine());

                }
                catch (System.FormatException)
                {
                    Console.WriteLine("\n\nDigite uma opção válida!!");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (vertice <= 0)
                {
                    Console.WriteLine("Não existe grafo com 0 vértices ou com um número menor que 0 de vértices!!");
                    Console.ReadKey();
                }
            }

            grafos matriz = new grafos();
            matriz.grafo(vertice);



            int cont = 0;
            int tamanho = 0;
            int opcao = 0;
            string[] cidades = new string[] {"Betim","Belo Horizonte","Caeté","Contagem","Ibirité","Lagoa Santa","Nova Lima","Pedro Leopoldo",
            "Raposos","Ribeirão das Neves","Rio Acima","Sabará","Santa Luzia","Vespasiano","Brumadinho","Esmeraldas","Igarapé","Mateus Leme","Arcos","Governardor Valadares"};


            while (opcao != 7)
            {
                if (cont == 1)
                {
                    vertice = tamanho;
                }
                Console.Clear();
                Console.WriteLine("1 - Criar arestas.");
                Console.WriteLine("2 - Remover aresta.");
                Console.WriteLine("3 - Reiniciar grafo.");
                Console.WriteLine("4 - Mostrar Grafo.");
                Console.WriteLine("5 - Busca em largura");
                Console.WriteLine("6 - Ler arquivo txt");
                Console.WriteLine("7 - Sair");
                try
                {
                    Console.Write("Escolha uma opção : ");
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("\n\nDigite uma opção válida!!");
                    opcao = 0;
                    Console.ReadKey();
                }

                switch (opcao)
                {

                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n Cidades e seus respectivos vértices :");

                        for (int i = 1; i <= vertice; i++)
                        {
                            Console.WriteLine("\n {0} = Vértice {1}", cidades[i - 1], i);
                        }
                        Console.WriteLine("\n Pressione enter para continuar!");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(" Digite as cidades que serão adjacentes entre sí: ");
                        Console.WriteLine(" ================================================");

                        try
                        {
                            Console.Write("\n\n Vertice 1 : ");
                            int vertice1 = int.Parse(Console.ReadLine());

                            Console.Write("\n\n Vertice 2 : ");
                            int vertice2 = int.Parse(Console.ReadLine());

                            matriz.arestas(vertice1, vertice2);
                        }
                        catch (System.FormatException)
                        {
                            Console.WriteLine("\n\n Formato Inválido!!");
                            Console.WriteLine("\n Pressione enter para continuar");
                            Console.ReadKey();
                        }

                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n Cidades e seus respectivos vértices :");

                        for (int i = 1; i <= vertice; i++)
                        {
                            Console.WriteLine("\n {0} = Vértice {1}", cidades[i - 1], i);
                        }
                        Console.WriteLine("\n Pressione enter para continuar!");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(" Digite as vertices que terão arestas removidas");
                        Console.WriteLine(" ==============================================");
                        try
                        {
                            Console.Write("\n\n Vertice 1 : ");
                            int verticeRemover1 = int.Parse(Console.ReadLine());
                            Console.Write("\n\n Vertice 2 : ");
                            int verticeRemover2 = int.Parse(Console.ReadLine());
                            matriz.removerAresstas(verticeRemover1, verticeRemover2);
                        }
                        catch (System.FormatException)
                        {
                            Console.WriteLine("\n\n Formato Inválido!!");
                            Console.WriteLine("\n Pressione enter para continuar");
                            Console.ReadKey();
                        }

                        break;

                    case 3:
                        Console.Clear();
                        matriz.Reiniciar(vertice);
                        break;

                    case 4:
                        Console.Clear();
                        matriz.mostrar(vertice);
                        break;

                    case 5:
                        matriz.Busca(vertice, cidades);
                        break;

                    case 6:
                        Console.Clear();
                        Console.Write(" Essa opcão irá criar um novo grafo de acordo com os parametros passados no arquivo txt.\n\n Pressione S para continuar ou N para cancelar: ");
                        string escolha = Console.ReadLine();

                        if (escolha.ToUpper() == "N")
                        {
                            break;
                        }
                        if (escolha.ToUpper() == "S")
                        {
                            cont++;
                            string path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"in.txt");
                            string text = System.IO.File.ReadAllText(path);
                            string[] lines = text.Split('\n');
                            string[] aux = new string[lines.Length];
                            tamanho = int.Parse(lines[0]);

                            matriz.grafo(tamanho);


                            for (int i = 0; i < lines.Length - 3; i++)
                            {
                                aux[i] = lines[i + 1];
                                string[] x = aux[i].Split(';');
                                matriz.arestas(Convert.ToInt32(x[0]), Convert.ToInt32(x[1]));

                            }
                            Console.Clear();
                            Console.WriteLine("Matriz alterada com Sucesso!!");
                            Console.WriteLine("Pressione Enter para voltar ao menu principal.");
                            Console.ReadKey();
                        }

                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Opção Inválida!!!");
                            Console.WriteLine("Pressione Enter para voltar ao menu principal.");
                            Console.ReadKey();
                        }

                        break;

                }

            }



        }
    }


}
