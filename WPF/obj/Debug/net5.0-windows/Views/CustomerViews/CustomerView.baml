   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WPF.Views	WPF.Views  5      /clr-namespace:WPF.ComponentsWPF.Components  5      *    $WPF.Views.CustomerViews.CustomerView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:WPF.Views     5      3
componentsclr-namespace:WPF.Components     5        � 	Resources  5
         Key �� MergedDictionaries �� Source �� 
TargetType  InformationButtonStyle �� BasedOn�� 5   
   
Dictionary   5      �� 5      $" ../../DefaultDictionary.xaml?�6%   %0   '��       7  �� 5      " ��6   8   6(   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   ��6    �� *	Customers+ �� SelectedItem 6B   �� *SelectedCustomer+ �� View 5      �� 5      .P�5      �� $��Id��6I    �� DisplayMemberBinding 6%   �� *Id+6I   �� 5      $
��Name��6K    6%   �� *Name+6K   �� 5      $��Address��6N    6%   �� *	Address+6N   �� 5      $
��City��6K    6%   �� *City+6K   �� 5      $��ZipCode��6N    6%   �� *	ZipCode+6N   �� 5       $��IC��6I    6%   �� *IC+6I   �� 5!      $	��DIC��6J    6%   �� *DIC+6J   5"      5$      �� 5&   
   $��1��6   $	��Add��6   $
��left=�6,   ��6G   �� *
AddCommand+�� 5'   
   $��1��6   $
��Edit��6   $��center=�6-   ��6J   �� *EditCommand+�� 5(   
   $��1��6   $��Delete��6   $��right=�6/   ��6K   �� *DeleteCommand+5)      5*      