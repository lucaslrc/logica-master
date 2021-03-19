using System;
using System.IO;

namespace logica
{
    public class GetInput
    {
        public Input Get()
        {
            try
            {
                using (var file = new StreamReader("./input.txt"))
                {
                    var obj = new Input();
                    string[] inputs = file.ReadLine().Trim().Split();
                    file.Close();

                    int ttask = int.Parse(inputs[0]);
                    int umax = int.Parse(inputs[1]);
                    int[] users = new int[inputs.Length - 2];

                    for (int i = 2; i < inputs.Length; i++)
                    {
                        users[i-2] = int.Parse(inputs[i]);
                    }

                    obj.Ttask = ttask;
                    obj.Umax = umax;
                    obj.Users = users;

                    return obj;
                }
            }
            catch (IOException e)
            {
                throw new IOException(e.ToString());
            }
        }
        public class Input
        {
            public int Ttask { get; set; }
            public int Umax { get; set; }
            public int[] Users { get; set; }
        }
    }
}