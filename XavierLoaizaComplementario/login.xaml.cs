using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XavierLoaizaComplementario.Models;

namespace XavierLoaizaComplementario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public login()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        public static IEnumerable<Usuarios> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasenia)
        {

            return db.Query<Usuarios>("SELECT * FROM Usuarios where Usuario = ? and Contrasena = ?", usuario, contrasenia);

        }


        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documentPhat = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(documentPhat);
                db.CreateTable<Usuarios>();
                IEnumerable<Usuarios> resultado = SELECT_WHERE(db, txtUsuario.Text, txtContrasena.Text);
                if (resultado.Count() > 0)
                {
                    var Nombre= txtUsuario.Text;
                    Navigation.PushAsync(new Registro(Nombre));
                }
                else
                {
                    DisplayAlert("Alerta", "Usuario no existe, porfavor Registrarse", "Ok");

                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Ok");
            }


        }

        private void btnRegistroLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegUsuario());

        }
    }
}