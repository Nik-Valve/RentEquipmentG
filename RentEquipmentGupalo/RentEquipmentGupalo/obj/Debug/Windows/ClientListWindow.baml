   M S B A M L   `   `   `  ����N  JRentEquipmentGupalo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:RentEquipmentGupalo.WindowsRentEquipmentGupalo.Windows  5   	   2    ,RentEquipmentGupalo.Windows.ClientListWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:RentEquipmentGupalo.Windows     5   	     � Title$  StaffWindow��5   	   $	��600��6   $
��1000��6*    � WindowStartupLocation$ CenterScreen=�5	   	   ���	#FF7C7C7C � 	Resources 5
         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 �� 
TargetType	 �� 
TargetType
 ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%U  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E    . $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5        � ��8  6,   �� 5!       � ��
 � ���6+   �� 5"       � ��$ 1q�60   �� 5#       � ��$ Center=�6;   �� 5$       � ��$ Center=�69   �� 5%       � ��$ 1q�6(   �� 5&       � �� 5'      �� 5(      "	 ��6&   .R�5)      �� $
 border��6!   ���#161a1e$ 10��6F   ���#1e1112$��5q�6n    . ._�5*      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5+       5,      P� 5-       �@��IsDefaulted . . �5.   "   �� $ border��6@   # � ��6T    � ��5/      P� 50       �@J�IsMouseOver . . �51   "   �� $ border��6?   8   � ��6S   �� 52   "   $ border��6@   8   � ��6T   53      P� 54       � �� . . �55   "   �� $ border��6?   8   � ��6S   �� 56   "   $ border��6@   8   � ��6T   57      P� 58       � {� .  . �59   "   �� $ border��6?   8   � ��6S   �� 5:   "   $ border��6@   8   � ��6T   �� 5;   "   $ contentPresenter��6K   8 	  � ��6i   5<      5>      5@      5A      5B      .��5C      � ���#264653 � RowDefinitions 5E   
   �� 5F      $��50 �6   �� 5G      $��50 �6   �� 5H      $��* �6   �� 5I      $��50 �6   .+�5K   
   �� $#��Список клиентов��6   $��Center=�5L      $��Center=�5M      
��� ���$��24(�5O      5P      �� 5Q   
   -   5         ��Name$ lvStaff��5Q      $��2��5R      $��Disabled=�5U      ��5W      �� 5X      .R�5Y      � 6"   5Z      ��5\      �� 5]      .R�5^      �� ���#4E5754$	��900��5`      $	��100��5a      $��2q�5b      $ 5��5c      
�������._�5f      �  � ColumnDefinitions 5g      �� 5h   "   $��* �63   6?   �� 5i   "   $��* �63   6?   �� 5j   "   $��* �63   6?    5l      �� 5m   "   $��* �60   6=   �� 5n   "   $��* �60   6=   �� 5o   "   $��* �60   6=   .+�5      ��  ��Name$ 
PhotoStaff��6$   $��3��5�   $   $��10q�5�   $   ��5�   "   �� 5�   &    �� Path$ Photo�6.    �� TargetNullValue 5�   *   ��5�   .   /RES/idiot.jpeg��6K   5�   '   5�      �� 5�      $��18(�5�      
�������$��Center=�5�      $��Right=�5�      $��5q�5�      $��1��5�      $��0��5�      ��5�      �� *
LastName+5�      �� 5�      $��18(�5�      
�������$��Center=�5�      $��Right=�5�      $��5q�5�      $��1��5�      $��1��5�      ��5�      �� *	FirstName+5�      �� 5�      $��18(�5�      
�������$��Center=�5�      $��Right=�5�      $��5q�5�      $��1��5�      $��2��5�      ��5�      �� *
MiddleName+5�      �� 5�      $�� ��5�      $��18(�5�      $��Center=�5�      $��Right=�5�      $��10q�5�      $��1��5�      $��0��5�      5�      5�      5�      5�      5�      �� 5�   
   -   5         ��Name$ btnStaffAdd��5�      #��� 
 5�      $��1��5�      $��50��5�      $	��150��5�      $%��Добавить клиента��5�      $��Right=�5�      $��0 0 20 0q�5�      $��14(�5�      5�      � 5�   
   $��1��6   $��Center=�6!   .+�5�      �� $��
Поиск��5�      $��24(�5�      $
��10 0q�5�      
��� ���5�      �� 5�      -   5         ��Name$ 	txtSearch��5�      $	��300��5�      $��16(�5�      $��10q�5�      5�      �� 5�      -   5         ��Name$ cmbSort��5�      $	��300��5�      $��16(�5�      $��10q�5�      5�      5�      �� 5�   
   -   5        $ btn_exit��5�      #��� 
 5�      $��3��5�      $	��100��5�      $��
Назад��5�      $��30��5�      $��14(�5�      $��Right=�5�      $��	 0 0 10 0q�5�      5�      5�      5�      