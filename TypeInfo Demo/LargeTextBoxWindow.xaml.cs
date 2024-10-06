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

namespace TypeInfo_Demo
{
    /// <summary>
    /// Interaction logic for LargeTextBoxWindow.xaml
    /// </summary>
    public partial class LargeTextBoxWindow : Window
    {
        public LargeTextBoxWindow()
        {
            InitializeComponent();
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
