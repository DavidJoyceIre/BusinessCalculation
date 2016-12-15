using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Views;

namespace BusinessCal.Droid.Screens
{
    [Activity(Label = "Business Calculations", MainLauncher = true)]
    public class HomeScreen : Activity
    {
        protected Button btnVat;
        protected Button btnGrossProfit;
        protected Button btnSalesPrice;
        protected Button btnBreakEven;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            RequestWindowFeature(WindowFeatures.ActionBar);

            SetContentView(Resource.Layout.scrHomeScreen);

            SetUpTheForm();
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
                case Resource.Id.mnuLogout:
                    return true;
                case Resource.Id.mnuMyDetails:
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }

        }
        
        private void SetUpTheForm()
        {

            btnVat = FindViewById<Button>(Resource.Id.btnVat);
            btnGrossProfit = FindViewById<Button>(Resource.Id.btnGrossProfit);
            btnSalesPrice = FindViewById<Button>(Resource.Id.btnSalePrice);
            btnBreakEven = FindViewById<Button>(Resource.Id.btnBreakEven);

            btnVat.Click += (object sender, System.EventArgs e) =>
            {
                btnVat_Click();
            };
            btnGrossProfit.Click += (object sender, System.EventArgs e) =>
            {
                btnGrossProfit_Click();
            };
            btnSalesPrice.Click += (object sender, System.EventArgs e) =>
            {
                btnSalesPrice_Click();
            };
            btnBreakEven.Click += (object sender, System.EventArgs e) =>
            {
                btnBreakEven_Click();
            };
        }

        #region Events
        public void btnVat_Click()
        {
            StartActivity(typeof(VATScreen));
        }

        public void btnGrossProfit_Click()
        {
            StartActivity(typeof(GrossProfitScreen));
        }

        public void btnSalesPrice_Click()
        {
            StartActivity(typeof(SalesPriceScreen));
        }

        public void btnBreakEven_Click()
        {
            StartActivity(typeof(BreakEvenPointScreen));
        }
        #endregion Event
    }
}