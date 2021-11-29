using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MinhasVendas.Models
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty IsNumericProperty = 
            BindableProperty.Create("IsNumeric", typeof(Boolean), typeof(Entry), false);

        public Boolean IsNumeric
        {
            get { return (Boolean)GetValue(IsNumericProperty); }
            set { SetValue(IsNumericProperty, value); }

        }
        
    }
}
