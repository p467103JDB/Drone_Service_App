   M S B A M L   `   `   `  ���� T  PDrone Service Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Drone_Service_ApplicationDrone_Service_Application  *    $Drone_Service_Application.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:Drone_Service_Application     ] YXceed.Wpf.Toolkit.NET5, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$  
MainWindow��$	��640��$
��1024��.��� .+��� $��Service Priority��$��32,319,832,208q�.���� .+�	� -    	�Name$ RegularButton��$��Regular�� 	� 	GroupName$ RadioButtons��$��16(�	� -   $ ExpressButton��$��Express��$ RadioButtons��$��16(��� -    ��Name$ 
AddNewItem��$��	Add Drone��$
��Left=�$��
32,437,0,0q�$	��Top=�$	��160��$��32��%  Xceed.Wpf.Toolkit.IntegerUpDown  -     Name$ 
ServiceTag���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value 100$��32,395,832,180q�   Minimum 100   Maximum 900�  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 10,  &Xceed.Wpf.Toolkit.Primitives.InputBase	   Text$		 100��
   AutoSelectBehavior$
 OnFocus=�   DefaultValue 100%   DisplayDefaultValueOnEmptyText$
 True��   AllowTextInput$ False�� J� IsManipulationEnabled$
 True���� -    ��Name$ ServiceDroneReg��$��288,62,0,358q�4  .System.Windows.Automation.AutomationProperties   IsColumnHeader$
 True��$
��Left=�$	��312�� �� View �� .P��� $��Client Name�� �� DisplayMemberBinding �� *
ClientName+�� $��Drone Model�� �� *
DroneModel+�� $��Service Tag�� �� *
ServiceTag+�� $��Service Fee�� �� *
ServiceFee+�� -    ��Name$ StatusStrip��$��	0,560,0,0q�.@��� .���� -    ��Name$ StatusMessage�� �� 
IsReadOnly$
 True��
������ 
������ 
���   �$��Center=��� �� -   $ ServiceDroneExp��$��288,312,0,108q�$
 True��$
��Left=�$	��312�� �� .P��� $��Client Name�� �� *
ClientName+�� $��Drone Model�� �� *
DroneModel+�� $��Service Tag�� �� *
ServiceTag+�� $��Service Fee�� �� *
ServiceFee+�� -	   $ 
ClientName��$
��Left=�$��	32,64,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��160��$��16(��� -
   $ ClientNameWatermark��$��Enter Client Name��$
��Left=�$��	32,64,0,0q�$
 Wrap=�$	��Top=�$	��160��$��16(� J� Opacity$	 0.5Q��� -   $ 
DroneModel��$
��Left=�$��	32,96,0,0q�$
 Wrap=�$	��Top=�$	��160��$��16(��� -   $ DroneModelWatermark��$��Enter Drone Model��$
��Left=�$��	32,96,0,0q�$
 Wrap=�$	��Top=�$	��160��$��16(�$	 0.5Q��� -   $ ServiceDescription��$
��Left=�$��
32,128,0,0q�$
 Wrap=�$	��Top=�$	��160��$	��160��$��16(��� -   $! ServiceDescriptionWatermark��$��Service Description��$
��Left=�$��
32,128,0,0q�$
 Wrap=�$	��Top=�$	��160��$	��160��$��16(�$	 0.5Q��� -   $ 
ServiceFee��$
��Left=�$��
32,298,0,0q�$
 Wrap=�$	��Top=�$	��160��$��16(�$��23.28���� -   $ ServiceFeeWatermark��$��Enter Service Fee��$
��Left=�$��
32,298,0,0q�$
 Wrap=�$	��Top=�$	��160��$��16(�$	 0.5Q� J� RenderTransformOrigin$ 0.528,1.338&��� -   $ DequeueRegular��$
��Left=�$��364,243,0,0q�$	��Top=�$	��160��$��32��$��	Completed���� -    ��Name$ ListBoxFinished��$��680,64,28,106q����� *FinishedList+���� .R���  �� Orientation$ 
Horizontal=�.+��� $	��148������ *
ClientName+�� $	��148������ *
ServiceFee+�� -   $ DequeueExpress��$��	Completed��$
��Left=�$��364,492,0,0q�$	��Top=�$	��160��$��32���� -   $ ClearFields��$��Clear��$
��Left=�$��
32,474,0,0q�$	��Top=�$	��160��$��32�� � ForceCursor$
 True�� � 
InputScope$ CurrencyAmount���� $��Drone Details:��$
��Left=�$��	32,24,0,0q�$	��Top=�$	��160��$��20(�$
��Bold"����	#FF3D847F�� $��Finished List��$
��Left=�$��
772,24,0,0q�$	��Top=�$	��128��$��20(�$
��Bold"����	#FF3D847F�� $��Regular Service Queue��$
��Left=�$��
332,25,0,0q�$	��Top=�$	��224��$��20(�$
��Bold"����	#FF3D847F�� $��Express Service Queue��$
��Left=�$��332,275,0,0q�$	��Top=�$	��224��$��20(�$
��Bold"����	#FF3D847F