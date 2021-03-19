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
                        if (i > ttask)
                        {
                            servidoresDisponiveis += ttask;
                            var servidoresRemovidos = servidoresAtivos -= ttask;
                            usuariosAtivos -= ttask;
                            outputs[i] = $"{servidoresAtivos} servidor(es) para {usuariosAtivos} usuário(s) ({servidoresRemovidos} removido(s))";
                        }
                        if (users[i] > umax)
                        {
                            usuariosAtivos += users[i];
                            if (servidoresDisponiveis > 1)
                            {
                                servidoresDisponiveis--;
                                servidoresAtivos++;
                            }
                            servidoresAtivos++;
                            outputs[i] = $"{servidoresAtivos} servidor(es) para {usuariosAtivos} usuário(s) (1 servidor criado)";
                        }
                        if (users[i] > 0 && users[i] <= umax)
                        {
                            usuariosAtivos += users[i]; 
                            if (servidoresDisponiveis > 1)
                            {
                                servidoresDisponiveis--;
                                servidoresAtivos++;  
                            }
                            servidoresAtivos++;
                            outputs[i] = $"{servidoresAtivos} servidor(es) para {usuariosAtivos} usuário(s) (1 servidor criado)";
                        }
                        if (users[i] <= 0)
                        {
                            outputs[i] = $"{servidoresAtivos} servidor(es) para {usuariosAtivos} usuário(s) (nenhum servidor criado ou removido)";
                        }
                    }

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