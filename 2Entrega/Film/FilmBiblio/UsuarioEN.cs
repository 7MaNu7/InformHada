﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FilmBiblio
{
    public class UsuarioEN
    {
        ///////////
        // Patos //
        ///////////

        private UsuarioCAD usuarioCad;  //Instancia de UsuarioCAD para gestionar la información de usuarios en la base de datos

        private int id;                 //Se usará como clave primaria en la base de datos
        private string usuario;         //El nombre del usuario en la página web
        private string psswd;           //El password del usuario para poder entrar a la página identificándose
        private string pais;            //El pais del usuario
        private string provincia;       //La provincia del usuario
        private string fechaNacimiento; //La fecha de nacimiento del usuario
        private string sexo;            //El sexo (Hombre o Mujer) del usuario
        private string email;           //El email del usuario
        private ArrayList amigos;       //Un vector del tipo UsuarioEn con sus amigos
        private string imagen;          //Será una url con la dirección de la imagen
        private string informacion;     //La información que el usuario quiera poner en su perfil

        ///////////////
        // Funciones //
        ///////////////

        //Constructor por defecto
        public UsuarioEN() { }

        //Constructor con parámetros que son las propiedades de dicho usuario
        public UsuarioEN(int pid, string pusuario, string ppsswd, string pemail,  ArrayList pamigos, string ppais, 
                        string pprovincia, string pfecha, string sexo, string imagen, string informacion)
        {
            id = pid;
            usuario = pusuario;
            psswd = ppsswd;
            email = pemail;
            pais = ppais;
            provincia = pprovincia;
            fechaNacimiento = pfecha;
            this.sexo = sexo;
            amigos = (ArrayList)pamigos.Clone();
            this.imagen = imagen;
            this.informacion = informacion;
        }

        //Se añade en la BD (en una tabla con la relación amigos), el id del usuario y el de su amigo
        public void AnyadirAmigo(UsuarioEN amigo_bueno)
        {
            amigos.Add(amigo_bueno);
            usuarioCad.AnyadirAmigo(this.id, amigo_bueno.id);
        }

        //Se elimina en la BD (en una tabla con la relación amigos), el id del usuario y el de su amigo
        public void EliminarAmigo(UsuarioEN amigo_malo)
        {
            amigos.Remove(amigo_malo);
            usuarioCad.EliminarAmigo(this.id, amigo_malo.id);
        }

        //Se inserta en la BD el nuevo usuario cuyos datos están en esta instancia this de UsuarioEN
        public void InsertarUsuario()
        {
            usuarioCad.InsertarUsuario(this);
        }

        //Se modifica en la BD un usuario cuyos datos están en esta instancia this de UsuarioEN
        public void UpdateUsuario()
        {
            usuarioCad.UpdateUsuario(this);
        }

        //Se borra en la BD un usuario diferenciado de los demás por su id
        public void BorrarUsuario()
        {
            usuarioCad.BorrarUsuario(this.id);
        }

        //Devuelve la información de todas los usuarios
        public ArrayList DameUsuarios()
        {
            ArrayList usuarios = new ArrayList();
            usuarios = usuarioCad.DameUsuarios();
            return usuarios;
        }

        //Devuelve la información del usuario que tiene como clave primaria el id pasado por parámetro
        public UsuarioEN DameUsuario()
        {
            UsuarioEN usuario = new UsuarioEN();
            usuario = usuarioCad.DameUsuario(this.id);
            return usuario;
        }

        /////////////////
        // Propiedades //
        /////////////////

        //Desde fuera de la clase se puede obtener el id y modificarlo
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        //Desde fuera de la clase se puede obtener el nombre (usuario) y modificarlo
        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        //Desde fuera de la clase se puede obtener el password y modificarlo
        public String Psswd
        {
            get { return psswd; }
            set { psswd = value; }
        }

        //Desde fuera de la clase se puede obtener la información del pais y modificarlo
        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        //Desde fuera de la clase se puede obtener la información de la provincia y modificarla
        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        //Desde fuera de la clase se puede obtener la información de la fecha de nacimiento y modificarla
        public string FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        //Desde fuera de la clase se puede obtener la información del sexo (solo podrá ser H o M) y modificarlo
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        //Desde fuera de la clase se puede obtener el email y modificarlo
        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        //Desde fuera de la clase se puede obtener los amigos del usuario y modificarlos
        public ArrayList Amigos
        {
            get { return amigos; }
            set { amigos = (ArrayList)value.Clone(); }
        }

        //Desde fuera de la clase se puede obtener la imágen del usuario y modificarla
        public String Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        //Desde fuera de la clase se puede obtener la información del usuario y modificarla
        public String Informacion
        {
            get { return informacion; }
            set { informacion = value; }
        }
    }
}
