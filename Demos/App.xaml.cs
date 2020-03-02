using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Demos {
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application {

        private void Arranque(object sender, StartupEventArgs e) {
            var dlg = new cDlg();
            if (dlg.ShowDialog() == true) {
                MainWindow = new frmPrincipal();
                MainWindow.Show();

            }
        }
    }
}
