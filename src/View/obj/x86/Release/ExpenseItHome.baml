   M S B A M L   `   `   `  ���� >  :App, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null^:clr-namespace:FSharpWpfMvvmTemplate.ViewModel;assembly=AppFSharpWpfMvvmTemplate.ViewModel  \9clr-namespace:FSharpWpfMvvmTemplate.Behavior;assembly=AppFSharpWpfMvvmTemplate.Behavior   View(   "WpfMvvmTemplate.View.ExpenseItHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     P	ViewModel:clr-namespace:FSharpWpfMvvmTemplate.ViewModel;assembly=App     NBehavior9clr-namespace:FSharpWpfMvvmTemplate.Behavior;assembly=App       � DataContext  <   6FSharpWpfMvvmTemplate.ViewModel.ExpenseItHomeViewModel   � 	Resources  �� Source�� $ ApplicationResources.xaml?�%    .��� $��
10,0,10,10q�$��Stretch=� F   @FSharpWpfMvvmTemplate.Behavior.StringExistsToVisibilityConverter   StringExistsToVisibility  nameItemTemplate �� Path  typeItemTemplate  amountItemTemplate��%�   &	        &	      &	 &     &	 N       �� .R��� ���� $
 Name��� .R��� ���� $ ExpenseType��� .R��� ���� $ ExpenseAmount�����  �� ImageSource$ watermark.png�� � ColumnDefinitions �� ��  � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0��$��2��  headerTextStyle#��[ .��View Expense Report� $��10q�$��0��$��1��$	��Top=� �� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��1��  listHeaderStyle#��[ ._���   listHeaderTextStyle#��[ .��Names�� -   $��peopleListBox��$��2��#��[ $ �� IsSynchronizedWithCurrentItem$
 TrueY����� $ ExpenseReports� �� SelectedItem �� $ SelectedExpenseReport�	 �� Mode$	 TwoWay=�� $��10q�$��1��$��1��$	��Top=�  �� *SelectedExpenseReport+ �� $	��57* ��� $
��125* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��2��$��0��
 �� Orientation$
 
Horizontal=�.+���   
labelStyle#��[ .��Name:�� #��[ ���� $
 Name��� $��0��$��2��$��1��$
 
Horizontal=�.+��� #��[ .��Department:�� #��[ ���� $ 
Department�� $��0��$��2��$��2��$	��Top=�$
��Left=�.+�&   System.Windows.Controls.DataGrid    columnHeaderStyle   ColumnHeaderStyle# [    AutoGenerateColumns .     RowHeaderWidth$ 0Q�$��
0,0,-139,0q����� $ ExpenseLineItems�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ExpenseType��   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� $ ExpenseType�  $ Amount�� .  �� $ ExpenseAmount��� $��3��$��Center=�$��0,10,0,0q�$��12(�$
��Bold"�$��2������ *LastApprovalDisplayMessage+y��� $  LastApprovalDisplayMessage� �� 	Converter# [  