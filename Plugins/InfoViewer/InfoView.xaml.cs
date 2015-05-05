using MetroRadiance.Controls;
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

namespace InfoViewer
{
    public partial class InfoView : UserControl
    {
        public InfoView()
        {
            InitializeComponent();
        }

        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            PromptTextBox tb = e.Source as PromptTextBox;
            tb.PreviewMouseDown += new MouseButtonEventHandler(OnPreviewMouseDown);
        }

        private void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PromptTextBox tb = e.Source as PromptTextBox;
            tb.Focus();
            e.Handled = true;
        }

        private void OnGotFocus(object sender, RoutedEventArgs e)
        {
            PromptTextBox tb = e.Source as PromptTextBox;
            tb.SelectAll();
            Clipboard.SetText(tb.Text);
            tb.PreviewMouseDown -= new MouseButtonEventHandler(OnPreviewMouseDown);
        }
    }
}