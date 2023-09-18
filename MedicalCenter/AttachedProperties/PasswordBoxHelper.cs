using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MedicalCenter.AttachedProperties
{
    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty BoundPasswordProperty =
            DependencyProperty.RegisterAttached("BoundPassword",
                typeof(string),
                typeof(PasswordBoxHelper),
                new PropertyMetadata(string.Empty, OnBoundPasswordChanged));

        public static string GetBoundPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(BoundPasswordProperty);
        }

        public static void SetBoundPassword(DependencyObject obj, string value)
        {
            obj.SetValue(BoundPasswordProperty, value);
        }

        private static void OnBoundPasswordChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (!(d is PasswordBox passwordBox))
                return;

            // Remove the handler to prevent memory leaks
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if (e.NewValue != null)
            {
                passwordBox.Password = e.NewValue.ToString();
            }
            else
            {
                passwordBox.Password = string.Empty;
            }

            // Attach the handler to keep the view model property in sync
            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!(sender is PasswordBox passwordBox))
                return;

            SetBoundPassword(passwordBox, passwordBox.Password);
        }
    }
}
