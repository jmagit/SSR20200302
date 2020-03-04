using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    [DataContract]
    public partial class Producto : EntityBase {
        private int id;
        [DataMember]
        [Required]
        public int Id {
            get => id;
            set {
                if (id != value) {
                    PreId(id, value);
                    id = value;
                    PostId(id, value);
                    NotifyPropertyChanged();
                }
            }
        }
        partial void PostId(int id, int value);
        partial void PreId(int id, int value);

        private string nombre;
        [DataMember]
        public string Nombre {
            get => nombre;
            set {
                if (nombre != value) {
                    PreNombre(nombre, value);
                    nombre = value;
                    PostNombre(nombre, value);
                    NotifyPropertyChanged();
                }
            }
        }
        partial void PostNombre(string nombre, string value);
        partial void PreNombre(string nombre, string value);

        private string descripcion;
        [DataMember]
        public string Descripcion {
            get => descripcion;
            set {
                if (descripcion != value) {
                    PreDescripcion(descripcion, value);
                    descripcion = value;
                    PostDescripcion(descripcion, value);
                    NotifyPropertyChanged();
                }
            }
        }
        partial void PostDescripcion(string descripcion, string value);
        partial void PreDescripcion(string descripcion, string value);

        private decimal precio;
        [DataMember]
        public decimal Precio {
            get => precio;
            set {
                if (precio != value) {
                    PrePrecio(precio, value);
                    precio = value;
                    PostPrecio(precio, value);
                    NotifyPropertyChanged();
                }
            }
        }
        partial void PostPrecio(decimal precio, decimal value);
        partial void PrePrecio(decimal precio, decimal value);


        private bool descatalogado;
        [DataMember]
        public bool Descatalogado {
            get => descatalogado;
            set {
                if (descatalogado != value) {
                    PreDescatalogado(descatalogado, value);
                    descatalogado = value;
                    PostDescatalogado(descatalogado, value);
                    NotifyPropertyChanged(nameof(Descatalogado));

                }
            }
        }
        partial void PostDescatalogado(bool descatalogado, bool value);
        partial void PreDescatalogado(bool descatalogado, bool value);

        private int idCategoria;
        [DataMember]
        public int IdCategoria {
            get => idCategoria;
            set {
                if (idCategoria != value) {
                    PreId(idCategoria, value);
                    idCategoria = value;
                    PostId(idCategoria, value);
                    NotifyPropertyChanged();
                }
            }
        }
        partial void PostIdCategoria(int idCategoria, int value);
        partial void PreIdCategoria(int idCategoria, int value);

    }
}
