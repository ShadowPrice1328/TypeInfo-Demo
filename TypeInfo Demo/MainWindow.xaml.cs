using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TypeInfo_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string typeName = Input.Text.Trim();
            Type? T = Type.GetType(typeName, false, true);

            if (T != null)
            {
                List<MethodInfo> methods = T.GetMethods().ToList();
                List<PropertyInfo> properties = T.GetProperties().ToList();
                List<ConstructorInfo> constructors = T.GetConstructors().ToList();

                string methodsString = string.Join('\n', methods.Select(m =>
                {
                    string parameters = string.Join(", ", m.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                    return $"{m.Name}({parameters}) => {m.ReturnType.Name}";
                }));

                string propertiesString = string.Join('\n', properties.Select(p => $"{p.Name} => {p.PropertyType.Name}"));

                string constructorsString = string.Join('\n', constructors.Select(c =>
                {
                    string parameters = string.Join(", ", c.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                    return $"({parameters})";
                }));

                Methods.Text = methodsString;
                Properties.Text = propertiesString;
                Constructors.Text = constructorsString;
            }
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Input.Text == "Type name...")
            {
                Input.Text = string.Empty;
                Input.Foreground = Brushes.Black;
            }
        }
        private void Input_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Input.Text))
            {
                Input.Text = "Type name...";
                Input.Foreground = Brushes.SlateGray;
            }
        }
    }
}