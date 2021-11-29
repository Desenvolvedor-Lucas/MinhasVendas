using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MinhasVendas.Models
{
    public class CustomStepper : StackLayout
    {
        public Button PlusBtn;
        public Button MinusBtn;
        public Entry Entry;

        public static readonly BindableProperty TextProperty =
          BindableProperty.Create(
             propertyName: "Text",
              returnType: typeof(int),
              declaringType: typeof(CustomStepper),
              defaultValue: 1,
              defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty TextColorProperty =
          BindableProperty.Create(
             propertyName: "TextColor",
              returnType: typeof(Color),
              declaringType: typeof(CustomStepper),
              defaultValue: Color.Red,
              defaultBindingMode: BindingMode.TwoWay); //vai sempre pro padrão tenho que arrumar algo

        public int Text
        {
            get { return (int)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }


        public CustomStepper()
        {
            PlusBtn = new Button { Text = "+", TextColor = this.TextColor,//
                WidthRequest = 40, FontAttributes = FontAttributes.Bold, CornerRadius = 100, FontSize = 15 };
            MinusBtn = new Button { Text = "-", TextColor = this.TextColor,//
                WidthRequest = 40, FontAttributes = FontAttributes.Bold, CornerRadius = 100, FontSize = 15 };
            switch (Device.RuntimePlatform)
            {

                case Device.UWP:
                case Device.Android:
                    {
                        PlusBtn.BackgroundColor = Color.Transparent;
                        MinusBtn.BackgroundColor = Color.Transparent;
                        break;
                    }
                case Device.iOS:
                    {
                        PlusBtn.BackgroundColor = Color.DarkGray;
                        MinusBtn.BackgroundColor = Color.DarkGray;
                        break;
                    }
            }

            Orientation = StackOrientation.Horizontal;
            PlusBtn.Clicked += PlusBtn_Clicked;
            MinusBtn.Clicked += MinusBtn_Clicked;
            Entry = new Entry
            {
                PlaceholderColor = Color.Gray,
                HorizontalTextAlignment = TextAlignment.Center,
                Keyboard = Keyboard.Numeric,
                WidthRequest = 40,
                BackgroundColor = Color.Transparent
            };

            Entry.SetBinding(Entry.TextProperty, new Binding(nameof(Text), BindingMode.TwoWay, source: this));
            Entry.SetBinding(Entry.TextColorProperty, new Binding(nameof(TextColor), BindingMode.TwoWay, source: this));
            Entry.TextChanged += Entry_TextChanged;

            PlusBtn.SetBinding(Entry.TextColorProperty, new Binding(nameof(TextColor), BindingMode.TwoWay, source: this));
            MinusBtn.SetBinding(Entry.TextColorProperty, new Binding(nameof(TextColor), BindingMode.TwoWay, source: this));

            Children.Add(PlusBtn);
            Children.Add(Entry);
            Children.Add(MinusBtn);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
                this.Text = int.Parse(e.NewTextValue);
        }

        private void MinusBtn_Clicked(object sender, EventArgs e)
        {
            if (Text > 1)
                Text--;
        }

        private void PlusBtn_Clicked(object sender, EventArgs e)
        {
            if(Text < 100)
                Text++;
        }

    }
}
