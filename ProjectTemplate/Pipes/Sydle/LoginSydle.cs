using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Pipes.Sydle
{
    internal class LoginSydle : IPipe
    {
        public object Run(dynamic input) 
        {
            string caminhoArquivo = "balabalanba";
            input.caminhoArquivo = caminhoArquivo;
            input.caminhoExiste = true;

            testar();

            return input;
        }


        public static void testar() 
        {
            Console.WriteLine("testado");
        }
    }
}
