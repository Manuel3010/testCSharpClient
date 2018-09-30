using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace ClienteAppPrueba.Entidad
{
    public class User
    {
        private int id;
        private String name;
        private int age;
        private String mail;
        protected String url="http://localhost:21722/test/ws/users";
        protected String json;
        protected JavaScriptSerializer serializador;
        

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Mail { get => mail; set => mail = value; }

        public User(int id, string name, int age, string mail)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.mail = mail;
        }

        public User()
        {
        }


        public List<User> findAll() {
            List<User> lista = new List<User>(); 
            try {
                json = new WebClient().DownloadString(url);
                serializador = new JavaScriptSerializer();
                lista = serializador.Deserialize<List<User>>(json);

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }

            return lista;
        } 
        public User findById(Object id)
        {
            User usuario = new User();
            try {
                String urlId = url+"/"+ id;
                json = new WebClient().DownloadString(urlId);
                serializador = new JavaScriptSerializer();
                usuario = serializador.Deserialize<User>(json);


            } catch(Exception ex)
            {
                throw new Exception(ex.Message); 
            }

            return usuario;
        }

    }
}
