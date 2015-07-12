using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;

namespace agkik.desktopclient.Utils
{
    internal static class BasicUtils
    {
        #region Internal Methods
        internal static void DisableNonNumericValue(System.Windows.Input.TextCompositionEventArgs e)
        {
            int temp;
            e.Handled = !int.TryParse(e.Text, out temp);
        }

        internal static bool IsParentComboBox(IInputElement iInputElement)
        {
            if (iInputElement.GetType() == typeof(TextBox) &&
                ((TextBox)Keyboard.FocusedElement).FindAncestor<ComboBox>() != null)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Private Methods
        private static T FindAncestor<T>(this DependencyObject obj) where T : DependencyObject
        {
            return obj.FindAncestor(typeof(T)) as T;
        }

        private static DependencyObject FindAncestor(this DependencyObject obj, Type ancestorType)
        {
            var tmp = VisualTreeHelper.GetParent(obj);
            while (tmp != null && !ancestorType.IsAssignableFrom(tmp.GetType()))
            {
                tmp = VisualTreeHelper.GetParent(tmp);
            }
            return tmp;
        }
        #endregion
    }
}
