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
using SortingVisualiser;
using System.Linq;
using System.Diagnostics;
using SortingVisualiser.SortingAlgorithms;
using SortingVisualiser.Windows;

namespace SortingVisualiser
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenComparisonViewButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            ComparisonView comparisonView = new ComparisonView();
            comparisonView.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void OpenAnimatedBubbleSortButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void OpenAnimatedInsertionSortButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenAnimatedMergeSortButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}