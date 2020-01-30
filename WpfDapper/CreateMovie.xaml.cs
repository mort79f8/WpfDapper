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
using WpfDapper.BIZ;
using WpfDapper.GUI;

namespace WpfDapper
{
    /// <summary>
    /// Interaction logic for CreateMovie.xaml
    /// </summary>
    public partial class CreateMovie : Window
    {
        ClassBiz biz = new ClassBiz();
        
        public CreateMovie()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CreateMovieBtn_Click(object sender, RoutedEventArgs e)
        {
            biz.CreateMovie(TitelTextBox.Text, LandTextBox.Text, int.Parse(YearTextBox.Text), GenreTextBox.Text, int.Parse(OscarsTextBox.Text));
            this.Close();
        }
    }
}
