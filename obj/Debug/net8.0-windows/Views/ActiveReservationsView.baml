   M S B A M L   `   `   `  ����  Hospital+    %Hospital.Views.ActiveReservationsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5      � ���#F0F4F8.+�5   
   �� .+�5	      ��   �� Orientation$  
Horizontal=�6   $��Right=�62   $��0,0,0,20q�6N   .+�5
      �� $��Create New Reservation��6   $	��160��6n   $��40��6z   $��5q�6�   ���	#FF1AC815
�������$
��Bold"�5   C   
������  � Cursor$
 Hand��5      ��5
   :   �� *!OpenCreateNewReservationCommand+ J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6+      	Direction$	 320Q�69      ShadowDepth$ 2Q�6I      Opacity$	 0.5Q�6Y      
BlurRadius$ 5Q�6g   5      5      �� 5      $��Active Reservations��6   $��24(�63   $��SemiBold"�6A   ���#333$��Center=�6i   $��0,0,0,20q�6�   �� 5      $��14(�6<   $��Segoe UI)�6J   ���#333��6   �� *Reservations+ � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%"  '��       '�� �     �� 5      "	 ��6   .�5      �� 
 � �� �#3DEB5067   �� 5      
 � ��
 �����67   �� 5      
 � ��$ Center=�6G   �� 5      
 � ��$
 Bold"�67   5      �� 5      "	 ��6   .�5      �� 
 � ��$ Center=�6@   5      5      ��5      �� 5       "	 ��6   .�5!      �� 
 � ��$ 5q�64   �� 5"      
 � ��$ 5q�63   �� 5#      
 � ��$ Center=�6G   5$       �� View 5&      �� 5'      .P�5(      �� $��ID��6)    �� Width$	 100��65    �� CellTemplate 5)      �� 5*   "   .R�5+   &   ��  �� TextAlignment$ Center=�6D   ��60   �� *Id+6D   5,   #   5.      �� 5/      $��
Entry Date��6)   $	 120��6=    50      �� 51   "   .R�52   &   �� $ Center=�6l   ��60   �� *	EntryDate+ �� StringFormat$ {0:dd/MM/yyyy}��6l   53   #   55      �� 56      $��Patient First Name��6)   $	 130��6E    57      �� 58   "   .R�59   &   �� $ Center=�6S   ��60   �� *Patient.FirstName+6S   5:   #   5<      �� 5=      $��Patient Last Name��6)   $	 130��6D    5>      �� 5?   "   .R�5@   &   �� $ Center=�6R   ��60   �� *Patient.LastName+6R   5A   #   5C      �� 5D      $��Doctor Username��6)   $	 120��6B    5E      �� 5F   "   .R�5G   &   �� $ Center=�6V   ��60   �� *Doctor.User.Username+6V   5H   #   5J      �� 5K      $��Doctor Specialization��6)   $	 150��6H    5L      �� 5M   "   .R�5N   &   �� $ Center=�6W   ��60   �� *Doctor.Specialization+6W   5O   #   5Q      �� 5R      $��	Bed Label��6)   $ 80��6<    5S      �� 5T   "   .R�5U   &   �� $ Center=�6K   ��60   �� *	Bed.Label+6K   5V   #   5X      �� 5Y      $��Room Number��6)   $	 100��6>    5Z      �� 5[   "   .R�5\   &   �� $ Center=�6Q   ��60   �� *Bed.Room.Number+6Q   5]   #   5_      �� 5`      $��	Room Type��6)   $ 80��6<    5a      �� 5b   "   .R�5c   &   �� $ Center=�6O   ��60   �� *Bed.Room.Type+6O   5d   #   5f      �� 5g      $��Reserved By Username��6)   $	 160��6G    5h      �� 5i   "   .R�5j   &   �� $ Center=�6Y   ��60   �� *ReservedByUser.Username+6Y   5k   #   5m      �� 5n      $��Actions��6)   $	 150��6:    5o      �� 5p   "   .R�5q   &   �� $  
Horizontal=�61   $��Center=�6J   .+�5s   *   �� $��Close��61   $��80��6�   $��30��6�   $��5q�6�   
���  ��
�������$
��Bold"�6  
������ $
 Hand��6I  ��6A   �� *)'DataContext.OpenCloseReservationCommand+ �� RelativeSource ��  �� AncestorType UserControl��6�   �� *Id+ 5t   .     5u   2   $ Black��6C   $	 320Q�6Q   $ 2Q�6a   $	 0.5Q�6q   $ 5Q�6   5w   +   �� 5x   *   $y�	Collapsed=�6H   ��64   �� *Id+6H   5y   '   5z   #   5|      5}      5      5�      5�      5�      