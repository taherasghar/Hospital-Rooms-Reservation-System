   M S B A M L   `   `   `  ����  Hospital"    Hospital.Views.AddDoctorView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
Add Doctor��5   	   $	��445��6   $	��415��6)    � WindowStartupLocation$ CenterScreen=�65   .��5      � $��
20,20,0,20q�6   .+�5   
   �� $	��Top=�6   $	��354��6-   $��0,0,10,0q�6:   .+�5      �� $��Add New Doctor��6   $��20(�6.   $
��Bold"�6<   $��0,0,0,20q�6N   $��Center=�6`   �� 5	       �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�62   .+�5
      �� $��	Username:��6   $	��100��6,   $��Center=�68   $��14(�6S   �� 5      $	��250��6\   $��14(�6h   ��6   �� *newUsername+ �� UpdateSourceTrigger$ PropertyChanged=�6h   5      �� 5      $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5      �� $��	Password:��6   $	��100��6,   $��Center=�68   $��14(�6S   �� 5      $	��250��6Y   $��14(�6e   ��6   �� *
Password+$ PropertyChanged=�6e   5      �� 5      $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5      �� $��First Name:��6   $	��100��6.   $��Center=�6:   $��14(�6U   �� 5      $	��250��6Z   $��14(�6f   ��6   �� *	FirstName+$ PropertyChanged=�6f   5      �� 5      $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5      �� $��
Last Name:��6   $	��100��6-   $��Center=�69   $��14(�6T   �� 5      $	��250��6Y   $��14(�6e   ��6   �� *
LastName+$ PropertyChanged=�6e   5      �� 5      $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5      �� $��Specialization:��6   $	��100��62   $��Center=�6>   $��14(�6Y   �� 5      $	��250��6_   $��14(�6k   ��6   �� *Specialization+$ PropertyChanged=�6k   5       �� 5"      $��
Add Doctor��6   $	��100��6*   $��35��66   $��Right=�6B   ���#007ACC
�������$��14(�6�   $
��Bold"�6�   ��6�   �� *AddDoctorCommand+��6�   ��  �� RelativeSource ��  �� AncestorType
 Window�� 5$      
���  ��$��Center=�6G   $��0,10,0,0q�6d   ��6   �� *ErrorMessage+6d   5%      5&      5'      