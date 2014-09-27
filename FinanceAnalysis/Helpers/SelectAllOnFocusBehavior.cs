using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;

namespace FinanceAnalysis.Helpers
{
    public static class SelectAllOnFocusBehaviour
    {
        /// 1. This is the boolean attached property with its getter and setter:
        public static readonly DependencyProperty SelectAllOnFocusProperty =
            DependencyProperty.RegisterAttached
            (
                "SelectAllOnFocus",
                typeof(bool),
                typeof(SelectAllOnFocusBehaviour),
                new UIPropertyMetadata(false, OnSelectAllOnFocusPropertyChanged)
            );

        public static bool GetSelectAllOnFocus(DependencyObject obj)
        {
            return (bool)obj.GetValue(SelectAllOnFocusProperty);
        }

        public static void SetSelectAllOnFocus(DependencyObject obj, bool value)
        {
            obj.SetValue(SelectAllOnFocusProperty, value);
        }

        /// 2. This is the change event of our attached property value:
        ///     * We get in the first parameter the dependency object to which the attached behavior was attached
        ///     * We get in the second parameter the value of the attached behavior.
        ///     * The implementation of the behavior is to check if we are attached to a textBox, and if so and the value of the behavior
        ///       is true, hook to the PreviewGotKeyboardFocus of the textbox.
        private static void OnSelectAllOnFocusPropertyChanged(DependencyObject dpo, DependencyPropertyChangedEventArgs args)
        {
            TextBoxBase textBox = dpo as TextBoxBase;
            if (textBox != null)
            {
                TextBoxBase tbb = dpo as TextBoxBase;
                if ((bool)args.NewValue)
                {
                    textBox.PreviewGotKeyboardFocus += OnTextBoxPreviewGotKeyboardFocus;
                }
                else
                {
                    textBox.PreviewGotKeyboardFocus -= OnTextBoxPreviewGotKeyboardFocus;
                }
            }
        }

        /// 3. The actual implementation: Whenever the textbox gets the keyboard focus, we select its text
        private static void OnTextBoxPreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBoxBase txtBox = (TextBoxBase)sender;
            Action action = () => { txtBox.SelectAll(); };
            txtBox.Dispatcher.BeginInvoke(action, DispatcherPriority.ContextIdle);
        }
    }
}
