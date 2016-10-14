using System.Windows;
using System.Windows.Input;

namespace MyMoney.ViewModel
{
    /// <summary>
    /// The ClickBehavior class exposes usefull attached properties that can be used to attach a commmand (ICommand)
    /// to a mouse event (such as MouseDoubleClick) to ANY UIElement.
    /// </summary>
    public class ClickCommands
    {
        #region MouseDoubleClickCommand
        /// <summary>
        /// MouseDoubleClickCommand Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty MouseDoubleClickCommandProperty =
            DependencyProperty.RegisterAttached(
                "MouseDoubleClickCommand",
                typeof(ICommand),
                typeof(ClickCommands),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnMouseDoubleClickCommandChanged)));

        /// <summary>
        /// Gets the MouseDoubleClickCommand property.
        /// </summary>
        public static ICommand GetMouseDoubleClickCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(MouseDoubleClickCommandProperty);
        }

        /// <summary>
        /// Sets the MouseDoubleClickCommand property.
        /// </summary>
        public static void SetMouseDoubleClickCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(MouseDoubleClickCommandProperty, value);
        }

        /// <summary>
        /// Handles changes to the MouseDoubleClickCommand property.
        /// </summary>
        private static void OnMouseDoubleClickCommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = target as UIElement;
            if (element != null)
            {
                if ((e.OldValue == null) && (e.NewValue != null))
                {
                    element.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(UIElementMouseLeftButtonDown), true);
                }
                else if ((e.OldValue != null) && (e.NewValue == null))
                {
                    element.RemoveHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(UIElementMouseLeftButtonDown));
                }
            }
        }

        private static void UIElementMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // gets the sender is UIElement and check ClickCount because we want double click only
            UIElement target = sender as UIElement;
            if (target != null && e.ClickCount > 1)
            {
                ICommand iCommand = (ICommand)target.GetValue(MouseDoubleClickCommandProperty);
                if (iCommand != null)
                {
                    RoutedCommand routedCommand = iCommand as RoutedCommand;
                    // check if the command has a parameter using the MouseEventParameterProperty
                    object parameter = target.GetValue(MouseEventParameterProperty);
                    // execute the command
                    if (parameter == null)
                    {
                        parameter = target;
                    }
                    if (routedCommand != null)
                    {
                        routedCommand.Execute(parameter, target);
                    }
                    else
                    {
                        iCommand.Execute(parameter);
                    }
                    e.Handled = true;
                }
            }
        }
        #endregion

        #region MouseEventParameter
        /// <summary>
        /// MouseEventParameter Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty MouseEventParameterProperty =
            DependencyProperty.RegisterAttached(
                "MouseEventParameter",
                typeof(object),
                typeof(ClickCommands),
                new FrameworkPropertyMetadata((object)null, null));

        /// <summary>
        /// Gets the MouseEventParameter property.
        /// </summary>
        public static object GetMouseEventParameter(DependencyObject d)
        {
            return d.GetValue(MouseEventParameterProperty);
        }

        /// <summary>
        /// Sets the MouseEventParameter property.
        /// </summary>
        public static void SetMouseEventParameter(DependencyObject d, object value)
        {
            d.SetValue(MouseEventParameterProperty, value);
        }
        #endregion
    }
}

