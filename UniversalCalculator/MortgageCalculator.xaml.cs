using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MortgageCalculator : Page
	{
		const double PERCENTAGE = 0.01;
		const int YEAR_MONTH = 12;
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			double principle;
			int years;
			int months;
			int yearsToMonths;
			double yearlyInterestRate;
			double monthlyInterestRate;
			double topFormula;
			double bottomFormula;
			double monthlyRepayment;

			principle = double.Parse(prinicpleBorrowTextBox.Text);
			years = int.Parse(yearsTextBox.Text);
			months = int.Parse(monthsTextBox.Text);
			yearlyInterestRate = double.Parse(yearlyInterestTextBox.Text);
			monthlyInterestRate = yearlyInterestRate / YEAR_MONTH;
			monthlyInterestRate = Math.Round((double)monthlyInterestRate, 4);
			monthlyInterestTextBox.Text = monthlyInterestRate.ToString() + "%";
			monthlyInterestRate = monthlyInterestRate * PERCENTAGE;

			yearsToMonths = (years * YEAR_MONTH) + months;
			topFormula = principle * (Math.Pow(1 + monthlyInterestRate, yearsToMonths)) * monthlyInterestRate;
			bottomFormula = Math.Pow(1 + monthlyInterestRate, yearsToMonths) - 1;
			monthlyRepayment = topFormula / bottomFormula;
			monthlyRepayment = Math.Round((double)monthlyRepayment, 2);
			monthlyRepaymentTextBox.Text = monthlyRepayment.ToString("C");

		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
