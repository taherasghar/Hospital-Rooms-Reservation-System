   M S B A M L   `   `   `  ����  Hospital     Hospital.Views.AddUserView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Add User��5   	   $	��405��6   $	��415��6'    � WindowStartupLocation$ CenterScreen=�63   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��259* �6   �� 5      $	��90* �6   .+�5
   
   �� $	��Top=�6   $	��314��6-   $��2��6:   .+�5      �� $��Add New User��6   $��20(�6,   $
��Bold"�6:   $��0,0,0,20q�6L   $��Center=�6^   �� 5       �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�62   .+�5      �� $��	Username:��6   $	��100��6,   $��Center=�68   $��14(�6S   �� 5      $	��250��6\   $��14(�6h   ��6   �� *newUsername+ �� UpdateSourceTrigger$ PropertyChanged=�6h   5      �� 5      $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5      �� $��	Password:��6   $	��100��6,   $��Center=�68   $��14(�6S   �� 5      $	��250��6Y   $��14(�6e   ��6   �� *
Password+$ PropertyChanged=�6e   5      �� 5      $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5      �� $��First Name:��6   $	��100��6.   $��Center=�6:   $��14(�6U   �� 5      $	��250��6Z   $��14(�6f   ��6   �� *	FirstName+$ PropertyChanged=�6f   5      �� 5      $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5      �� $��
Last Name:��6   $	��100��6-   $��Center=�69   $��14(�6T   �� 5      $	��250��6Y   $��14(�6e   ��6   �� *
LastName+$ PropertyChanged=�6e   5      �� 5!      $ 
Horizontal=�6   $��0,0,0,20q�62   .+�5"      �� $��Role:��6   $	��100��6(   $��Center=�64   $��14(�6O   �� 5#      $ 
Horizontal=�6   .+�5$      	� $��Center=�6"   $��Admin��6=    	� 	GroupName$
 Role��6M   $��0,0,10,0q�6�    d� 	IsChecked 6^   �� *IsAdminChecked+6�   	� 5%      $��Center=�6"   $��	Registrar��6=   $
 Role��6Q    6b   �� *IsRegistrarChecked+5&      5'      �� 5)      $��Add User��6   $	��100��6(   $��35��64   $��Right=�6@   ���#007ACC
�������$��14(�6�   $
��Bold"�6�   ��6�   �� *AddUserCommand+��6�   ��  �� RelativeSource ��  �� AncestorType
 Window�� 5+      
���  ��$��Center=�6G   $��0,10,0,0q�6d   ��6   �� *ErrorMessage+6d   5,      5-      5.      