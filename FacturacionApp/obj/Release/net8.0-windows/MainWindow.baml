   M S B A M L   `   `   `  ���� I  EFacturacionApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:FacturacionAppFacturacionApp      FacturacionApp.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:FacturacionApp       � Title$  
MainWindow��$	��800��$
��1200��$
��1200��.���  � RowDefinitions �� $	��150���� .+�� $��0�����#F5F5F5 � ColumnDefinitions �� �� �� $
��auto �.+��  �� $
��auto ��� .+��  �� $
��auto ���  �� �� �� .+��� 
���   �$��15(�$��Nombre del Facturante:��$��10,10,10,10q��� -   $��nombreFacturanteTxt��$��1��
���   �$��15(�$��	0,10,0,10q�$	��350��$
��Left=��� $��1��
���   �$��15(�$��Domicilio del Facturante:��$��10,10,10,10q��� -   $��domicilioFacturanteTxt��$��1��$��1��
���   �$��15(�$��	0,10,0,10q�$	��350��$
��Left=��� $��2��
���   �$��15(�$��CIF del Facturante:��$��10,10,10,10q��� -   $��cifFacturanteTxt��$��2��$��1��
���   �$��15(�$��	0,10,0,10q�$	��350��$
��Left=�� $��1�� �� $
��auto ���  �� �� �� $��50 �.+��� 
���   �$��15(�$��Nombre del Facturado:��$��10,10,10,10q��� -   $��nombreFacturadoTxt��$��1��
���   �$��15(�$��	0,10,0,10q�$	��350��$
��Left=��� $��1��
���   �$��15(�$��Domicilio del Facturado:��$��10,10,10,10q��� -   $��domicilioFacturadoTxt��$��1��$��1��
���   �$��15(�$��	0,10,0,10q�$	��350��$
��Left=��� $��2��
���   �$��15(�$��CIF del Facturado:��$��10,10,10,10q��� -   $��cifFacturadoTxt��$��2��$��1��
���   �$��15(�$��	0,10,0,10q�$	��350��$
��Left=�� $��2��$��0,0,10,0q� �� $
��auto ���  �� �� �� .+��� $��1��
���   �$��15(�$��Retencion (%):��$��10,10,10,10q��� -   $��retencionTxt��$��1��$��1��
���   �$��15(�$��	0,10,0,10q�$	��100��$
��Left=�$��15��� $��1�� �� $	��220��$	��220���� .+�� $��0�����#F5F5F5 �� $��0* ��� $��5* ��� $��15 ��� $	��70* �.+��� ���#4CAF50$��1��.���  �� $	��50* ��� $	��50* �.+��� $��0���� -    ��Name$ 
ButtonText��$��1��$��
Generacion�����#FFFFFF$��18(�����  �� 
TargetType" ��.R���  ��Name$ ButtonBorder��#��z�� �� Padding$ 10q�._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver	 P� Value$
	 True��. ��� 
 �� 
TargetName$
 ButtonBorder�� �� Property � �� �� Value �#6BAF92P�  � ��$
	 True��. ��� $
 ButtonBorder�� � �� �#388E3C�� ���#F5F5F5$��2��$��2��$��2��� $��3�� �� $��20 ��� .+��� -	    ��Name$ ListViewPlaylists��$��1��
������ $��Disabled=�$��10,0,0,0q�$��0q����� *	playlists+���� .R��� $��20(�
����������� *name+ � 	Resources  �� 
TargetType �� RadiusX �� RadiusY ]� Thumb J� Opacity � Cursor �� CornerRadius��%0  '��       �� " ��.���  � ��$ 12����  � ��
 ���� ��  � �� �� " ��.R�� $��12��.+��� ���#1E1E1E$��12��$ 6��$ 6��]� $��
PART_Track��$
��true�� n� ���#0078D7$��12��$
��auto��$	 0.8Q�$
 Hand������ " n�.R��� ���#0078D7$ 6��� -
   $��Content��$��1�����#E0E0E0.+��  �� $	��.9* ��� $	��.1* �.+��� -   $��CurrentScreen���� -   $��1��$	��150��$��	0,10,0,10q����#4CAF50$��Generar��$��20(�
����������� " ��.R��� $ ButtonBorder��#��z��$ 10q�$ 2��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
	 True��. ��� $
 ButtonBorder�� � �� �#6BAF92P�  � ��$
	 True��. ��� $
 ButtonBorder�� � �� �#388E3C