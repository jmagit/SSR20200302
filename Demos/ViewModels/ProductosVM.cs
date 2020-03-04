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
using Domains.Services;

namespace Demos.ViewModels {
    public class ProductosVM : ObservableBase, IClosed, ICanClosed {
        //private IProductosService srv = new ProductosServiceClient();
        private ProductosService srv = new ProductosService();

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
                        elemento.PropertyChanged += (s, ev) => { if (Accept != null) Accept.IsEnabled = true; };
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
                    }, x => Elemento != null && Elemento.IsValid);
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
                        }, x => Elemento != null && Elemento.IsValid);
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
                        accept = Cancel;
                    }
                });
            }
        }
        public DelegateCommand Delete {
            get {
                return new DelegateCommand(cmdArg => {
                    if (cmdArg != null) {
                        // srv.RemoveById((int)cmdArg);
                        srv.Remove((int)cmdArg);
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
        protected DelegateCommand accept = null;
        public DelegateCommand Accept => accept;


        public DelegateCommand Close {
            get {
                return new DelegateCommand(cmdArg => {
                    OnClosed();
                });
            }
        }

        public ObservableCollection<Elemento<int>> ListaDeCategorias {
            get {
                var rslt = new ObservableCollection<Elemento<int>>();
                rslt.Add(new Elemento<int>(0, "General"));
                rslt.Add(new Elemento<int>(1, "Buena"));
                rslt.Add(new Elemento<int>(2, "Mala"));
                return rslt;
            }
        }

    }
}
