   M S B A M L   `   `   `  ����B  >Cinebel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CinebelCinebel  5   	       Cinebel.Acteurs   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Cinebel     5   	     � Title$  Ajouter un Acteur��5   	   $	��500��6#   $	��350��60    � 
ResizeMode$ NoResize=�6<      Acteurss � DataContext# [  6R   .��5	      � .+�5
   
   �� $8��2Sélectionnez les acteurs faisant partie du film :��6   $��Center=�6L   $��0,38,0,0q�6i   $	��Top=�6{   $	��268��6�   �� 5   
    �� SelectionMode$ Single=�6   $��86,94,86,164q�6+   ��6A   �� *TousActeurs+ �� SelectedItem 6f   �� *Id+ �� Mode$ TwoWay=� �� View 5      �� 5      .P�5      �� $
��Nr°��6%    �� DisplayMemberBinding 63   �� *Id_Personne+6b   �� 5      $��Prenom��6%    66   �� *Nom+6^   �� 5      $	��Nom��6%    63   �� *Prenom+6^   5      5      �� 5   
   $��Rôle :��6   $
��Left=�6!   $��
89,339,0,0q�6<   $	��Top=�6P   $��99��6h   �� 5   
   $��Center=�6   $��	0,378,0,0q�6E    �� TextWrapping$
 Wrap=�6X   $	��Top=�6m   $	��178��6�   $��24��6�   ��6/   �� *Role+6�   �� 5   
   $
��Left=�6:   $��
151,23,0,0q�6U   $	��Top=�6i   ��6   �� *EnregistrementMessage+6i   �� 5   
   $��Button��6   $��Center=�6=   $��	0,421,0,0q�6Z   $	��Top=�6m   $	��154��6�   $��29��6�   ��6"   �� *Actors+6�   5      5      