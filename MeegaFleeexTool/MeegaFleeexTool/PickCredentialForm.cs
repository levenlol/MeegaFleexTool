using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeegaFleeexTool
{
    public partial class PickCredentialForm : Form
    {
        public PickCredentialForm()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string fileName = CredentialsGetter.FILE_NAME;

            string[] credentials = new string[2];
            credentials[0] = userTextBox.Text;
            credentials[1] = Crypt.Encrypt(passwordTextBox.Text, CredentialsGetter.KEY);

            File.WriteAllLines(fileName, credentials);

            Close();
        }
    }
}
