using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BusinessCal.Droid.Code;

namespace BusinessCal.Droid.Screens
{
    [Activity(Label = "Break Even Point")]
    public class BreakEvenPointScreen : Activity
    {
        protected Button btnCalculate;
        protected EditText etFixedExpenses = null;
        protected EditText etVariableExpenses = null;
        protected EditText etTotalSales = null;
        protected TextView lbBreakEvenPoint = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            RequestWindowFeature(WindowFeatures.ActionBar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);


            ActionBar.SetHomeButtonEnabled(true);

            SetContentView(Resource.Layout.scrBreakEven);

            AssignDetails();
        }

        protected void Save()
        {
            Finish();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                default:
                    Finish();
                    return base.OnOptionsItemSelected(item);
            }
        }

        public void btnOk_Click()
        {
            Finish();
        }

        private void AssignDetails()
        {
            btnCalculate = FindViewById<Button>(Resource.Id.btnCalculate);
            etFixedExpenses = FindViewById<EditText>(Resource.Id.txtFixedExpenses);
            etVariableExpenses = FindViewById<EditText>(Resource.Id.txtVariableExpenses);
            etTotalSales = FindViewById<EditText>(Resource.Id.txtTotalSales);

            lbBreakEvenPoint = FindViewById<TextView>(Resource.Id.lblBreakEvenPoint);

            btnCalculate.Click += (object sender, EventArgs e) =>
            {
                btnCalculate_Click();
            };
        }

        #region Events
        public void btnCalculate_Click()
        {
            double fixedExpenses = GlobalCode.NullDouble(etFixedExpenses.Text);
            double variableExpenses = GlobalCode.NullDouble(etVariableExpenses.Text);
            double totalSales = GlobalCode.NullDouble(etTotalSales.Text);
            if (0 != totalSales)
            {
                double ContributionMargin  = (totalSales - variableExpenses) / totalSales;

                lbBreakEvenPoint.Text = string.Format("Break Even Point: {0:0.00}",
                                                    Math.Round(fixedExpenses / ContributionMargin, 2));

                GlobalCode.ShowToast(this, "Calculation Done");
            }
            else
            {
                GlobalCode.ShowToast(this, "Total Sales cannot be Zero");
            }
        }
        #endregion Events
    }
}