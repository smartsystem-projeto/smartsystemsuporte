   M S B A M L   `   `   `  ����H  DDashboard.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Dashboard.WPFDashboard.WPF  5   	       Dashboard.WPF.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Dashboard.WPF     5   	     � Title$  	Dashboard��5   	   $	��768��6   $
��1024��6(    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ CanMinimize=�5
   	    � 	Resources 5         col �� 
TargetType �� Property �� Value  col-margin-bottom  col-no-padding  nav  navItem �� Triggers P� Property	 P� Value  	textBlock  	formLabel  formTextBox  formComboBox 	 
btnPrimary 
 	btnDanger  dataGrid&   System.Windows.Controls.DataGrid��%�
  &	        &	 t     &	 �     &	 6    &	 �    &	     &	 �    &	 C    &	 �    &		 �    &	
     &	 �	    �� 5   
   " ��6   .�5      ��  � ��$ 15q�6'   �� 5       �@��Padding$ 15q�6(   5      �� 5   
   " ��6*   .�5      ��  � ��$ 0 0 0 10q�6'   �� 5       �@��Padding$ 15q�6(   5      �� 5   
   " ��6'   .�5      ��  � ��$ 15q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$
 0 15q�6'   5      �� 5   
   " ��6    .�5      ��  � ��$ 40��6'   �� 5       � ��$
 10 0q�6(   �� 5       � �� �#3336+   �� 5       � ��$
 Left=�6;   �� 5        � ��$ 0q�60   �� 5!       � �� �#fff6+   �� 5"       � ��$ 15(�6)    5#      P� 5$       �@J�IsMouseOver	 . . �5%      ��  � �� �#5a5a5a63   5&      5(      �� 5)   
   " ��6"   .�5*      ��  � �� �#3336+   �� 5+       � ��$ 15(�6)   �� 5,       � ��$
 Wrap=�6-   5-      �� 5.   
   " ��6"   .�5/      ��  � ��$ -5 0 0 0q�6'   �� 50       � �� �#3336+   �� 51       � ��$ 15(�6)   52      �� 53   
   " ��6$   .�54      ��  � ��$ Center=�69   �� 55       � ��$ 30��6'   �� 56       � ��$ 0 0 0 10q�6'   �� 57       � ��$ 	10 0 10 0q�6(   �� 58       � �� �#3333336+   �� 59       � ��$ 15(�6)   �� 5:       �@��TextWrapping$
 Wrap=�6-   5;      �� 5<   
   " ��6%   .�5=      ��  � ��$ Center=�69   �� 5>       � ��$ 30��6'   �� 5?       � ��$ 0 0 0 10q�6'   �� 5@       � ��$ 	10 0 10 0q�6(   �� 5A       � �� �#3333336+   �� 5B       � ��$ 15(�6)   5C      �� 5D   
   " ��6#   .�5E      ��  � ��$
 auto��6&   �� 5F       � ��$ 30��6'   �� 5G       � ��$ 	30 0 30 0q�6(   �� 5H       � �� �#263a7f6+   �� 5I       � �� �#ffffff6+   �� 5J       � ��$ 15(�6)    5K      P� 5L       �@J�IsMouseOver	 . . �5M      ��  � �� �#33333363   5N      5P      �� 5Q   
   " ��6"   .�5R      ��  � ��$
 auto��6&   �� 5S       � ��$ 30��6'   �� 5T       � ��$ 	30 0 30 0q�6(   �� 5U       � �� �#dc35456+   �� 5V       � �� �#ffffff6+   �� 5W       � ��$ 15(�6)    5X      P� 5Y       �@J�IsMouseOver	 . . �5Z      ��  � �� �#33333363   5[      5]      �� 5^   
   "  6!   .�5_      ��  � �� �#ffffff6+   �� 5`        �@ AlternatingRowBackground �#f1f2f369   5a      5b      .��5f      � 
 � ColumnDefinitions
 5g   
   �� 5h      $��3* �6   �� 5i      $	��10* �6    � RowDefinitions 5l   
   �� 5m      .+�5p   
   � $��0��6   $��0��5q      ���#333.+�5t      �� #��[ 6   .+�5u      �� -   5         ��Name$ btnChamados��5u      #��[ 6.   $��Chamados��6O   6b   �� 5v      -   5        $ btnProdutos��5v      #��[ 6.   $��Produtos��6O   6b   �� 5w      -   5        $ btnTiposchamado��5w      #��[ 62   $��Tipos de chamado��6S   6n   �� 5x      -   5        $ btnAssuntosChamado��5x      #��[ 65   $��Assuntos de chamado��6V   6t   �� 5y      -   5        $ btnClientes��5y      #��[ 6.   $��Clientes��6O   6b   �� 5z      -   5        $ btnFuncionarios��5z      #��[ 62   $��Funcionarios��6S   6j   �� 5{      -   5        $ btnUsuarios��5{      #��[ 6.   $��	Usuários��6O   6b   5|      5}      � 5�   
   -   5         �Name$ produtos��5�      $��0��6!   $��1��6.   ���#f1f2f3$y�	Collapsed=�5�   "   
 5�      �� 5�       5�      �� 5�      $
��auto �6    �� 5�      .+�5�      �� $��0��6   $��0��6"   #��[  5�      ���#fff._�5�      �� .+�5�      � $��0 0 0 10q�6   
 5�      �� 5�      �� 5�      .+�5�      ��  �� Orientation$ 
Horizontal=�6%   $��0��6>   .+�5�      �� #��[ 6$   $��Produto��6G   $��18(�6Y   $
��Bold"�6g   �� 5�      -	   5         ��Name$ txbIdProduto��5�   &   #��[ 6<    �� 
IsReadOnly . $��0q�6s   $	��100��6~   ���#ccc6�   5�      �� 5�      $��1��6%   $ 
Horizontal=�65   $��Right=�6N   .+�5�      �� -
   5        $ btnAdicionarProduto��5�   %   #��[	 6B   $
��Novo��6f   6u   5�      5�      �� 5�      #��[ 6   $
��Nome��6?   �� 5�      -   5        $ txbNomeProduto��5�      #��[ 66   �� 5�      #��[ 6   $��Descrição��6?   �� 5�      -   5        $ txbDescricaoProduto��5�      #��[ 6;   �� 5�      -   5        $ btnSalvarProduto��5�      #��[	 67   $��Salvar��6[   $��Right=�6l   6�   5�      5�      �� 5�      $��1��6   $��0��6"   #��[  5�      ���#fff._�5�      � 
 5�      �� 5�       5�      �� 5�      �� 5�      $
��auto �6(   .+�5�        -   5          Name$ dtgProdutos��5�      $��0��5�      $��0��6,   #��[ 5�   .      AutoGenerateColumns .     
IsReadOnly .    Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 20 6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *	ProdutoId+  5�      $
 Nome��61    6?   �� *Nome+  5�      $ Descrição��61    6D   �� *	Descricao+  5�      $ Cadastro��61    6C   �� *DataCadastro+  5�      $ Última atualização��61    6M   �� *DataAtualizacao+5�      �� 5�      $��1��6!   $��0��6.   $��0 10 0 0q�6>   $ 
Horizontal=�6P   $��Right=�6i   .+�5�      �� -   5        $ btnEditarProduto��5�   !   #��[	 6;   $��Editar��6_   6p   �� 5�      -   5        $ btnRemoverProduto��5�   !   #��[
 6<   $��Remover��6_   $��10 0 0 0q�6q   6�   5�      5�      5�      5�      � 5�   
   -   5        $ tiposChamado��5�      $��0��6%   $��1��62   ���#f1f2f3$y�	Collapsed=�5�   "   
 5�      �� 5�       5�      �� 5�      $
��auto �6    �� 5�      .+�5�      �� $��0��6   $��0��6"   #��[  5�      ���#fff._�5�      �� .+�5�      � $��0 0 0 10q�6   
 5�      �� 5�      �� 5�      .+�5�      �� $ 
Horizontal=�6%   $��0��6>   .+�5�      �� #��[ 6$   $��Tipo de chamado��6G   $��18(�6a   $
��Bold"�6o   �� 5�      -   5        $ txbIdTipoChamado��5�   &   #��[ 6@    . $��0q�6w   $	��100��6�   ���#ccc6�   5�      �� 5�      $��1��6%   $ 
Horizontal=�65   $��Right=�6N   .+�5�      �� -   5        $ btnAdicionarTipoChamado��5�   %   #��[	 6F   $
��Novo��6j   6y   5�      5�      �� 5�      #��[ 6   $��Descrição��6?   �� 5�      -   5        $ txbDescricaoTipoChamado��5�      #��[ 6?   �� 5�      #��[ 6   $��
Prioridade��6?   �� 5�      -   5        $ txbPrioridadeTipoChamado��5�      #��[ 6@   6e   �� 5�      -   5        #��[	 5�      $��Salvar��6A   $��Right=�6R   6n   5�      5�      �� 5�      $��1��6   $��0��6"   #��[  5�      ���#fff._�5�      � 
 5�      �� 5�       5      �� 5     �� 5     $
��auto �6(   .+�5       -   5        $ dtgTiposChamado��5     $��0��5     $��0��6,   #��[ 5  2    .   .  5	       5
     $ Id��61   $ 20 6=    6H   �� *TipoChamadoId+  5     $ Descrição��61    6D   �� *	Descricao+  5     $ 
Prioridade��61    6E   �� *
Prioridade+  5     $ Cadastro��61    6C   �� *DataCadastro+  5     $ Última atualização��61    6M   �� *DataAtualizacao+5     �� 5     $��1��6!   $��0��6.   $��0 10 0 0q�6>   $ 
Horizontal=�6P   $��Right=�6i   .+�5     �� -   5        $ btnEditarTipoChamado��5  !   #��[	 6?   $��Editar��6c   6t   �� 5     -   5        $ btnRemoverTipoChamado��5  !   #��[
 6@   $��Remover��6c   $��10 0 0 0q�6u   6�   5     5     5     5     � 5  
   -   5        $ assuntosChamado��5     $��0��6(   $��1��65   ���#f1f2f3$y�	Collapsed=�5  "   
 5     �� 5      5"     �� 5#     $
��auto �6    �� 5$     .+�5'     �� $��0��6   $��0��6"   #��[  5(     ���#fff._�5*     �� .+�5,     � $��0 0 0 10q�6   
 5-     �� 5.     �� 5/     .+�52     �� $ 
Horizontal=�6%   $��0��6>   .+�53     �� #��[ 6$   $��Assunto de chamado��6G   $��18(�6d   $
��Bold"�6r   �� 54     -   5        $ txbIdAssuntoChamado��54  &   #��[ 6C    . $��0q�6z   $	��100��6�   ���#ccc6�   55     �� 56     $��1��6%   $ 
Horizontal=�65   $��Right=�6N   .+�57     �� -   5        $  btnAdicionarAssuntoChamado��57  %   #��[	 6I   $
��Novo��6m   6|   58     59     �� 5;     #��[ 6   $��Descrição��6?   �� 5<     -   5        $  txbDescricaoAssuntoChamado��5<     #��[ 6B   �� 5>     #��[ 6   $��Tipo de chamado��6?   �� 5?     -   5         ��Name$# cbTipoChamadoIdAssuntoChamado��5?     #��[ 6F    �� DisplayMemberPath$ 	Descricao��6l    �� SelectedValuePath$ TipoChamadoId��6�   �� 5A     -   5        $ btnSalvarAssuntoChamado��5A     #��[	 6>   $��Salvar��6b   $��Right=�6s   6�   5B     5C     �� 5E     $��1��6   $��0��6"   #��[  5F     ���#fff._�5H     � 
 5I     �� 5J      5M     �� 5N     �� 5O     $
��auto �6(   .+�5R       -    5        $ dtgAssuntosChamado��5S     $��0��5R     $��0��6,   #��[ 5S  5    .   .  5V       5W     $ Id��61   $ 20 6=    6H   �� *AssuntoChamadoId+  5X     $ Descrição��61    6D   �� *	Descricao+  5Y     $ Tipo de chamado��61    6J   ��  �� Path$ TipoChamado.Descricao�  5Z     $ Cadastro��61    6C   �� *DataCadastro+  5[     $ Última atualização��61    6M   �� *DataAtualizacao+5]     �� 5^     $��1��6!   $��0��6.   $��0 10 0 0q�6>   $ 
Horizontal=�6P   $��Right=�6i   .+�5_     �� -!   5        $ btnEditarAssuntoChamado��5_  !   #��[	 6B   $��Editar��6f   6w   �� 5`     -"   5        $ btnRemoverAssuntoChamado��5`  !   #��[
 6C   $��Remover��6f   $��10 0 0 0q�6x   6�   5a     5b     5c     5d     � 5h  
   -#   5        $ clientes��5h     $��0��6!   $��1��6.   ���#f1f2f3$y�	Collapsed=�5i  "   
 5k     �� 5l      5o     �� 5p     $
��auto �6    �� 5q     .+�5t     �� $��0��6   $��0��6"   #��[  5u     ���#fff._�5w     �� .+�5y     � $��0 0 0 10q�6   
 5z     �� 5{     �� 5|     .+�5     �� $ 
Horizontal=�6%   $��0��6>   .+�5�     �� #��[ 6$   $��Cliente��6G   $��18(�6Y   $
��Bold"�6g   �� 5�     -$   5        $ txbIdCliente��5�  &   #��[ 6<    . $��0q�6s   $	��100��6~   ���#ccc6�   5�     �� 5�     $��1��6%   $ 
Horizontal=�65   $��Right=�6N   .+�5�     �� -%   5        $ btnAdicionarCliente��5�  %   #��[	 6B   $
��Novo��6f   6u   5�     5�     �� 5�     $ 
Horizontal=�6!   .+�5�     �� #��[ 6    $��Razão social��6C   �� 5�     -&   5        $ txbRazaoSocialCliente��5�  "   #��[ 6A   $	��629��6f   5�     �� 5�     $ 
Horizontal=�6!   .+�5�     �� #��[ 6    $��Nome fantasia��6C   �� 5�     -'   5        $ txbNomeFantasiaCliente��5�  "   #��[ 6B   $	��614��6g   5�     �� 5�     $ 
Horizontal=�6!   .+�5�     �� #��[ 6    $
��CNPJ��6C   �� 5�     -(   5        $ txbCNPJCliente��5�  "   #��[ 6:   $	��319��6_    �� 	MaxLength$ 14��6k   6z   �� 5�     #��[ 6    $	��CPF��6C   $��5 0 0 0q�6Q   �� 5�     -)   5        $ txbCPFCliente��5�  "   #��[ 69   $	��318��6^   $ 11��6j   6y   5�     �� 5�     $ 
Horizontal=�6!   .+�5�     �� #��[ 6    $��E-mail��6C   �� 5�     -*   5        $ txbEmailCliente��5�  "   #��[ 6;   $	��408��6`   �� 5�     #��[ 6    $��Tempo de resposta��6C   $��5 0 0 0q�6_   �� 5�     -+   5        $ txbTempoRespostaCliente��5�  "   #��[ 6C   $	��120��6h   5�     �� 5�     $ 
Horizontal=�6!   .+�5�     �� #��[ 6    $��
Telefone 1��6C   �� 5�     -,   5        $ txbTelefoneId1Cliente��5�  "   $y�	Collapsed=�6A   �� 5�     --   5        $ txbTelefone1DDDCliente��5�  "   #��[ 6B   $��50��6g   $ 2��6r   6�   �� 5�     -.   5        $ txbTelefone1NumeroCliente��5�  "   #��[ 6E   $	��230��6j   $ 9��6v   6�   �� 5�     #��[ 6    $��
Telefone 2��6C   $��5 0 0 0q�6X   �� 5�     -/   5        $ txbTelefoneId2Cliente��5�  "   $y�	Collapsed=�6A   �� 5�     -0   5        $ txbTelefone2DDDCliente��5�  "   #��[ 6B   $��50��6g   $ 2��6r   6�   �� 5�     -1   5        $ txbTelefone2NumeroCliente��5�  "   #��[ 6E   $	��230��6j   $ 9��6v   6�   5�     �� 5�     -2   5        $ txbEnderecoIdCliente��5�     $y�	Collapsed=�6<   �� 5�     $ 
Horizontal=�6!   .+�5�     �� #��[ 6    $	��Rua��6C   �� 5�     -3   5        $ txbRuaCliente��5�  "   #��[ 69   $	��553��6^   �� 5�     #��[ 6    $	��Nº��6C   $��5 0 0 0q�6P   �� 5�     -4   5        $ txbNumeroCliente��5�  "   #��[ 6<   $	��100��6a   6m   5�     �� 5�     $ 
Horizontal=�6!   .+�5�     �� #��[ 6    $��Bairro��6C   �� 5�     -5   5        $ txbBairroCliente��5�  "   #��[ 6<   $	��239��6a   �� 5�     #��[ 6    $��Cidade��6C   $��5 0 0 0q�6T   �� 5�     -6   5        $ txbCidadeCliente��5�  "   #��[ 6<   $	��239��6a   �� 5�     #��[ 6    $��UF��6C   $��5 0 0 0q�6P   �� 5�     -7   5        $ txbUFCliente��5�  "   #��[ 68   $	��100��6]   $ 2��6i   5�     �� 5�     -8   5        $ btnSalvarCliente��5�     #��[	 67   $��Salvar��6[   $��Right=�6l   6�   5�     5�     �� 5�     $��1��6   $��0��6"   #��[  5�     ���#fff._�5�     � 
 5�     �� 5�      5�     �� 5�     �� 5�     $
��auto �6(   .+�5�       -9   5        $ dtgClientes��5�     $��0��5�     $��0��6,   #��[ 5�  .    .   .  5�       5�     $ Id��61   $ 20 6=    6H   �� *	ClienteId+  5�     $ Razão social��61    6G   �� *RazaoSocial+  5�     $ Nome fantasia��61    6H   �� *NomeFantasia+  5�     $ E-mail��61    6A   �� *Email+  5�     $ Cadastro��61    6C   �� *DataCadastro+  5�     $ Última atualização��61    6M   �� *DataAtualizacao+5�     �� 5�     $��1��6!   $��0��6.   $��0 10 0 0q�6>   $ 
Horizontal=�6P   $��Right=�6i   .+�5�     �� -:   5        $ btnEditarCliente��5�  !   #��[	 6;   $��Editar��6_   6p   �� 5�     -;   5        $ btnRemoverCliente��5�  !   #��[
 6<   $��Remover��6_   $��10 0 0 0q�6q   6�   5�     5�     5�     5�     � 5�  
   -<   5        $ funcionarios��5�     $��0��6%   $��1��62   ���#f1f2f3$y�	Collapsed=�5�  "   
 5�     �� 5�      5�     �� 5�     $
��auto �6    �� 5�     .+�5�     �� $��0��6   $��0��6"   #��[  5�     ���#fff._�5�     �� .+�5�     � $��0 0 0 10q�6   
 5�     �� 5�     �� 5�     .+�5     �� $ 
Horizontal=�6%   $��0��6>   .+�5     �� #��[ 6$   $��Funcionário��6G   $��18(�6]   $
��Bold"�6k   �� 5     -=   5        $ txbIdFuncionario��5  &   #��[ 6@    . $��0q�6w   $	��100��6�   ���#ccc6�   5     �� 5     $��1��6%   $ 
Horizontal=�65   $��Right=�6N   .+�5     �� ->   5        $ btnAdicionarFuncionario��5  %   #��[	 6F   $
��Novo��6j   6y   5     5     �� 5
     $ 
Horizontal=�6!   .+�5     �� #��[ 6    $��Nome de tratamento��6C   �� 5     -?   5        $" txbNomeTratamentoFuncionario��5  "   #��[ 6H   $	��571��6m   5     �� 5     $ 
Horizontal=�6!   .+�5     �� #��[ 6    $	��CPF��6C   $��5 0 0 0q�6Q   �� 5     -@   5        $ txbCPFFuncionario��5  "   #��[ 6=   $	��221��6b   $ 11��6n   6}   5     �� 5     $ 
Horizontal=�6!   .+�5     �� #��[ 6    $��
Telefone 1��6C   �� 5     -A   5        $ txbTelefoneId1Funcionario��5  "   $y�	Collapsed=�6E   �� 5     -B   5        $  txbTelefone1DDDFuncionario��5  "   #��[ 6F   $��50��6k   $ 2��6v   6�   �� 5     -C   5        $# txbTelefone1NumeroFuncionario��5  "   #��[ 6I   $	��230��6n   $ 9��6z   6�   �� 5     #��[ 6    $��
Telefone 2��6C   $��5 0 0 0q�6X   �� 5     -D   5        $ txbTelefoneId2Funcionario��5  "   $y�	Collapsed=�6E   �� 5     -E   5        $  txbTelefone2DDDFuncionario��5  "   #��[ 6F   $��50��6k   $ 2��6v   6�   �� 5      -F   5        $# txbTelefone2NumeroFuncionario��5   "   #��[ 6I   $	��230��6n   $ 9��6z   6�   5!     �� 5#     -G   5        $ txbEnderecoIdFuncionario��5#     $y�	Collapsed=�6@   �� 5$     $ 
Horizontal=�6!   .+�5%     �� #��[ 6    $	��Rua��6C   �� 5&     -H   5        $ txbRuaFuncionario��5&  "   #��[ 6=   $	��553��6b   �� 5(     #��[ 6    $	��Nº��6C   $��5 0 0 0q�6P   �� 5)     -I   5        $ txbNumeroFuncionario��5)  "   #��[ 6@   $	��100��6e   6q   5*     �� 5,     $ 
Horizontal=�6!   .+�5-     �� #��[ 6    $��Bairro��6C   �� 5.     -J   5        $ txbBairroFuncionario��5.  "   #��[ 6@   $	��239��6e   �� 50     #��[ 6    $��Cidade��6C   $��5 0 0 0q�6T   �� 51     -K   5        $ txbCidadeFuncionario��51  "   #��[ 6@   $	��239��6e   �� 53     #��[ 6    $��UF��6C   $��5 0 0 0q�6P   �� 54     -L   5        $ txbUFFuncionario��54  "   #��[ 6<   $	��100��6a   $ 2��6n   55     �� 57     -M   5        $ btnSalvarFuncionario��57     #��[	 6;   $��Salvar��6_   $��Right=�6p   6�   58     59     �� 5;     $��1��6   $��0��6"   #��[  5<     ���#fff._�5>     � 
 5?     �� 5@      5C     �� 5D     �� 5E     $
��auto �6(   .+�5H       -N   5        $ dtgFuncionarios��5I     $��0��5H     $��0��6,   #��[ 5I  2    .   .  5L       5M     $ Id��61   $ 20 6=    6H   �� *FuncionarioId+  5N     $ Nome de tratamento��61    6M   �� *NomeTratamento+  5O     $	 CPF��61    6>   �� *CPF+  5P     $ Cadastro��61    6C   �� *DataCadastro+  5Q     $ Última atualização��61    6M   �� *DataAtualizacao+5S     �� 5T     $��1��6!   $��0��6.   $��0 10 0 0q�6>   $ 
Horizontal=�6P   $��Right=�6i   .+�5U     �� -O   5        $ btnEditarFuncionario��5U  !   #��[	 6?   $��Editar��6c   6t   �� 5V     -P   5        $ btnRemoverFuncionario��5V  !   #��[
 6@   $��Remover��6c   $��10 0 0 0q�6u   6�   5W     5X     5Y     5Z     � 5^  
   -Q   5        $ usuarios��5^     $��0��6!   $��1��6.   ���#f1f2f3$y�	Collapsed=�5_  "   
 5a     �� 5b      5e     �� 5f     $
��auto �6    �� 5g     .+�5j     �� $��0��6   $��0��6"   #��[  5k     ���#fff._�5m     �� .+�5n     � $��0 0 0 10q�6   
 5o     �� 5p     �� 5q     .+�5t     �� $ 
Horizontal=�6%   $��0��6>   .+�5u     �� #��[ 6$   $��Usuário��6G   $��18(�6Y   $
��Bold"�6g   �� 5v     -R   5        $ txbIdUsuario��5v  &   #��[ 6<    . $��0q�6s   $	��100��6~   ���#ccc6�   5w     �� 5x     $��1��6%   $ 
Horizontal=�65   $��Right=�6N   .+�5y     �� -S   5        $ btnAdicionarUsuario��5y  %   #��[	 6B   $
��Novo��6f   6u   5z     5{     �� 5}     $ 
Horizontal=�6!   .+�5~     �� #��[ 6    $��Tipo de usuário��6C   �� 5     -T   5        $ cbTipoUsuario��5  #   #��[ 6:   $	��607��6`   .@�5�     �� $�� ��6+   �� 5�     $��Cliente��6+   �� 5�     $��Funcionário��6+   5�     5�     �� 5�     -U   5         ��Name$ clientesUsuario��5�  !   $ 
Horizontal=�6:   .+�5�     �� #��[ 6    $��Cliente��6C   �� 5�     -V   5        $ cbClienteIdUsuario��5�  #   #��[ 6?   $ RazaoSocial��6e   $ 	ClienteId��6�   $	��670��6�   5�     �� 5�     -W   5        $ funcionariosUsuario��5�  !   $ 
Horizontal=�6>   .+�5�     �� #��[ 6    $��Funcionário��6C   �� 5�     -X   5        $ cbFuncionarioIdUsuario��5�  #   #��[ 6C   $ NomeTratamento��6i   $ FuncionarioId��6�   $	��670��6�   5�     �� 5�     $ 
Horizontal=�6!   .+�5�     �� #��[ 6    $
��Nome��6C   �� 5�     -Y   5        $ txbNomeUsuario��5�  "   #��[ 6:   $	��669��6_   5�     �� 5�     $ 
Horizontal=�6!   .+�5�     �� #��[ 6    $��E-mail��6C   �� 5�     -Z   5        $ txbEmailUsuario��5�  "   #��[ 6;   $	��668��6`   5�     �� 5�     $ 
Horizontal=�6!   .+�5�     �� #��[ 6    $��Login��6C   �� 5�     -[   5        $ txbLoginUsuario��5�  "   #��[ 6;   $	��278��6`   �� 5�     #��[ 6    $��Nível de acesso��6C   $��5 0 0 0q�6]   �� 5�     -\   5        $ cbNivelUsuario��5�  #   #��[ 6;   $	��278��6a   .@�5�     �� $�� ��6+   �� 5�     $��Cliente��6+   �� 5�     $��Técnico��6+   �� 5�     $��Coordenador��6+   5�     5�     �� 5�     $ 
Horizontal=�6!   .+�5�     �� #��[ 6    $��Senha��6C   �� 5�     -]   5        $ txbSenhaUsuario��5�  "   #��[ 6;   $	��273��6`   �� 5�     #��[ 6    $��Confirmar senha��6C   $��5 0 0 0q�6]   �� 5�     -^   5        $ txbConfirmarSenhaUsuario��5�  "   #��[ 6D   $	��273��6i   5�     �� 5�     -_   5        $ btnSalvarUsuario��5�     #��[	 67   $��Salvar��6[   $��Right=�6l   6�   5�     5�     �� 5�     $��1��6   $��0��6"   #��[  5�     ���#fff._�5�     � 
 5�     �� 5�      5�     �� 5�     �� 5�     $
��auto �6(   .+�5�       -`   5        $ dtgUsuarios��5�     $��0��5�     $��0��6,   #��[ 5�  .    .   .  5�       5�     $ Id��61   $ 20 6=    6H   �� *	UsuarioId+  5�     $ Login��61    6@   �� *Login+  5�     $
 Nome��61    6?   �� *Nome+  5�     $ E-mail��61    6A   �� *Email+  5�     $ Nível de acesso��61    6J   �� *Nivel+  5�     $ Cadastro��61    6C   �� *DataCadastro+  5�     $ Última atualização��61    6M   �� *DataAtualizacao+5�     �� 5�     $��1��6!   $��0��6.   $��0 10 0 0q�6>   $ 
Horizontal=�6P   $��Right=�6i   .+�5�     �� -a   5        $ btnEditarUsuario��5�  !   #��[	 6;   $��Editar��6_   6p   �� 5�     -b   5        $ btnRemoverUsuario��5�  !   #��[
 6<   $��Remover��6_   $��10 0 0 0q�6q   6�   5�     5�     5�     5�     � 5�  
   -c   5        $ chamados��5�     $��0��6!   $��1��6.   ���#f1f2f3$y�	Collapsed=�5�  "   .+�5�     �� #��[  6   ���#fff._�5�     � 
 5�     �� 5�      5�     �� 5�     $
��auto �6(   �� 5�     �� 5�     $
��auto �6(   .+�5�     �� $��0��6!   $��0��6.   $��0 0 0 10q�6>   $ 
Horizontal=�6P   .+�5�     �� -d   5        $" btnFiltrarSemTecnicoChamados��5�  !   #��[	 6G   $��Sem técnico responsável��6k   6�   5�       5�     -e   5        $ dtgChamados��5�     $��1��5�     $��0��6,   #��[ 5�  .    .   .  5�       5�     $	 Nº��61   $ 20 6=    6H   �� *	ChamadoId+  5�     $ Abertura��61    6C   �� *DataAbertura+  5�     $
 Tipo��61    6?   �� $ TipoChamado.Descricao�  5�     $ Assunto��61    6B   �� $ AssuntoChamado.Descricao�  5�     $ Último posicionamento��61    6P   �� *UltimoPosicionamento+  5�     $ Status��61    6A   �� *Status+  5�     $ Responsável��61    6F   �� *Responsavel+5�     �� 5�     $��2��6!   $��0��6.   $��0 10 0 0q�6>   $ 
Horizontal=�6P   $��Right=�6i   .+�5�     �� -f   5        $ btnVerChamado��5�  !   #��[	 68   $��Ver chamado��6\   6r   5�     5      5     5     � 5  
   -g   5        $ chamado��5     $��0��6    $��1��6-   ���#f1f2f3$y�	Collapsed=�5  "   
 5     �� 5	     �� 5
      5     �� 5     $
��auto �6    .+�5     � $��0��6   $��0��6    
 5     �� 5      5     �� 5     $
��auto �6$   .+�5     �� $��0��6   $��0��6&   #��[  5     ���#fff._�5     � 
 5     �� 5      5"     �� 5#     $
��auto �6,   �� 5$     .+�5'     � 
 5(     �� 5)  "   �� 5*  "   .+�5-     �� $��0 0 0 15q�6)   .+�5.  "   �� #��[ 6,   $��Cliente:��5/  ,   $��12(�6<   $
��Bold"�6J   $��0 0 10 0q�6\   �� 50  "   -h   5         ��Name$ txbClienteChamado��50  ,   #��[ 6G   $��12(�51  ,   �� 52  "   -i   5        $ lblFuncionarioIdChamado��52  ,   #��[ 6M   $��	Técnico:��53  ,   $��12(�6<   $
��Bold"�6J   $��0 0 10 0q�6\   �� 54  "   -j   5        $ cbFuncionarioIdChamado��54  +   #��[ 6K   $ NomeTratamento��55  +   $ FuncionarioId��6N   56  +   57     �� 59     $��0��6)   $��1��66   $��Right=�5:  !   $��0 0 0 10q�5;  !   .+�5=  "   �� -k   5        $ cbStatusChamado��5=  +   #��[ 6D   .@�5?  &   �� $��Recebido��63   �� 5@  &   $��Em andamento��63   �� 5A  &   $��Aguardando posicionamento��63   �� 5B  &   $��	Encerrado��63   5C  #   �� 5E  "   $ 
Horizontal=�6-   .+�5F  &   �� #��[ 60   $��Número:��5G  0   $��12(�6?   $
��Bold"�6M   $��0 0 10 0q�6_   �� 5H  &   -l   5        $ txbIdChamado��5H  0   #��[ 6F   $��12(�6i   5I  #   �� 5J  "   $ 
Horizontal=�6-   .+�5K  &   �� #��[ 60   $��	Abertura:��6S   $��12(�6d   $
��Bold"�6r   $��0 0 10 0q�6�   �� 5L  &   -m   5        $ txbAberturaChamado��5L  0   #��[ 6L   $��12(�6o   5M  #   5N     5O     �� 5P     $��1��6%   $��0��62   .+�5Q     �� #��[ 6(   $��Produto��6K   $
��Bold"�6Z   �� 5R     -n   5        $ txbProdutoChamado��5R  (   #��[ 6C   $��Número��6f   $��0 0 0 10q�6t   �� 5T     #��[ 6(   $
��Tipo��6K   $
��Bold"�6W   �� 5U     -o   5        $ txbTipoChamado��5U  (   #��[ 6@   $��Número��6c   $��0 0 0 10q�6q   �� 5W     #��[ 6(   $��Assunto��6K   $
��Bold"�6Z   �� 5X     -p   5        $ txbAssuntoChamado��5X  (   #��[ 6C   $��Número��6f   $��0 0 0 10q�6t   �� 5Z     #��[ 6(   $��Descrição��6K   $
��Bold"�6\   �� 5[     -q   5        $ txbDescricaoChamado��5[  (   #��[ 6E   $��Número��6h   $��0 0 0 10q�6v   5\     5]     5^     5_     �� 5a     -r   5         ��Name$ posicionamentosChamado��5a     $��0��65   $��1��6B   $	��530��5b     #��[ 5c     ._�5d     � 
 5e     �� 5f      5i     �� 5j     $
��auto �6(   �� 5k     .+�5n     � $��0��6   $��0��6(   $��0 0 0 10q�5o     
 5p     �� 5q     �� 5r     .+�5u     �� $��0��6%   $ 
Horizontal=�65   .+�5v     �� #��[ 6(   $��Posicionamentos��5w  $   $
��Bold"�6;   $��0 0 10 0q�6M   5x     �� 5y     $��1��6%   $ 
Horizontal=�65   $��Right=�5z  )   .+�5{     �� -s   5        $  btnAdicionarPosicionamento��5{  %   #��[	 6I   $��	Adicionar��5|  %   $��25��69   5}  %   5~     5     �� 5�     $��1��6$   $��0��61   $��0 0 10 0q�5�     $��Visible=�5�     $��Hidden=�6C   .��5�     �� -t   5        $  listPosicionamentosChamado��5�  %   5�     5�     5�     5�     5�     5�     5�     