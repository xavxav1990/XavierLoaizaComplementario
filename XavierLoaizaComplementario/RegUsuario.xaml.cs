using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XavierLoaizaComplementario.Models;

namespace XavierLoaizaComplementario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegUsuario : ContentPage
    {
        private SQLiteAsyncConnection con;
        public RegUsuario()
        {
            InitializeComponent();
            //Interfaz de coneccion a la base de datos que devuelve la interfaz Database
            con = DependencyService.Get<Database>().GetConnection();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                //traigo las variables de el xaml de registro Ej: "Nombre = txtNombre.Text"
                var Registro = new Usuarios { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasena = txtContrasena.Text };
                //utilizo InsertAsyc para insertar en la tabla estudiantes
                con.InsertAsync(Registro);
                //muestro una alerta de dato ingresado
                DisplayAlert("Alerta", "Dato Ingresado", "OK");
                //dejo las casillas en blanco del imput
                txtNombre.Text = "";
                txtContrasena.Text = "";
                txtUsuario.Text = "";
                Navigation.PushAsync(new login());
            }
            catch (Exception ex) { }

        }
    }
}