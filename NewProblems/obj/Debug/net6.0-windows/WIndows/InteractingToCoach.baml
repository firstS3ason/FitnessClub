   M S B A M L   `   `   `  ����F  BNewProblems, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:NewProblems.WIndowsNewProblems.WIndows  5   	   ,    &NewProblems.WIndows.InteractingToCoach   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:NewProblems.WIndows     5   	     � Title$  InteractingToCoach��5   	   $	��344��6$   $	��420��61   .��5	      � ���	#FF357B9E � ColumnDefinitions 5
   
   �� 5      $	��97* �6   �� 5      $
��323* �6   .+�5   
   ]� $��False��6   $��
0,213,0,40q�6*   ���	#FF251717$��2��6U   ]� 5   
   $��False��6   $��
0,10,0,216q�6*   ���	#FF211818$��2��6U   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ UsersDataGrid��5   C      AutoGenerateColumns$ False��6      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 63   $	��420��6Z   $	��124��6f      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Login+5      5      �� 5   
   -   5        $	��Add��5      $
��Left=�6   $��
74,213,0,0q�6:   $	��Top=�6N   $��49��6f   $��78��6r   ���	#FFA6B6C5$��1��6�   �� 5   
   -   5         ��Name$ txtName��5      $
��Left=�6#   $��
90,117,0,0q�6>   	 �� TextWrapping$
	 Wrap=�6R   $	��Top=�6�   $	��120��6�   ���	#FF0A0A0A
 �� SelectionBrush
 �	#FF43749C���	#FF67A0AB$��2��6  ��6f   �� *SelectedItem.Login+ �� ElementName$ UsersDataGrid��6  �� 5   
   -   5        $ txtAge��5      $
��Left=�6"   $��118,117,0,0q�6=   $
	 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��120��6�   ���	#FF0A0A0A
 �	#FF43749C���	#FF67A0AB$��1��6�   �� 5   
   -   5        $ 	txtGender��5      $
��Left=�6%   $��51,0,0,0q�6@   $
	 Wrap=�6R   $�� ��6f   $��Center=�6n   $	��120��6�   ���	#FF0A0A0A
 �	#FF43749C���	#FF67A0AB$��2��6�   �� 5   
   -   5        $ txtProfessionalIn��5      $
��Left=�6-   $��	129,0,0,0q�6H   $
	 Wrap=�6[   $�� ��6o   $��Center=�6w   $	��120��6�   ���	#FF0A0A0A
 �	#FF43749C���	#FF67A0AB$��1��6�   �� 5   
   $��Name:��6   $
��Left=�6    $��
36,112,0,0q�6;   $	��Top=�6O   
�������6g   �� 5   
   $	��Age��6   $
��Left=�6   $��249,112,0,0q�69   $	��Top=�6N   
�������$��1��6y   �� 5   
   $��Gender��6   $
��Left=�6!   $��
62,164,0,0q�6<   $	��Top=�6P   
�������$��2��6{   �� 5    
   $��OurGymWorkerFrom��6   $
��Left=�6+   $��
53,167,0,0q�6F   $	��Top=�6Z   
�������$��1��6�   �� 5!   
   $��Professional in��6   $
��Left=�6*   $��178,167,0,0q�6E   $	��Top=�6Z   
�������$��1��6�   �� 5"   
   -   5        $��choose��5"      $
��Left=�6"   $��
68,188,0,0q�6=   $	��Top=�6Q   $��90��6i   $��1��6�   �� 5#   
   -   5         ��Name$ 
escape_btn��5#      $��escape��6%   $
��Left=�66   $��249,213,0,0q�6Q   $	��Top=�6f   $��49��6~   $��78��6�   ���	#FFA6B6C5$��1��6�   5%      5&      