using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string cadena = "Server=LAB1507-17\\SQLEXPRESS03; Database=Neptuno;User ID=userBlas;Password=987654;MultipleActiveResultSets=True";

            List<Cliente> Listaclientes = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("USP_ListarClientes", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        idcliente = reader["idCliente"] != DBNull.Value ? reader["idCliente"].ToString() : string.Empty,
                        nombrecompañia = reader["Nombrecompañia"] != DBNull.Value ? reader["Nombrecompañia"].ToString() : string.Empty,
                        nombrecontacto = reader["Nombrecontacto"] != DBNull.Value ? reader["Nombrecontacto"].ToString() : string.Empty,
                        cargocontacto = reader["CargoContacto"] != DBNull.Value ? reader["CargoContacto"].ToString() : string.Empty,

                    };
                    Listaclientes.Add(cliente);
                }
            }
          
            Gridclientes.ItemsSource = Listaclientes;

        }
    }
}