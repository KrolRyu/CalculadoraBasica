using System.Windows;

namespace CalculadoraBasica
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            Operando1TextBox.Clear();
            Operando2TextBox.Clear();
            OperadorTextBox.Clear();
            ResultadoTextBox.Clear();
        }

        private void CalcularButton_Click(object sender, RoutedEventArgs e)
        {
            int n1 = default, n2 = default;
            try
            {
                n1 = int.Parse(Operando1TextBox.Text);
                n2 = int.Parse(Operando2TextBox.Text);
            }
            catch (System.Exception)
            {
                MessageBox.Show("Introduce números válidos","ERROR");
                Limpiar();
            }

            try
            {
                switch (OperadorTextBox.Text)
                {
                    case "+":
                        ResultadoTextBox.Text = (n1 + n2).ToString();
                        break;
                    case "-":
                        ResultadoTextBox.Text = (n1 - n2).ToString();
                        break;
                    case "*":
                        ResultadoTextBox.Text = (n1 * n2).ToString();
                        break;
                    case "/":
                        ResultadoTextBox.Text = (n1 / n2).ToString();
                        break;
                    default:
                        break;
                }
            }
            catch (System.DivideByZeroException)
            {
                MessageBox.Show("Por favor, no trates de dividir entre 0", "ERROR");
                Limpiar();
            }
            
        }

        private void LimpiarButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void OperadorTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (OperadorTextBox.Text == "+" || OperadorTextBox.Text == "-" || OperadorTextBox.Text == "*" || OperadorTextBox.Text == "/")
                CalcularButton.IsEnabled = true;
            else
                CalcularButton.IsEnabled = false;
        }
    }
}
