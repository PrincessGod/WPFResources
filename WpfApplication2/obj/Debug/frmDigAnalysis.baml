   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    WpfApplication2$   WpfApplication1.frmDigAnalysis   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9system&clr-namespace:System;assembly=mscorlib     5   	   W SMaterialDesignThemes.Wpf, Version=1.2.0.31832, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Window1��5   	   $	��700��6   $	��200��6&    � WindowStyle$
 None=�62    � AllowsTransparency .  � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6u      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5	   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5
   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 	Resources 5       �� MergedDictionaries	 �� Source�� 5   
    5      �� 5      $d	 ^pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml?�6%   �� 5      $h	 bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $t	 npack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Cyan.xaml?�6%   �� 5      $s	 mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   �� 5      $h	 bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.PopupBox.xaml?�6%   �� 5      $o	 ipack://application:,,,/MaterialDesignColors;component/Themes/MaterialDesignColor.Green.Named.Primary.xaml?�6%   %    5      .��5      #  MaterialDesignThemes.Wpf.Card  +  %MaterialDesignThemes.Wpf.ShadowAssist
   ShadowDepth$
 Depth5=�6   
���   �$��Stretch=�6^   $��Stretch=�6z   .��5   
   � $��1q�6   #���  6   .+�5       (  "MaterialDesignThemes.Wpf.ColorZone  -   5        $��
24,10,6,10q�5    G   $
 Depth0=�6\      Mode$ Standard=�5!   -   .��5"      ]� .+�5#      �� -   5        $��Right=�5#   6   $��	10,0,10,0q�6M     MaterialDesignFlatButton#��[ 6a   .��5$      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=1.2.0.31832, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�62   $��24��6?   $��24��6K   5%      �� 5,      $
��Left=�6    $��Center=�6;   $��22(�6V   挖掘分析6j   5-      5.      � 5/      $��8 50 8 0q�6    � RowDefinitions 50      �� 51      $��0 �6$   �� 52      $��* �6$   .+�54      � .+�55        $ Information=�6.   $��24 0 0 2q�6A   $��20��6S   $��20��6^   $��Center=�6j   �� 56      $
��Left=�6     �� Padding$ 0q�6;   $��Center=�6G   $��54,0,0,0q�6b   $��14(�6u   $��1��6�   97说明文字 在这里写这一页的相关描述信息6�   �� 57      $��	-8,0,-8,1q�6   $��0 1 0 0q�60   $��Bottom=�6J     MaterialDesignDivider#���  6e   $��1��6�   58      � 59      $��0,2,0,0q�6   $��1��6(   .+�5:      �� .+�5;      9�  9� 
IsExpanded . $��交通模式��65   .��5<      �� #���   6*   $��
24,8,24,16q�6f   .+�5>   "   d� -   5         d�Name$
 btn1��5>   /   $
��Left=�6=   $��0 6 0 2q�6X   $	��100��6�   $
��auto��6�    " MaterialDesignFlatToggleButton#��[ 6�   ��5?   &   �� 5@   *    �� Orientation$ 
Horizontal=�65   $��0 4 0 4q�6N   $��Center=�6_   .+�5A   .   �� $��14(�68   密度分布6M   5B   +   5E   #   �� 5F   "   -   5         ��Name$ 
BottomText��5F   D   $y�	Collapsed=�6-   .+�5G   &   (  "System.Windows.Controls.DatePicker  -   5          Name$ 	StartDate��5G   =   $	��100��61    � Language$ zh-CN�6P   $��Center=�6a   $��0 15 0 0q�6|   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 日期��6�    ( $MaterialDesignFloatingHintDatePicker#��[ 6�   )	  #MaterialDesignThemes.Wpf.TimePicker	  5H   &   -   5         	 Name$ 	StartTime��5H   Q    	  	Is24Hours .  	  SelectedTimeFormat$
 Long=�6e   $��Center=�6   $	��100��6�   $��Center=�6�   $��0 0 0 0q�6�   $ 时间��6�   5I   #   d� 5K   "   -   5        $
 btn2��5K   0   $
��Left=�6>   $��0 6 0 2q�6Y   $	��100��6�   $
��auto��6�   #��[ 6�   ��5L   &   �� 5M   *   $ 
Horizontal=�65   $��0 4 0 4q�6N   $��Center=�6_   .+�5N   .   �� $��14(�68   流量分布6M   5O   +   5R   #   �� 5S   "   -   5        $ BottomText2��5S   D   $y�	Collapsed=�6-   .+�5T   &     -	   5        $ 
StartDate2��5T   =   $	��100��61   $ zh-CN�6Q   $��Center=�6b   $��0 15 0 0q�6}   $ 日期��6�   #��[ 6�   	  5U   &   -
   5        $ 
StartTime2��5U   Q    . $
 Long=�6f   $��Center=�6�   $	��100��6�   $��Center=�6�   $��0 0 0 0q�6�   $ 时间��6�   5V   #   d� 5X   "   -   5        $
 btn3��5X   0   $
��Left=�6>   $��0 6 0 2q�6Y   $	��100��6�   $
��auto��6�   #��[ 6�   ��5Y   &   �� 5Z   *   $ 
Horizontal=�65   $��0 4 0 4q�6N   $��Center=�6_   .+�5[   .   �� $��14(�68   失事分布6M   5\   +   5_   #   �� 5`   "   -   5        $ BottomText3��5`   D   $y�	Collapsed=�6-   .+�5a   &     -   5        $ 
StartDate3��5a   =   $	��100��61   $ zh-CN�6Q   $��Center=�6b   $��0 15 0 0q�6}   $ 日期��6�   #��[ 6�   	  5b   &   -   5        $ 
StartTime3��5b   Q    . $
 Long=�6f   $��Center=�6�   $	��100��6�   $��Center=�6�   $��0 0 0 0q�6�   $ 时间��6�   5c   #   5d      5f      9� 5g       . $��预测评估��65   .��5h      �� #���   6*   $��
20,8,24,16q�6f   .+�5i   "   d� -   5        $
��Left=�5i   /   $��0 6 0 2q�6J   $	��100��6x   $
��auto��6�   #��[ 6�   ��5j   &   �� 5k   *   $ 
Horizontal=�65   $��0 4 0 4q�6N   $��Center=�6_   .+�5l   .   �� $��14(�68   活动预测6M   5m   +   5o   #   d� 5p   "   -   5        $
 btn5��5p   ^   $
��Left=�60   $��0 6 0 2q�6K   $	��100��6�   $
��auto��6�   #��[ 6�   ��5q   &   �� 5r   *   $ 
Horizontal=�65   $��0 4 0 4q�6N   $��Center=�6_   .+�5s   .   �� $��14(�68   风险评估6M   5t   +   5v   #   5w      5x      5y      5z      5{      5}      5~      5      