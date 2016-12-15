using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BusinessCal.Droid.Code;

namespace BusinessCal.Droid.Screens
{
    [Activity(Label = "Value Added Tax")]
    public class VATScreen : Activity
    {

        protected EditText etPriceExc = null;
        protected EditText etPriceInc = null;
        protected EditText etVAT = null;
        protected TextView lbVAT = null;
        protected Button btnCalculate;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestWindowFeature(WindowFeatures.ActionBar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            SetContentView(Resource.Layout.scrVAT);

            AssignControls();
        }

        protected override void OnResume()
        {
            base.OnResume();
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
            etPriceExc = FindViewById<EditText>(Resource.Id.txtPrice);
            etPriceInc = FindViewById<EditText>(Resource.Id.txtPriceIncVat);
            etVAT = FindViewById<EditText>(Resource.Id.txtValueAddedTax);
            lbVAT = FindViewById<TextView>(Resource.Id.lblVAT);
            btnCalculate = FindViewById<Button>(Resource.Id.btnCalculate);

            btnCalculate.Click += (object sender, EventArgs e) =>
            {
                btnCalculate_Click();
            };
        }

        #region Events
        public void btnCalculate_Click()
        {
            double VAT = (100 + GlobalCode.NullDouble(etVAT.Text)) / 100;
            if (string.IsNullOrEmpty(etPriceExc.Text))
            {
                double PriceInc = GlobalCode.NullDouble(etPriceInc.Text);

                etPriceExc.Text = Math.Round(PriceInc / VAT, 2).ToString();
            }
            else
            {
                double PriceInc = GlobalCode.NullDouble(etPriceExc.Text);

                etPriceInc.Text = Math.Round(PriceInc * VAT, 2).ToString();
            }
            lbVAT.Text = "Value Added Tax: " + string.Format("{0:0.00}",
                                        Math.Round(GlobalCode.NullDouble(etPriceInc.Text) - GlobalCode.NullDouble(etPriceExc.Text), 2));

            GlobalCode.ShowToast(this, "Calculation Done");
        }
        #endregion Events

        
    }
}