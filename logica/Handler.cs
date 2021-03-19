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
                using (var file = new StreamWriter("../output.txt"))
                {
                    GetInput g = new GetInput();

                    var ttask = g.Get().Ttask;
                    var umax = g.Get().Umax;
                    int[] users = g.Get().Users;

                    int servidoresAtivos = 0;
                    int servidoresDisponiveis = 0;
                    int usuariosAtivos = 0;
                    int servidoresRemovidos = 0;

                    string[] outputs = new string[ttask + umax + users.Length];

                    for (int i = 0; i < users.Length; i++)
                    {
                        if (i > ttask)
                        {
                            servidoresDisponiveis += ttask;
                            servidoresRemovidos = servidoresAtivos - 1;
                            servidoresAtivos -= ttask;
                            usuariosAtivos -= ttask;
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
                            file.WriteLine($"{servidoresAtivos} servidor(es) para {usuariosAtivos} usuário(s) (1 servidor criado)");
                        }
                        if (users[i] > 0 && users[i] <= umax)
                        {
                            usuariosAtivos += users[i]; 
                            if (servidoresDisponiveis >= 1)
                            {
                                servidoresDisponiveis--;
                                servidoresAtivos++;  
                            }
                            servidoresAtivos++;
                            if (servidoresRemovidos >= 1)
                            {
                                file.WriteLine($"{servidoresAtivos} servidor(es) para {usuariosAtivos} usuário(s) ({servidoresRemovidos} removido(s))");
                            }
                            else
                            {
                                file.WriteLine($"{servidoresAtivos} servidor(es) para {usuariosAtivos} usuário(s) (1 servidor criado)");
                            }
                        }
                        if (users[i] <= 0)
                        {
                            file.WriteLine($"{servidoresAtivos} servidor(es) para {usuariosAtivos} usuário(s) (nenhum servidor criado ou removido)");
                        }
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