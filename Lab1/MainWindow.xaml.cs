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

namespace Lab1
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

        private void _DPSelectedDateChanged (object sender, SelectionChangedEventArgs e)
        {

            DateTime? date = DatePick.SelectedDate;

            try
            {
                DateOfBirthViemModel model = new DateOfBirthViemModel(date);
                TBAge.Text = "Your age is " + model.Age;
                TBWestZodiak.Text = "Western zodiak: " + model.ZodiacWest;
                TBChineseZodiak.Text = "China zodiak: " + model.ZodiacChinese;
                if (model.IsaBDay)
                    MessageBox.Show("Z DNEM NARODZHENNYA ! SLAVA UKRAINE");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("You enter illegal date!");
            }

        }
    }
}
