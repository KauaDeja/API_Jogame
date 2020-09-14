using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Domains
{
    /// <summary>
    /// Definimos a classe jogador
    /// </summary>
    public class Jogador : BaseDomain
    {
        // Fazemos as propriedades
        public string   Nome            { get; set; }
        public string   Email           { get; set; }
        public string   Senha           { get; set; }
        public DateTime DataNascimento  { get; set; }
    }
}
