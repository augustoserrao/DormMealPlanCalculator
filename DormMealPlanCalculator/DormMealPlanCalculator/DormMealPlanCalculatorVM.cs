using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DormMealPlanCalculator
{
    class DormMealPlanCalculatorVM : INotifyPropertyChanged
    {
        DormitoryItem selectedDormitory = null;
        MealItem selectedMeal = null;

        static DormMealPlanCalculatorVM instance = null;

        List<DormitoryItem> dormitoryList = new List<DormitoryItem>
        {
            new DormitoryItem() { Name = "Allen Hall"       , ImagePath = "Images/Allen_Hall.jpg"       , PricePerSemester = 1500 },
            new DormitoryItem() { Name = "Pike Hall"        , ImagePath = "Images/Pike_Hall.jpg"        , PricePerSemester = 1600 },
            new DormitoryItem() { Name = "Farthing Hall"    , ImagePath = "Images/Farthing_Hall.jpg"    , PricePerSemester = 1800 },
            new DormitoryItem() { Name = "University Suites", ImagePath = "Images/University_Suites.jpg", PricePerSemester = 2500 }
        };

        List<MealItem> mealList = new List<MealItem>
        {
            new MealItem() { Name = "7 meals/week", ImagePath = "Images/Poor_Meal.jpg", PricePerSemester = 600 },
            new MealItem() { Name = "14 meals/week", ImagePath = "Images/Regular_Meal.jpg", PricePerSemester = 1200 },
            new MealItem() { Name = "21 meals/week", ImagePath = "Images/Good_Meal.jpg", PricePerSemester = 1400 },
            new MealItem() { Name = "Unlimited meals", ImagePath = "Images/Amazing_Meal.jpg", PricePerSemester = 1700 }
        };

        decimal total = 0;

        public List<DormitoryItem> DormitoryList
        {
            get => dormitoryList;
            set { dormitoryList = value; propertyChanged(); }
        }

        public List<MealItem> MealList
        {
            get => mealList;
            set { mealList = value; propertyChanged(); }
        }

        public DormitoryItem SelectedDormitory
        {
            get => selectedDormitory;
            set { selectedDormitory = value; propertyChanged(); }
        }

        public MealItem SelectedMeal
        {
            get => selectedMeal;
            set { selectedMeal = value; propertyChanged(); }
        }

        public decimal Total
        {
            get => total;
            set { total = value; propertyChanged(); }
        }

        public static DormMealPlanCalculatorVM GetInstance()
        {
            if (instance == null)
            {
                instance = new DormMealPlanCalculatorVM();
            }

            return instance;
        }

        public void SetDormitory(DormitoryItem dorm)
        {
            this.selectedDormitory = dorm;
            calculateTotal();
        }

        public void SetMeal(MealItem meal)
        {
            this.selectedMeal = meal;
            calculateTotal();
        }

        void calculateTotal()
        {
            if (selectedDormitory == null || selectedMeal == null)
                return;

            Total = selectedDormitory.PricePerSemester + selectedMeal.PricePerSemester;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void propertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
