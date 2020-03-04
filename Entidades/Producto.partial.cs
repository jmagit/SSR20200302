using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public partial class Producto {

        // Propiedades no persistente
        public override string this[string columnName] {
            get {
                switch(columnName) {
                    case nameof(Nombre):
                        if(string.IsNullOrWhiteSpace(Nombre)) {
                            return "Es obligatorio";
                        }
                        break;
                }
                return base[columnName];
            }
        } 

        // Métodos de negocio de la entidad
    }
}
