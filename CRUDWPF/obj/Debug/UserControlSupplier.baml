   M S B A M L   `   `   `  ����  CRUDWPF!    CRUDWPF.UserControlSupplier   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5	      � 
�������.+�5
   
   �� $��Supplier��6   $
��Left=�6#   $��
431,32,0,0q�6>   $	��Top=�6R   $��28(�6j   $	��111��6x   $��50��6�   �� 5   
   -   5          ��Name$  	btnInsert��5      $��Insert��6$   $
��Left=�65   $��591,425,0,0q�6P   $	��Top=�6e   $��85��6}   6�   �� 5   
   -   5         ��Name$ txtName��5      $
��Left=�6#   $��26��6>   $��659,217,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��202��6�   6�   �� 5   
   -   5         ��Name$ lblName��5      $
��Nama��6!   $
��Left=�60   $��591,217,0,0q�6K   $	��Top=�6`   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dtList��5      $
��Left=�6#   $	��300��6>   $��
36,155,0,0q�6K   $	��Top=�6_   $	��506��6w      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $
 Name��6%    63   �� *Name+  5      $ Email��6%    64   �� *Email+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Action��6)   	   CellTemplate	 5      �� 5      .R�5      �� $  	btnDelete��6%   -   5        .��5   "   '  !MaterialDesignThemes.Wpf.PackIcon  ���	#FFFFFAFC
   Kind$
 Trash=�6Q   $��25��6^   $��25��6i   5      5      5      5      �� 5   
   -   5        $ lblID��5      $��ID��6   $
��Left=�6,   $��591,167,0,0q�6G   $	��Top=�6\   �� 5    
   -   5        $ txtID��5       $
��Left=�6!   $��26��6<   $��659,165,0,0q�6H   $
 Wrap=�6]   $	��Top=�6q   $	��202��6�    �� 
IsReadOnly . 6�   �� 5!   
   -   5        $  	btnUpdate��5!      $��Update��6$   $
��Left=�65   $��708,425,0,0q�6P   $	��Top=�6e   $��83��6}   6�   �� 5#   
   -	   5        $ lblEmail��5#      $��Email��6"   $
��Left=�62   $��591,290,0,0q�6M   $	��Top=�6b   �� 5$   
   -
   5        $ txtEmail��5$      $
��Left=�6$   $��26��6?   $��659,288,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��202��6�   6�   �� 5%   
   -   5        $ lblPass��5%      $
��Pass��6!   $
��Left=�60   $��591,345,0,0q�6K   $	��Top=�6`   �� 5&   
   -   5        $ txtPass��5&      $
��Left=�6#   $��26��6>   $��659,343,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��202��6�   �� 5(   
   -   5        $ lblStatusName��5(      $�� ��6'   $
��Left=�62   $��591,246,0,0q�6M   $	��Top=�6b   $	��301��6z   ���	#00000000���	#DDFF00006�   �� 5)   
   -   5        $ 	lblSearch��5)      $��Search��6#   $
��Left=�64   $��174,125,0,0q�6O   $	��Top=�6d   $��52��6|   �� 5*   
   -   5        $ 	txtSearch��5*      $
��Left=�6%   $��26��6@   $��242,125,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��196��6�   �� 5+   
   -   5        $  	btnSearch��5+      $��Search��6$   $
��Left=�65   $��458,119,0,0q�6P   $	��Top=�6e   $��84��6}    J� RenderTransformOrigin$ 0.232,0.172&�6�   �� 5-   
   -   5        $  
btnRefresh��5-      $
��Left=�6%   $��820,425,0,0q�6@   $	��Top=�6U   $��59��6m   $��30��6�   .��5.        ���#fff$
 Reload=�68   $��25��6F   $��25��6Q   $ 	0.46,0.44&�6]   5/      52      53      