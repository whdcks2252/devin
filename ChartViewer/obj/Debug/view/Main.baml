   M S B A M L   `   `   `  ����F  BChartViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ChartViewer.viewChartViewer.view  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5          ChartViewer.view.Main   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:ChartViewer.view     5      R NOxyPlot.Wpf, Version=2.1.2.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0Y UOxyPlot.Wpf.Shared, Version=2.1.2.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0"oxyhttp://oxyplot.org/wpf   5      5System&clr-namespace:System;assembly=mscorlib   5      
�������  � Icon$  
/chart.png��5       � Title$ ChartViewer��5      $
��1200��6   .��5      �  � 	Resources 5   
    �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6   .�5      ��  � ��
 �����6D   �� 5       � ��$ 1q�64   6@   �� 5       � ��$ -1, 0, 0, -0.5q�6+   6D   5      5       � ColumnDefinitions 5   
   �� 5      $
��3.9* �6   �� 5      $	��250 �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��5* �6   �� 5      $	��120 �6   .+�5$   
   � $��0��6   $��2��6    5%      �� 5&      $��9* �6#    5(      �� 5)      $��1* �6    �� 5*      $��7* �6    .+�5-      �� $��1��6   ._�5.      � $��1��6    5/      �� 50      $��2 �6(   �� 51      �� 52      $��2 �6(    54      �� 55      $��60 �6+   �� 56      �� 57      .+�5:      �� $��1��6       SearchTextStyle#��[  60   $��1��6Y   $��15(�5;       $
��Bold"�6/    K� ZIndex$ 1��6A   $
��Left=�6R   $��Center=�6n   	 �� Left$	 10��6�   

 �� Top$
 4��5<       $	��110��6/    �� TextAlignment$ Center=�6<   
���   ���5:   f   �� *YLable+ �� UpdateSourceTrigger$ PropertyChanged=�5<   i   5=      5>      �� 5?      $��1��6   $��1��6%   ._�5@      � .+�5A        OxyPlot.Wpf.PlotView    OxyPlot.Wpf.PlotViewBase   Model 6$   �� *PlotModelmp+$ PropertyChanged=�5B      5C      5D      �� 5F   
   $��0��6   $��3��6!   ._�5H      �  5I      �� 5J      �� 5K      $	��130 �6'    5M      �� 5N      $��5 �6$   �� 5O      �� 5P      $��5 �6$   .+�5R      �� $��2��6   $��1��6-    �� Orientation$ Vertical=�6:   .+�5S      �� -   5         ��Name$ FreqSearchBt��5S   J     TaskCtrlButtonStyle#��[ 6   $��39��6�   $��
FreqSearch��5T      ��5S   `   �� *FreSearchBt+��5T   /   �� *FreSearchPageBtBG+$ PropertyChanged=���5U      �� *FreSearchPageBtFG+$ PropertyChanged=�y�5V      �� *FreSearchPageBtVis+$ PropertyChanged=��� 5W      -   5        $ PageSearchBt��5W   k   #��[ 6   $��39��6�   $��
PageSearch��6�   ��6J   �� *PageSearchBt+��5X      �� *PageSearchPageBtBG+$ PropertyChanged=���5Y      �� *PageSearchPageBtFG+$ PropertyChanged=�y�5Z      �� *PageSearchPageBtVis+$ PropertyChanged=�5[       � 5\      -   5          �Name$ fr��5\   U   $��1��6   $��0��6%     � NavigationUIVisibility$ Hidden=�6b   ��65   �� *
Fr1Content+6b   5]      5^      �� 5`   
   $��1��6   $��3��6!   ._�5a      �  5b      �� 5c      $��50 �6$   �� 5d      .+�5g      � $��0��6    5h      �� 5i      6*   �� 5j      6*   �� 5k      6*   .+�5m      �� $��1��6!   $ 
Horizontal=�6.   .+�5n      �� #��[  6$   $ Center=�6M   $��FileName : ��6d   �� 5o      #��[  6$   $ Center=�6M   
�������
���   �$��13(�6�   ��6d   �� *
TxtBlock+6�   5p      5q      � 5r      $��2��6    5s      �� 5t      $��20 �6(   �� 5u      $	��110 �6(   �� 5v      .+�5x       � -   5        $ NumOfPageFrame��5x   d   $��1��6   $
��Left=�6)   $ Hidden=�6|   ��6D   �� *
Fr2Content+6|   5y      5z      5{      5}      5~      