using Dashboard.WPF.Controllers;
using Dashboard.WPF.Services;
using Dashboard.WPF.ViewModels;
using Dashboard.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Dashboard.WPF
{
    // <summary>
    // Interação lógica para MainWindow.xam
    // </summary>
    public partial class MainWindow : Window
    {
        private ProdutosController _produtosController;
        private ProdutoViewModel _produtoViewModel;
        private TiposChamadoController _tiposChamadoController;
        private TipoChamadoViewModel _tipoChamadoViewModel;
        private AssuntosChamadoController _assuntosChamadoController;
        private AssuntoChamadoViewModel _assuntoChamadoViewModel;
        private ClientesController _clientesController;
        private ClienteViewModel _clienteViewModel;
        private FuncionariosController _funcionariosController;
        private UsuariosController _usuariosController;
        private UsuarioViewModel _usuarioViewModel;
        private ChamadosController _chamadosController;

        public MainWindow()
        {
            this.Hide();
            Entrar entrar = new Entrar();
            entrar.ShowDialog();

            if (UsuarioAutal.Login == null)
            {
                this.Close();
                return;
            }

            this.Show();
            _produtosController = new ProdutosController();
            _tiposChamadoController = new TiposChamadoController();
            _assuntosChamadoController = new AssuntosChamadoController();
            _clientesController = new ClientesController();
            _funcionariosController = new FuncionariosController();
            _usuariosController = new UsuariosController();
            _chamadosController = new ChamadosController();
            InitializeComponent();
            UpdateMenuItemsVisibility();
            btnChamados.Background = new SolidColorBrush(Color.FromRgb(90, 90, 90));
            UpdateIndexChamados();
            chamados.Visibility = Visibility.Visible;
            this.WindowState = WindowState.Maximized;
        }

        private void UpdateMenuItemsVisibility()
        {
            if (UsuarioAutal.Nivel.Equals("Coordenador"))
            {
                btnProdutos.Visibility = Visibility.Visible;
                btnTiposchamado.Visibility = Visibility.Visible;
                btnAssuntosChamado.Visibility = Visibility.Visible;
                btnClientes.Visibility = Visibility.Visible;
                btnFuncionarios.Visibility = Visibility.Visible;
                btnUsuarios.Visibility = Visibility.Visible;
            }
            else
            {
                btnProdutos.Visibility = Visibility.Collapsed;
                btnTiposchamado.Visibility = Visibility.Collapsed;
                btnAssuntosChamado.Visibility = Visibility.Collapsed;
                btnClientes.Visibility = Visibility.Collapsed;
                btnFuncionarios.Visibility = Visibility.Collapsed;
                btnUsuarios.Visibility = Visibility.Collapsed;
            }
        }

        private void ResetMenuItemsBackground()
        {
            btnProdutos.Background = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            btnTiposchamado.Background = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            btnAssuntosChamado.Background = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            btnClientes.Background = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            btnFuncionarios.Background = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            btnUsuarios.Background = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            btnChamados.Background = new SolidColorBrush(Color.FromRgb(51, 51, 51));
        }

        private void ResetContentItemsVisibility()
        {
            produtos.Visibility = Visibility.Collapsed;
            tiposChamado.Visibility = Visibility.Collapsed;
            assuntosChamado.Visibility = Visibility.Collapsed;
            clientes.Visibility = Visibility.Collapsed;
            funcionarios.Visibility = Visibility.Collapsed;
            usuarios.Visibility = Visibility.Collapsed;
            chamados.Visibility = Visibility.Collapsed;
            chamado.Visibility = Visibility.Collapsed;
        }

        #region Produtos
        private void btnProdutos_Click(object sender, RoutedEventArgs e)
        {
            ResetMenuItemsBackground();
            btnProdutos.Background = new SolidColorBrush(Color.FromRgb(90, 90, 90));
            UpdateIndexProdutos(null);
            ResetContentItemsVisibility();
            produtos.Visibility = Visibility.Visible;
        }

        private void btnAdicionarProduto_Click(object sender, RoutedEventArgs e)
        {
            LimparIndexProdutos();
        }

        private void btnSalvarProduto_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> produtoDictionary = new Dictionary<string, string>();
            _produtoViewModel = new ProdutoViewModel();

            produtoDictionary["ProdutoId"] = txbIdProduto.Text;
            produtoDictionary["Nome"] = txbNomeProduto.Text;
            produtoDictionary["Descricao"] = txbDescricaoProduto.Text;
            _produtoViewModel = _produtosController.Validar(produtoDictionary);

            if (_produtosController.IsSuccessStatus)
            {
                if (!String.IsNullOrEmpty(txbIdProduto.Text))
                    _produtoViewModel.ProdutoId = Convert.ToInt32(txbIdProduto.Text);

                _produtoViewModel.Nome = txbNomeProduto.Text;
                _produtoViewModel.Descricao = txbDescricaoProduto.Text;

                if ((_produtoViewModel.ProdutoId == 0))
                    _produtoViewModel = _produtosController.Adicionar(_produtoViewModel);
                else
                    _produtoViewModel = _produtosController.Atualizar(_produtoViewModel);

                if (_produtosController.IsSuccessStatus)
                {
                    UpdateIndexProdutos(_produtoViewModel.ProdutoId);
                    MessageBox.Show(_produtosController.Message);
                }
                else
                {
                    MessageBox.Show(_produtosController.Message);
                }
            }
            else
            {
                MessageBox.Show(_produtosController.Message);
            }
        }

        private void btnEditarProduto_Click(object sender, RoutedEventArgs e)
        {
            if (dtgProdutos.SelectedItem != null)
            {
                _produtoViewModel = (ProdutoViewModel)dtgProdutos.SelectedItem;
                UpdateIndexProdutos(_produtoViewModel.ProdutoId);
            }
            else
            {
                MessageBox.Show("Selecione um Produto");
            }
        }

        private void btnRemoverProduto_Click(object sender, RoutedEventArgs e)
        {
            _produtoViewModel = new ProdutoViewModel();

            if (dtgProdutos.SelectedItem != null)
            {
                _produtoViewModel = (ProdutoViewModel)dtgProdutos.SelectedItem;
                _produtosController.Remover(_produtoViewModel.ProdutoId);

                if (_produtosController.IsSuccessStatus)
                {
                    UpdateIndexProdutos(null);
                    MessageBox.Show(_produtosController.Message);
                }
                else
                {
                    MessageBox.Show(_produtosController.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione um Produto");
            }
        }

        public void UpdateIndexProdutos(int? id)
        {
            _produtoViewModel = new ProdutoViewModel();

            LimparIndexProdutos();

            if (id != null)
            {
                _produtoViewModel = _produtosController.Index(id);

                if (_produtosController.IsSuccessStatus)
                {
                    txbIdProduto.Text = _produtoViewModel.ProdutoId.ToString();
                    txbNomeProduto.Text = _produtoViewModel.Nome;
                    txbDescricaoProduto.Text = _produtoViewModel.Descricao;
                }
            }
            else
            {
                _produtoViewModel = _produtosController.Index(null);
            }

            if (_produtosController.IsSuccessStatus)
            {
                dtgProdutos.ItemsSource = _produtoViewModel.ProdutosViewModel;
            }
            else
            {
                MessageBox.Show(_produtosController.Message);
            }
        }

        private void LimparIndexProdutos()
        {
            txbIdProduto.Text = String.Empty;
            txbNomeProduto.Text = String.Empty;
            txbDescricaoProduto.Text = String.Empty;
        }
        #endregion

        #region TiposChamado
        private void btnTiposchamado_Click(object sender, RoutedEventArgs e)
        {
            ResetMenuItemsBackground();
            btnTiposchamado.Background = new SolidColorBrush(Color.FromRgb(90, 90, 90));
            UpdateIndexTiposChamado(null);
            ResetContentItemsVisibility();
            tiposChamado.Visibility = Visibility.Visible;
        }

        private void btnAdicionarTipoChamado_Click(object sender, RoutedEventArgs e)
        {
            LimparIndexTiposChamado();
        }

        private void btnSalvarTipoChamado_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> tipoChamadoDictionary = new Dictionary<string, string>();
            _tipoChamadoViewModel = new TipoChamadoViewModel();

            tipoChamadoDictionary["TipoChamadoId"] = txbIdTipoChamado.Text;
            tipoChamadoDictionary["Descricao"] = txbDescricaoTipoChamado.Text;
            tipoChamadoDictionary["Prioridade"] = txbPrioridadeTipoChamado.Text;
            _tipoChamadoViewModel = _tiposChamadoController.Validar(tipoChamadoDictionary);

            if (_tiposChamadoController.IsSuccessStatus)
            {
                if ((_tipoChamadoViewModel.TipoChamadoId == 0))
                    _tipoChamadoViewModel = _tiposChamadoController.Adicionar(_tipoChamadoViewModel);
                else
                    _tipoChamadoViewModel = _tiposChamadoController.Atualizar(_tipoChamadoViewModel);

                if (_tiposChamadoController.IsSuccessStatus)
                {
                    UpdateIndexTiposChamado(_tipoChamadoViewModel.TipoChamadoId);
                    MessageBox.Show(_tiposChamadoController.Message);
                }
                else
                {
                    MessageBox.Show(_tiposChamadoController.Message);
                }
            }
            else
            {
                MessageBox.Show(_tiposChamadoController.Message);
            }
        }

        private void btnEditarTipoChamado_Click(object sender, RoutedEventArgs e)
        {
            if (dtgTiposChamado.SelectedItem != null)
            {
                _tipoChamadoViewModel = (TipoChamadoViewModel)dtgTiposChamado.SelectedItem;
                UpdateIndexTiposChamado(_tipoChamadoViewModel.TipoChamadoId);
            }
            else
            {
                MessageBox.Show("Selecione um tipo de chamado.");
            }
        }

        private void btnRemoverTipoChamado_Click(object sender, RoutedEventArgs e)
        {
            _tipoChamadoViewModel = new TipoChamadoViewModel();

            if (dtgTiposChamado.SelectedItem != null)
            {
                _tipoChamadoViewModel = (TipoChamadoViewModel)dtgTiposChamado.SelectedItem;
                _tiposChamadoController.Remover(_tipoChamadoViewModel.TipoChamadoId);

                if (_tiposChamadoController.IsSuccessStatus)
                {
                    UpdateIndexTiposChamado(null);
                    MessageBox.Show(_tiposChamadoController.Message);
                }
                else
                {
                    MessageBox.Show(_tiposChamadoController.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione um tipo de chamado");
            }
        }

        public void UpdateIndexTiposChamado(int? id)
        {
            _tipoChamadoViewModel = new TipoChamadoViewModel();

            LimparIndexTiposChamado();

            if (id != null)
            {
                _tipoChamadoViewModel = _tiposChamadoController.Index(id);

                if (_tiposChamadoController.IsSuccessStatus)
                {
                    txbIdTipoChamado.Text = _tipoChamadoViewModel.TipoChamadoId.ToString();
                    txbDescricaoTipoChamado.Text = _tipoChamadoViewModel.Descricao;
                    txbPrioridadeTipoChamado.Text = _tipoChamadoViewModel.Prioridade.ToString();
                }
            }
            else
            {
                _tipoChamadoViewModel = _tiposChamadoController.Index(null);
            }

            if (_tiposChamadoController.IsSuccessStatus)
            {
                dtgTiposChamado.ItemsSource = _tipoChamadoViewModel.TiposChamadoViewModel;
            }
            else
            {
                MessageBox.Show(_tiposChamadoController.Message);
            }
        }

        private void LimparIndexTiposChamado()
        {
            txbIdTipoChamado.Text = String.Empty;
            txbDescricaoTipoChamado.Text = String.Empty;
            txbPrioridadeTipoChamado.Text = String.Empty;
        }
        #endregion

        #region AssuntosChamado
        private void btnAssuntosChamado_Click(object sender, RoutedEventArgs e)
        {
            ResetMenuItemsBackground();
            btnAssuntosChamado.Background = new SolidColorBrush(Color.FromRgb(90, 90, 90));
            UpdateIndexAssuntosChamado(null);
            ResetContentItemsVisibility();
            assuntosChamado.Visibility = Visibility.Visible;
        }

        private void btnAdicionarAssuntoChamado_Click(object sender, RoutedEventArgs e)
        {
            LimparIndexAssuntosChamado();
        }

        private void btnSalvarAssuntoChamado_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> assuntoChamadoDictionary = new Dictionary<string, string>();
            _assuntoChamadoViewModel = new AssuntoChamadoViewModel();

            assuntoChamadoDictionary["AssuntoChamadoId"] = txbIdAssuntoChamado.Text;
            assuntoChamadoDictionary["Descricao"] = txbDescricaoAssuntoChamado.Text;
            assuntoChamadoDictionary["TipoChamadoId"] = cbTipoChamadoIdAssuntoChamado.SelectedValue != null
                ? cbTipoChamadoIdAssuntoChamado.SelectedValue.ToString()
                : String.Empty;
            _assuntoChamadoViewModel = _assuntosChamadoController.Validar(assuntoChamadoDictionary);

            if (_assuntosChamadoController.IsSuccessStatus)
            {
                if ((_assuntoChamadoViewModel.AssuntoChamadoId == 0))
                    _assuntoChamadoViewModel = _assuntosChamadoController.Adicionar(_assuntoChamadoViewModel);
                else
                    _assuntoChamadoViewModel = _assuntosChamadoController.Atualizar(_assuntoChamadoViewModel);

                if (_assuntosChamadoController.IsSuccessStatus)
                {
                    UpdateIndexAssuntosChamado(_assuntoChamadoViewModel.AssuntoChamadoId);
                    MessageBox.Show(_assuntosChamadoController.Message);
                }
                else
                {
                    MessageBox.Show(_assuntosChamadoController.Message);
                }
            }
            else
            {
                MessageBox.Show(_assuntosChamadoController.Message);
            }
        }

        private void btnEditarAssuntoChamado_Click(object sender, RoutedEventArgs e)
        {
            if (dtgAssuntosChamado.SelectedItem != null)
            {
                _assuntoChamadoViewModel = (AssuntoChamadoViewModel)dtgAssuntosChamado.SelectedItem;
                UpdateIndexAssuntosChamado(_assuntoChamadoViewModel.AssuntoChamadoId);
            }
            else
            {
                MessageBox.Show("Selecione um assunto de chamado.");
            }
        }

        private void btnRemoverAssuntoChamado_Click(object sender, RoutedEventArgs e)
        {
            _assuntoChamadoViewModel = new AssuntoChamadoViewModel();

            if (dtgAssuntosChamado.SelectedItem != null)
            {
                _assuntoChamadoViewModel = (AssuntoChamadoViewModel)dtgAssuntosChamado.SelectedItem;
                _assuntosChamadoController.Remover(_assuntoChamadoViewModel.AssuntoChamadoId);

                if (_assuntosChamadoController.IsSuccessStatus)
                {
                    UpdateIndexAssuntosChamado(null);
                    MessageBox.Show(_assuntosChamadoController.Message);
                }
                else
                {
                    MessageBox.Show(_assuntosChamadoController.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione um assunto de chamado");
            }
        }

        private void UpdateIndexAssuntosChamado(int? id)
        {
            _assuntoChamadoViewModel = new AssuntoChamadoViewModel();

            if (id != null)
            {
                _assuntoChamadoViewModel = _assuntosChamadoController.Index(id);

                LimparIndexAssuntosChamado();

                if (_assuntosChamadoController.IsSuccessStatus)
                {
                    cbTipoChamadoIdAssuntoChamado.ItemsSource = _assuntoChamadoViewModel.TiposChamadoViewModel;
                    txbIdAssuntoChamado.Text = _assuntoChamadoViewModel.AssuntoChamadoId.ToString();
                    txbDescricaoAssuntoChamado.Text = _assuntoChamadoViewModel.Descricao;
                    cbTipoChamadoIdAssuntoChamado.SelectedValue = _assuntoChamadoViewModel.TipoChamadoId;
                }
            }
            else
            {
                _assuntoChamadoViewModel = _assuntosChamadoController.Index(null);

                if (_assuntosChamadoController.IsSuccessStatus)
                    cbTipoChamadoIdAssuntoChamado.ItemsSource = _assuntoChamadoViewModel.TiposChamadoViewModel;
            }

            if (_assuntosChamadoController.IsSuccessStatus)
            {
                dtgAssuntosChamado.ItemsSource = _assuntoChamadoViewModel.AssuntosChamadoViewModel;
            }
            else
            {
                MessageBox.Show(_assuntosChamadoController.Message);
            }
        }

        private void LimparIndexAssuntosChamado()
        {
            txbIdAssuntoChamado.Text = String.Empty;
            txbDescricaoAssuntoChamado.Text = String.Empty;
        }
        # endregion

        #region Clientes
        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            ResetMenuItemsBackground();
            btnClientes.Background = new SolidColorBrush(Color.FromRgb(90, 90, 90));
            UpdateIndexClientes(null);
            ResetContentItemsVisibility();
            clientes.Visibility = Visibility.Visible;
        }

        private void btnAdicionarCliente_Click(object sender, RoutedEventArgs e)
        {
            LimparIndexClientes();
        }

        private void btnSalvarCliente_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> clienteDictionary = new Dictionary<string, string>();
            _clienteViewModel = new ClienteViewModel();

            clienteDictionary["ClienteId"] = txbIdCliente.Text;
            clienteDictionary["RazaoSocial"] = txbRazaoSocialCliente.Text;
            clienteDictionary["NomeFantasia"] = txbNomeFantasiaCliente.Text;
            clienteDictionary["CNPJ"] = txbCNPJCliente.Text;
            clienteDictionary["CPF"] = txbCPFCliente.Text;
            clienteDictionary["Email"] = txbEmailCliente.Text;
            clienteDictionary["TempoResposta"] = txbTempoRespostaCliente.Text;
            clienteDictionary["EnderecoId"] = txbEnderecoIdCliente.Text;
            clienteDictionary["Rua"] = txbRuaCliente.Text;
            clienteDictionary["Numero"] = txbNumeroCliente.Text;
            clienteDictionary["Bairro"] = txbBairroCliente.Text;
            clienteDictionary["Cidade"] = txbCidadeCliente.Text;
            clienteDictionary["UF"] = txbUFCliente.Text;
            clienteDictionary["Telefone1Id"] = txbTelefoneId1Cliente.Text;
            clienteDictionary["Telefone1DDD"] = txbTelefone1DDDCliente.Text;
            clienteDictionary["Telefone1Numero"] = txbTelefone1NumeroCliente.Text;
            clienteDictionary["Telefone2Id"] = txbTelefoneId2Cliente.Text;
            clienteDictionary["Telefone2DDD"] = txbTelefone2DDDCliente.Text;
            clienteDictionary["Telefone2Numero"] = txbTelefone2NumeroCliente.Text;
            _clienteViewModel = _clientesController.Validar(clienteDictionary);

            if (_clientesController.IsSuccessStatus)
            {
                if ((_clienteViewModel.ClienteId == 0))
                    _clienteViewModel = _clientesController.Adicionar(_clienteViewModel);
                else
                    _clienteViewModel = _clientesController.Atualizar(_clienteViewModel);

                if (_clientesController.IsSuccessStatus)
                {
                    UpdateIndexClientes(_clienteViewModel.ClienteId);
                    MessageBox.Show(_clientesController.Message);
                }
                else
                {
                    MessageBox.Show(_clientesController.Message);
                }
            }
            else
            {
                MessageBox.Show(_clientesController.Message);
            }
        }

        private void btnEditarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (dtgClientes.SelectedItem != null)
            {
                _clienteViewModel = (ClienteViewModel)dtgClientes.SelectedItem;
                UpdateIndexClientes(_clienteViewModel.ClienteId);
            }
            else
            {
                MessageBox.Show("Selecione um cliente.");
            }
        }

        private void btnRemoverCliente_Click(object sender, RoutedEventArgs e)
        {
            _clienteViewModel = new ClienteViewModel();

            if (dtgClientes.SelectedItem != null)
            {
                _clienteViewModel = (ClienteViewModel)dtgClientes.SelectedItem;
                _clientesController.Remover(_clienteViewModel.ClienteId);

                if (_clientesController.IsSuccessStatus)
                {
                    UpdateIndexClientes(null);
                    MessageBox.Show(_clientesController.Message);
                }
                else
                {
                    MessageBox.Show(_clientesController.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente");
            }
        }

        public void UpdateIndexClientes(int? id)
        {
            _clienteViewModel = new ClienteViewModel();

            LimparIndexClientes();

            if (id != null)
            {
                _clienteViewModel = _clientesController.Index(id);

                if (_clientesController.IsSuccessStatus)
                {
                    txbIdCliente.Text = _clienteViewModel.ClienteId.ToString();
                    txbRazaoSocialCliente.Text = _clienteViewModel.RazaoSocial;
                    txbNomeFantasiaCliente.Text = _clienteViewModel.NomeFantasia;
                    txbCNPJCliente.Text = _clienteViewModel.CNPJ;
                    txbCPFCliente.Text = _clienteViewModel.CPF;
                    txbEmailCliente.Text = _clienteViewModel.Email;
                    txbTempoRespostaCliente.Text = _clienteViewModel.TempoResposta.ToString();
                    txbEnderecoIdCliente.Text = _clienteViewModel.Endereco.EnderecoId.ToString();
                    txbRuaCliente.Text = _clienteViewModel.Endereco.Rua;
                    txbNumeroCliente.Text = _clienteViewModel.Endereco.Numero.ToString();
                    txbBairroCliente.Text = _clienteViewModel.Endereco.Bairro;
                    txbCidadeCliente.Text = _clienteViewModel.Endereco.Cidade;
                    txbUFCliente.Text = _clienteViewModel.Endereco.UF;

                    if (_clienteViewModel.Telefones.Count > 0)
                    {
                        txbTelefoneId1Cliente.Text = _clienteViewModel.Telefones[0].TelefoneId.ToString();
                        txbTelefone1DDDCliente.Text = _clienteViewModel.Telefones[0].DDD.ToString();
                        txbTelefone1NumeroCliente.Text = _clienteViewModel.Telefones[0].Numero.ToString();
                    }

                    if (_clienteViewModel.Telefones.Count > 1)
                    {
                        txbTelefoneId2Cliente.Text = _clienteViewModel.Telefones[1].TelefoneId.ToString();
                        txbTelefone2DDDCliente.Text = _clienteViewModel.Telefones[1].DDD.ToString();
                        txbTelefone2NumeroCliente.Text = _clienteViewModel.Telefones[1].Numero.ToString();
                    }
                }
            }
            else
            {
                _clienteViewModel = _clientesController.Index(null);
            }

            if (_clientesController.IsSuccessStatus)
            {
                dtgClientes.ItemsSource = _clienteViewModel.ClientesViewModel;
            }
            else
            {
                MessageBox.Show(_clientesController.Message);
            }
        }
        
        private void LimparIndexClientes()
        {
            txbIdCliente.Text = String.Empty;
            txbRazaoSocialCliente.Text = String.Empty;
            txbNomeFantasiaCliente.Text = String.Empty;
            txbCNPJCliente.Text = String.Empty;
            txbCPFCliente.Text = String.Empty;
            txbEmailCliente.Text = String.Empty;
            txbTempoRespostaCliente.Text = String.Empty;
            txbEnderecoIdCliente.Text = String.Empty;
            txbRuaCliente.Text = String.Empty;
            txbNumeroCliente.Text = String.Empty;
            txbBairroCliente.Text = String.Empty;
            txbCidadeCliente.Text = String.Empty;
            txbUFCliente.Text = String.Empty;
            txbTelefoneId1Cliente.Text = String.Empty;
            txbTelefone1DDDCliente.Text = String.Empty;
            txbTelefone1NumeroCliente.Text = String.Empty;
            txbTelefoneId2Cliente.Text = String.Empty;
            txbTelefone2DDDCliente.Text = String.Empty;
            txbTelefone2NumeroCliente.Text = String.Empty;
        }
        # endregion

        #region Funcionarios
        private void btnFuncionarios_Click(object sender, RoutedEventArgs e)
        {
            ResetMenuItemsBackground();
            btnFuncionarios.Background = new SolidColorBrush(Color.FromRgb(90, 90, 90));
            UpdateIndexFuncionarios(null);
            ResetContentItemsVisibility();
            funcionarios.Visibility = Visibility.Visible;
        }

        private void btnAdicionarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            ClearIndexFuncionarios();
        }

        private void btnSalvarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> funcionarioDictionary = new Dictionary<string, string>();
            FuncionarioViewModel _funcionarioViewModel = new FuncionarioViewModel();

            funcionarioDictionary["FuncionarioId"] = txbIdFuncionario.Text;
            funcionarioDictionary["NomeTratamento"] = txbNomeTratamentoFuncionario.Text;
            funcionarioDictionary["CPF"] = txbCPFFuncionario.Text;
            funcionarioDictionary["EnderecoId"] = txbEnderecoIdFuncionario.Text;
            funcionarioDictionary["Rua"] = txbRuaFuncionario.Text;
            funcionarioDictionary["Numero"] = txbNumeroFuncionario.Text;
            funcionarioDictionary["Bairro"] = txbBairroFuncionario.Text;
            funcionarioDictionary["Cidade"] = txbCidadeFuncionario.Text;
            funcionarioDictionary["UF"] = txbUFFuncionario.Text;
            funcionarioDictionary["Telefone1Id"] = txbTelefoneId1Funcionario.Text;
            funcionarioDictionary["Telefone1DDD"] = txbTelefone1DDDFuncionario.Text;
            funcionarioDictionary["Telefone1Numero"] = txbTelefone1NumeroFuncionario.Text;
            funcionarioDictionary["Telefone2Id"] = txbTelefoneId2Funcionario.Text;
            funcionarioDictionary["Telefone2DDD"] = txbTelefone2DDDFuncionario.Text;
            funcionarioDictionary["Telefone2Numero"] = txbTelefone2NumeroFuncionario.Text;
            _funcionarioViewModel = _funcionariosController.Validar(funcionarioDictionary);

            if (_funcionariosController.IsSuccessStatus)
            {
                if ((_funcionarioViewModel.FuncionarioId == 0))
                    _funcionarioViewModel = _funcionariosController.Adicionar(_funcionarioViewModel);
                else
                    _funcionarioViewModel = _funcionariosController.Atualizar(_funcionarioViewModel);

                if (_funcionariosController.IsSuccessStatus)
                {
                    UpdateIndexFuncionarios(_funcionarioViewModel.FuncionarioId);
                    MessageBox.Show(_funcionariosController.Message);
                }
                else
                {
                    MessageBox.Show(_funcionariosController.Message);
                }
            }
            else
            {
                MessageBox.Show(_funcionariosController.Message);
            }
        }

        private void btnEditarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            if (dtgFuncionarios.SelectedItem != null)
            {
                FuncionarioViewModel _funcionarioViewModel = (FuncionarioViewModel)dtgFuncionarios.SelectedItem;
                UpdateIndexFuncionarios(_funcionarioViewModel.FuncionarioId);
            }
            else
            {
                MessageBox.Show("Selecione um funcionario.");
            }
        }

        private void btnRemoverFuncionario_Click(object sender, RoutedEventArgs e)
        {
            FuncionarioViewModel _funcionarioViewModel = new FuncionarioViewModel();

            if (dtgFuncionarios.SelectedItem != null)
            {
                _funcionarioViewModel = (FuncionarioViewModel)dtgFuncionarios.SelectedItem;
                _funcionariosController.Remover(_funcionarioViewModel.FuncionarioId);

                if (_funcionariosController.IsSuccessStatus)
                {
                    UpdateIndexFuncionarios(null);
                    MessageBox.Show(_funcionariosController.Message);
                }
                else
                {
                    MessageBox.Show(_funcionariosController.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione um funcionario");
            }
        }

        public void UpdateIndexFuncionarios(int? id)
        {
            FuncionarioViewModel _funcionarioViewModel = new FuncionarioViewModel();

            ClearIndexFuncionarios();

            if (id != null)
            {
                _funcionarioViewModel = _funcionariosController.Index(id);

                if (_funcionariosController.IsSuccessStatus)
                {
                    txbIdFuncionario.Text = _funcionarioViewModel.FuncionarioId.ToString();
                    txbNomeTratamentoFuncionario.Text = _funcionarioViewModel.NomeTratamento;
                    txbCPFFuncionario.Text = _funcionarioViewModel.CPF;
                    txbEnderecoIdFuncionario.Text = _funcionarioViewModel.Endereco.EnderecoId.ToString();
                    txbRuaFuncionario.Text = _funcionarioViewModel.Endereco.Rua;
                    txbNumeroFuncionario.Text = _funcionarioViewModel.Endereco.Numero.ToString();
                    txbBairroFuncionario.Text = _funcionarioViewModel.Endereco.Bairro;
                    txbCidadeFuncionario.Text = _funcionarioViewModel.Endereco.Cidade;
                    txbUFFuncionario.Text = _funcionarioViewModel.Endereco.UF;

                    if (_funcionarioViewModel.Telefones.Count > 0)
                    {
                        txbTelefoneId1Funcionario.Text = _funcionarioViewModel.Telefones[0].TelefoneId.ToString();
                        txbTelefone1DDDFuncionario.Text = _funcionarioViewModel.Telefones[0].DDD.ToString();
                        txbTelefone1NumeroFuncionario.Text = _funcionarioViewModel.Telefones[0].Numero.ToString();
                    }

                    if (_funcionarioViewModel.Telefones.Count > 1)
                    {
                        txbTelefoneId2Funcionario.Text = _funcionarioViewModel.Telefones[1].TelefoneId.ToString();
                        txbTelefone2DDDFuncionario.Text = _funcionarioViewModel.Telefones[1].DDD.ToString();
                        txbTelefone2NumeroFuncionario.Text = _funcionarioViewModel.Telefones[1].Numero.ToString();
                    }
                }
            }
            else
            {
                _funcionarioViewModel = _funcionariosController.Index(null);
            }

            if (_funcionariosController.IsSuccessStatus)
            {
                dtgFuncionarios.ItemsSource = _funcionarioViewModel.FuncionariosViewModel;
            }
            else
            {
                MessageBox.Show(_funcionariosController.Message);
            }
        }

        private void ClearIndexFuncionarios()
        {
            txbIdFuncionario.Text = String.Empty;
            txbNomeTratamentoFuncionario.Text = String.Empty;
            txbCPFFuncionario.Text = String.Empty;
            txbEnderecoIdFuncionario.Text = String.Empty;
            txbRuaFuncionario.Text = String.Empty;
            txbNumeroFuncionario.Text = String.Empty;
            txbBairroFuncionario.Text = String.Empty;
            txbCidadeFuncionario.Text = String.Empty;
            txbUFFuncionario.Text = String.Empty;
            txbTelefoneId1Funcionario.Text = String.Empty;
            txbTelefone1DDDFuncionario.Text = String.Empty;
            txbTelefone1NumeroFuncionario.Text = String.Empty;
            txbTelefoneId2Funcionario.Text = String.Empty;
            txbTelefone2DDDFuncionario.Text = String.Empty;
            txbTelefone2NumeroFuncionario.Text = String.Empty;
        }
        # endregion

        #region Usuarios
        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            ResetMenuItemsBackground();
            btnUsuarios.Background = new SolidColorBrush(Color.FromRgb(90, 90, 90));
            UpdateIndexUsuarios(null);
            ResetContentItemsVisibility();
            usuarios.Visibility = Visibility.Visible;
        }

        private void btnAdicionarUsuario_Click(object sender, RoutedEventArgs e)
        {
            ClearIndexUsuarios();
        }

        private void cbTipoUsuario_DropDownClosed(object sender, EventArgs e)
        {
            string selectedValue = cbTipoUsuario.Text;
            switch (selectedValue)
            {
                case "Cliente":
                    clientesUsuario.Visibility = Visibility.Visible;
                    funcionariosUsuario.Visibility = Visibility.Collapsed;
                    break;
                case "Funcionário":
                    clientesUsuario.Visibility = Visibility.Collapsed;
                    funcionariosUsuario.Visibility = Visibility.Visible;
                    break;
                default:
                    clientesUsuario.Visibility = Visibility.Collapsed;
                    funcionariosUsuario.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void btnSalvarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (!txbSenhaUsuario.Text.Equals(txbConfirmarSenhaUsuario.Text))
            {
                MessageBox.Show("As senhas não combinam");
                return;
            }

            Dictionary<string, string> usuarioDictionary = new Dictionary<string, string>();
            _usuarioViewModel = new UsuarioViewModel();

            usuarioDictionary["UsuarioId"] = txbIdUsuario.Text;
            usuarioDictionary["Nome"] = txbNomeUsuario.Text;
            usuarioDictionary["Email"] = txbEmailUsuario.Text;
            usuarioDictionary["Login"] = txbLoginUsuario.Text;
            usuarioDictionary["Senha"] = txbSenhaUsuario.Text;
            usuarioDictionary["Nivel"] = cbNivelUsuario.Text;

            if (cbTipoUsuario.Text.Equals("Cliente"))
            {
                usuarioDictionary["ClienteId"] = cbClienteIdUsuario.SelectedValue.ToString();
            }

            if (cbTipoUsuario.Text.Equals("Funcionário"))
            {
                usuarioDictionary["FuncionarioId"] = cbFuncionarioIdUsuario.SelectedValue.ToString();
            }

            _usuarioViewModel = _usuariosController.Validar(usuarioDictionary);

            if (_usuariosController.IsSuccessStatus)
            {
                if ((_usuarioViewModel.UsuarioId == 0))
                    _usuarioViewModel = _usuariosController.Adicionar(_usuarioViewModel);
                else
                    _usuarioViewModel = _usuariosController.Atualizar(_usuarioViewModel);

                if (_usuariosController.IsSuccessStatus)
                {
                    UpdateIndexUsuarios(_usuarioViewModel.UsuarioId);
                    MessageBox.Show(_usuariosController.Message);
                }
                else
                {
                    MessageBox.Show(_usuariosController.Message);
                }
            }
            else
            {
                MessageBox.Show(_usuariosController.Message);
            }
        }

        private void btnEditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (dtgUsuarios.SelectedItem != null)
            {
                _usuarioViewModel = (UsuarioViewModel)dtgUsuarios.SelectedItem;
                UpdateIndexUsuarios(_usuarioViewModel.UsuarioId);
            }
            else
            {
                MessageBox.Show("Selecione um usuário.");
            }
        }

        private void btnRemoverUsuario_Click(object sender, RoutedEventArgs e)
        {
            _usuarioViewModel = new UsuarioViewModel();

            if (dtgUsuarios.SelectedItem != null)
            {
                _usuarioViewModel = (UsuarioViewModel)dtgUsuarios.SelectedItem;
                _usuariosController.Remover(_usuarioViewModel.UsuarioId);

                if (_usuariosController.IsSuccessStatus)
                {
                    UpdateIndexUsuarios(null);
                    MessageBox.Show(_usuariosController.Message);
                }
                else
                {
                    MessageBox.Show(_usuariosController.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione um usuário");
            }
        }

        public void UpdateIndexUsuarios(int? id)
        {
            _usuarioViewModel = new UsuarioViewModel();

            ClearIndexUsuarios();

            if (id != null)
            {
                _usuarioViewModel = _usuariosController.Index(id);

                if (_usuariosController.IsSuccessStatus)
                {
                    cbClienteIdUsuario.ItemsSource = _usuarioViewModel.ClientesViewModel;
                    cbFuncionarioIdUsuario.ItemsSource = _usuarioViewModel.FuncionariosViewModel;
                    txbIdUsuario.Text = _usuarioViewModel.UsuarioId.ToString();
                    txbNomeUsuario.Text = _usuarioViewModel.Nome;
                    txbEmailUsuario.Text = _usuarioViewModel.Email;
                    txbLoginUsuario.Text = _usuarioViewModel.Login;
                    cbNivelUsuario.Text = _usuarioViewModel.Nivel;
                    txbSenhaUsuario.Text = _usuarioViewModel.Senha;
                    txbConfirmarSenhaUsuario.Text = _usuarioViewModel.Senha;

                    if (_usuarioViewModel.ClienteId != null)
                    {
                        clientesUsuario.Visibility = Visibility.Visible;
                        cbClienteIdUsuario.SelectedValue = _usuarioViewModel.ClienteId;
                        cbTipoUsuario.Text = "Cliente";
                    }

                    if (_usuarioViewModel.FuncionarioId != null)
                    {
                        funcionariosUsuario.Visibility = Visibility.Visible;
                        cbFuncionarioIdUsuario.SelectedValue = _usuarioViewModel.FuncionarioId;
                        cbTipoUsuario.Text = "Funcionário";
                    }
                }
            }
            else
            {
                _usuarioViewModel = _usuariosController.Index(null);

                if (_usuariosController.IsSuccessStatus)
                {
                    cbClienteIdUsuario.ItemsSource = _usuarioViewModel.ClientesViewModel;
                    cbFuncionarioIdUsuario.ItemsSource = _usuarioViewModel.FuncionariosViewModel;
                }
            }

            if (_usuariosController.IsSuccessStatus)
            {
                dtgUsuarios.ItemsSource = _usuarioViewModel.UsuariosViewModel;
            }
            else
            {
                MessageBox.Show(_usuariosController.Message);
            }
        }

        private void ClearIndexUsuarios()
        {
            cbTipoUsuario.Text = String.Empty;
            clientesUsuario.Visibility = Visibility.Collapsed;
            funcionariosUsuario.Visibility = Visibility.Collapsed;
            txbIdUsuario.Text = String.Empty;
            txbNomeUsuario.Text = String.Empty;
            txbEmailUsuario.Text = String.Empty;
            txbLoginUsuario.Text = String.Empty;
            cbNivelUsuario.Text = String.Empty;
            txbSenhaUsuario.Text = String.Empty;
            txbConfirmarSenhaUsuario.Text = String.Empty;
        }
        #endregion

        #region Chamados
        private void btnChamados_Click(object sender, RoutedEventArgs e)
        {
            ResetMenuItemsBackground();
            btnChamados.Background = new SolidColorBrush(Color.FromRgb(90, 90, 90));
            UpdateIndexChamados();
            ResetContentItemsVisibility();
            chamados.Visibility = Visibility.Visible;
        }

        private void btnFiltrarSemTecnicoChamados_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, bool> filtros = new Dictionary<string, bool>() { { "ApenasSemTecnico", true } };
            UpdateIndexChamados(filtros);
        }

        private void btnVerChamado_Click(object sender, RoutedEventArgs e)
        {
            ChamadoViewModel chamadoViewModel = new ChamadoViewModel();

            if (dtgChamados.SelectedItem == null)
            {
                MessageBox.Show("Selecione um usuário.");
                return;
            }

            chamadoViewModel = (ChamadoViewModel)dtgChamados.SelectedItem;
            UpdateIndexChamado(chamadoViewModel.ChamadoId);
            ResetContentItemsVisibility();
            chamado.Visibility = Visibility.Visible;
        }

        public void UpdateIndexChamados(Dictionary<string, bool> filtros = null)
        {
            ChamadoViewModel chamadoViewModel = new ChamadoViewModel();
            chamadoViewModel = _chamadosController.Index(filtros != null ? filtros : null);

            if (UsuarioAutal.Nivel.Equals("Coordenador"))
                btnFiltrarSemTecnicoChamados.Visibility = Visibility.Visible;
            else
                btnFiltrarSemTecnicoChamados.Visibility = Visibility.Collapsed;

            if (_chamadosController.IsSuccessStatus)
            {
                dtgChamados.ItemsSource = chamadoViewModel.ChamadosViewModel;
            }
            else
            {
                MessageBox.Show(_chamadosController.Message);
            }
        }

        private void UpdateIndexChamado(int id)
        {
            ChamadoViewModel chamadoViewModel = new ChamadoViewModel();
            chamadoViewModel = _chamadosController.Chamado(id);

            if (!_chamadosController.IsSuccessStatus)
            {
                MessageBox.Show(_chamadosController.Message);
                return;
            }

            txbClienteChamado.Text = chamadoViewModel.Cliente.RazaoSocial;

            if (chamadoViewModel.FuncionariosViewModel != null)
            {
                lblFuncionarioIdChamado.Visibility = Visibility.Visible;
                cbFuncionarioIdChamado.Visibility = Visibility.Visible;
                cbFuncionarioIdChamado.ItemsSource = chamadoViewModel.FuncionariosViewModel;

                if (chamadoViewModel.FuncionarioId != null)
                    cbFuncionarioIdChamado.SelectedValue = chamadoViewModel.FuncionarioId;
            }
            else
            {
                lblFuncionarioIdChamado.Visibility = Visibility.Collapsed;
                cbFuncionarioIdChamado.Visibility = Visibility.Collapsed;
            }

            cbStatusChamado.Text = chamadoViewModel.Status;
            txbIdChamado.Text = chamadoViewModel.ChamadoId.ToString();
            txbAberturaChamado.Text = chamadoViewModel.DataAbertura.ToString("dd/MM/yyyy");
            txbProdutoChamado.Text = chamadoViewModel.Produto.Nome;
            txbTipoChamado.Text = chamadoViewModel.TipoChamado.Descricao;
            txbAssuntoChamado.Text = chamadoViewModel.AssuntoChamado.Descricao;
            txbDescricaoChamado.Text = chamadoViewModel.Descricao;

            if (chamadoViewModel.PosicionamentosChamado != null)
            {
                listPosicionamentosChamado.Children.Clear();

                foreach (var posicionamento in chamadoViewModel.PosicionamentosChamado)
                {
                    Border border = new Border();
                    TextBlock textBlock = new TextBlock();
                    border.Style = (Style)(this.Resources["col-margin-bottom"]);
                    border.SetBinding(MaxWidthProperty, new Binding("ActualWidth") { ElementName = "listPosicionamentosChamado" });
                    textBlock.Text = string.Format(posicionamento.Descricao + "\n— " + posicionamento.DataCadastro.ToString("dd/MM/yyyy H:i"));
                    textBlock.Style = (Style)(this.Resources["textBlock"]);

                    if (posicionamento.ClienteId != null)
                    {
                        border.Background = new SolidColorBrush(Color.FromRgb(38, 58, 127));
                        textBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    }
                    else
                    {
                        border.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        textBlock.TextAlignment = TextAlignment.Right;
                    }

                    border.Child = textBlock;
                    listPosicionamentosChamado.Children.Add(border);
                }
            }
        }

        private void cbFuncionarioIdChamado_DropDownClosed(object sender, EventArgs e)
        {
            _chamadosController.AtualizarFuncionarioId(
                Convert.ToInt32(txbIdChamado.Text),
                Convert.ToInt32(cbFuncionarioIdChamado.SelectedValue.ToString())
                );
            MessageBox.Show(_chamadosController.Message);
        }

        private void cbStatusChamado_DropDownClosed(object sender, EventArgs e)
        {
            _chamadosController.AtualizarStatus(
                Convert.ToInt32(txbIdChamado.Text),
                cbStatusChamado.Text
                );
            MessageBox.Show(_chamadosController.Message);
        }

        private void btnAdicionarPosicionamento_Click(object sender, RoutedEventArgs e)
        {
            AdicionarPosicionamentoChamado adicionarPosicionamentoChamado = new AdicionarPosicionamentoChamado();
            adicionarPosicionamentoChamado.txbChamadoId.Text = txbIdChamado.Text;
            adicionarPosicionamentoChamado.ShowDialog();
            UpdateIndexChamado(Convert.ToInt32(txbIdChamado.Text));
        }
        #endregion


        private bool TextoNumerico(string str)
        {
            Regex reg = new Regex("[^0-9]");
            return reg.IsMatch(str);
        }

        private void TextoNumerico_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = TextoNumerico(e.Text);
        }
    }
}
