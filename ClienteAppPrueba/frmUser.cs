using ClienteAppPrueba.Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteAppPrueba
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        public User usuario;
        public List<User> listaUsuario;

        public void cargarUser() {
            try
            {
                usuario = new User();  
                listaUsuario = new List<User>();
                listaUsuario = usuario.findAll();
                //int t = listaUsuario.Count;
                foreach (User u in listaUsuario) {
                    dtUser.Rows.Add(u.Id, u.Name, u.Age, u.Mail);
                }

                
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarUser();
        }
    }
}
