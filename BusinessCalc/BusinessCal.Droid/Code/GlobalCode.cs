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
using System.Globalization;

namespace BusinessCal.Droid.Code
{
    public static class GlobalCode
    {
        static ProgressDialog progressDialog = null;

        //public static void RefreshAnimal()
        //{
        //    //if ("" != HerdDetails.GUID)
        //    //{
        //    //    WWWherdledger.app API = new WWWherdledger.app();
        //    //    BL.Animal appAnimal = new BL.Animal();

        //    //    foreach (WWWherdledger.tblanimals Record in API.GetAnimals(HerdDetails.GUID))
        //    //    {
        //    //        appAnimal = new BL.Animal();
        //    //        appAnimal.GUID = Record.GUID;
        //    //        appAnimal.TAG_NUMBER = Record.tag_number;
        //    //        appAnimal.FARM_GUID = Record.farm_GUID;
        //    //        appAnimal.DATE_OF_BIRTH = string.Format("{0:dd/MM/yyyy}", Record.date_of_birth);
        //    //        appAnimal.BREED = Record.breed;
        //    //        appAnimal.SEX = Record.sex;
        //    //        appAnimal.BOUGHT_FROM = Record.bought_from;
        //    //        appAnimal.BOUGHT_WEIGHT = Record.bought_weight;
        //    //        appAnimal.BOUGHT_DATE = string.Format("{0:dd/MM/yyyy}", Record.bought_date);
        //    //        appAnimal.BOUGHT_AMOUNT = Record.bought_amount;
        //    //        appAnimal.CURRENT_WEIGHT = Record.current_weight;
        //    //        appAnimal.LOT_NUMBER = Record.LOT_NUMBER;
        //    //        BL.Managers.AnimalManager.Save(appAnimal);
        //    //    }
        //    //}
        //}

        #region Control Assignment Code
        public static void AssignValue(object Control, object Value)
        {
            if ((null != Control) && (null != Value))
            {
                if (typeof(EditText) == Control.GetType())
                {
                    if (IsNumeric(Value.ToString()))
                    {
                        ((EditText)Control).Text = string.Format("{0:#,##0.000}", double.Parse(Value.ToString()));
                    }
                    else
                    {
                        ((EditText)Control).Text = Value.ToString();
                    }
                }
            }
        }
        #endregion Control Assignment Code

        #region Helpful Code
        /// <summary>
        /// Returns true if string is numeric and not empty or null or whitespace.
        /// Determines if string is numeric by parsing as Double
        /// </summary>
        /// <param name="str"></param>
        /// <param name="style">Optional style - defaults to NumberStyles.Number (leading and trailing whitespace, leading and trailing sign, decimal point and thousands separator) </param>
        /// <param name="culture">Optional CultureInfo - defaults to InvariantCulture</param>
        /// <returns></returns>
        private static bool IsNumeric(this string str, NumberStyles style = NumberStyles.Number, CultureInfo culture = null)
        {
            double num;
            if (culture == null) culture = CultureInfo.InvariantCulture;
            return Double.TryParse(str, style, culture, out num) && !String.IsNullOrWhiteSpace(str);
        }
        #endregion Helpful Code

        #region Null Objects
        /// <summary>
        /// Checks for a null and returns a blank string if it finds it
        /// <para>Added 13 April 2015 by David joyce</para>
        /// </summary>
        /// <param name="pvar_Value"></param>
        /// <returns></returns>
        public static string NullString(object pvar_Value)
        {
            if (pvar_Value != null)
            {
                return Convert.ToString(pvar_Value).Trim();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// Checks for a null and returns a 0 if it finds it
        /// </summary>
        /// <param name="pvar_Value"></param>
        /// <returns></returns>
        public static decimal NullDecimal(object pvar_Value)
        {
            decimal outholder = 0;
            if (null == pvar_Value)
            {
                return 0;
            }
            if (!System.Convert.IsDBNull(pvar_Value) & decimal.TryParse(pvar_Value.ToString(), out outholder))
            {
                return Convert.ToDecimal(pvar_Value);
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Checks for a null and returns a 0 if it finds it
        /// </summary>
        /// <param name="pvar_Value"></param>
        /// <returns></returns>
        public static double NullDouble(object pvar_Value)
        {
            double outholder = 0;
            if (null == pvar_Value)
            {
                return 0;
            }
            if (!System.Convert.IsDBNull(pvar_Value) & double.TryParse(pvar_Value.ToString(), out outholder))
            {
                return Convert.ToDouble(pvar_Value);
            }
            else
            {
                return 0;
            }
        }
        #endregion Null Objects

        #region Activity Code
        public static void ShowToast(Activity Form, string message)
        {
            if (null != Form)
            {
                Toast.MakeText(Form, message, ToastLength.Long).Show();
            }
        }

        public static void ShowProgressDialog(Activity Form, string message, string title = "Please Wait...", bool indeterminate = true)
        {
            if (null != Form)
            {
                progressDialog = ProgressDialog.Show(Form, title, message, indeterminate); 
            }
        }
        public static void HideProgressDialog()
        {
            if (null != progressDialog)
            {
                progressDialog.Hide();
            }
        }
        #endregion

        
    }
}