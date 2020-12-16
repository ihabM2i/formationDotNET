using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CoursEntityFrameWorkCore.SpecialControl
{
    public class SpecialListBox : ListBox
    {

        public SpecialListBox()
        {
            SelectionChanged += ActionSelectedChanged;
        }
        private void ActionSelectedChanged(object sender, RoutedEventArgs e)
        {
            SpecialSelectedItems = SelectedItems;
        }
        public IList SpecialSelectedItems
        {
            get
            {
                return (IList)GetValue(SpecialSelectedItemsProperty);
            }
            set 
            {
                SetValue(SpecialSelectedItemsProperty, value);
            }
        }

        public static readonly DependencyProperty SpecialSelectedItemsProperty =
            DependencyProperty.Register(nameof(SpecialSelectedItems), typeof(IList), typeof(SpecialListBox));
    }
}
