   M S B A M L   `   `   `  ���� B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp2.viewWpfApp2.view  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem     WpfApp2.view.Main   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:WpfApp2.view     R NOxyPlot.Wpf, Version=2.1.2.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0Y UOxyPlot.Wpf.Shared, Version=2.1.2.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0"oxyhttp://oxyplot.org/wpf   5System&clr-namespace:System;assembly=mscorlib     � Title$
  Main��$	��879��.���  � ColumnDefinitions �� $��3* ��� $��1* � � RowDefinitions �� $��1* ��� $��4* ��� $��1* �.+�� $��1��$��0��.+���  �� Orientation$ 
Horizontal=�.+��� $��Center=� �� TextAlignment$ Center=�$
��Wrap=�
�������
���   �$��15(�$��56��$��94������ *
TxtBlock+�� $��20,0,0,0q�$��Center=�$��LoadFile��$��56��$��94������ *
SaveData+����  �� Color# � ��� $��0��$��2�� �� $��1* ��� $��7* ��� $��1* � �� $��1* ��� $��7* ��� $��1* �.+�� $��1��$��1��.+��� .+��� $��13(� K� ZIndex$ 1��$
��Left=�$��Center=� �� Left$ 10��
 �� Top$ 4��$	��110������ *YLable+	 �� UpdateSourceTrigger$	 PropertyChanged=�  OxyPlot.Wpf.PlotView  $	��379��$	��467��  OxyPlot.Wpf.PlotViewBase
   Model
 �� *PlotModelmp+$	 PropertyChanged=��� $��15(�$ 1��$	 410��$	 346��$
��Left=�$��Center=�$��91���� $�	frequency��� $��0��$��3��.+��� $ Vertical=� J� RenderTransformOrigin$ 0.5,0.5&�$��
518,0,0,11q�.+��� -    ��Name$ FreqSearchBt��$��39��$��
FreqSearch������ *FreSearchBt+���� *FreSearchPageBtBG+$	 PropertyChanged=����� *FreSearchPageBtFG+$	 PropertyChanged=�y��� *FreSearchPageBtVis+$	 PropertyChanged=��� -   $ PageSearchBt��$��39��$��
PageSearch������ *PageSearchBt+���� *PageSearchPageBtBG+$	 PropertyChanged=����� *PageSearchPageBtFG+$	 PropertyChanged=�y��� *PageSearchPageBtVis+$	 PropertyChanged=� � -     �Name$ fr��$��	0,0,141,0q�  � NavigationUIVisibility$ Hidden=����� *
Fr1Content+� $��1��$��1��.+� � -   $ NumOfPageFrame��$ Hidden=����� *
Fr2Content+