   M S B A M L   `   `   `  ????  YouTube Demo    FinalCoverDemo.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      X TXceed.Wpf.Toolkit, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        ? Title$  
MainWindow??5      $
??1200??5	      $	??700??5
       ? 
ResizeMode$ NoResize=?5       +? FocusedElement 5      ??  ?? ElementName$ canvas1??.??5      ?  ? RowDefinitions 5   
   ?? 5      $??35 ?6   ?? 5      $	??310 ?6   ?? 5      $??* ?6   ?? 5      $??55 ?6   .+?5   
   ?? $??0??5      $
??Left=?5      $??CaseGaurd Image Editor??5      ?? 5   
   -   5         ??Name$ FileNameLabel??5      $??0??5      $??Center=?5      $?? ??5      $??16(?5       ?? 5"   
   -   5         ??Name$ FileDropStackPanel??5#      $??1??5$      $??	40,0,40,5q?5%       J? 	AllowDrop . 
???????.+?5)      ?? -   5         ??Name$ UploadButton??5*      $	??100??5+      $??35??5,      $??0,5,0,0q?5-      
????ح?$??Browse For a File??50      ?? 51      $??Center=?6   $??Or Drop Files Here??61   #  Xceed.Wpf.Toolkit.ColorCanvas  52      -   5        	  Name$	 colorPicker??53      $	??200??54      $	??247??55      $
??Left=?56      
   SelectedColor$	
 RedX?57      $y?Visible=?58      59      ?? 5;   
   -   5         ??Name$ border1??5<      $??2??5=      
???  ??$??3q?5?      ._?5A      ?? -   5         ??Name$ canvas1??5B      
????ح?|?. .+?5H      ?? -   5         ??Name$ ImagePreviewer??5I      $??Uniform=?5L      ??5J      ??  ?? Path$ ActualWidth?$ canvas1????5K      ?? $ ActualHeight?$ canvas1??5L      5M      5O      ?? 5R   
   $??3??6   $??	40,0,40,5q?6"   .+?5T      ?? -   5        $ 
SaveButton??5U      $	??100??5V      $??0,5,0,0q?5W      $??Center=?5X      
????ح?$??SAVE SESSION??5[      ?? 5]      -	   5        $ ResetButton??5^      $	??100??5_      $??0,5,0,0q?5`      $??Center=?5a      
????ح?$??RESET??5d      5e      5i      5j      