using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XavierLoaizaComplementario.Models
{
    public class Usuarios
    {
        //Campos de la tabla usuarios
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        [MaxLength(50)]
        public string Nombre { set; get; }
        [MaxLength(25)]
        public string Usuario { set; get; }
        [MaxLength(25)]
        public string Contrasena { set; get; }
    }
}
