using System;
using System.IO;

namespace logica
{
    public class Handler
    {
        public void Handle()
        {
            try
            {
                using (var file = new StreamWriter("./output.txt"))
                {
                    GetInput g = new GetInput();

                    var ttask = g.Get().Ttask;
                    var umax = g.Get().Umax;
                    var users = g.Get().Users;

                    int servidoresAtivos = 0;
                    int servidoresDisponiveis = 0;
                    int usuariosAtivos = 0;

                    string[] outputs = new string[ttask + umax + users.Length];

                    for (int i = 0; i < users.Length; i++)
                    {
                        if (users[i] > 0 && users[i] <= umax)
                        {
                            servidoresAtivos++;
                            usuariosAtivos = users[i];
                            if ()
                            {
                                
                            }
                            outputs[i] = $"{servidoresAtivos}";
                        }
                        // else if (users[i] == 0)
                        // {
                        //     if (servidoresAtivos >= 0)
                        //     {
                        //         servidoresAtivos--;
                        //         servidoresDisponiveis++;
                        //         outputs[i] = $"{servidoresAtivos}, {servidoresDisponiveis}";
                        //     }
                        // }
                        // else if (users[i] > umax)
                        // {
                        //     if (servidoresDisponiveis > 0)
                        //     {
                        //         servidoresDisponiveis--;
                        //         servidoresAtivos++;
                        //     }
                        //     else
                        //     {
                        //         servidoresAtivos++;
                        //     }
                        // }
                        // else if(users[i] < umax && users[i] > 0)
                        // {
                        //     servidoresAtivos--;
                        //     servidoresDisponiveis++;
                        // }
                    }
                    
                    Console.WriteLine(outputs.Length);

                    foreach (var item in outputs)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            catch (IOException e)
            {
                throw new IOException(e.ToString());
            }
        }
    }
}