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

namespace DormMealPlanCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool dormitorySelected = false;
        bool mealSelected = false;

        TotalWindow totalWindow = null;
        DormMealPlanCalculatorVM vm = DormMealPlanCalculatorVM.GetInstance();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Button_Submit_Click(object sender, RoutedEventArgs e)
        {
            if (totalWindow == null)
            {
                totalWindow = new TotalWindow();
                totalWindow.Closed += TotalWindow_Closed;
                totalWindow.Show();
            }
        }

        private void TotalWindow_Closed(object sender, EventArgs e)
        {
            totalWindow = null;
        }

        private void Dormitory_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (lbxDormitory.SelectedItem != null)
            {
                vm.SetDormitory((DormitoryItem)lbxDormitory.SelectedItem);

                dormitorySelected = true;

                if (mealSelected)
                    btnSubmit.IsEnabled = true;
            }
        }

        private void Meal_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (lbxMeal.SelectedItem != null)
            {
                vm.SetMeal((MealItem)lbxMeal.SelectedItem);

                mealSelected = true;

                if (dormitorySelected)
                    btnSubmit.IsEnabled = true;
            }
        }
    }
}
