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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demos.Views {
    /// <summary>
    /// Lógica de interacción para ucPersonalizado.xaml
    /// </summary>
    public partial class ucPersonalizado : UserControl {


        public String Titulo {
            get { return (String)GetValue(TituloProperty); }
            set { 
                SetValue(TituloProperty, value);
                txtTitulo.Text = Titulo;
            }
        }

        public string kk { get; set; }

        // Using a DependencyProperty as the backing store for Titulo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TituloProperty =
            DependencyProperty.Register("Titulo", typeof(String), typeof(ucPersonalizado), new PropertyMetadata("Hola Mundo"));


        public ucPersonalizado() {
            InitializeComponent();
        }
    }
}
