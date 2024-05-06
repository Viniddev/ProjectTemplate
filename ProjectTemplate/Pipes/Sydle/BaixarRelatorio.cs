using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Pipes.Sydle
{
    internal class BaixarRelatorio : IPipe
    {
        public object Run(dynamic input) 
        {
            try 
            {
                string caminho = input.caminhoArquivo;

            }catch (Exception ex) 
            {
                throw new ArgumentException("não baixou o relatorio");
            }

            return input;
        }
    }
}
