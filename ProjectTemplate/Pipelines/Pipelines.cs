using PipeliningLibrary;
using ProjectTemplate.Pipes.RM;
using ProjectTemplate.Pipes.Sydle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Pipelines
{
    internal class Pipelines : PipelineGroup
    {
        public Pipelines() 
        {
            //aqui vai a declaração das pipeline;
            Pipeline("LoginSydle")
                .Pipe<LoginSydle>()
                ;

            Pipeline("BaixarRelatorio")
                .Pipe<BaixarRelatorio>()
                ;

            Pipeline("GerarRelatorio")
                .Pipe<GerarRelatorio>()
                ;
        }
    }
}
