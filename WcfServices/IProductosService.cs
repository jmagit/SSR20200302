using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServices {
    [ServiceContract]
    public interface CRUDService<TEntity, Key> where TEntity : class {
        [OperationContract]
        IEnumerable<TEntity> GetAll();
        [OperationContract]
        TEntity GetById(Key id);
        [OperationContract]
        void Add(TEntity item);
        [OperationContract]
        void Remove(TEntity item);
        [OperationContract]
        void RemoveById(Key id);
        [OperationContract]
        void Modify(TEntity item);
    }

    [ServiceContract]
    public interface IProductosService : CRUDService<Producto, int> {
    }
}
