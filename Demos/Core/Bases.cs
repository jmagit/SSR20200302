using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Core {
    public interface IClosed {
        event EventHandler<CancelEventArgs> Closed;
    }
    public interface ICanClosed {
        bool CanClosed();
    }

    public enum EstadoCRUD {
        list,
        add,
        edit,
        view,
        delete
    }

    public class Elemento<Key> {
        public Key Value { get; set; }
        public string Display { get; set; }

        public Elemento(Key Value, string Display) {
            this.Value = Value;
            this.Display = Display;
        }
    }

}