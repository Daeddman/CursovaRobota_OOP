   M S B A M L   `   `   `  ����  CursovaRobota+    %CursovaRobota.Views.WindowInputDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterOwner=�5   	    � 
ResizeMode$ NoResize=�5   	    � SizeToContent$ WidthAndHeight=�5   	    � AllowsTransparency .  � WindowStyle$
 None=�5	   	   
������  � 	Resources 5         HeaderBrush �� Color  SubHeaderBrush  AccentBrush  	CellBrush  CellBorderBrush  
TodayBrush  WeekendBrush  DotBrush  
HoverBrush 	 PressedBrush3  -System.Windows.Media.Effects.DropShadowEffect 
 
CardShadow   Color   
BlurRadius	   ShadowDepth
   Opacity  	BoolToVis  DialogButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 #     &	 F     &	 i     &	 �     &	 �     &	 �     &	 �     &	     &		 ;    &	
 ^    &	 �    &	 �    7  7  7  7 	 �� 5   
   $ 	#FF444444��64   �� 5   
   $ 	#FF666666��64   �� 5   
   $ 	#FFDD3333��64   �� 5   
   $ 	#FFFFFFFF��64   �� 5   
   $ 	#FFCCCCCC��64   �� 5   
   $ 	#FFFFF3E0��64   �� 5   
   $ 	#FFF5E0E0��64   �� 5   
   $ 	#FFDD3333��64   �� 5   
   $ 	#FFE8E8E8��64   �� 5   
   $ 	#FFD4C7C7��64     5   
   $ Black��5      $ 16Q�5      $	 0Q�5      $

 0.15Q�5      �� 5    
   6'   �� 5#   
   " ��6*   .�5$      ��  � ��$ 4q�60   �� 5%       � ��$	 8,4q�60   �� 5&       � ��$ 14(�60   �� 5'       � ��$ SemiBold"�60   �� 5(       � ��8   60   �� 5)       � ��
 �����60   �� 5*       � ��$ 0q�60   �� 5+       � ��$ 90��60   �� 5,       � ��$ 36��60   �� 5-       �@�Cursor$
 Hand��60   �� 5.       � �� 5/      �� 50      " ��6&   .R�51      �� $ bd��6!   #��z��52   !   $ 4��53   !   # z��54   !   ._�55      �� $��Center=�6/   $��Center=�56   /   57       58      P� 59       �@J�IsMouseOver . . �5:   "   �� $ bd��6)   8   � ��6O   �� 5;   "   8   � ��6?   5<      P� 5=       � �� . . �5>   "   �� $ bd��6)   8   � ��6O   5?      5A      5C      5D      5E      .��5H      � ���	#80000000.+�5I   
   �� -   5        #��[ 5I      $��1q�5K      #��[ 5L      $ 14q�5M       J� Effect# [
 5N      ._�5Q      ��  �� Orientation$ Vertical=�6   $	��300��60   .+�5S      �� -   5         ��Name$ 	TxtPrompt��5S      $��SemiBold"�5T      $��14(�5U      $
��Wrap=�5V      #��[  5W      �� 5Z      $��Назва події��6   $��0,12,0,2q�5[      $��SemiBold"�5\      #��[  5]      �� 5^      -   5         ��Name$ TitleBox��5^      $��28��5_      #��[ 5`      
���   �5a      �� 5d      $��Опис події��6   $��0,12,0,2q�5e      $��SemiBold"�5f      #��[  5g      �� 5h      -   5        $ DescriptionBox��5h      $��70��5i       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5k      #��[ 5l      
���   �5m      �� 5p      -   5         ��Name$ HolidayCheckBox��5p      $3��-Позначити подію як свято��5q      $��0,10,0,2q�5r      #��[  5s      �� 5v      $��0,6,0,0q�6   y�5w      ��  �� ElementName$ HolidayCheckBox�� �� Path$ 	IsChecked� �� 	Converter# [ .+�5x      �� $��Анімація:��6    $��SemiBold"�5y       $��0,0,0,2q�5z       #��[  5{       �� 5|      -   5          ��Name$  AnimBox��5|      
�������$	��150��5~      ! �� SelectedIndex$! 0��5�      ��5      �� *AnimationKeys+5�      5�      �� 5�      -   5        $ RepeatCheck��5�      $��Повторювати��5�      $��0,10,0,2q�5�      #��[  5�      �� 5�      -   5        " ��Name$" RepeatPanel��5�      y�5�      �� $ RepeatCheck��$ 	IsChecked�# [ .+�5�      �� $��Частота:��6    $��SemiBold"�5�       $��0,6,0,2q�5�       #��[  5�       �� 5�      $ 
Horizontal=�6!   .+�5�      �� -	   5        $  FreqBox��5�   #   $	��100��5�   #   $! 0��5�   #   # �� SelectedValuePath$	# Tag��5�   #   $ �� SelectedValue$$ Daily��5�   #   .@�5�      �� $��
Щодня��6+   
% � Tag$% Daily��6;   �� 5�      $��Щотижня��6+   $% Weekly��6=   �� 5�      $��Щомісяця��6+   $% Monthly��6>   �� 5�      $��Щороку��6+   $% Yearly��6<   5�      �� 5�      $��
кожні��6$   $��8,0,4,0q�5�   $   $��Center=�5�   $   #��[ 5�   $   �� 5�      -
   5        $ IntervalBox��5�   "   $��40��5�   "   $��1��5�   "   $��Center=�5�   "   #��[ 5�   "   #��[ 5�   "   �� 5�      -   5        $ PeriodLabel��5�   $   $��Center=�5�   $   #��[ 5�   $   ��5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��$ днів��6=   & �� Triggers& 5�   &   �� 5�   *   ' �� Binding' 66   �� $ FreqBox��$ SelectedValue�( �� Value
( Weekly6r   .a�5�   .   ��  � ��$ тижнів��6E   5�   +   �� 5�   *   ' 66   �� $ FreqBox��$ SelectedValue�( Monthly6r   .a�5�   .   ��  � ��$ місяців��6E   5�   +   �� 5�   *   ' 66   �� $ FreqBox��$ SelectedValue�
( Yearly6r   .a�5�   .   ��  � ��$ 
років��6E   5�   +   5�   #   5�      5�      �� 5�      -   5        $" WeekdayPanel��5�   !   $ 
Horizontal=�5�   !   $��0,6,0,0q�5�   !   ��5�      �� 5�      " ��6$   .�5�   "   ��  � y�$ 	Collapsed=�6?   & 5�   "   �� 5�   &   ' 62   �� $ FreqBox��$ SelectedValue�
( Weekly6n   .a�5�   *   ��  � y�$ Visible=�6G   5�   '   5�      .+�5�      �� $
��Пн��6#   $% Monday��60   $	��2,0q�6=   #��[  6J   �� 5�      $
��Вт��6#   $% Tuesday��60   $	��2,0q�6>   #��[  6K   �� 5�      $
��Ср��6#   $% 	Wednesday��60   $	��2,0q�6@   #��[  6M   �� 5�      $
��Чт��6#   $% Thursday��60   $	��2,0q�6?   #��[  6L   �� 5�      $
��Пт��6#   $% Friday��60   $	��2,0q�6=   #��[  6J   �� 5�      $
��Сб��6#   $% Saturday��60   $	��2,0q�6?   #��[  6L   �� 5�      $
��Нд��6#   $% Sunday��60   $	��2,0q�6=   #��[  6J   5�      �� 5�      $ 
Horizontal=�6!   $��0,10,0,0q�6:   .+�5�      �� $��
Час з:��6$   $��Center=�62   #��[  6M   �� 5�      -   5        $ TimeFromBox��5�   "   $��50��5�   "   $	��4,0q�5�   "   $��09:00��5�   "   #��[ 5�   "   #��[ 5�   "   �� 5�      $
��до��6$   $��Center=�6.   #��[  6I   �� 5�      -   5        $ 	TimeToBox��5�   "   $��50��5�   "   $	��4,0q�5�   "   $��18:00��5�   "   #��[ 5�   "   #��[ 5�   "   5�      5�      �� 5�      $ 
Horizontal=�6   $��0,14,0,0q�5�      $��Center=�5�      .+�5�      �� -   5        $��OK��5�      #��[ 5�      ) �� 	IsDefault) . 5�      �� 5�      -   5        $��Скасувати��5�      #��[ 5�      #��[ 5�      #��[  5�      * �� IsCancel* . 5�      5�      5�      5�      5�      5�      