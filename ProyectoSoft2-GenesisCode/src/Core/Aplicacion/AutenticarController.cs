using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Persistencia;
using Dominio;
using Interfaces;
using Excepciones;
using Microsoft.IdentityModel.Tokens;
using JsonFlatFileDataStore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Aplicacion
{
    public class AutenticarController
    {
        public IEntidadRepository<IDocumentCollection<Usuario>,IEnumerable<Usuario>> repositorioUsuario;
		public IEntidadRepository<IDocumentCollection<Log>,IEnumerable<Log>> repositorioLogin;

		/***
			Inicializa el repositorio usuario.
		*/
        public void setRepositorioUsuario(Object repositorioUsuario){
            this.repositorioUsuario = (UsuarioRepositorio) repositorioUsuario;
        }

		/***
			Inicializa el repositorio login.
		*/
		public void setRepositorioLogin(Object repositorioLogin){
            this.repositorioLogin = (LogRepositorio) repositorioLogin;
        }

		/***
			Obtiene un usuario por medio de su id
		*/
        public Usuario GetUsuario(string id)
		{
			try
			{
				var collection = repositorioUsuario.getQueryEntidad();
				var results = collection.First(x=>x.documento==id);
				return results;
			}
			catch (Exception)
			{
				throw new UsuariosException("El documento asignado no corresponde con alguno que se encuentre almacenado en la base de datos.");
			}
		}

		/***
			Obtiene una lista con todos los usuarios que se encuentren en el repositorio
		*/
        public IEnumerable<Usuario> GetUsuarios()
		{		
			var results = repositorioUsuario.getQueryEntidad();
			return results;
		}

		/***
			Crea los usuarios validando que estos no existan
		*/
        public async Task<Usuario> SetUsuarioAsync(Usuario usuario)
		{   
            
            if (UsuarioExistente(usuario.documento))
			{
              try
                {
                    IDocumentCollection<Usuario> usuarios = repositorioUsuario.getDataEntidad();
                    await usuarios.InsertOneAsync(usuario);
                    return usuario;
                }
                catch (Exception)
                {
                    throw new UsuariosException("No se pudo crear el usuario, revise el objeto suministrado en formato JSON");
                }
			}else
			{
				throw new UsuariosException("El usuario ya existe, ingrese uno nuevo");
			}
        }    	

		/***
			Elimina un usuario especificado por su id en la URL. ademas de validar que el usuario exista.
		*/
        public async Task<Usuario> RemoveUsuario(string id)
		{
			Usuario actual = this.GetUsuario(id);

			if(actual != null){
				var collection = repositorioUsuario.getDataEntidad();
				await collection.DeleteOneAsync(e => e.documento == id);
			}
			return actual;
		}

		/***
			Valida que el usuario no exista, si existe retorna false si no retorna true.
		*/
		private Boolean UsuarioExistente(string documento){
			
			IEnumerable<Usuario> usuarios = GetUsuarios();
			foreach (var usuario in usuarios)
			{
				if (usuario.documento == documento)
				{
					return false;
				}
			}
			return true;
		}

		/***
			retorna una lista con todos los login que se tienen
		*/
		public IEnumerable<Log> GetLogs()
		{		
			var results = repositorioLogin.getQueryEntidad();
			return results;
		}

		/***
			Metodo que genera el bearer token, el cual cumple la funcion de dar la posibilidad al usuario de
			ingresar a navegar por nuestra aplicación durante determinado tiempo esto gracias a los claims 
			que crean el identificador y documento para general token que a su vez se pasara por la 
			encriptacion y su clave se codificara gracias a metodo base64encoder el cual almacena como
			cadena dicha encriptación que debe ser igual a la almacenada en la base de datos, ademas de
			que gracias a metodo MD5 generamos un codigo de token que se le mostrara por pantalla al usuario
			de esta manera mostrando que la autenticación fue exitosa en otro caso lanzaría error por el usuario
			o la contraseña que no se encuentran almacenados en la base de datos.
		*/
		public string LoginAsync(Log login)
        {   
			try
			{
				Usuario usuario =  this.GetUsuarios().Where(x=>x.documento == login.fkdocumento).FirstOrDefault();   
				Log log = this.GetLogs().Where(x=>x.fkdocumento == login.fkdocumento ).FirstOrDefault();
				var clave = Base64Encode(login.clave);
				Log usuarioLog = this.GetLogs().Where(x=> x.clave == clave).FirstOrDefault();

				if (usuario == null || log == null)
				{	
					throw new UsuariosException("El usuario no existe en la base de datos de usuario o login con ese documento.");
				}else if(usuarioLog == null)
				{
					throw new UsuariosException("La contraseña suministrada es incorrecta");
				}									
				IDocumentCollection<Log> Logs = repositorioLogin.getDataEntidad();

				var claims = new ClaimsIdentity();
				claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, log.fkdocumento));

				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = claims,
					Expires = DateTime.UtcNow.AddHours(4),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Convert.FromBase64String(clave)), SecurityAlgorithms.HmacSha256Signature)
				};
				var tokenHandler = new JwtSecurityTokenHandler();
				var createdToken = MD5(tokenDescriptor.ToString());
				string bearer_token = createdToken;
				return  bearer_token;
			}
			catch (System.Exception)
			{
				return null;
				throw new UsuariosException("Algo ocurrió durante la validación.");
			}
		}

		/***
			Codifica un string a base 64 y retorna dicho byte[] a string
		*/
		public static string Base64Encode(string word) 
        {
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(word);
            return Convert.ToBase64String(byt);
        }

		/***
			Decodifica una base64 a string y retorna dicho byte[] a string
		*/
        public static string Base64Decode(string word)
        {
            byte[] b = Convert.FromBase64String(word);
            return System.Text.Encoding.UTF8.GetString(b);
        }

		/***
			Metodo de encriptacion que recibe un string y se encarga de realizar el token de seguridad en la autenticacion.
		*/
		public static string MD5(string word) 
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(word));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

		/***
			Imprime un objeto en caso de necesitar que contiene este.
		*/
        private void PrintObject(string text, Object obj)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };
			Console.WriteLine(text + "\n" + JsonSerializer.Serialize(obj, options));
 		}
    }
}