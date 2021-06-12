
using System;
using System.Security.Cryptography;
using System.Text;


namespace InventarioFod.Clases.Entidades.Security
{
    class Usuario_Seguridad
    {
        public static string Procesar_Nombre_Usuarios(string user)
        {
            try
            {
                
                StringBuilder sBuilder = new StringBuilder();
                using (MD5 md5hash = MD5.Create())
                {
                    byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(user));
                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                        if (((i % 4) == 3) && i != (data.Length - 1))
                        {
                            sBuilder.Append("-");
                        }

                    }
                }
                return sBuilder.ToString().ToUpper();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public static string Procesar_Pass_Usuarios(string pass)
        {
            try
            {
                StringBuilder sBuilder = new StringBuilder();
                using (SHA256 hash256 = SHA256.Create())
                {
                    byte[] array = hash256.ComputeHash(Encoding.UTF8.GetBytes(pass));
                    for (int i = 0; i < array.Length; i++)
                    {
                        sBuilder.Append(array[i].ToString("x2"));
                        if (((i % 4) == 3) && i != (array.Length - 1))
                        {
                            sBuilder.Append("-");
                        }
                    }
                }
                return sBuilder.ToString().ToUpper();
            }
            catch (Exception)
            {

                throw;
            }
            
        }


    }
}
