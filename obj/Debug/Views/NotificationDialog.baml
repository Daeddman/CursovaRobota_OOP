   M S B A M L   `   `   `  ����  CursovaRobota,    &CursovaRobota.Views.NotificationDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Повідомлення��5   	    � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������  � SizeToContent$ WidthAndHeight=�5
   	    � 	Resources 5         DialogButtonStyle �� 
TargetType �� Property	 �� Value��%�  &	        �� 5   
   " ��6*   .�5      ��  � ��$	 8,12,8,0q�6'   �� 5       � ��$		 6,2q�6(   �� 5       � ��$	 14(�6)   �� 5       � ��$	 SemiBold"�6+   �� 5       � ��	 �	#FF2196F36+   �� 5       � ��
	 �����6+   �� 5       � ��$	 0q�60   �� 5       � ��$	 80��6&   �� 5       � ��$	 Center=�64   �� 5       �@�Cursor$
	 Hand��6'   5      5      .��5      �� 
�������
 �� CornerRadius$
 8��5      $��1q�5      ���	#FF2196F3 �� Padding$ 16q�5       J� Effect 5    
   3  -System.Windows.Media.Effects.DropShadowEffect  5!         
BlurRadius$ 10Q�6      ShadowDepth$ 0Q�6/      Opacity$
 0.25Q�6?   ._�5$   
   �� $	��300��6   .+�5%      �� -   5         ��Name$ MessageText��5%      $
��Wrap=�5'      $��14(�5(      $��SemiBold"�5)      ���	#FF333333��5&      �� *	Message+5*      �� 5+      -   5        $��OK��5+      #��[  5,      5-      5.      5/      50      