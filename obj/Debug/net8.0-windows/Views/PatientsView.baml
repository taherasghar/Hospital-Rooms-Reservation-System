   M S B A M L   `   `   `  ����  Hospital!    Hospital.Views.PatientsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5      � ���#F0F4F8.+�5   
   �� .+�5	      ��   �� Orientation$  
Horizontal=�6   $��Right=�62   $��0,0,0,20q�6N   .+�5
      �� $��Register New Patient��6   $	��150��6b   $��40��6n   $��5q�6z   ���#F8691D
�������$
��Bold"�5   A   
������  � Cursor$
 Hand��5      ��5
   8   �� *OpenAddPatientCommand+ J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6+      	Direction$	 320Q�69      ShadowDepth$ 2Q�6I      Opacity$	 0.5Q�6Y      
BlurRadius$ 5Q�6g   5      5      �� 5      $��Patients Manager��6   $��24(�60   $��SemiBold"�6>   ���#333$��Center=�6f   $��0,0,0,20q�6�   �� 5      $��14(�68   $��Segoe UI)�6F   ���#333��6   �� *
Patients+ � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%"  '��       '�� �     �� 5      "	 ��6   .�5      �� 
 � �� �#F8691D67   �� 5      
 � ��
 �����67   �� 5      
 � ��$ Center=�6G   �� 5      
 � ��$
 Bold"�67   5      �� 5      "	 ��6   .�5      �� 
 � ��$ Center=�6@   5      5      ��5      �� 5       "	 ��6   .�5!      �� 
 � ��$ 5q�64   �� 5"      
 � ��$ 5q�63   �� 5#      
 � ��$ Center=�6G   5$       �� View 5&      �� 5'      .P�5(      �� $��ID��6)    �� Width$	 350��65    �� CellTemplate 5)      �� 5*   "   .R�5+   &   ��  �� TextAlignment$ Center=�6D   ��60   �� *Id+6D   5,   #   5.      �� 5/      $��
First Name��6)   $	 200��6=    50      �� 51   "   .R�52   &   �� $ Center=�6K   ��60   �� *	FirstName+6K   53   #   55      �� 56      $��	Last Name��6)   $	 200��6<    57      �� 58   "   .R�59   &   �� $ Center=�6J   ��60   �� *
LastName+6J   5:   #   5<      �� 5=      $��Date of Birth��6)   $	 150��6@    5>      �� 5?   "   .R�5@   &   �� $ Center=�6n   ��60   �� *DateOfBirth+ �� StringFormat$ {0:dd/MM/yyyy}��6n   5A   #   5C      �� 5D      $��Gender��6)   $	 150��69    5E      �� 5F   "   .R�5G   &   �� $ Center=�6H   ��60   �� *Gender+6H   5H   #   5J      5K      5M      5N      5O      5P      