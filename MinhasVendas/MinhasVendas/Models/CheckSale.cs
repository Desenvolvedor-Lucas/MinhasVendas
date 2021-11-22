using MinhasVendas.ABC_Translate;
using MinhasVendas.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasVendas.Models
{
    public class CheckSale
    {
        public static bool Check = false;
        int NumberCheck;

        string Name_Check;
        string Product_Check;
        int Unit_Check;
        decimal Value_Check;

        public CheckSale(string name, string product, int unit, decimal value)
        {
            Name_Check = name;
            Product_Check = product;
            Unit_Check = unit;
            Value_Check = value;
        }

        public int Verification()
        {
            NumberCheck = 0;

            if (Name_Check == "" || Name_Check == null)
                NumberCheck += 1;

            if (Product_Check == "" || Product_Check == null)
                NumberCheck += 10;

            if ((Unit_Check == 0) || (Unit_Check.ToString() == ""))
                NumberCheck += 50;

            if ((Value_Check == 0) || (Value_Check.ToString() == ""))
                NumberCheck += 100;

            return NumberCheck;
        }

        public bool AlertsVerification(int check)
        {
            switch (check)
            {
                //1 Name
                case 1:
                    Alert($"{AppResources.Name_empty}",
                          $"{AppResources.Please_make_sure_you_have_added_something_in_the_Name_entry}",
                          $"{AppResources.Ok}");
                    Check = false;
                    break;

                //10 Product
                case 10:
                    Alert($"{AppResources.Product_empty}",
                          $"{AppResources.Please_make_sure_you_have_added_something_in_the_Product_entry}",
                          $"{AppResources.Ok}");
                    Check = false;
                    break;

                //50 Unit
                case 50:
                    Alert($"{AppResources.Unit_empty}",
                          $"{AppResources.Please_check_if_you_have_added_something_at_the_entrance_of_the_units}",
                          $"{AppResources.Ok}");
                    Check = false;
                    break;

                //100 Value
                case 100:
                    Alert($"{AppResources.Value_empty}",
                          $"{AppResources.Please_check_if_you_have_added_something_in_the_value_entry}",
                          $"{AppResources.Ok}");
                    Check = false;
                    break;

                //

                // 1 + 10 = 11 Name/Product
                case 11:
                    Alert($"{AppResources.Name_and_Product_empty}",
                          $"{AppResources.Please_make_sure_you_have_added_something_in_the_Name_and_Product_entry}",
                          $"{AppResources.Ok}");
                    Check = false;
                    break;

                //1 + 50 = 51 Name/Unit
                case 51:
                    Alert($"{AppResources.Name_and_Unit_empty}",
                          $"{AppResources.Please_make_sure_that_you_have_added_something_in_the_Name_and_Units}",
                          $"{AppResources.Ok}");
                    Check = false;
                    break;

                //1 + 100 = 101 Name/Value
                case 101:
                    Alert($"{AppResources.Name_and_Value_empty}",
                          $"{AppResources.Please_make_sure_you_have_added_something_in_the_Name_and_Value_entry}",
                          $"{AppResources.Ok}");
                    Check = false;
                    break;

                //10 + 50 = 60 Product/Unit
                case 60:
                    Alert($"{AppResources.Product_and_Unit_empty}",
                          $"{AppResources.Please_check_if_you_have_added_something_at_the_entry_of_the_name_or_product__and_the_units}",
                          $"{AppResources.Ok}");
                    Check = false;
                    break;

                //10 + 100 = 110 Product/Value
                case 110:
                    Alert($"{AppResources.Product_and_Value_empty}",
                          $"{AppResources.Please_check_if_you_have_added_something_in_the_name_or_product_entry__and_the_value}",
                          $"{AppResources.Ok}");
                    Check = false;
                    break;

                //50 + 100 = 150 Unit/Value
                case 150:
                    Alert($"{AppResources.Unit_and_Value_empty}",
                          $"{AppResources.Please_check_if_you_have_added_something_at_the_entrance_of_the_units__and_the_value}",
                          $"{AppResources.Ok}");
                    Check = false;
                    break;

                //

                //1 + 10 + 50 = 61 Name/Product/Unit
                case 61:
                    Alert($"{AppResources.Name__Product_and_Unit_empty}",
                          $"{AppResources.Please_make_sure_you_have_added_something_in_the_Name__Product_and_Units_entry}",
                          $"{AppResources.Ok}");
                    Check = false;
                    break;

                //1 + 10 + 100 = 111 Name/Product/Value
                case 111:
                    Alert($"{AppResources.Name__Products_and_Value_empty}",
                          $"{AppResources.Please_make_sure_you_have_added_something_in_the_Name__Product_and_Value_entry}",
                          $"{AppResources.Ok}");
                    Check = false;
                    break;

                //1 + 50 + 100 = 151 Name/Unit/Value
                case 151:
                    Alert($"{AppResources.Name__Unit_and_Value_empty}",
                          $"{AppResources.Please_make_sure_you_ve_added_something_in_the_Name__Units__and_Value_entry}",
                          $"{AppResources.Ok}");
                    Check = false;
                    break;

                //10 + 50 + 100 = 160 Product/Unit/Value
                case 160:
                    Alert($"{AppResources.Product__Unit_and_Value_empty}",
                          $"{AppResources.Please_make_sure_you_have_added_something_at_the_product_entry__Units_and_Value}",
                          $"{AppResources.Ok}");
                    Check = false;
                    break;

                //

                //1 + 10 + 50 + 100 = 161 Name/Product/Unit/Value (All)
                case 161:
                    Alert($"{AppResources.All_empty}",
                          $"{AppResources.Please_make_sure_you_have_added_something_in_all_entries}",
                          $"{AppResources.Ok}");
                    Check = false;
                    break;

                //

                //default
                default:
                    Alert($"{AppResources.Sale_completed}",
                          $"{AppResources.Sale_added_Successfully}",
                          $"{AppResources.Ok}"); 
                    Check = true;
                    break;
            }
            return Check;
        }

        public static async void Alert(string Title, string Message, string Cancel)
        {
            await App.Current.MainPage.DisplayAlert(title: Title, message: Message, cancel: Cancel);
        }
    }
}
