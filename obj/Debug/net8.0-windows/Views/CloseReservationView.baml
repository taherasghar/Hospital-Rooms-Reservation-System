   M S B A M L   `   `   `  ����  Hospital)    #Hospital.Views.CloseReservationView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Close Reservation��5   	   $	��305��6#   $	��385��60    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � ���#F0F4F8.+�5   
   �� $��20q�6   .+�5	      �� $��Close Reservation��6   $��24(�61   $��SemiBold"�6?   ���#333$��Center=�6g   $��0,0,0,20q�6�   �� 5
      $��Reservation ID:��6   $
��Bold"�6/   �� 5       �� 
IsReadOnly$
 True��65   $��0,0,0,20q�6G   ��6   �� *ReservationId+6G   �� 5      $��
Exit Date:��6   $
��Bold"�6*   (  "System.Windows.Controls.DatePicker  5      $��0,0,0,20q�6;      SelectedDate 6   �� *
ExitDate+6;   �� 5      $��Confirm Close Reservation��6   $	��160��6�   $��40��6�   $��5q�6�   ���	#FF1AC815
�������$
��Bold"�5   ?   
������  � Cursor$
 Hand��5      $��Center=�6#   ��5   9   �� *CloseReservationCommand+��6e   ��  �� RelativeSource ��  �� AncestorType
 Window J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   Color$	 Black��6'   
   	Direction$	
 320Q�65      ShadowDepth$ 2Q�6E      Opacity$	 0.5Q�6U      
BlurRadius$ 5Q�6c   5      5      5      5      