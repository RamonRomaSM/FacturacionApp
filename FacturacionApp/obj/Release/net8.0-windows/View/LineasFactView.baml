   M S B A M L   `   `   `  ���� I  EFacturacionApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FacturacionApp.ViewFacturacionApp.View  (    "FacturacionApp.View.GenerarControl   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:FacturacionApp.View     .���   � RowDefinitions  �� .+��� $
��Auto=�.���� 
������ .+��� -    ��Name$ lineasListView��
������ $��	10,0,10,0q�$��0q����� *lineas+���� .R�� $��0,20,0,0q�.+��� 
������ $��3q����#BDBDBD �� CornerRadius$ 3��._��   �� �� �� �� �� .+�� $��	10,5,10,0q� � ColumnDefinitions �� $	��30* ��� $	��70* �.+��� 
���   �$��15(�$��Cliente:���� 
���   �$��1��$��15(����� *	cliente+� $��	10,5,10,0q�$��1�� �� $	��30* ��� $	��70* �.+��� 
���   �$��15(�$��	Concepto:���� 
���   �$��1��$��15(����� *
concepto+� $��	10,5,10,0q�$��2�� �� $	��30* ��� $	��70* �.+��� 
���   �$��15(�$��Importe Bruto:���� 
���   �$��1��$��15(����� *importeBruto+� $��	10,5,10,0q�$��3�� �� $	��30* ��� $	��70* �.+��� 
���   �$��15(�$��Importe Neto:���� 
���   �$��1��$��15(����� *importeNeto+� $��	10,5,10,0q�$��4�� �� $	��30* ��� $	��70* �.+��� 
���   �$��15(�$
��IVA:���� 
���   �$��1��$��15(����� *iva+�� -   $��30��$��30�� � Cursor$
 Hand��$��
0,-15,25,0q�$
��Bold"�$
��🗑��$	��Top=�$��Right=�����  �� 
TargetType" ��.���  �� Property � �� �� Value
 �������  � ��
 �  ����  � ��$ 0q���  � ��$
 10,5q���  � �� ��  �� 
TargetType" ��.R��� 	 ��Name$	 border��#��z��$ 8��
 J� SnapsToDevicePixels$

 True��._��� $��Center=�$��Center=�$
��True�� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  �� 
TargetName$ border�� � �� �#660000P�  � ��$
 True��. ��� $ border�� � �� �#4D0000P�  � {�$ False��. ��� $ border�� � ��
 �������  � �� �#DDDDDD���� " ��.���  � ��
 ���� ��  � ��
 ���� ��  � |�$ False����  � �� �� " ��.R��� 
������ ._���  �� Triggers P�  �@J�IsMouseOver$
 True��. ���  � ��
 ���� ��  � ��
 ���� P�  �@��
IsSelected$
 True��. ���  � ��
 ���� ��  � ��
 ���� � .+��� 
������ $��3q����#BDBDBD$��	10,0,10,0q�$ 3��._�� $	��120�����#E0E0E0  �� $
��.25* ��� $
��.75* �.+��  �� �� �� .+�� $��0��$��	10,5,10,0q� �� �� .+��� 
���   �$��15(�$��Cliente:���� -   $��
clienteTxt��$��1��
���   �$��15(�� $��1��$��	10,5,10,0q� �� �� .+��� 
���   �$��15(�$��Importe Bruto(€):���� -   $��
importeTxt��$��1��
���   �$��15(�� $��2��$��	10,5,10,0q� �� �� .+��� 
���   �$��15(�$��IVA (%):���� -   $��ivaTxt��$��1��
���   �$��15(�$��21���� $��1��$��	10,5,10,5q� �� Orientation$ 
Horizontal=�.+��� $��1��
���   �$��15(�$��Descripción:��$��0,0,20,0q��� -   $��descTxt��$��1��$��1��
���   �$��15(� �� AcceptsReturn$
 True�� �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�$	��400���� -   $��Añadir��$	��top=�$	��100��$��40�����#BDBDBD���#4E6A5A���#BDBDBD$��2q�$��14(�$	��Top=�$
 Hand������ " ��.R��� $	 ButtonBorder��#��z�� �� Padding$ 10q�$ 15��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� $ ButtonBorder�� � �� �#8AA897P�  � ��$
 True��. ��� $ ButtonBorder�� � �� �#5C8A72