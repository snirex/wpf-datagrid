using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Enumerable.Range(0, 10)
                .Select(i => new { Id = i, Text = "text" + i });

            dg.Loaded += new RoutedEventHandler(dg_Loaded);
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            GetCell(dg, 1, 1).Background = Brushes.Yellow;
        }

        private DataGridCell GetCell(DataGrid dg, int rowIndex, int columnIndex)
        {
            var dr = dg.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            var dc = dg.Columns[columnIndex].GetCellContent(dr);
            return dc.Parent as DataGridCell;
        }
        
        private string RandomString(int length)
        {
            string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
