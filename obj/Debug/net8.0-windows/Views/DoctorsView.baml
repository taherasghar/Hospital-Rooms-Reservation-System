   M S B A M L   `   `   `  ����  Hospital     Hospital.Views.DoctorsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Ed7http://schemas.microsoft.com/expression/blend/2008/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5      � ���#F0F4F8.+�5   
   �� .+�5	      ��   �� Orientation$  
Horizontal=�6   $��Right=�62   $��0,0,0,20q�6N   .+�5
      �� $��
Add Doctor��6   $	��120��6W   $��40��6c   $��5q�6o   ���	#FF1AC815
�������$
��Bold"�5   C   
������  � Cursor$
 Hand��5      ��5
   .   �� *OpenAddDoctorCommand+ J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6+      	Direction$	 320Q�69      ShadowDepth$ 2Q�6I      Opacity$	 0.5Q�6Y      
BlurRadius$ 5Q�6g   5      5      �� 5      $��Doctors Manager��6   $��24(�6/   $��SemiBold"�6=   ���#333$��Center=�6e   $��0,0,0,20q�6�   �� 5      $��14(�67   $��Segoe UI)�6E   ���#333��6   �� *	Doctors+ � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%$  '��       '�� �     �� 5      "	 ��6   .�5      �� 
 � �� �	#FF1AC81567   �� 5      
 � ��
 �����67   �� 5      
 � ��$ Center=�6G   �� 5      
 � ��$
 Bold"�67   5      �� 5      "	 ��6   .�5      �� 
 � ��$ Center=�6@   5      5      ��5      �� 5       "	 ��6   .�5!      �� 
 � ��$ 5q�64   �� 5"      
 � ��$ 5q�63   �� 5#      
 � ��$ Center=�6G   5$       �� View 5&      �� 5'      .P�5(      �� $��ID��6)    �� Width$	 350��65    �� DisplayMemberBinding 6A   �� *Id+ �� CellTemplate 5)      �� 5*   "   .R�5+   &   ��  �� TextAlignment$ Center=�6D   ��60   �� *Id+6D   5,   #   5.      �� 5/      $��Username��6)   $	 200��6;    6G   �� *User.Username+ 50      �� 51   "   .R�52   &   �� $ Center=�6O   ��60   �� *User.Username+6O   53   #   55      �� 56      $��
First Name��6)   $	 200��6=    6I   �� *User.FirstName+ 57      �� 58   "   .R�59   &   �� $ Center=�6P   ��60   �� *User.FirstName+6P   5:   #   5<      �� 5=      $��	Last Name��6)   $	 200��6<    6H   �� *User.LastName+ 5>      �� 5?   "   .R�5@   &   �� $ Center=�6O   ��60   �� *User.LastName+6O   5A   #   5C      �� 5D      $��Specialization��6)   $	 250��6A    6M   �� *Specialization+ 5E      �� 5F   "   .R�5G   &   �� $ Center=�6P   ��60   �� *Specialization+6P   5H   #   5J      5K      5M      5N      5O      5P      