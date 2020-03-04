using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Aplication.Core;
using Demos.ViewModels;
using Demos.Views;

namespace Demos {
    /// <summary>
    /// Lógica de interacción para frmPrincipal.xaml
    /// </summary>
    public partial class frmPrincipal : Window {
        public frmPrincipal() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            var win = new MainWindow();
            win.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            var win = new MainWindow();
            win.Owner = this;
            win.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            var dlg = new cDlg();
            dlg.Owner = this;
            if(dlg.ShowDialog() == true) {

            }

        }

        private ucPersonas personas = null;
        private void Button_Click_3(object sender, RoutedEventArgs e) {
            //if(personas == null) {
            //    personas = new ucPersonas();
            //}
            //ccHost.Content = personas;
            ccHost.Content = new ucProductos();
        }

        private void abrir(UserControl uc, object vm = null) {
            if (vm != null) {
                uc.DataContext = vm;
            }
            if (uc.DataContext is IClosed)
                (uc.DataContext as IClosed).Closed += (s, ev) => {
                    if (!(uc.DataContext is ICanClosed) || (uc.DataContext as ICanClosed).CanClosed())
                        Cerrar();
                };
            ccHost.Content = uc;
        }

        private void Cerrar() {
            ccHost.Content = null;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) {
            var vm = new ProductosVM();
            vm.PropertyChanged += (s, ev) => {
                if (ev.PropertyName == nameof(ProductosVM.Modo))
                    switch (vm.Modo) {
                        case EstadoCRUD.list:
                            abrir(new ProductosLst(), vm);
                            break;
                        case EstadoCRUD.add:
                        case EstadoCRUD.edit:
                            abrir(new ProductosForm(), vm);
                            break;
                        case EstadoCRUD.view:
                            abrir(new ProductosView(), vm);
                            break;
                    }
            };
            abrir(new ProductosLst(), vm);
            vm.List.Execute();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e) {
            ccHost.Content = null;
        }
        private void Button_Click_6(object sender, RoutedEventArgs e) {
            App.Current.Shutdown();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e) {
            var wb = new WebBrowser();
            wb.Navigate("https://iga.emea.corpinter.net/guestwifi/ES157i/connected.html");
            ccHost.Content = wb;

        }

        private void btnActores_Click(object sender, RoutedEventArgs e) {
            var uc = new ucActores();
            uc.DataContext = new ActoresVM();
            ccHost.Content = uc;
        }
    }
}
