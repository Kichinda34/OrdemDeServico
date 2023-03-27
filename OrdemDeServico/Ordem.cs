using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemDeServicos
{
    public class OrdemDeServico
    {
        public int ID { get; set; }

        public string Descricao { get; set; }

        public List<string> Pecas { get; set; }

        public double Valor { get; set; }

        public OrdemDeServico(int id, string descricao, double valor, List<string> p)
        {
            ID = id;
            Descricao = descricao;
            Pecas = p;
            Valor = valor;
        }

        public override string ToString()
        {
            string pecas = "";
            foreach (var item in Pecas)
            {
                pecas += item + ";";
            }

            return ID + ";" + Descricao + ";" +pecas+";"+Valor;
        }

        public string ToUser()
        {
            return @"ID: "+ ID + "\nDescrição: " + Descricao + "\nValor: " + Valor;
        }
    }
}
