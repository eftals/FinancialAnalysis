   M S B A M L   `   `   `  ����J  FFinanceAnalysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FinanceAnalysisFinanceAnalysis  5   	   A%clr-namespace:FinanceAnalysis.HelpersFinanceAnalysis.Helpers  5   	        FinanceAnalysis.MainWindow   5   	   X TXceed.Wpf.Toolkit, Version=2.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ,vmclr-namespace:FinanceAnalysis     5   	   ;	behaviors%clr-namespace:FinanceAnalysis.Helpers     5   	      ApplicationTitle  � Title#  [  5   	   $	��350��63   $	��525��6@     EftalDBViewModel � DataContext# �  5   	    � 	Resources 5
      '  !FinanceAnalysis.CurrencyConverter  CurrencyConverter&   System.Windows.Controls.DataGrid  PriceHistoryGrid   AutoGenerateColumns �� Path �� SelectedItem   Columns0  *System.Windows.Controls.DataGridTextColumn,  &System.Windows.Controls.DataGridColumn   Header   
IsReadOnly1  +System.Windows.Controls.DataGridBoundColumn	   Binding4  .System.Windows.Controls.DataGridTemplateColumn
   CellTemplate   CellEditingTemplate(  "System.Windows.Controls.DatePicker   SelectedDate �� Mode 
 Ticker   CanUserAddRows �� 	Converter �� StringFormat � ContextMenu m� Command&   FinanceAnalysis.EftalDBViewModel  DailyStockPriceTemplate �� DataType��%�  &	       &	     &	 �   7  &	 7    &	 J      5   
   6     5   
    .  ��6H   �� $ dStockPriceColl� 6u   �� $ SelectedTicker� 5        5      $ Price ID��6%    . 	 67   �� $ DailyStockPriceID�6b     5      $ Ticker��6%    . 	 65   �� $ TICKER�6U     5      $ 
TickerName��6%    . 	 69   �� $ 
tickerName�6]     5      $
 Open��6%    . 	 63   �� $
 Open�6Q     5      $
 High��6%    . 	 63   �� $
 High�6Q     5      $	 Low��6%    . 	 62   �� $	 Low�6O     5      $ Close��6%    . 	 64   �� $ Close�6S     5      $ Volume��6%    . 	 65   �� $ Volume�6U     5      $
 Date��6)   
 5      �� 5      .R�5      �� $��4q�6>   ��6(   �� *Date+6>   5       5      �� 5      .R�5         5    !   �� *Date+$ TwoWay=�5!      5#      5&        5)   
    .   .  ��6>   �� $ dTickerColl�$ TwoWay=� 6u   �� $ SelectedTicker� 5*        5+      $ Ticker��6%    . 	 65   �� $ TickerID�6W     5,      $ 
TickerName��6%    . 	 69   �� $ 
TickerName�6]     5-      $ Price��6%    . 	 64   �� $ 	LastPrice�8   6�     5.      $
 Date��6)   
 5/      �� 50      .R�51      �� $��0q�6[   ��6(   �� *Date+$ {0:MM/dd/yy}��6[   52       54      �� 55      .R�56         57   !   �� *Date+$ {0:MM/dd/yy}��$ TwoWay=�58      5:        5;      $ Last Updated��6)   
 5<      �� 5=      .R�5>      �� $��0q�6E   ��6(   �� *LastUpdated+6E   5?       5A      �� 5B      .R�5C         5D   !   �� *Date+$ TwoWay=�5E      5G       5J      �� 5K      .@�5L      m� $��_Add New��6A    6   �� *AddNewCommand+6A   m� 5N      $��_Edit��6?    6   �� *EditCommand+6?   m� 5P      $��_Delete��6   �� 5R      m� 5S      $��_Refresh History��6    69   �� *GetPriceHistoryCommand+5U      5W        5Z   
   6   �� 5\   
   $ DailyStockPrice��67   5^      5`      .��5c      �� -   5        $��TradeScreens��5c      .@�5d   
   �� -   5        $��_TickerScreen��5d      $��_Tickers��6'   .��5e      � -   5        $��
tickerGrid��5e       � ColumnDefinitions 5f      �� 5g      $��* �6'   �� 5h      $��* �6'   .+�5j      �� $��0��6!   $��10q�61   #��[ 6=    6_   �� 6y   �� 5k      $��1��6!   $��10,10,10,10q�62   #��[ 6G    6s   �� 6�   5m      5q      �� 5r   
   $��_Price History��6   .��5s      �  � RowDefinitions 5t      �� 5u      �� 5v      $��* �6$   .+�5x      �� $��0��6   $��10,10,10,10q�6)   .��5y      ��  �� Orientation$ 
Horizontal=�6!    6:   �� .+�5z      �� $��10,10,10,10q�6    $��50��65   $��30��6A   .��6M   Ticker6U   �� 5{      $��10,10,10,10q�6"   $��50��67   $��30��6B   7	   1FinanceAnalysis.Helpers.SelectAllOnFocusBehaviour 	  SelectAllOnFocus . ��6N   �� $ SelectedTicker.TickerName�6~   �� 5|      $��10,10,10,10q�6    $��50��66   $��30��6A   .��6M   Price6T   �� 5}      $��10,10,10,10q�6"   $��50��68   $��30��6C   6Q   �� 5~      $��10,10,10,10q�6!   $��50��66   $��50��6A   ��6M   �� *UpdatePrices+.��6n   Update6v   5      5�      �� 5�      $��2��6!   $��10,10,10,10q�6/   #��[ 6D    6p   �� 6�   5�      5�      �� 5�   
   $��Ticker Detail��6   .��5�      
   FinanceAnalysis.tkrDetail
   6   �� $ SelectedTicker�5�      5�      5�      