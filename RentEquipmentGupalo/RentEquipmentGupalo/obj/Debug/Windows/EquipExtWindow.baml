   M S B A M L   `   `   `  ����N  JRentEquipmentGupalo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:RentEquipmentGupalo.WindowsRentEquipmentGupalo.Windows  5   	   0    *RentEquipmentGupalo.Windows.EquipExtWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:RentEquipmentGupalo.Windows     5   	     � Title$+  %Выдача оборудования��5   
   $	��600��6&   $
��1000��63    � WindowStartupLocation$ CenterScreen=�6@   .��5	      � ���#264653 � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��Выдача��6   $��Center=�5      $��Center=�5      $��24(�5      
��� ���5      �� 5   
   -   5         ��Name$ 
lvEquipExt��5      $��2��5      
������� �� View 5      �� 5      .P�5      �� $��
Номер��6%    �� Width$ 50��64    �� DisplayMemberBinding 6?   �� *ID+6e   �� 5      $��Клиент��6%   $ 50��65    6@   �� *	Client.ID+6m   �� 5      $#��Фамилия клиента��6%   $	 150��6>    6J   �� *Client.LastName+6}   �� 5       $��Сотрудник��6%   $ 75��68    6C   �� *
Staff.ID+6o   �� 5!      $)��#Фамилия сотрудника��6%   $	 200��6A    6M   �� *Staff.LastName+6   �� 5"      $��Дата выдачи��6%   $	 150��6:    6F   �� *DateOfIssue+6u   �� 5#      $)��#Номер оборудования��6%   $	 150��6A    6M   �� *
Product.ID+6{   �� 5$      $��Выдано��6%   $	 125��65    6A   �� *Product.NameProduct+6x   5%      5'      �� 5(   
   -   5         ��Name$ btnEExtWindow��5)         ButtonStyle1#���   5(      $+��%Выдать оборудование��5*      $��Right=�5+      $��Center=�5,      $��20(�5-      $��1��5.      $��10 10 10 10q�5/      51      �� 52   
   -   5        $ btn_exit��53      #���   52      $��3��54      $	��100��55      $��
Назад��56      $��30��57      $��14(�58      $��Right=�59      $��	 0 0 10 0q�5:      5;      5<      5=      