   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPF.ComponentsWPF.Components  5      K GHamburgerControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:HamburgerControl;assembly=HamburgerControlHamburgerControl 5          WPF.Components.Layout   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WPF.Components     5      Kcustom8clr-namespace:HamburgerControl;assembly=HamburgerControl     5        � 	Resources  5
         Key �� MergedDictionaries �� Source �� 
TargetType  LayoutButtonStyle �� BasedOn�� 5   
   
Dictionary   5      �� 5      $ ../DefaultDictionary.xaml?�6%   %0   '��       7  �� 5      " ��6   8   6(   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
      WPF.Components.Navbar  $��0��6   $��2��6(   $��0��6<    � DataContext 6I   �� *NavbarViewModel+�� 5   
   $��0��6   $
��1000��6)   $��20q�69   $��1��6j   ��6E   �� *ContentViewModel+6y      HamburgerControl.Hamburger  5    
   $��1��6   $��1��5!      $��0 1 0 0q�5"      ���#f2f2f2���#dbdbdb$��1 0 0 0q�5&         OpenCloseDuration$ 0:0:0.5D�5'      	   IsOpen	 5$      �� *IsOpen+  5(      
 �� Property �� Value$  HamburgerControl.HamburgerItem �� Triggers :� RoutedEvent �� TargetProperty	 �� To g� Duration P� Property P� Value��%�  '��       '  X     �� 5)      " ��6   .�5*      �� 
 �@��Padding$ 
100 7 10 7q�60   5+      �� 5,      "  6   .�5-      �� 
 � ��
 ���� 63   �� 5.      
 � ��$ 17(�61    5/      :� 50      $ 
MouseEnter��6'   .[�51      �� .��52   "   �� .��53   &   �� $* $(Background).(SolidColorBrush.Color)�65    #dbdbdb54   5   $ 0:0:0.15D�55   5   56   #   57      58      :� 59      $ 
MouseLeave��6'   .[�5:      �� .��5;   "   �� .��5<   &   �� $* $(Background).(SolidColorBrush.Color)�65    Transparent5=   5   $ 0:0:0.15D�5>   5   5?   #   5@      5A      P� 5B       �@J�IsMouseOver$
 True��69   . �5C      �� 
 � �� �#1669bb6;   �� 5D      
 �@�Cursor$
 Hand��67   5E      P� 5F       �@d�	IsChecked$
 TrueY�67   . �5G      �� 
 � �� �#1669bb6;   �� 5H      
 �@�Cursor$
 Hand��67   5I      5K      5L         Content 5M      � 5N      $
��0 10q�6    5O      �� 5P      $
��Auto �6(   �� 5Q      $��* �6(   �� 5R      $
��Auto �6(   �� 5S      $
��Auto �6(   .+�5U        $��0��6+   .��5V      �� $��Account��6$    J� InputBindings 5W      d� 5X   "    d� MouseAction$ 	LeftClicke�6Q    �� Command 6/   �� *LogoutCommand+6Q   5Z      5[        5\      $��2��6+   .��5]      �� $��Log Out��6$    5^      d� 5_   "   $ 	LeftClicke�6Q    6/   �� *LogoutCommand+6Q   5a      5b        5c      $��3��6+   .��5d      �� $
��Exit��6$    5e      d� 5f   "   $ 	LeftClicke�6O    6/   �� *ExitCommand+6O   5h      5i      5j      5l      5m      5n      