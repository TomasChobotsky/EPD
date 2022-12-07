using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HamburgerControl
{
    public class Hamburger : Control
    {
        public static readonly DependencyProperty IsOpenProperty = 
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(Hamburger), new PropertyMetadata(false, OnIsOpenPropertyChanged));

        public bool IsOpen
        {
            get {return (bool)GetValue(IsOpenProperty);}
            set {SetValue(IsOpenProperty, value);}
        }
        
        public static readonly DependencyProperty OpenCloseDurationProperty = 
            DependencyProperty.Register("OpenCloseDuration", typeof(Duration), typeof(Hamburger), new PropertyMetadata(Duration.Automatic));
        
        public Duration OpenCloseDuration 
        {
            get {return (Duration)GetValue(OpenCloseDurationProperty);}
            set {SetValue(OpenCloseDurationProperty, value);}
        }
        
        public static readonly DependencyProperty ContentProperty = 
            DependencyProperty.Register("Content", typeof(FrameworkElement), typeof(Hamburger), new PropertyMetadata(null));
        
        public FrameworkElement Content 
        {
            get {return (FrameworkElement)GetValue(ContentProperty);}
            set {SetValue(ContentProperty, value);}
        }
        
        static Hamburger()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Hamburger),
                new FrameworkPropertyMetadata(typeof(Hamburger)));
        }

        public Hamburger()
        {
            Width = 0;
        }
        
        private static void OnIsOpenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Hamburger hamburger)
            {
                hamburger.OnIsOpenPropertyChanged();
            }
        }
        private void OnIsOpenPropertyChanged()
        {
            if (IsOpen)
            {
                OpenMenuAnimated();
            }
            else
            {
                CloseMenuAnimated();
            }
        }

        private void OpenMenuAnimated()
        {
            Content.Measure(new Size(MaxWidth, MaxHeight));
            Double contentWidth = Content.DesiredSize.Width;
            
            DoubleAnimation openingAnimation = new DoubleAnimation(contentWidth, OpenCloseDuration);
            BeginAnimation(WidthProperty, openingAnimation);
        }
        
        private void CloseMenuAnimated()
        {
            DoubleAnimation closingAnimation = new DoubleAnimation(0, OpenCloseDuration);
            BeginAnimation(WidthProperty, closingAnimation);
        }
    }
}