   M S B A M L   `   `   `  ����  Hospital    Hospital.Views.RoomsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � ���#F0F4F8.+�5	   
   �� .+�5      ��   �� Orientation$  
Horizontal=�6   $��Right=�62   $��0,0,0,20q�6N   .+�5      �� $��Add New Room��6   $	��120��60   $��40��6<   $��5q�6H   ���#76F7E6
�������$
��Bold"�5   =   
������  � Cursor$
 Hand��5      ��6#   �� *OpenAddNewRoomCommand+ J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6+      	Direction$	 320Q�69      ShadowDepth$ 2Q�6I      Opacity$	 0.5Q�6Y      
BlurRadius$ 5Q�6g   5      5      �� 5      $��Rooms Manager��6   $��24(�6-   $��SemiBold"�6;   ���#333$��Center=�6c   $��0,0,0,20q�6�   $��Segoe UI)�6�   � 5       � ColumnDefinitions 5      �� 5      $��* �6'   $	��300��61   �� 5      $
��Auto �6'   $��20��64   �� 5      $��* �6'   $	��300��61   .+�5!      �� $��1��6   ���#DCDCDC$��1��6>   $��5q�6H   �� 5$      $��0��6   $��0,0,10,0q�6-   .+�5%      �� $��Private Rooms��6    $��18(�65   $
��Bold"�6C   ���#333$��0,0,0,10q�6g   $��Center=�6y   $��Segoe UI)�6�   &   System.Windows.Controls.DataGrid  5&      	   AutoGenerateColumns$	 False��6D   $��0,0,0,20q�6`   
   CanUserAddRows$
 False��5'         CanUserDeleteRows$ False��66      CanUserResizeRows$ False��6P      
IsReadOnly$
 True��6j      GridLinesVisibility$
 None=�5(         HeadersVisibility$ Column=�6:   $��14(�5)      $��Segoe UI)�6-   ���#333   RowBackground �#FFFFFF   AlternatingRowBackground �#F9F9F9���#DCDCDC$��1q�5+   5   ��5&      �� *PrivateRooms+ � 	Resources 5,      )  #System.Windows.Controls.DataGridRow �� 
TargetType �� Property �� Value �� RelativeSource �� Path �� Triggers P� Property P� Value*  $System.Windows.Controls.DataGridCell=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�  '        '  2    '  �    �� 5.      "  6$   .�5/   "   ��  � ��
 ���� 6?   �� 50   "    �@�ToolTip 6<   ��  �� *Self+$
 Item� 51   "   P� 52   &    �@J�IsMouseOver$
 True��6E   . �53   *   ��  � �� �#76F7E66G   �� 54   *    � �� �#1DF8E76G   55   '   57      �� 59      "  6$   .�5:   "   ��  � ��$ Center=�6F   �� 5;   "    � ��$ Center=�6H   �� 5<   "    � ��$ 5q�6<   5=      �� 5?      "  6$   .�5@   "   ��  � ��$ Center=�6O   �� 5A   "    � �� �#76F7E66?   �� 5B   "    � ��
 �����6?   �� 5C   "    � ��$
 Bold"�6?   �� 5D   "    � ��$ Center=�6M   �� 5E   "    � ��$ 40��6;   5F      5G         Columns 5H      0  *System.Windows.Controls.DataGridTextColumn  5I      ,  &System.Windows.Controls.DataGridColumn   Header$ Room Number��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6f      
FontWeight$
 Bold"�6p   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6F   �� *Room.Number+6p     5J      $ Floor��61   $ * 6_    6@   �� *
Room.Floor+6_     5K      $ Capacity��61   $ * 6e    6C   �� *Room.Capacity+6e   4
  .System.Windows.Controls.DataGridTemplateColumn
  5L      $ 
Bed Status��65   $ * 6I     
  CellTemplate  5M   "   �� 5N   &   .R�5O   *   �� $
��Bold"�5P   4   ! �� Padding$! 5q�5R   4   $��Center=�5S   4   $��Center=�5T   4   " �� TextAlignment$" Center=�5U   4   ��5O   4   �� *	BedStatus+��5Q   4   �� *StatusBackground+5U   4   5V   '   5X      5Z      5[      �� 5^      $��2��6   $��10,0,0,0q�6-   .+�5_      �� $��Shared Rooms��6    $��18(�64   $
��Bold"�6B   ���#333$��0,0,0,10q�6f   $��Center=�6x   $��Segoe UI)�6�     5`      $	 False��6C   $
 False��5a      $ False��66   $ False��6P   $
 True��6j   $
 None=�5b      $ Column=�6:   $��14(�5c      $��Segoe UI)�6-   ���#333 �#FFFFFF �#F9F9F9���#DCDCDC$��1q�5e   5   ��5`      �� *SharedRooms+ 5f      ��%�  '        '  2    '  �    �� 5h      "  6$   .�5i   "   ��  � ��
 ���� 6?   �� 5j   "    �@�ToolTip 6<   ��  �� *Self+$
 Item� 5k   "   P� 5l   &    �@J�IsMouseOver$
 True��6E   . �5m   *   ��  � �� �#76F7E66G   �� 5n   *    � �� �#1DF8E76G   5o   '   5q      �� 5s      "  6$   .�5t   "   ��  � ��$ Center=�6F   �� 5u   "    � ��$ Center=�6H   �� 5v   "    � ��$ 5q�6<   5w      �� 5y      "  6$   .�5z   "   ��  � ��$ Center=�6O   �� 5{   "    � �� �#76F7E66?   �� 5|   "    � ��
 �����6?   �� 5}   "    � ��$
 Bold"�6?   �� 5~   "    � ��$ Center=�6M   �� 5   "    � ��$ 40��6;   5�      5�       5�        5�      $ Room Number��61   $ * 6f   $
 Bold"�6p    6F   �� *Room.Number+6p     5�      $ Floor��61   $ * 6_    6@   �� *
Room.Floor+6_     5�      $ Capacity��61   $ * 6e    6C   �� *Room.Capacity+6e   
  5�      $
 Beds��65   $ * 6C     5�   "   �� 5�   &   .R�5�   *   �� ��67   �� *Beds+��5�   .   �� 5�   2   .R�5�   6   �� $  
Horizontal=�6A   $��5q�6Z   .+�5�   :   �� $��0,0,10,0q�6[   $��Center=�6m   ��6D   �� *Label+6m   �� 5�   :   $
��Bold"�5�   D   $! 5q�5�   D   $��Center=�5�   D   $��Center=�5�   D   $" Center=�5�   D   ��5�   D   �� *Status+��5�   D   �� *StatusBackground+5�   D   5�   7   5�   3   5�   +   5�   '   5�      5�      5�      5�      5�      5�      5�      