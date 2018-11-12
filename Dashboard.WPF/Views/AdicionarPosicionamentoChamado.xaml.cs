using Dashboard.WPF.Controllers;
using Dashboard.WPF.ViewModels;
using System.Collections.Generic;
using System.Windows;

namespace Dashboard.WPF.Views
{
    /// <summary>
    /// Lógica interna para AdicionarPosicionamentoChamado.xaml
    /// </summary>
    public partial class AdicionarPosicionamentoChamado : Window
    {
        private ChamadosController _chamadosController;

        public AdicionarPosicionamentoChamado()
        {
            _chamadosController = new ChamadosController();
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> posicionamentoChamadoDictionary = new Dictionary<string, string>();
            PosicionamentoChamadoViewModel posicionamentoChamadoViewModel = new PosicionamentoChamadoViewModel();

            posicionamentoChamadoDictionary["ChamadoId"] = txbChamadoId.Text;
            posicionamentoChamadoDictionary["Descricao"] = txbDescricao.Text;
            posicionamentoChamadoViewModel = _chamadosController.ValidarPosicionamento(posicionamentoChamadoDictionary);

            if (_chamadosController.IsSuccessStatus)
            {
                _chamadosController.AdicionarPosicionamento(posicionamentoChamadoViewModel);

                if (_chamadosController.IsSuccessStatus)
                {
                    this.Close();
                    MessageBox.Show(_chamadosController.Message);
                }
                else
                {
                    MessageBox.Show(_chamadosController.Message);
                }
            }
            else
            {
                MessageBox.Show(_chamadosController.Message);
            }
        }
    }
}
