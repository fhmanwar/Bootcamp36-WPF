   M S B A M L   `   `   `  ����B  >CRUDWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CRUDWPFCRUDWPF  5   	       CRUDWPF.RegisterWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:CRUDWPF     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��600��5      $	��600��6'     � WindowStartupLocation$  CenterScreen=�63   .��5	      � -   5         �Name$ GridMain��5	      .+�5
   
   � ��5      �� 5       �� ImageSource$ Assets/image_3.jpg��6   5      � 5   
   ���	#7F4242426   �� 5   
   -   5         ��Name$ Heading��5      $��Register��6!   
�������$
��Left=�6G   $��
247,37,0,0q�6b   $	��Top=�6v   $��28(�6�   �� 5   
   $
��Left=�6   $	��318��6/   $	��Top=�6<   $	��518��6T    �� RadiusX$ 20��6`    �� RadiusY$ 20��6m   $��
37,111,0,0q�6z   ���	#4CC3C3C36�   �� 5   
   -   5        $ lblNama��5      $
��Nama��6!   
�������$
��Left=�6C   $��
65,136,0,0q�6^   $	��Top=�6r   $��16(�6�   $��67��6�   �� 5   
   -   5         ��Name$ txtNama��5      
�������$
��Left=�66   $��26��6Q   $��
65,170,0,0q�6]    �� TextWrapping$
 Wrap=�6q   $	��Top=�6�   $	��210��6�   ���	#89FFFFFF6�   �� 5   
   -   5        $ lblEmail��5      $��Email��6"   
�������$
��Left=�6E   $��319,136,0,0q�6`   $	��Top=�6u   $��16(�6�   $��60��6�   �� 5   
   -   5        $ txtEmail��5      
�������$
��Left=�67   $��26��6R   $��319,170,0,0q�6^   $
 Wrap=�6s   $	��Top=�6�   $	��206��6�   ���	#89FFFFFF6�   �� 5   
   -   5        $ lblPass��5      $��Password��6!   
�������$
��Left=�6G   $��
65,224,0,0q�6b   $	��Top=�6v    J� RenderTransformOrigin$ 0.468,0.458&�6�   $��16(�6�   $��87��6�   G� 5   
   -   5        $��txtPass��5      	 G� Password$	  ��6%   
�������$��Center=�6D   $	��208��6a   ���	#89FFFFFF$��65,258,319,274q�6�   �� 5   
   -	   5        $ 	lblRePass��5      $��Confirm Password��6#   
�������$
��Left=�6Q   $��319,224,0,0q�6l   $	��Top=�6�   $ 0.468,0.458&�6�   $��16(�6�   $	��140��6�   G� 5   
   -
   5        
 G�Name$
 	txtRePass��5      
�������$��Center=�6<   $��319,258,69,274q�6Y   $	��204��6q   ���	#89FFFFFF6}   �� 5   
   -   5         ��Name$ 	btnSignUp��5      $
��Left=�6%   $��253,336,0,0q�6@   $	��Top=�6U   $��89��6m   $��48��6�    � ToolTip$ Register��6�   ���	#00000000���	#00008EFF.��5      '  !MaterialDesignThemes.Wpf.PackIcon  
�������   Kind$ Register=�69   $��43��6I   $��36��6T   5      �� 5!   
   -   5        $ signUp��5!      $��you have account?��6    
�������$
��Left=�6O   $��158,469,0,0q�6j   $	��Top=�6   $ 0.468,0.458&�6�   $��20(�6�   �� 5"   
   -   5        $ btnLogin��5"      $
��Left=�6$   $��319,462,0,0q�6?   $	��Top=�6T   $��94��6l   $��56��6�   $ Sign In��6�   ���	#00000000���	#00008EFF.��5#        
�������$ Login=�69   $��40��6F   $��36��6Q   5$      5&      5'      