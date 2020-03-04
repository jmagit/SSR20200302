using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Services {
    public class ProductosService {
        private static List<Producto> lst;
        static ProductosService() {
            lst = new List<Producto>();
            lst.Add(new Producto() { Id = 1, Nombre = "Uno", Precio = 10, Descatalogado = false, Descripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis elit odio, egestas et dolor id, rutrum interdum sem." });
            lst.Add(new Producto() { Id = 2, Nombre = "Dos", Precio = 20, Descatalogado = false, Descripcion = "Fusce ultricies lacinia finibus. Ut malesuada sodales venenatis. Integer eget commodo augue, sit amet tempor nunc. Ut viverra quam sed ipsum malesuada." });
            lst.Add(new Producto() { Id = 3, Nombre = "Tres", Precio = 0, Descatalogado = true, Descripcion = "Maecenas at quam sed arcu molestie feugiat. Vivamus vitae ultricies mauris, eget egestas lacus. Nam in finibus ante. " });
        }
        public void Add(Producto item) {
            lst.Add(item);
        }

        public IEnumerable<Producto> GetAll() {
            return lst;
        }

        public Producto GetById(int id) {
            return lst.FirstOrDefault(item => item.Id == id);
        }

        public void Modify(Producto item) {
            var i = lst.FindIndex(data => data.Id == item.Id);
            if (i >= 0) lst.RemoveAt(i);
            lst.Add(item);
        }

        public void Remove(Producto item) {
            var i = lst.FindIndex(data => data.Id == item.Id);
            if (i >= 0) lst.RemoveAt(i);
        }

        public void Remove(int id) {
            var i = lst.FindIndex(data => data.Id == id);
            if (i >= 0) lst.RemoveAt(i);
        }
    }
}
