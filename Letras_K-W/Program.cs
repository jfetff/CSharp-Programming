using System;

namespace letras
{
    class Program
    {
        static void Main(string[] args)
        {
            pintarLetra('w');
        }

        static void pintarLetra(char letra)
        {
            char[] miLetra = new char[49];
            for(int h = 0; h < 49; h++)
            {
                miLetra[h] = ' ';
            }
            letra = Char.ToUpper(letra);
            switch (letra)
            {
                case 'K':
                    int f = 0, c = 1, paso = 2, index = 5, conteo = 0;
                    while(f < 7)
                    {
                        miLetra[conteo] = '*';
                        Console.Write("*");
                        conteo++;
                        while(c < 5)
                        {
                            if(c == (index - 1) && (f < 4))
                            {
                                miLetra[conteo] = '*';
                                Console.Write("*");
                                conteo++;
                            }
                            else if(f > 3)
                            {
                                if((f - paso) == c)
                                {
                                    miLetra[conteo] = '*';
                                    Console.Write("*");
                                    conteo++;
                                }
                                else{
                                    miLetra[conteo] = ' ';
                                    Console.Write(" ");
                                    conteo++;
                                }
                            }
                            else{
                                miLetra[conteo] = ' ';
                                Console.Write(" ");
                                conteo++;                              
                            }
                            c++;
                        }
                        index--;
                        c = 1;
                        Console.Write("\n");
                        f++;
                    }
                    break;
                case 'W':
                    int row = 0, col = 0, step = 0, ind = 5, count = 0;
                    while(row < 7)
                    {
                        while(col < 7)
                        {
                            if(((col == 0) || (col == 3) || (col == 6)) && (row < 5))
                            {
                                miLetra[count] = '*';
                                Console.Write("*");
                                count++;
                            }
                            else if((row == 5) &&  (step == col))
                            {
                                miLetra[count] = '*';
                                Console.Write("*");
                                count++;
                                step = step + 2;
                            }
                            else if((row == 6) && ((col == 1) || (col == 5)))
                            {
                                miLetra[count] = '*';
                                Console.Write("*");
                                count++;
                                step = step + 2;
                            }
                            else{
                                miLetra[count] = ' ';
                                Console.Write(" ");
                                count++;
                            }
                            col++;
                        }
                        ind--;
                        col = 0;
                        Console.Write("\n");
                        row++;
                    }
                    break;
                default:
                    Console.WriteLine("Letra equivocada, trate nuevamente!!");
                    break;
            }
        }
    }
}