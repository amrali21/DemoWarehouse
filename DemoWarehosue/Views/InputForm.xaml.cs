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

namespace DemoWarehosue.Views
{
    /// <summary>
    /// Interaction logic for InputForm.xaml
    /// </summary>
    public partial class InputForm : UserControl
    {
        public InputForm()
        {
            InitializeComponent();
            
        }
        //props:
        // id,
        // name,
        // category,
        // last updated

        public static readonly DependencyProperty DisplayTextProperty =
            DependencyProperty.Register("DisplayText", typeof(string), typeof(InputForm), new PropertyMetadata("Default Text"));

        public string DisplayText
        {
            get => (string)GetValue(DisplayTextProperty);
            set => SetValue(DisplayTextProperty, value);
        }

        //we need a function sets these controls that can be called from outside
        //can we 

        // what binding does UserControl take?
        //
    }
}
