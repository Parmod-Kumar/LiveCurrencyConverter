   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   L HCurrencyConverter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CurrencyConverter.ViewModelsCurrencyConverter.ViewModels 5   	   3   -CurrencyConverter.Views.CurrencyConverterView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   A
viewModels*clr-namespace:CurrencyConverter.ViewModels     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$ ThreeDBorderWindow=�5   	   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 ��d�   ShowMinButton .     ShowMaxRestoreButton .   � Title$ Currency Converter��5   	   $	��150��6$   $	��700��61    � DataContext 5      =  7CurrencyConverter.ViewModels.CurrencyConverterViewModel  5   
    � 	Resources 5       �� 
TargetType	 �� Property
 �� Value��%�   '��       '�� H     �� 5   
   " ��6   .�5      �� 	 � ��$
 20(�6)   5      �� 5   
   " ��6   .�5      �� 	 � ��$
 27(�6)   �� 5      	 � ��$
 Center=�69   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6    � ColumnDefinitions 5!   
   �� 5"      $��* �6   �� 5#      $��* �6   .+�5%   
   ��  �� SelectedIndex$ 0��6   $��0��6�   $��0��6�   ��6%   �� *FromCurrencies+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6r   �� *SelectedFromCurrency+��5&      �� 5'      .R�5(      ��  �� Orientation$ 
Horizontal=�6!   .+�5)      �� ��6$   �� *Description+�� 5*      $��(��6$   �� 5+      ��6$   �� *Code+�� 5,      $��)��6$   5-      5.      51      �� 52   
   $ 0��6   $��0��6�   $��1��6�   ��6%   �� *ToCurrencies+$ PropertyChanged=� 6q   �� *SelectedToCurrency+��53      �� 54      .R�55      �� $ 
Horizontal=�6!   .+�56      �� ��6$   �� *Description+�� 57      $��(��6$   �� 58      ��6$   �� *Code+�� 59      $��)��6$   5:      5;      5=      �� 5>   
   -   5         �� 	MaxLength$ 10��5>   `   $��1��6�    �� MaxLines$ 1��6�   $��0��6�   ��6   �� *FromCurrencyTextBoxValue+$ PropertyChanged=�.��6�   .��5C   )   5D      �� 5E   
   $��1��6^    �� 
IsReadOnly . $��1��6}   ��6   �� *ToCurrencyTextBoxValue+$ PropertyChanged=�6}   5F      5G      