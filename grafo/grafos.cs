using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace grafo
{
    class grafos
    {
        public int[,] matriz;

        public void grafo(int tamanho)
        {

            matriz = new int[tamanho, tamanho];

        }

        public void arestas(int a, int b)
        {
            try
            {
                matriz[a - 1, b - 1] = 1;
                matriz[b - 1, a - 1] = 1;
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("\n\n Vértices Inválidos!!");
                Console.ReadKey();
            }


        }

        public void removerAresstas(int a, int b)
        {
            try
            {
                matriz[a - 1, b - 1] = 0;
                matriz[b - 1, a - 1] = 0;
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("\n\n Vértices Inválidos!!");
                Console.ReadKey();
            }

        }

        public void mostrar(int a)
        {
            int cont = 0;

            Console.WriteLine();
            Console.WriteLine();


            for (int i = 1; i < a + 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\t " + i);

            }
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < a; i++)
            {
                cont++;
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write(cont);


                for (int j = 0; j < a; j++)
                {

                    Console.ForegroundColor = ConsoleColor.White;
                    if (matriz[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("\t " + matriz[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ReadKey();
        }


        public void Reiniciar(int a)
        {
            int cont = 0;

            Console.WriteLine();
            Console.WriteLine();


            for (int i = 1; i < a + 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\t " + i);

            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < a; i++)
            {
                cont++;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(cont);

                for (int j = 0; j < a; j++)
                {

                    Console.ForegroundColor = ConsoleColor.White;
                    if (matriz[i, j] == 1)
                    {
                        matriz[i, j] = 0;

                    }
                    Console.Write("\t " + matriz[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadLine();
        }


        public void Busca(int vertice, string[] cidade)
        {
            int indexCidade = 0, cidadePesquisa = 0;
            Console.Clear();
            Console.WriteLine("\n Cidades e seus respectivos vértices :");

            for (int i = 1; i <= vertice; i++)
            {
                Console.WriteLine("\n {0} = Vértice {1}", cidade[i - 1], i);
            }

            try
            {
                Console.Write("\n\n\n Digite o vértice da cidade de início :");
                indexCidade = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("\n\n Formato Inválido!!");
                Console.ReadLine();
                return;

            }

            try
            {
                Console.Write("\n\n\n Digite o vértice da cidade a ser pesquisada :");
                cidadePesquisa = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("\n\n Formato Inválido!!");
                Console.ReadLine();
                return;

            }

            Queue aux = new Queue();
            Vertice[] z = new Vertice[vertice];
            Vertice numero;
            Queue fila = new Queue();
            for (int i = 0; i < vertice; i++)
            {
                numero = new Vertice();
                numero.numero = i;
                z[i] = numero;
            }
            try
            {
                Vertice raiz = z[indexCidade - 1];
                raiz.visitado = true;
                fila.Enqueue(raiz.numero);
                int b = cidadePesquisa - 1;

                int cont = 0;
                while (fila.Count > 0)
                {
                    if (cont == 1)
                    {
                        break;
                    }
                    for (int j = 0; j < vertice; j++)
                    {
                        int i = Convert.ToInt32(fila.Peek());
                        if (matriz[i, j] == 1)
                        {
                            if (z[j].numero == b)
                            {
                                fila.Enqueue(z[j].numero);
                                Console.Clear();
                                Console.WriteLine("Foi encontrado o vertíce pesquisado");
                                Console.WriteLine("\n Pressione enter para ver as cidades que a busca passou para encontrar {0}", cidade[cidadePesquisa - 1]);
                                Console.ReadKey();

                                cont++;
                                break;
                            }
                            if (z[j].visitado == false)
                            {
                                z[j].visitado = true;
                                fila.Enqueue(z[j].numero);
                            }
                        }

                    }

                    aux.Enqueue(fila.Dequeue());
                }

                while (fila.Count > 0)
                {
                    aux.Enqueue(fila.Dequeue());
                }
                string[] texto = new string[vertice];
                Console.Clear();

                if (cont > 0)
                {
                    foreach (int c in aux)
                    {
                        if (c == b)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        Console.WriteLine(cidade[c]);

                        texto[cont] = cidade[c];

                        Console.ForegroundColor = ConsoleColor.White;
                        cont++;
                    }
                }

                else
                {
                    Console.WriteLine("Não foi encontrado o vértice pesquisado,verifique se é um grafo conexo");
                }
                string path = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory), "out.xt");
                System.IO.File.WriteAllLines(path, texto);
                Console.ReadLine();
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("\n\n Vértices Inválidos!!");
                Console.ReadKey();
            }

        }

    }
}




