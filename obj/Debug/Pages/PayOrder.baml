   M S B A M L   `   `   `  ����P  LWPFModernVerticalMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WPFModernVerticalMenu.PagesWPFModernVerticalMenu.Pages  5   	   *    $WPFModernVerticalMenu.Pages.PayOrder   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:WPFModernVerticalMenu.Pages     5   	     � Title$  PayOrder��5   	   $	��450��6   $	��800��6'   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��3.5* �6   �� 5      $
��0.5* �6   .+�5   
   � $��0��6   .+�5      �� $��20,0,0,0q�5      $��/res/test.png��5      $
��Left=�5      $��Center=�5      �� 5      $��25(�5      $-��'Подтверждение заказа��5      $��Center=�5      $��Center=�5      �� 5      -   5        $��0,0,20,0q�5      $	��100��5       $��50��5!      $��Right=�5"      $��Center=�5#      5$      5%      � 5'   
   $��1��6    5(      �� 5)      $��* �6    �� 5*      $��50 �6    .+�5,      &   System.Windows.Controls.DataGrid  -   5          Name$ SecretOrder��5,   R   $��0��6      AutoGenerateColumns .     
IsReadOnly . $y�Visible=�6g      Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� 	 �� Path$
	 Name�  5/      $ Цена��6)   $
 0.5* 67    6D   �� $
	 Cost�  50      $ Кол-во��6)   $
 0.5* 69    6F   �� $	 Count�  51      $ 
Итого��6)   $ * 68    6B   �� $	 Costing�4  .System.Windows.Controls.DataGridTemplateColumn  52      $ * 6-   
   CellTemplate
 53      �� 54      .R�55   "   ��  �� Orientation$ 
Horizontal=�6-   .+�56   &   �� $
��plus��6-   -   5        .��56   O   +6R   �� 57   &   $��minus��6-   -   5        .��57   P   -6S   �� 58   &   $��delete��6-   -   5        .��58   Q   DEL6V   59   #   5:      5<      5>      �� 5?      -   5        $��clickbuy��5?      $��1��6%   $��5q�62   6=   5@      � 5B   
   $��2��6   .+�5D      �� $��20,0,0,0q�5E      $��Копирайт��5F      $��Center=�5G      $��20(�5H      �� 5J      $ 
Horizontal=�5K      $��Right=�5L      $��Center=�5M      $��0,0,20,0q�5N      .+�5O      �� $��30��5P      $��30��5Q      $��10,0,0,0q�5R      �� 5S      $��30��5T      $��30��5U      $��10,0,0,0q�5V      5W      5X      5Y      5Z      