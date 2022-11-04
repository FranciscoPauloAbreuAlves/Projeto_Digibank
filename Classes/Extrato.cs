using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Extrato
    {
        public Extrato(DateTime data, string descricao, double valor)//, string tipo)
        {
            this.Data = data;
            this.Descricao = descricao;
            this.Valor = valor;
            //this.Tipo = tipo;
        }
        public DateTime Data { get; private set; }
        public string Descricao { get; private set; }
        public double Valor { get; private set; }
        //public string Tipo { get; private set; }
    } 
}
