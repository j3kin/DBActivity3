using DBActivity3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DBActivity3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BmiView : ContentPage
    {
        FiebaseService firebaseHelper = new FiebaseService();
        public BmiView()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var allBmis = await firebaseHelper.GetAllBmi();
            bmilist.ItemsSource = allBmis;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            string category;
            double bmi = (Convert.ToDouble(weight.Text) / Convert.ToDouble(height.Text) / Convert.ToDouble(height.Text)) * 10000;
            if (bmi < 18.5)
                category = "underweight";
            else if (bmi >= 18.5 && bmi < 24.9)
                category = "Normal weight";
            else if (bmi >= 25)
                category = "Overweight";
            else
                category = "Obesity ";

            await firebaseHelper.AddBMI(Convert.ToInt32(idnum.Text), name.Text, Convert.ToDouble(height.Text), Convert.ToDouble(weight.Text), bmi, category);
            height.Text = "";
            weight.Text = "";
            name.Text = "";
            idnum.Text = "";
            var allBmis = await firebaseHelper.GetAllBmi();
            bmilist.ItemsSource = allBmis;

        }
    }
}