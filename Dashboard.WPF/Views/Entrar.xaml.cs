using Dashboard.WPF.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dashboard.WPF.Views
{
    /// <summary>
    /// Lógica interna para Entrar.xaml
    /// </summary>
    public partial class Entrar : Window
    {
        private ContaController _contaController;

        public Entrar()
        {
            _contaController = new ContaController();
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txbLogin.Text) || String.IsNullOrEmpty(pbSenha.Password))
                MessageBox.Show("Preencha o login e senha");
            else
            {
                _contaController.Entrar(txbLogin.Text, pbSenha.Password);

                if (!_contaController.IsSuccessStatus)
                {
                    MessageBox.Show(_contaController.Message);
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}
