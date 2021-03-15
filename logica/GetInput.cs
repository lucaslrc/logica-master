using System;
using System.IO;

namespace logica
{
    public class GetInput
    {
        public void Get()
        {
            try
            {
                using (var file = new StreamReader("./input.txt"))
                {
                    string[] inputs = file.ReadLine().Trim().Split();

                    try
                    {
                        int ttask = int.Parse(inputs[0]);
                        int umax = int.Parse(inputs[1]);
                        int[] fluxo = new int[inputs.Length - 2];

                        for (int i = 2; i < inputs.Length; i++)
                        {
                            fluxo[i-2] = int.Parse(inputs[i]);
                        }

                        foreach (var item in fluxo)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException(e.ToString());
                    }

                    file.Close();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("O aquivo não pôde ser lido pelo sistema.");
                Console.WriteLine(e.Message);
            }
        }
        protected internal class Input
        {
            protected int ttask { get; set; }
            protected int umax { get; set; }
            protected int[] fluxo { get; set; }
        }
    }
}