   M S B A M L   `   `   `  ����C  ?Hospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Hospital.ViewsHospital.Views  5   	        Hospital.Views.AddRoomView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   .localclr-namespace:Hospital.Views     5   	     � Title$  Add Room��5   	   $	��355��6   $	��445��6'    � WindowStartupLocation$ CenterScreen=�63   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Add New Room��6   $��20(�6(   $
��Bold"�66   $��0,0,0,20q�6H   $��Center=�6Z   $��2��6w   �� 5   
    �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6.   $��2��6@   $��Center=�6M   .+�5      �� $��Room Number:��6   $	��120��6+   $��Center=�67   $��14(�6R   �� 5      $	��250��6S   $��14(�6_   ��6   �� *Number+ �� UpdateSourceTrigger$ PropertyChanged=�6_   5      �� 5   
   $ 
Horizontal=�6   $��0,0,0,10q�6.   $��3��6@   $��Center=�6M   .+�5      �� $��Floor:��6   $	��120��6%   $��Center=�61   $��14(�6L   �� 5      $	��250��6R   $��14(�6^   ��6   �� *Floor+$ PropertyChanged=�6^   5      �� 5!   
   $ 
Horizontal=�6   $��0,0,0,10q�6.   $��4��6@   $��Center=�6M   .+�5"      �� $��
Room Type:��6   $	��120��6)   $��Center=�65   $��14(�6P   �� 5#      $ 
Horizontal=�6   .+�5$      	� $��Private��6    	� 	GroupName$ RoomType��60   $��Center=�6l   $
��10,0q�6�    d� 	IsChecked 6E   �� *IsPrivateChecked+6�   	� 5%      $��Shared��6   $ RoomType��6/   $��Center=�6j   $
��10,0q�6�    6D   �� *IsSharedChecked+6�   5&      5'      �� 5*   
   $ 
Horizontal=�6   $��0,0,0,20q�6.   $��5��6@   $��Center=�6M   .+�5+      �� $��	Capacity:��6   $	��120��6(   $��Center=�64   $��14(�6O   �� 5,      $	��100��6U   $��14(�6a   $
��Left=�6o   ��6   �� *
Capacity+$ PropertyChanged=�6o   �� 5-      $��(Number of beds)��6   $��Center=�60   $	��5,0q�6K   5.      �� 51   
   $��Add Room��6   $	��100��6$   $��35��60   $��Right=�6<   ���#007ACC
�������$��14(�6�   $
��Bold"�6�   $��6��6  ��6�   �� *AddRoomCommand+��6�   ��  �� RelativeSource ��  �� AncestorType
 Window6  �� 54   
   
���  ��$��Center=�6C   $��0,10,0,0q�6`   $��7��6r   ��6   �� *ErrorMessage+6r   55      56      