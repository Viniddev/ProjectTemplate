using PipeliningLibrary;
using ProjectTemplate.Pipelines;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Pipes.RM
{
    internal class GerarRelatorio : IPipe
    {
        public object Run(dynamic input)
        {
            int relatorio = StartPipelines.numRelatorio;
            gerarRelatorio(relatorio);
            
            return input;
        }

        public void gerarRelatorio(int relatorio)
        {
            Console.WriteLine($"Relatorio {relatorio} foi gerado");
        }

    }
}
