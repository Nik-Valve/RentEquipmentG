   M S B A M L   `   `   `  ����N  JRentEquipmentGupalo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:RentEquipmentGupalo.WindowsRentEquipmentGupalo.Windows  5   	   1    +RentEquipmentGupalo.Windows.EquipListWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:RentEquipmentGupalo.Windows     5   	     � Title$+  %Список оборудования��5   	   $	��600��6%   $
��1000��62   .��5	      � ���#264653 � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $+��%Список оборудования��6   $��Center=�5      $��Center=�5      $��24(�5      
��� ���5      �� 5   
   -   5         ��Name$ lvEquipList��5      $��2��5      $��Disabled=�5      ��5      �� 5      .R�5      � 6"   5       ��5"      �� 5#      .R�5$      �� ���#4E5754$	��400��5&      $	��500��5'      $��2q�5(       �� CornerRadius$ 5��5)      
�������._�5,      �  � ColumnDefinitions 5-      �� 5.   "   $��* �63   �� 5/   "   $��* �63   �� 50   "   $��* �63    53      �� 54   "   $��* �60   �� 55   "   $��* �60   �� 56   "   $��* �60   �� 57   "   $��* �60   �� 58   "   $��* �60   .+�5F      ��  ��Name$ 
PhotoStaff��6$   $��3��5G   $   $��10q�5H   $   ��5I   "   �� 5J   &    �� Path$ Photo�6.    �� TargetNullValue 5K   *   ��5L   .   /RES/idiot.jpeg��6K   5N   '   5P      �� 5S      $��2��5T      $��0��5U      $	��130��5V      $��30��5W      $
��Left=�5X      $��NameProduct:  ��5Y      $��15(�5Z       �� Padding$ 10 5 0 0q�5[      �� 5\      $��3��5]      $��3��5^      $	��130��5_      $��30��5`      $
��Left=�5a      $	��Top=�5b      $��Type: ��5c      $��15(�5d      $ 10 5 0 0q�5e      �� 5f      $��4��5g      $��0��5h      $	��130��5i      $��30��5j      $
��Left=�5k      $��Price: ��5l      $��15(�5m      $ 10 5 0 0q�5n      �� 5s      $��18(�5u      
�������$��Center=�5w      $��Right=�5x      $��5q�5y      $��1��5z      $��2��5{      ��5t      �� *NameProduct+5|      �� 5}      $��18(�5      
�������$��Center=�5�      $��Center=�5�      $��5q�5�      $��3��5�      $��3��5�      ��5~      �� *Type.NameType+5�      �� 5�      $��18(�5�      
�������$��Center=�5�      $��Right=�5�      $��5q�5�      $��1��5�      $��4��5�      $
��Wrap=�5�      ��5�      �� *Price+5�      5�      5�      5�      5�      �� 5�   
   -   5        	 ��Name$	 btnStaffAdd��5�         ButtonStyle1#���   5�      $��1��5�      $��50��5�      $	��150��5�      $%��Добавить продукт��5�      $��Right=�5�      $��0 0 20 0q�5�      $��14(�5�      5�      � 5�   
   $��1��6   $��Center=�6!   .+�5�      �� $��
Поиск��5�      $��24(�5�      $
��10 0q�5�      
��� ���5�      �� 5�      -   5        
 ��Name$
 	txtSearch��5�      $	��300��5�      $��16(�5�      $��10q�5�      5�      �� 5�      -   5         ��Name$ cmbSort��5�      $	��300��5�      $��16(�5�      $��10q�5�      5�      5�      �� 5�   
   -   5        $	 btn_exit��5�      #���   5�      $��3��5�      $	��100��5�      $��
Назад��5�      $��30��5�      $��14(�5�      $��Right=�5�      $��	 0 0 10 0q�5�      5�      5�      5�      