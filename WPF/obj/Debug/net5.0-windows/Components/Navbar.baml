   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPF.ComponentsWPF.Components  5          WPF.Components.Navbar   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3
componentsclr-namespace:WPF.Components     5        � 	Resources  5	       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value	 �� 
TargetName 	  Title��%.  '��       &	  �    �� 5
   
   " ��6   .�5      ��  � ��$ 0 0 15 0q�6'   �� 5       � ��
 ���� 6+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   ._�5      � .+�5   "   �� $ 
background��6,   #��z��5   ,   �� 5   "   #��z��5   %   #��z��5   %   5      5       5      P� 5       �@J�IsMouseOver$
 True��6=   . �5   "   �� $	 
background��6)    �@J�Opacity$ 0Q�6T   �� 5   "    � �� �#cfcfcf6?   �� 5    "    �@�Cursor$
 Hand��6;   5!      5#      5%      5&      �� 5'   
   " ��6   .�5(      ��  � ��$ 15 0 0 0q�6'   �� 5)       � ��
 ���� 6+   �� 5*       � ��
 �   �6+   �� 5+       � ��$ 0q�60   �� 5,       � �� 5-      �� 5.      " ��6&   .R�5/      �� #��z��6!   #��z��50   !   ._�51      � .+�52   "   �� $ 
background��6,   #��z��53   ,   �� 54   "   #��z��55   %   #��z��56   %   57      58       59      P� 5:       �@J�IsMouseOver$
 True��6=   . �5;   "   �� $	 
background��6)    �@J�Opacity$ 0Q�6T   �� 5<   "    �@�Cursor$
 Hand��6;   5=      5?      5A      5B      5C      .��5D      � 
����d�.+�5E   
   �� 
 �� Padding$
 5q�6   ._�5F      � -   5         � ColumnDefinitions 5G      �� 5H      $
��Auto �6'   �� 5I      $��* �6'   �� 5J      $
��Auto �6'   �� 5K      $
��Auto �6'   �� 5L      $
��Auto �6'   �� 5M      $
��Auto �6'   .+�5P      �� #��[  6   $��Evidence Pracovni Doby��6a   $��Center=�6�   $
��Left=�5Q      $��20(�64   $��0��6B   ��5P   8   �� *NavigateHomeCommand+5Q   B   �� 5S      $��1��6   �� 5U      $��
Activities��6   $��2��6Z   ��6.   �� *NavigateActivityCommand+6Z   �� 5V      $��	Customers��6   $��3��6Y   ��6-   �� *NavigateCustomerCommand+6Y   �� 5W      $��Projects��6   $��4��6W   ��6,   �� *NavigateProjectCommand+6W   �� 5X      $��5��6    d� 	IsChecked 6+   �� *	IsChecked+��5Y      �� 5Z      " ��6*   .R�5[      � 
������ .+�5\   "   �� $��/Images/Account.png��6(   $��20��6E   $��20��6P   5]      5^      5`      5a      5b      5c      5d      