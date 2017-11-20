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
            matriz[a - 1, b - 1] = 1;
            matriz[b - 1, a - 1] = 1;

        }

        public void removerAresstas(int a, int b)
        {
            matriz[a - 1, b - 1] = 0;
            matriz[b - 1, a - 1] = 0;
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

        public void LerArquivo()
        {
            int cont = 0;
            string text = System.IO.File.ReadAllText(@"C:\Users\depau\Desktop\Softwares\grafo\hhhh.txt");
            string[] lines = text.Split(';');
            foreach(string x in lines)
            {
                Console.WriteLine(x);
            }

            Console.ReadKey();
        }

        public void Busca(int vertic,string[]cidade)
        {
            Console.Clear();
            Console.WriteLine("\n Cidades e seus respectivos vértices :");

            for (int i = 1; i <= vertic; i++)
            {
               Console.WriteLine("\n {0} = Vértice {1}", cidade[i - 1], i);
            }

            Console.Write("\n\n\n Digite o vértice da cidade de início :" );
            int indexCidade = int.Parse(Console.ReadLine());

            Console.Write("\n\n\n Digite o vértice da cidade a ser pesquisada :");
            int cidadePesquisa = int.Parse(Console.ReadLine());

            Queue v = new Queue();
            vertice[] z = new vertice[vertic];
            vertice numer;
            Queue q = new Queue();
            for (int i = 0; i < vertic; i++)
            {
                numer = new vertice();
                numer.numero = i;
                z[i] = numer;
            }

            vertice raiz = z[indexCidade-1];
            raiz.visitado = true;
            q.Enqueue(raiz.numero);
            int b = cidadePesquisa-1 ;

            int cont = 0;
            while (q.Count > 0)
            {
                if (cont == 1)
                {
                    break;
                }
                for (int j = 0; j < vertic; j++)
                {
                    int i = Convert.ToInt32(q.Peek());
                    if (matriz[i, j] == 1)
                    {
                        if (z[j].numero == b)
                        {
                            q.Enqueue(z[j].numero);
                            Console.Clear();
                            Console.WriteLine("Foi encontrado o vertíce pesquisado");
                            Console.WriteLine("\n Pressione enter para ver as cidades que a busca passou para encontrar {0}",cidade[cidadePesquisa-1]);
                            Console.ReadKey();

                            cont++;
                            break;
                        }
                        if (z[j].visitado == false)
                        {
                            z[j].visitado = true;
                            q.Enqueue(z[j].numero);
                        }
                    }

                }

                v.Enqueue(q.Dequeue());
            }

            while (q.Count > 0)
            {
                v.Enqueue(q.Dequeue());
            }
            string[] a = new string[10];
            Console.Clear();
            if (cont > 0)
            {
                foreach (int c in v)
                {
                    if (c == b)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    
                    Console.WriteLine(cidade[c]);
                    
                    a[cont] = cidade[c];
                  
                    Console.ForegroundColor = ConsoleColor.White;
                    cont++;
                }
            }
          
            else
            {
                Console.WriteLine("Não foi encontrado o vértice pesquisado,verifique se é um grafo conexo");
            }
            string path = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory), "out.xt");
            System.IO.File.WriteAllLines(path, a);
            Console.ReadLine();
        }


        class vertice
        {

            public bool visitado { get; set; }
            public int numero { get; set; }

        }
    }
}




