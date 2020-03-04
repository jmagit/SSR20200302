using Aplication.Core;
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

        private ACTOR elemento;
        public ACTOR Elemento {
            get => elemento;
            set {
                elemento = value;
                NotifyPropertyChanged();
            }
        }

        public DelegateCommand Cargar => new DelegateCommand(
            cmdArg => {
                var db = new SakilaEntities();
                Listado = new ObservableCollection<ACTOR>(
                    db.ACTOR.ToList()
                    );
                NotifyPropertyChanged(nameof(Listado));
                Cambia.Execute();
            }
            );
        public DelegateCommand Falla => new DelegateCommand(
            cmdArg => {
                if (elemento != null)
                    elemento.FIRST_NAME = "kkkkkk";
            }
            );

        private bool visible = true;
        public bool Visible {
            get => visible;
            set {
                visible = value;
                NotifyPropertyChanged();
            }
        }

        public DelegateCommand Cambia => new DelegateCommand(
            cmdArg => {
                Visible = !Visible;
            }
        );
    }
}
