   M S B A M L   `   `   `  ����F  BAssignment1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Assignment1Assignment1  5   	       Assignment1.Sale   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Assignment1     5   	     � Title$
  Sale��5   	   $	��550��6   $	��900��6#   .��5	      �  � RowDefinitions 5
   
   �� 5      $��20 �6   �� 5      $	��87* �6   �� 5      $
��320* �6   �� 5      $	��87* �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��213* �6   �� 5      $
��217* �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6    $
��Left=�6-   $��Produce Pro Sale Terminal��6O   $��25(�5      $
��Bold"�6   $��Center=�6(   $��2��6J   �� 5   
   $��1��6   $��Customer Name��6    $��Right=�68   $��	0,30,30,0q�6T   $��2��6g   $	��Top=�6t   �� 5   
   -   5         ��Name$ custName��5      $��2��6$   $
��Left=�64   $��	30,35,0,0q�6O   $��2��6b    �� TextWrapping$
 Wrap=�6o   $	��Top=�6�   $	��120��6�   �� 5   
   $��1��6   $��
Product ID��6    $��Right=�65   $��	0,69,30,0q�6Q   $��2��6d   $	��Top=�6q   �� 5   
   -   5        $ 	productId��5      $��2��6%   $
��Left=�65   $��	30,74,0,0q�6P   $��2��6c   $
 Wrap=�6p   $	��Top=�6�   $	��120��6�   �� 5   
   $��1��6   $��Amount (kg)��6    $��Right=�66   $��
0,108,30,0q�6R   $��2��6f   $	��Top=�6s   �� 5   
   -   5        $ amountKg��5      $��2��6$   $
��Left=�64   $��
30,113,0,0q�6O   $��2��6c   $
 Wrap=�6p   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ total��5      $��2��6!   $
��Left=�61   $��
30,198,0,0q�6L   $��2��6`   $
 Wrap=�6m   $	��Top=�6�   $	��120��6�   {�.  6�   �� 5    
   -   5         ��Name$ calculateTotal��5       $��1��6)   $��Calculate Total��69   $��Right=�6S   $��
0,198,30,0q�6o   $��2��6�   $	��Top=�6�   $	��100��6�   6�   �� 5!   
   -   5        $ confirmSale��5!      $��1��6&   $��Confirm Sale��66   $��Right=�6M   $��281,276,30,0q�6i   $��2��6   $	��Top=�6�   {�.  6�   5"      5#      