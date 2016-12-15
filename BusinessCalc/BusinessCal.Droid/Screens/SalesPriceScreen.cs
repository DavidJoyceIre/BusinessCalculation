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
    [Activity(Label = "Calcualate Sales Price")]
    public class SalesPriceScreen : Activity
    {
        protected EditText etCostPrice = null;
        protected EditText etVAT = null;
        protected EditText etMargin = null;
        protected EditText etSalesPrice = null;
        protected Button btnCalculate = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestWindowFeature(WindowFeatures.ActionBar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            SetContentView(Resource.Layout.scrSalesPrice);

            AssignControls();
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

        private void AssignControls()
        {
            etCostPrice = FindViewById<EditText>(Resource.Id.txtCostPrice);
            etVAT = FindViewById<EditText>(Resource.Id.txtValueAddedTax);
            etMargin = FindViewById<EditText>(Resource.Id.txtMargin);
            etSalesPrice = FindViewById<EditText>(Resource.Id.txtSalesPrice);

            btnCalculate = FindViewById<Button>(Resource.Id.btnCalculate);
            
            btnCalculate.Click += (object sender, EventArgs e) =>
            {
                btnCalculate_Click();
            };
        }

        #region Events
        public void btnCalculate_Click()
        {
            double costPrice = GlobalCode.NullDouble(etCostPrice.Text);
            double VAT = (GlobalCode.NullDouble(etVAT.Text) + 100) / 100;
            double Margin = (GlobalCode.NullDouble(etMargin.Text) + 100) / 100;
            double salesPrice = costPrice * VAT;

            salesPrice = salesPrice * Margin;

            etSalesPrice.Text = string.Format("{0:0.00}",
                                                Math.Round(salesPrice, 2));

            GlobalCode.ShowToast(this, "Calculation Done");
        }
        #endregion Events
    }
}