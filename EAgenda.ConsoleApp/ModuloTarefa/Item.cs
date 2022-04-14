using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.ConsoleApp.ModuloTarefa
{
    public class Item
    {
        public StatusTarefa statusConclusao = StatusTarefa.Fazer;
        public string descrição;

        public enum StatusTarefa
        {
            Fazer, Fazendo, Feito
        }


    }
}
