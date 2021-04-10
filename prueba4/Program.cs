using System;
using System.Collections.Generic;
using System.Linq;
using prueba4;
using System.IO;
using System.Xml.Serialization;
using prueba4.Modelo;



namespace prueba4
{
    class Program
    {
        static List<Estudiantes> ListaEstudiantes = new List<Estudiantes>();
        static Validaciones vali = new Validaciones();
        static pantallas pantalla = new pantallas();
        static void Main(string[] args)

        {
            int opcion;
            int opcionMenu;
            pantalla.pantalla1();
            Console.SetCursorPosition(3, 2);Console.WriteLine("1. agregar Estudiante");
            Console.SetCursorPosition(25, 2);Console.WriteLine("2. Listar estudiantes");
            Console.SetCursorPosition(50, 2);Console.WriteLine("3. Buscar un Estudiante");
            Console.SetCursorPosition(80, 2);Console.WriteLine("4. editar estudiante");
            Console.SetCursorPosition(30, 4);Console.WriteLine("5. Borrar estudiante");
            Console.SetCursorPosition(60, 4);Console.WriteLine("0. salir");

            Console.SetCursorPosition(40, 7);Console.WriteLine("Digite una opcion del menu:..");
            Console.SetCursorPosition(55, 8);
            opcion = Convert.ToInt32(Console.ReadLine());
            opcionMenu = Convert.ToInt32(opcion);
            switch (opcionMenu)
            {
                case 1:
                    AgregarEstudiante();
                    break;
                case 2:
                    ListarEstudiantes();
                    break;
                case 3:
                    BuscarEstudiante();
                    break;
                case 4:
                    EditarEstudiantes();
                    break;
                case 5:
                    BorrarEstudiante();
                    break;
                case 0:
                    Console.WriteLine("saliendo de la aplicacion");
                    break;
                default:
                    Console.WriteLine("la opcion non es valida");
                    break;


            }
            Console.SetCursorPosition(37, 15);
            Console.WriteLine("presione cualquier tecla para continuar");
            //Console.ReadKey();
        }

        static void AgregarEstudiante()
        {
            Console.Clear();
            var baseDatos = new tallersenaContext();
            string cod, nom, corr;
            double no1, no2, no3, noFinal;
            string nota1, nota2, nota3;


            bool CodigoValido = false;
            bool NombreValido = false;
            bool correoValido = false;
            bool ValidoNot1 = false;
            bool ValidoNot2 = false;
            bool ValidoNot3 = false;



            Console.Clear();
            pantalla.pantalla2();
            Console.SetCursorPosition(38, 2);
            Console.WriteLine(" ...... crear estudiante.....");

            do
            {
                Console.SetCursorPosition(38, 3);
                Console.Write(" Digite Codigo Estudiante: ");
                cod = Console.ReadLine();
                if (!vali.Vacio(cod))
                    if (vali.TipoNumero(cod))
                        CodigoValido = true;
            } while (!CodigoValido);


            do
            {
                Console.SetCursorPosition(38, 4);
                Console.Write(" Digite el nombre del estudiante: ");
                nom = Console.ReadLine();
                if (!vali.Vacio(nom))
                    if (vali.TipoTexto(nom))
                        NombreValido = true;

 
            } while (!NombreValido);


            do
            {
                Console.SetCursorPosition(38, 6);
                Console.Write(" Digite el correo del Estudiante: ");
                Console.SetCursorPosition(55, 7);
                corr = Console.ReadLine();
                if (vali.Mail(corr))
                    correoValido = true;
            } while (!correoValido);


            do
            {
                Console.SetCursorPosition(38, 8);
                Console.WriteLine("Digite nota 1 del estudiante");
                Console.SetCursorPosition(55, 9);
                nota1 = (Console.ReadLine());
                if (vali.Vacio(nota1))
                    if (vali.TipoNumero(nota1))
                        ValidoNot1 = true;
            } while (ValidoNot1);
            no1 = double.Parse(nota1);
            do
            {
                Console.SetCursorPosition(38, 10);
                Console.WriteLine("Digite nota 2 del estudiante");
                Console.SetCursorPosition(55, 11);
                nota2 = (Console.ReadLine());
                if (vali.Vacio(nota2))
                    if (vali.TipoNumero(nota2))
                        ValidoNot2 = true;
            } while (ValidoNot2);

            no2 = double.Parse(nota2);
            do
            {
                Console.SetCursorPosition(38, 12);
                Console.WriteLine("Digite nota 3 del estudiante");
                Console.SetCursorPosition(55, 13);
                nota3 = (Console.ReadLine());
                if (vali.Vacio(nota3))
                    if (vali.TipoNumero(nota3))
                        ValidoNot3 = true;

            } while (ValidoNot3);

            no3 = double.Parse(nota3);
            noFinal = (no1 + no2 + no3) / 3;

            Estudiantes AUX = new Estudiantes();
            AUX.Codigo = (uint)Convert.ToInt32(cod);
            AUX.Nombre = nom;
            AUX.Correo = corr;
            AUX.Nota1 = no1;
            AUX.Nota2 = no2;
            AUX.Nota3 = no3;
            AUX.NotaFinal = Math.Round(noFinal, 1);

            //Console.WriteLine(AUX.Nombre);//

            baseDatos.Estudiantes.Add(AUX);
           //baseDatos.SaveChanges(tallersenaContext);//

            ListaEstudiantes.Add(AUX);
            Console.Clear();
        }


        static void ListarEstudiantes()
        {
            var baseDatos = new tallersenaContext();
            var ListaEstudiantes = baseDatos.Estudiantes.ToList();
            Console.SetCursorPosition(50, 2); Console.WriteLine("Listar Estudiantes");
            Console.SetCursorPosition(2, 5); Console.Write("Codigo");
            Console.SetCursorPosition(11, 5); Console.Write("Nombre");
            Console.SetCursorPosition(38, 5); Console.Write("Correo");
            Console.SetCursorPosition(61, 5); Console.Write("Nota 1");
            Console.SetCursorPosition(70, 5); Console.Write("Nota 2");
            Console.SetCursorPosition(79, 5); Console.Write("Nota 3");
            Console.SetCursorPosition(88, 5); Console.Write("Nota Final");
            Console.Write("\n");
           
            int y = 6;
            foreach (var itemEstudiante in ListaEstudiantes)

            {
                y++;
                Console.SetCursorPosition(3, y); Console.Write(itemEstudiante.Codigo);
                Console.SetCursorPosition(10, y); Console.Write(itemEstudiante.Nombre);
                Console.SetCursorPosition(37, y); Console.Write(itemEstudiante.Correo);
                Console.SetCursorPosition(63, y); Console.Write(itemEstudiante.Nota1);
                Console.SetCursorPosition(72, y); Console.Write(itemEstudiante.Nota2);
                Console.SetCursorPosition(81, y); Console.Write(itemEstudiante.Nota3);
                Console.SetCursorPosition(90, y); Console.Write(itemEstudiante.NotaFinal);

            }
            Console.Write("\n");

        }
        static void BuscarEstudiante()
        {
            var baseDatos = new tallersenaContext();
            var Estudiantes = baseDatos.Estudiantes.ToList();
            string cod;
            bool CodigoValido = false;

            do
            {

                Console.Clear();
                pantalla.pantalla2();
                Console.SetCursorPosition(38, 2);
                Console.WriteLine("---------buscar un estudiante----------");
                Console.SetCursorPosition(38, 3);
                Console.WriteLine("--------digite el codigo a buscar--------");
                Console.SetCursorPosition(38, 4);
                cod = (Console.ReadLine());
                if (!vali.Vacio(cod))
                    if (vali.TipoNumero(cod))
                        CodigoValido = true;
            } while (!CodigoValido);
            if (Existe(Convert.ToInt32(cod)))
            {

                Console.SetCursorPosition(38, 5);
                Console.WriteLine("estudiante encontrado");

                Estudiantes myEstudiante = ObtenerDatos(Convert.ToInt32(cod));
      
                Console.SetCursorPosition(38, 6);
                Console.WriteLine("Codigo: " + myEstudiante.Codigo);
                Console.SetCursorPosition(38, 7);
                Console.WriteLine("\t Nombre: " + myEstudiante.Nombre);
                Console.SetCursorPosition(38, 8);
                Console.WriteLine("\t Correo: " + myEstudiante.Correo);
                Console.SetCursorPosition(38, 9);
                Console.WriteLine("\t Nota 1:" + myEstudiante.Nota1);
                Console.SetCursorPosition(38, 10);
                Console.WriteLine("\t Nota 2: " + myEstudiante.Nota2);
                Console.SetCursorPosition(38, 11);
                Console.WriteLine("\t Nota 3: " + myEstudiante.Nota3);
                Console.SetCursorPosition(38, 12);
                Console.WriteLine("\t Nota 3: " + myEstudiante.Nota3);
                Console.SetCursorPosition(38, 13);
                Console.WriteLine("\t Nota Final: " + myEstudiante.NotaFinal);
            }
            else
                Console.SetCursorPosition(38, 14);
            Console.WriteLine("el estudiante no se encontro");
        }
        //metodo existe

        static bool Existe(int cod)
        {
            Console.Clear();
            var baseDatos = new tallersenaContext();
            //esudintes una nueva variable 
            var estudiantes = baseDatos.Estudiantes.ToList();
            bool aux = false;
            foreach (var myEstudiante in estudiantes)
            {
                if (myEstudiante.Codigo == cod)
                    aux = true;
            }
            return aux;
        }
        //metodo obtener datos
        static Estudiantes ObtenerDatos(int cod)
        {
            var baseDatos = new tallersenaContext();
            var Estudiantes = baseDatos.Estudiantes.ToList();
            foreach (Estudiantes ObjetoEstudiante in Estudiantes)
            {
                if (ObjetoEstudiante.Codigo == cod)
                    return ObjetoEstudiante;
            }
            return null;
        }
        static void EditarEstudiantes()
        {
            var baseDatos = new tallersenaContext();
            string cod;
            bool CodigoValido = false;
            do
            {

                Console.Clear();
                pantalla.pantalla3();
                Console.SetCursorPosition(32, 2);
                Console.WriteLine("editar estudiantes");
                Console.SetCursorPosition(30, 4);
                Console.WriteLine("digite el codigo a editar");
                Console.SetCursorPosition(38, 5);
                cod = Console.ReadLine();
                if (!vali.Vacio(cod))
                    if (vali.TipoNumero(cod))
                        CodigoValido = true;
            } while (!CodigoValido);
            if (Existe(Convert.ToInt32(cod)))
            {
                bool NombreValido = false, CorreoValido = false, n1Valido = false, n2Valido = false, n3Valido = false;

                string nom, corr, n1, n2, n3;
                double nf1, nf2, nf3, nf;
                Estudiantes myEstudiante = ObtenerDatos(int.Parse(cod));
                Console.SetCursorPosition(18, 10); Console.WriteLine(myEstudiante.Nombre);
                Console.SetCursorPosition(18, 12); Console.WriteLine(myEstudiante.Correo);
                Console.SetCursorPosition(18, 14); Console.WriteLine(myEstudiante.Nota1);
                Console.SetCursorPosition(18, 16); Console.WriteLine(myEstudiante.Nota2);
                Console.SetCursorPosition(18, 18); Console.WriteLine(myEstudiante.Nota3);
                Console.SetCursorPosition(18, 20); Console.WriteLine(myEstudiante.NotaFinal);

                do
                {
                    Console.SetCursorPosition(60, 10); Console.Write("Nuevo Nombre:");
                    Console.SetCursorPosition(74, 10); nom = Console.ReadLine();
                    Console.SetCursorPosition(40, 24); if (vali.Vacio(nom))
                        Console.SetCursorPosition(40, 24); if (vali.TipoTexto(nom))
                        NombreValido = true;
                } while (!NombreValido);

                do
                {

                    Console.SetCursorPosition(60, 12); Console.Write("Correo nuevo:");
                    Console.SetCursorPosition(74, 12); corr = Console.ReadLine();
                    Console.SetCursorPosition(40, 24); if (vali.Vacio(corr))
                        Console.SetCursorPosition(40, 24); if (vali.Mail(corr))
                        CorreoValido = true;
                } while (!CorreoValido);


                do
                {

                    Console.SetCursorPosition(60, 14); Console.Write("Nota 1:");

                    Console.SetCursorPosition(74, 14); n1 = Console.ReadLine();
                    Console.SetCursorPosition(40, 24); if (vali.Vacio(n1))
                        Console.SetCursorPosition(40, 24); if (vali.TipoNumero(n1))
                        n1Valido = true;
                } while (!n1Valido);

                do
                {

                    Console.SetCursorPosition(60, 16); Console.Write("Nota 2:");

                    Console.SetCursorPosition(74, 16); n2 = Console.ReadLine();
                    Console.SetCursorPosition(40, 24); if (vali.Vacio(n2))
                        Console.SetCursorPosition(40, 24); if (vali.TipoNumero(n2))
                        n2Valido = true;
                } while (!n2Valido);

                do
                {

                    Console.SetCursorPosition(60, 18); Console.Write("Nota 3:");

                    Console.SetCursorPosition(74, 18); n3 = Console.ReadLine();
                    Console.SetCursorPosition(40, 24); if (vali.Vacio(n3))
                        Console.SetCursorPosition(40, 24); if (vali.TipoNumero(n3))
                        n3Valido = true;
                } while (!n3Valido);

                nf1 = double.Parse(n1); nf2 = double.Parse(n1); nf3 = double.Parse(n1);
                nf = (nf1 + nf2 + nf3) / 3;
                myEstudiante.Nombre = nom;
                myEstudiante.Correo = corr;
                myEstudiante.Nota1 = double.Parse(n1);
                myEstudiante.Nota2 = double.Parse(n2);
                myEstudiante.Nota3 = double.Parse(n3);
                myEstudiante.NotaFinal = Math.Round(nf, 1);
                //actualizar
                baseDatos.Estudiantes.Update(myEstudiante);
                baseDatos.SaveChanges();


                Console.Clear();

                Console.SetCursorPosition(25, 23); Console.WriteLine("         Los datos han sido actualizados con exito                   ");

                //-------------------------

            }
            else
            {
                Console.SetCursorPosition(26, 17); Console.WriteLine("      El estudiante no existe    ");
            }
        }

        static void BorrarEstudiante()
        {
            var baseDatos = new tallersenaContext();
            string cod;
            bool CodigoValido = false;

            Console.Clear();
            pantalla.pantalla3();
            Console.SetCursorPosition(25, 2); Console.WriteLine("       Borrar estudiante     ");
            do
            {
                Console.SetCursorPosition(21, 3);
                Console.Write("Digite Codigo del Estudiante que desea borrar");
                //Console.SetCursorPosition(35, 4);
                cod = Console.ReadLine();
                if (vali.TipoNumero(cod))
                    CodigoValido = true;
            } while (!CodigoValido);

            if (Existe(int.Parse(cod)))
            {
                Console.Clear();
                Console.SetCursorPosition(33, 7); Console.WriteLine("    ¡¡¡  Aviso Importante  !!!");
                Estudiantes myEstudiante = ObtenerDatos(int.Parse(cod));
                Console.SetCursorPosition(33, 13); Console.WriteLine($"Desea eliminar a {myEstudiante.Nombre} del sistema S/N");
                Console.SetCursorPosition(52, 20); string confirmar = Console.ReadLine();
                if (confirmar == "s" || confirmar == "S")
                {
                    baseDatos.Estudiantes.Remove(myEstudiante);
                    baseDatos.SaveChanges();
                }
            }
            else
            {
                Console.SetCursorPosition(35, 18); Console.WriteLine("     El estudiante no existe   ");
            }

        }

    }

}

