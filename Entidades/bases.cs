using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class ObservableBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null) {
            Debug.Assert(
                string.IsNullOrEmpty(propertyName) ||
                (GetType().GetProperty(propertyName) != null),
                "Check that the property name exists for this instance.");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    [DataContract]
    public class EntityBase : ObservableBase, IDataErrorInfo {
        public virtual string this[string columnName] => null;

        public virtual string Error {
            get {
                var msg = "";
                foreach(var p in GetType().GetProperties()) {
                    var cad = this[p.Name];
                    if(!string.IsNullOrWhiteSpace(cad)) { msg += '\n' + cad; }
                }
                if (string.IsNullOrWhiteSpace(msg))
                    return null;
                else
                    return msg.Substring(1);
            }
        }

        public virtual bool IsValid => Error == null;
        public virtual bool IsInvalid => !IsValid;

    }
}
