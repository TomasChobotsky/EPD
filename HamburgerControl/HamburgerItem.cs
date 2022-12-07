using System.Windows;
using System.Windows.Controls;

namespace HamburgerControl
{
    public class HamburgerItem : RadioButton
    {
        static HamburgerItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HamburgerItem),
                new FrameworkPropertyMetadata(typeof(HamburgerItem)));
        }
    }
}