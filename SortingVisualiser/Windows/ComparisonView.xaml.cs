using SortingVisualiser.SortingAlgorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SortingVisualiser.Windows
{
    public partial class ComparisonView : Window
    {
        public ComparisonView()
        {
            InitializeComponent();
        }

        MyLinkedList oldArray = new MyLinkedList();

        // Randomise button is clicked and a random array is displayed
        private void RandomiseButton_Click(object sender, RoutedEventArgs e)
        {

            ClearPanel();

            // Get size from text box
            if (int.TryParse(SizeInput.Text, out int arraySize) && arraySize > 0 && arraySize <= 800)
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
            int[] currentArray = GetCurrentArray();
            oldArray.ConvertArrayToLinkedList(currentArray);

            // Bubble sort
            double ticks;
            int comparisons;
            int swaps;
            BubbleSorts.BubbleSort(currentArray, out ticks, out comparisons, out swaps);

            // Display the sorted array on the visualising panel
            ClearPanel();
            VisualiseArray(currentArray);

            DisplayElapsedTime(ticks);
            DisableSorts();

        }

        private void InsertionSortButton_Click(object sender, RoutedEventArgs e)
        {
            // Get array from the display panel bit by getting the text stored in each bar
            int[] currentArray = GetCurrentArray();
            oldArray.ConvertArrayToLinkedList(currentArray);

            // Insertion sort
            double milliseconds;
            int comparisons;
            int swaps;
            InsertionSorts.InsertionSort(currentArray, out milliseconds, out comparisons, out swaps);

            // Display the sorted array on the visualising panel
            ClearPanel();
            VisualiseArray(currentArray);

            DisplayElapsedTime(milliseconds);
            DisableSorts();
            
        }

        private void MergeSortButton_Click(object sender, RoutedEventArgs e)
        {
            // Get array from the display panel bit by getting the text stored in each bar
            int[] currentArray = GetCurrentArray();
            oldArray.ConvertArrayToLinkedList(currentArray);
            // Merge sort
            Stopwatch sw = Stopwatch.StartNew();
            MergeSorts.MergeSort(currentArray);
            sw.Stop();

            // Display the sorted array on the visualising panel
            ClearPanel();
            VisualiseArray(currentArray);

            DisplayElapsedTime(sw.ElapsedTicks);
            DisableSorts();
            
        }

        #region Visual Methods
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

        private void UnsortButton_Click(object sender, RoutedEventArgs e)
        {
            int[] unsortedArray = oldArray.ConvertLinkedListToArray();
            ClearPanel();
            VisualiseArray(unsortedArray);
            AllowSorts();
        }

        private int[] GetCurrentArray()
        {
            int[] currentArray = VisualisingPanel.Children
                .Cast<Border>()
                .Select(b => int.Parse(((TextBlock)b.Child).Text))
                .ToArray();
            return currentArray;
        }

        private void DisplayElapsedTime(double ticks)
        {
            double microseconds = ticks / 10;
            if (microseconds < 1000)
            {
                ActualTimeLabel.Content = $"{microseconds:F2} μs";
            }
            else
            {
                ActualTimeLabel.Content = $"{microseconds / 1000:F2} ms";
            }
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
            UnsortButton.IsEnabled = false;
        }

        private void DisableSorts()
        {
            BubbleSortButton.IsEnabled = false;
            InsertionSortButton.IsEnabled = false;
            MergeSortButton.IsEnabled = false;
            UnsortButton.IsEnabled = true;
        }


        private void MaxSizeButton_Click(object sender, RoutedEventArgs e)
        {
            SizeInput.Text = "800";
        }
        #endregion
    }
}
