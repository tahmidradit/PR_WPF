using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient httpClient;
        Uri baseAddress = new Uri("https://localhost:7084/api/Order/");
        Order order ;
        public MainWindow()
        {
            InitializeComponent();
            this.httpClient = new HttpClient();
            this.order = new Order();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add
            (
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")    
            );
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetAll();
        }

        public async void GetAll()
        {
            List<Order> orders = new List<Order>();
            var httpResponseMessage = await httpClient.GetStringAsync(baseAddress);
            string data;
            //if (httpResponseMessage.IsSuccessStatusCode)
            //{
                //data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                orders = JsonConvert.DeserializeObject<List<Order>>(httpResponseMessage);
            //}

            dataGrid.ItemsSource = orders;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var formData = new Order()
            {
                CustomerName = CustomerName.Text,
                CustomerAddress = CustomerAddress.Text,
                ShippingAddress = ShippingAddress.Text,
                ItemName = ItemName.Text,
                UnitPrice = Convert.ToDecimal(UnitPrice.Text),
                Quantity = int.Parse(Quantity.Text),
                Discount = int.Parse(Discount.Text),
                //TotalPrice = TotalPrice.Text,
                OrderInvoiceNo = int.Parse(OrderInvoiceNo.Text),
                OrderDateTime = Convert.ToDateTime(OrderDateTime),
                ShippingDate = Convert.ToDateTime(ShippingDate)
            };
            httpClient.PostAsJsonAsync(baseAddress, this.order);
            MessageBox.Show("Confirm","Result");
        }
    }
}
