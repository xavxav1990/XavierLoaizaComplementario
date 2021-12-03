using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using XavierLoaizaComplementario.Droid;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SqlClient))]

namespace XavierLoaizaComplementario.Droid
{
    class SqlClient : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            //creo la variable donde se guardara la base de datos en un lugar fisico del sistema android
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //creo el nombre de la base que se va a crear combinado con la direccion fisica 
            var path = Path.Combine(documentPath, "uisrael.db3");
            //deviuelvo los datos como path
            return new SQLiteAsyncConnection(path);
        }
    }
}