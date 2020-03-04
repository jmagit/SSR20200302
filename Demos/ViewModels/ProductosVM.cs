using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Datos;
using Entidades;
using Aplication.Core;
using Demos.Servicios;

namespace Demos.ViewModels {
    public class ProductosVM : ObservableBase, IClosed, ICanClosed {
        private IProductosService srv = new ProductosServiceClient();

        public event EventHandler<CancelEventArgs> Closed;
        public event EventHandler<EventArgs> Aceptado;
        public event EventHandler<EventArgs> Cancelado;

        protected virtual void OnClosed() {
            Closed?.Invoke(this, new CancelEventArgs());
        }
        protected virtual void OnClosed(ref CancelEventArgs e) {
            Closed?.Invoke(this, e);
        }
        protected virtual void OnAceptado() {
            Aceptado?.Invoke(this, new EventArgs());
        }
        protected virtual void OnCancelado() {
            Cancelado?.Invoke(this, new EventArgs());
        }

        public bool CanClosed() {
            return modo != EstadoCRUD.add && modo != EstadoCRUD.edit;
        }

        private ObservableCollection<Producto> listado;
        public ObservableCollection<Producto> Listado {
            get {
                return listado;
            }
        }
        private Producto seleccionado;
        public Producto Seleccionado {
            get {
                return seleccionado;
            }
            set {
                if (seleccionado != value) {
                    seleccionado = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private Producto elemento;
        public Producto Elemento {
            get {
                return elemento;
            }
            set {
                if (elemento != value) {
                    elemento = value;
                    if (elemento != null)
                        elemento.PropertyChanged += (s, ev) => NotifyPropertyChanged(nameof(Accept));
                    NotifyPropertyChanged();
                }
            }
        }

        private EstadoCRUD modo = EstadoCRUD.list;
        public EstadoCRUD Modo {
            get {
                return modo;
            }
            set {
                if (modo != value) {
                    modo = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(EsList));
                    NotifyPropertyChanged(nameof(EsAdd));
                    NotifyPropertyChanged(nameof(EsEdit));
                    NotifyPropertyChanged(nameof(EsView));
                }
            }
        }

        public bool EsList => modo == EstadoCRUD.list;
        public bool EsAdd => modo == EstadoCRUD.add;
        public bool EsEdit => modo == EstadoCRUD.edit;
        public bool EsView => modo == EstadoCRUD.view;

        public DelegateCommand List {
            get {
                return new DelegateCommand(cmdArg => {
                    listado = new ObservableCollection<Producto>(srv.GetAll());
                    NotifyPropertyChanged(nameof(Listado));
                    Seleccionado = listado.FirstOrDefault();
                    Modo = EstadoCRUD.list;
                });
            }
        }

        public DelegateCommand Add {
            get {
                return new DelegateCommand(cmdArg => {
                    Elemento = new Producto();
                    Modo = EstadoCRUD.add;
                    accept = new DelegateCommand(x => {
                        srv.Add(Elemento);
                        cancelEdit();
                        OnAceptado();
                    });
                    NotifyPropertyChanged(nameof(Accept));
                });
            }
        }
        public DelegateCommand Edit {
            get {
                return new DelegateCommand(cmdArg => {
                    if (cmdArg != null) {
                        Elemento = srv.GetById((int)cmdArg);
                        Modo = EstadoCRUD.edit;
                        accept = new DelegateCommand(x => {
                            srv.Modify(Elemento);
                            cancelEdit();
                            OnAceptado();
                        });
                        NotifyPropertyChanged(nameof(Accept));
                    }
                });
            }
        }
        public DelegateCommand View {
            get {
                return new DelegateCommand(cmdArg => {
                    if (cmdArg != null) {
                        Elemento = srv.GetById((int)cmdArg);
                        Modo = EstadoCRUD.view;
                    }
                });
            }
        }
        public DelegateCommand Delete {
            get {
                return new DelegateCommand(cmdArg => {
                    if (cmdArg != null) {
                        srv.RemoveById((int)cmdArg);
                        //Modo = EstadoCRUD.delete;
                        List.Execute();
                    }
                });
            }
        }
        protected void cancelEdit() {
            Elemento = null;
            List.Execute();
            accept = null;
        }
        public DelegateCommand Cancel {
            get {
                return new DelegateCommand(cmdArg => {
                    cancelEdit();
                    OnCancelado();
                });
            }
        }
        public DelegateCommand Accept {
            get {
                return new DelegateCommand(cmdArg => {
                    switch (Modo) {
                        case EstadoCRUD.add:
                            srv.Add(Elemento);
                            Cancel.Execute();
                            break;
                        case EstadoCRUD.edit:
                            srv.Modify(Elemento);
                            Cancel.Execute();
                            break;
                    }
                }, cmdArg => Elemento != null && Elemento.IsValid);
            }
        }
        protected DelegateCommand accept = null;
        // protected DelegateCommand accept = new DelegateCommand(cmdArg => {
        //            switch (Modo) {
        //                case EstadoCRUD.add:
        //                    srv.Add(Elemento);
        //                    Cancel.Execute();
        //                    break;
        //                case EstadoCRUD.edit:
        //                    srv.Modify(Elemento);
        //                    Cancel.Execute();
        //                    break;
        //            }
        //        }, cmdArg => Elemento != null && Elemento.IsValid);

        public DelegateCommand Close {
            get {
                return new DelegateCommand(cmdArg => {
                    OnClosed();
                });
            }
        }
    }
}
