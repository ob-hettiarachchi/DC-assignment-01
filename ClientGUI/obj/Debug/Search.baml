   M S B A M L   `   `   `  ????D  @ClientGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ClientGUI	ClientGUI  5   	       ClientGUI.Search   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ClientGUI     5   	     ? Title$  Search??5   	   $	??450??6   $	??800??6%   .??5	      ? ???	#FFFFD21B.+?5
   
   ?? $??Search Services??6   $
??Left=?6*   $??
280,26,0,0q?6E   $	??Top=?6Y   $??58??6q   $	??229??6}   $??24(?6?   $??Center=?6?   $??Century Gothic)?6?   $
??Bold"?6?   
???   ?6?   ?? 5   
   -   5         ??Name$ 	btnSearch??5      $??Search??6$   $
??Left=?65   $??
625,95,0,0q?6P   $	??Top=?6d   $	??110??6|   $??20(?6?   $??34??6?   $??Century Gothic)?6?   $
??Bold"?6?   
???????
???   ?6?   ?? 5   
   -   5         ??Name$ search??5      $
??Left=?6"   $??34??6=   $??	43,95,0,0q?6I    ?? TextWrapping$
 Wrap=?6\   $	??Top=?6p   $	??554??6?   $??20(?6?   ? 5   
   -   5         ?Name$ ProgressBar1??5      $
??Left=?6,   $??10??6G   $??344,140,0,0q?6S   $	??Top=?6h   $	??100??6?   ?? 5   
   -   5        $ btntest??5      $??All Services??6"   $
??Left=?69   $??330,380,0,0q?6T   $	??Top=?6i   $	??128??6?   $??20(?6?   $??34??6?   $??Century Gothic)?6?   $
??Bold"?6?   
???????
???   ?6?   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ serviceInfo??5   /      AutoGenerateColumns .  $
??Left=?6D   $	??196??6_   $??
26,163,0,0q?6l   $	??Top=?6?   $	??736??6?      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name??6%   	   
IsReadOnly	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 180 6^   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   ?? *Name+6l     5      $ Description??6%   	 . $	
 230 6l    6L   ?? *Description+6z     5      $ API EndPoint??6%   	 . $	
 100 6m    6M   ?? *APIEndPoint+6{     5      $ No. of Operands??6%   	 . $	
 100 6q    6P   ?? *NoOfOperands+6     5      $ OperandType??6%   	 . $	
 125 6l    6L   ?? *OperandType+6z   5      5      5      