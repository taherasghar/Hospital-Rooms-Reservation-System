   M S B A M L   `   `   `  ����  Hospital#    Hospital.Views.AddPatientView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Add Patient��5   	   $	��355��6   $	��415��6*    � WindowStartupLocation$ CenterScreen=�66   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��259* �6   �� 5      $	��90* �6   .+�5
   
   �� $	��Top=�6   $	��314��6-   $��2��6:   .+�5      �� $��Add New Patient��6   $��20(�6/   $
��Bold"�6=   $��0,0,0,20q�6O   $��Center=�6a   �� 5       �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�62   .+�5      �� $��First Name:��6   $	��100��6.   $��Center=�6:   $��14(�6U   �� 5      $	��250��6Z   $��14(�6f   ��6   �� *	FirstName+ �� UpdateSourceTrigger$ PropertyChanged=�6f   5      �� 5      $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5      �� $��
Last Name:��6   $	��100��6-   $��Center=�69   $��14(�6T   �� 5      $	��250��6Y   $��14(�6e   ��6   �� *
LastName+$ PropertyChanged=�6e   5      �� 5      $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5      �� $��Gender:��6   $	��100��6*   $��Center=�66   $��14(�6Q   �� 5      $ 
Horizontal=�6   .+�5      	� $��Center=�6"   $
��Male��6=    	� 	GroupName$ Gender��6L   $��0,0,10,0q�6�    d� 	IsChecked 6_   �� *IsMaleChecked+6�   	� 5      $��Center=�6"   $��Female��6=   $ Gender��6N    6a   �� *IsFemaleChecked+5      5      �� 5      $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5       �� $��Date of Birth:��6   $	��100��61   $��Center=�6=   $��14(�6X   (  "System.Windows.Controls.DatePicker  5!      $	��250��6B   $��14(�6N      SelectedDate 6   �� *DateOfBirth+6N   5"      �� 5$      $��Add Patient��6   $	��100��6+   $��35��67   $��Right=�6C   ���#007ACC
�������$��14(�6�   $
��Bold"�6�   ��6�   �� *AddPatientCommand+��6�   ��  �� RelativeSource �� 	 �� AncestorType
	 Window�� 5&      
���  ��$��Center=�6G   $��0,10,0,0q�6d   ��6   �� *ErrorMessage+6d   5'      5(      5)      