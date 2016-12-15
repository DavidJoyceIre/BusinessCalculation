using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Graphics;
using Android.Views;
using BusinessCal.Droid.Code;
using Android.Util;
using System.Reflection;

namespace BusinessCal.Droid.Screens
{
    [Activity(Label = "Calculate Gross Profit")]
    public class GrossProfitScreen : Activity
    {
        protected Button btnCalculate;
        protected EditText etSales = null;
        protected EditText etCostOfGoodsSold = null;
        protected TextView lbGrossProfit = null;
        protected TextView lbGrossProfitMargin = null;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            RequestWindowFeature(WindowFeatures.ActionBar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
            
            SetContentView(Resource.Layout.scrGrossProfit);

            AssignDetails();
            //Window.SetSoftInputMode(SoftInput.StateHidden);
            
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
            etSales = FindViewById<EditText>(Resource.Id.txtSales);
            etCostOfGoodsSold = FindViewById<EditText>(Resource.Id.txtCostOfGoods);

            lbGrossProfit = FindViewById<TextView>(Resource.Id.lblGrossProfit);
            lbGrossProfitMargin = FindViewById<TextView>(Resource.Id.lblGrossProfitMargin);
            
            btnCalculate.Click += (object sender, EventArgs e) =>
            {
                btnCalculate_Click();
            };
        }

        #region Events
        public void btnCalculate_Click()
        {
            double salesValue = GlobalCode.NullDouble(etSales.Text);
            double costOfGoodsSold = GlobalCode.NullDouble(etCostOfGoodsSold.Text);
            double grossProfit = salesValue - costOfGoodsSold;

            lbGrossProfit.Text = string.Format("Gross Profit: {0:0.00}",
                                                Math.Round(grossProfit, 2));

            lbGrossProfitMargin.Text = string.Format("Gross Profit Margin (%): {0:0.00}",
                                                Math.Round((grossProfit / salesValue) * 100, 2));

            GlobalCode.ShowToast(this, "Calculation Done");
        }
        #endregion Events
    }
}