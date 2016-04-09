using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework.Forms
{
    public partial class FormForRecords : Form
    {
        public FormForRecords( string s)//пытаюсь создавать динамически поля (чтобы не городить множество форм)
        {
            int displacement = 10;
            int X0 = 10;
            int WidthOfLabels = 100;
            InitializeComponent();
            switch (s)
            {
                case "product":
                    {
                        Label idLabel = new Label();
                        idLabel.Text = "ID записи";
                        idLabel.Location = new Point(X0, displacement);
                        idLabel.Width = WidthOfLabels;
                        this.Controls.Add(idLabel);

                        TextBox tbID = new TextBox();
                        tbID.Text = "";
                        tbID.Multiline = false;
                        tbID.Width = WidthOfLabels;
                        tbID.Location = new Point(X0 + idLabel.Width, displacement);
                        this.Controls.Add(tbID);
                        break;
                    }
                case "provider": { break; }
                case "sale": { break; }
                case "manager": { break; }
                case "storage":  { break; }
            }
               
        }

        private void FormForRecords_Load(object sender, EventArgs e)
        {

        }
    }
}
