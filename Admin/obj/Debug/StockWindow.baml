   M S B A M L   `   `   `  ����@  <Admin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:AdminAdmin  5   >       Admin.StockWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   %Adminclr-namespace:Admin     5   >   -   5          � Title$  StockWindow��5   	   $��332.609��6   $��537.391��6.    � 	Resources 5      #  Admin.CellBackgroundConverter   CellBackgroundConverter  	cellStyle �� 
TargetType*  $System.Windows.Controls.DataGridCell �� Property �� Value �� RelativeSource �� Path �� 	Converter��%�   &	        &	      7     5   
   6(   �� 5   
   "  6"   .�5      ��  � �� 5	      ��  �� *Self+$ Content.Text�8   �� 5
       � ��
 �   �67   5      5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5      $
��Left=�6%   $��	10,10,0,0q�6@   $	��Top=�6S   $	��244��6k   $	��509��6x   	   CanUserAddRows	 .  ��6�   �� 6�   �� 5   
   -   5        
 ��Name$
 	btnUpdate��5      $��Opdater��6$   $
��Left=�66   $��444,259,0,0q�6Q   $	��Top=�6f   $��75��6~   $��34��6�   6�   �� 5   
   -   5        $
 btnBack��5      $��Tilbage��6"   $
��Left=�64   $��
10,259,0,0q�6O   $	��Top=�6c   $��75��6{   $��34��6�   6�   5      5      