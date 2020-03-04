using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.ViewModels {
    public class ActoresVM : ObservableBase {
        public ObservableCollection<ACTOR> Listado { get; set; }

    }
}
