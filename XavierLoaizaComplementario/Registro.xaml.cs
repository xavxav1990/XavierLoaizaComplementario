using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XavierLoaizaComplementario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro(String Nombre)
        {
            InitializeComponent();
            lblnombre.Text = "Usuario conectado: " + Nombre;
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            double monto = Convert.ToDouble(txtMonto.Text);

            if (monto <= 1800 && monto >= 0)
            {

                double cuotas = ((1800 - monto) / 3) * 1.05;
                txtCuota1.Text = Convert.ToString(cuotas);
                txtCuota2.Text = Convert.ToString(cuotas);
                txtCuota3.Text = Convert.ToString(cuotas);

            }
            else
            {
                DisplayAlert("Alerta", "Valor debe ser entre: 0 y 1800", "ok").ToString();

            }
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {

            try {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("monto_ini", txtMonto.Text);



            } catch (Exception ex) {
            await DisplayAlert("Alerta", "Error: "+ex.Message, "ok");
            }
        }
    }
}