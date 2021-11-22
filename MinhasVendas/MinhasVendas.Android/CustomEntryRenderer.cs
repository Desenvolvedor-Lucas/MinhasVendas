using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text.Method;
using Android.Views;
using Android.Widget;
using MinhasVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(MinhasVendas.Droid.CustomEntryRenderer))]
namespace MinhasVendas.Droid
{

    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control == null || Element == null) return;

            var element = (CustomEntry)Element;

            var isNumeric = element.IsNumeric;

            if(element.Text != null)
            {
                for (int i = 0; i < element.Text.Length; i++)
                {
                    if (element.Text[i] == ',')
                    {
                        var newText = element.Text.Replace(',', '.');
                        element.Text = newText;
                    }
                }
            }

            if (isNumeric)
            {
                // Force the keyboard to be numeric without sign
                Control.KeyListener = new DigitsKeyListener(false, true);

            }
        }
    }
}