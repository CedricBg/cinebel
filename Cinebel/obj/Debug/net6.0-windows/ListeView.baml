   M S B A M L   `   `   `  ����B  >Cinebel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CinebelCinebel  5   	       Cinebel.ListeView   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Cinebel     5   	     � Title$  	ListeView��5   	   $	��450��6   $	��800��6(    � 
ResizeMode$ NoResize=�64    
  Listee � DataContext# [  6J   ��5	      �� 5
   
    �� ImageSource$ /Images/Cine.jpg��6    j� Stretch$
 Fill=�64   .��5      � .+�5   
   �� $@��:Sélectionnez un film à ajouter à la liste dans la liste��6   $	��Top=�6T    J� RenderTransformOrigin$ 0.289,0.502&�6l   $��32��6�   $��728,33,85,0q�6�   �� 5   
    �� SelectionMode$ Single=�6   $ 0.5,0.5&�6�   $��425,70,72,102q�6�   ��6,   �� *	TousGenre+ �� SelectedItem 6N   �� *filmSelecter+ �� Mode$ TwoWay=�	 �� View	 5      �� 5      .P�5      �� $
��Nr°��6%   
 �� Width$
 30��62    �� DisplayMemberBinding 6=   �� *Id+6d   �� 5      $��Titre��6%   $	
 100��64    6@   �� *Titre+6j   �� 5      $��Genre��6%   $	
 100��64    6@   �� *
StrGenre+6m   5      5      �� 5   
   $!��Ajouter un film à la liste��6   $��Center=�6R   $��	0,381,0,0q�6o   $	��Top=�6�   $	��252��6�   ��66   �� *	AddFilm+6�   5      5      