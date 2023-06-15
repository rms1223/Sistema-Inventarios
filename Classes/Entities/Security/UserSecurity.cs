
using System;
using System.Security.Cryptography;
using System.Text;


namespace SystemIventory.Classes.Entities.Security
{
    class UserSecurity
    {
        public static string ProcessUserName(string user)
        {
            try
            {
                
                StringBuilder _sBuilder = new StringBuilder();
                using (MD5 md5hash = MD5.Create())
                {
                    byte[] _dataEncoding = md5hash.ComputeHash(Encoding.UTF8.GetBytes(user));
                    for (int i = 0; i < _dataEncoding.Length; i++)
                    {
                        _sBuilder.Append(_dataEncoding[i].ToString("x2"));
                        if (((i % 4) == 3) && i != (_dataEncoding.Length - 1))
                        {
                            _sBuilder.Append("-");
                        }

                    }
                }
                return _sBuilder.ToString().ToUpper();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public static string ProcessPasswordUser(string pass)
        {
            try
            {
                StringBuilder _sBuilder = new StringBuilder();
                using (SHA256 hash256 = SHA256.Create())
                {
                    byte[] _arrayEncoding = hash256.ComputeHash(Encoding.UTF8.GetBytes(pass));
                    for (int i = 0; i < _arrayEncoding.Length; i++)
                    {
                        _sBuilder.Append(_arrayEncoding[i].ToString("x2"));
                        if (((i % 4) == 3) && i != (_arrayEncoding.Length - 1))
                        {
                            _sBuilder.Append("-");
                        }
                    }
                }
                return _sBuilder.ToString().ToUpper();
            }
            catch (Exception)
            {

                throw;
            }
            
        }


    }
}
