using ProjectTemplate;
using ProjectTemplate.Pipelines;
using System;

namespace program
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Task contador = Aplication.ContadorLimiteTempo();
            Aplication.Contador = 0;


            StartPipelines startPipelines = new StartPipelines();
            Console.WriteLine("Finalizou");
        }
    }
}