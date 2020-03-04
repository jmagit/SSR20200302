using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServices {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ProductosService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ProductosService.svc o ProductosService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ProductosService : IProductosService {
        private Domains.Services.ProductosService srv = new Domains.Services.ProductosService();
        public void Add(Producto item) {
            srv.Add(item);
        }

        public IEnumerable<Producto> GetAll() {
            return srv.GetAll();
        }

        public Producto GetById(int id) {
            return srv.GetById(id);
        }

        public void Modify(Producto item) {
            srv.Modify(item);
        }

        public void Remove(Producto item) {
            srv.Remove(item);
        }

        public void RemoveById(int id) {
            srv.Remove(id);
        }
    }
}
