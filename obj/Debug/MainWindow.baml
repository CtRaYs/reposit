   M S B A M L   `   `   `  ����P  LWPFModernVerticalMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:WPFModernVerticalMenu.ControlsWPFModernVerticalMenu.Controls  5   	   =#clr-namespace:WPFModernVerticalMenuWPFModernVerticalMenu  5   	   &     WPFModernVerticalMenu.MainWindow   5   	   5ctls,clr-namespace:WPFModernVerticalMenu.Controls  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:WPFModernVerticalMenu     5   	   -   5        $
��home��5        � Title$  
MainWindow��5	   	   $	��650��6   $
��1000��6)    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�6.   
������  � AllowsTransparency .  � 
ResizeMode$ NoResize=�5   	   $��Poppins)�6   .��5      ��  �� CornerRadius$ 8��5      ���	#FF6365FF._�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� $��0��6   ���	#FF424D8A$ 8 0 0 8��5      ._�5      � -   5         �Name$ GridNav��5      $��60��6(    � RowDefinitions 5      �� 5      $��60 �6(   �� 5      $��* �6(   .+�5      � $��0��6   .+�5       �� $��7 0 0 0q�5!      $��50��5"      $��50��6*   $
��Left=�5#      ��5$      �� 5%   "   	 �� ImageSource$	 Resources/logoWpf.tif��6-   
 j� Stretch$
 Uniform=�6Q   5'      �� 5)      $/��)Магазин автозапчастей��6    
�������$
��Bold"�5+       $��12(�5,       $��Center=�5-       $
��Left=�5.       $��60 0 0 0q�5/       ��50       Z� 51      �� 54      $��1��6!   $��
-1 40 0 20q�6.   .+�55      �� -   5         ��Name$ btnHome��55   !   ��6�   Z� ��6�   Z� .��56      -   'WPFModernVerticalMenu.Controls.MenuItem     	GroupName$ MenuItem��6,      IndicatorBrush$ 	#FF4EF3FF��6A      home   Icon# �   6\      	IconWidth$ 16��6z      Text$ Главная��6�   $��Center=�6�   57      �� 58      -   5        $ btnProducts��58   !     PopupButtonStyle#���  66   .��59        $ MenuItem��6,   $ 	#FF4EF3FF��6A     products# �  6\   $ 16��6~   $ Каталог��6�   $��Center=�6�   5:      �� 5;      -   5        $ btnPointOfSale��5;   !   #���  69   .��5<        $ MenuItem��6,   $ 	#FF4EF3FF��6A     car# �  6\   $ 16��6y   $ Корзина��6�   $��Center=�6�   5=      �� 5>      -   5        $ 
btnSetting��5>   !   #���  65   .��5?        $ MenuItem��6,   $ 	#FF4EF3FF��6A     settings# �  6\   $ 16��6~   $' !Настройки профиля��6�   $��Center=�6�   5@      5A      � 5E      -   5         �Name$ Popup��5E       � AllowsTransparency .  � HorizontalOffset$ 0��6G    � VerticalOffset$ 10��6\   .��5F      .   (WPFModernVerticalMenu.Controls.UserPopup  -   5          Name$ Header��5F   )   
���   �69   5G      5J      5K      � 5M      $��1��6    5N      �� 5O      $��60 �6$   �� 5P      $��* �6$   .+�5S      d� -	   5         d�Name$ Tg_Btn��5S      $��1��6/   $��Center=�6?   $
��Left=�6Z   $��0q�6u   $��
10,15,0,15q�6�   $��30��6�   $��30��6�   
���   �$y�Visible=�6�   ��6�   Z� ��5T      �� 5U      $	 /Resources/menu.png��6%   $
 Uniform=�6G    � Triggers 5X      :� 5Y       :� RoutedEvent$ ToggleButton.Unchecked��6'   .[�5Z      �� .��5[   "   �� -
   5         ��Name$ HideStackPanel��5[   -   .��5\   &   W�  �� 
TargetName$ GridNav��66    �� TargetProperty$ Width�6V    g� 	BeginTime$ 0:0:0X�6x    W� From$	 210X�6�   	 W� To$ 60X�6�    g� Duration$ 0:0:0.5D�6�   5]   '   5^   #   5_      5`      :� 5a      $ ToggleButton.Checked��6'   .[�5b      �� .��5c   "   �� -   5        $ ShowStackPanel��5c   -   .��5d   &   W� $ GridNav��66   $ Width�6V   $ 0:0:0X�6x   $ 60X�6�   $	 210X�6�   $ 0:0:0.5D�6�   5e   '   5f   #   5g      5h      5j      �� 5m      $��0��6   $��Right=�6*   $	��Top=�6F   $��0,5,10,0q�6^   $��30��6p     �� Orientation$  
Horizontal=�6|   $��2��6�   .+�5n      �� -   5        $ btnClose��5n        IconButtonsStyle#��[ 6/   
! � Tag$! IsCloseButton��6q   " � Cursor$
" Hand��6�   ��5o      �� 5p      $	 /Resources/exit.png��6)   # j� TileMode$
# None=�6K   $

 Fill=�6[   5r      5s       � 5v      -   5        $��
fContainer��5w      $��1��5v      $��20q�5x      $  � NavigationUIVisibility$$ Hidden=�5y      5{      5}      5�      5�      5�      