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

namespace SortingVisualiser
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

        // Randomise button is clicked and a random array is displayed
        private void RandomiseButton_Click(object sender, RoutedEventArgs e)
        {

            ClearPanel();

            // Get size from text box
            if (int.TryParse(SizeInput.Text, out int arraySize) && arraySize > 0 && arraySize <= 500)
            {
                int[] arr = new int[arraySize];
                GeneratingArray.FillArray(arr);
                VisualiseArray(arr);
            }
            else
            {
                int[] arr = new int[10];
                SizeInput.Text = "10";
                GeneratingArray.FillArray(arr);
                VisualiseArray(arr);
            }

            AllowSorts();

        }

        private void BubbleSortButton_Click(object sender, RoutedEventArgs e)
        {
            // Get array from the display panel bit by getting the text stored in each bar
            int[] currentArray = VisualisingPanel.Children
                .Cast<Border>()
                .Select(b => int.Parse(((TextBlock)b.Child).Text))
                .ToArray();

            // Bubble sort
            double milliseconds;
            SortingAlgorithms.BubbleSort(currentArray, out milliseconds);

            // Display the sorted array on the visualising panel
            ClearPanel();
            VisualiseArray(currentArray);

            DisplayElapsedTime(milliseconds);
            DisableSorts();
        }

        private void InsertionSortButton_Click(object sender, RoutedEventArgs e)
        {
            // Get array from the display panel bit by getting the text stored in each bar
            int[] currentArray = VisualisingPanel.Children
                .Cast<Border>()
                .Select(b => int.Parse(((TextBlock)b.Child).Text))
                .ToArray();

            // Insertion sort
            double milliseconds;
            SortingAlgorithms.InsertionSort(currentArray, out milliseconds);

            // Display the sorted array on the visualising panel
            ClearPanel();
            VisualiseArray(currentArray);

            DisplayElapsedTime(milliseconds);
            DisableSorts();
        }

        private void MergeSortButton_Click(object sender, RoutedEventArgs e)
        {
            // Get array from the display panel bit by getting the text stored in each bar
            int[] currentArray = VisualisingPanel.Children
                .Cast<Border>()
                .Select(b => int.Parse(((TextBlock)b.Child).Text))
                .ToArray();
            // Merge sort
            SortingAlgorithms.MergeSort(currentArray);
            // Display the sorted array on the visualising panel
            ClearPanel();
            VisualiseArray(currentArray);
            DisableSorts();
        }


        // Display the array on the visualising panel
        private void VisualiseArray(int[] array)
        {
            int ScaleFactor = 800 / array.Length;
            foreach (int i in array)
            {
                Border bar = new Border
                {
                    Height = i * ScaleFactor,
                    Background = Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Bottom,

                    Child = new TextBlock 
                    {
                        Text = i.ToString(),
                        Foreground = array.Length > 100 ? Brushes.Black : Brushes.White,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center 
                    }
                };

                VisualisingPanel.Children.Add(bar);
            }
        }

        private void DisplayElapsedTime(double milliseconds)
        {
            ActualTimeLabel.Content = $"{milliseconds} ms";
        }

        private void ClearPanel()
        {
            VisualisingPanel.Children.Clear();
        }

        private void AllowSorts()
        {
            BubbleSortButton.IsEnabled = true;
            InsertionSortButton.IsEnabled = true;
            MergeSortButton.IsEnabled = true;
        }

        private void DisableSorts()
        {
            BubbleSortButton.IsEnabled = false;
            InsertionSortButton.IsEnabled = false;
            MergeSortButton.IsEnabled = false;
        }

    }
}