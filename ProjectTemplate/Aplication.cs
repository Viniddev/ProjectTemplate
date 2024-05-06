using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate
{
    internal class Aplication
    {
        public static int Contador{ get; set; }
        //contador limite de tempo 
        public static async Task ContadorLimiteTempo() 
        {
            Task cont = Task.Run(async () =>
            {
                while (Contador < 900) 
                {
                    Contador++;
                    await Task.Delay(1000);
                }
            });

            await cont;

            Environment.Exit(0);
        }
    }
}
