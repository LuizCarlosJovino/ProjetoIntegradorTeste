using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIntegrador
{
    internal class Avaliacoes
    {
        internal string Avaliacao()
        {
            string avAtendimento = "";

            Console.WriteLine("Como foi sua Experiencia com esse trabalho ou contratado?");
            Console.WriteLine("Quantas Estrelas você da pra esse atendimento, informe de 1 A 5 Estrelas!");
            Console.WriteLine("[1] avaliar Com 1 Estrela");
            Console.WriteLine("[2] avaliar Com 2 Estrela");
            Console.WriteLine("[3] avaliar Com 3 Estrela");
            Console.WriteLine("[4] avaliar Com 4 Estrela");
            Console.WriteLine("[5] avaliar Com 5 Estrela");

            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Parabéns você Avaliou com 1 estrela");
                    avAtendimento = "1 Estrela";
                    break;
                case 2:
                    Console.WriteLine("Parabéns você Avaliou com 2 estrela");
                    avAtendimento = "2 Estrela";
                    break;
                case 3:
                    Console.WriteLine("Parabéns você Avaliou com 3 estrela");
                    avAtendimento = "3 Estrela";
                    break;
                case 4:
                    Console.WriteLine("Parabéns você Avaliou com 4 estrela");
                    avAtendimento = "4 Estrela";
                    break;
                case 5:
                    Console.WriteLine("Parabéns você Avaliou com 5 estrela");
                    avAtendimento = "5 Estrela";
                    break;
            }

            return avAtendimento;
        }

    }
}
