using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entidade
{
    public class Agenda
    {
        public int id { get; set; }
        public Cliente idCli { get; set; }
        public String hora { get; set; }
        public String data { get; set; }
    }
}