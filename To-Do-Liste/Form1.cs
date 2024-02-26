using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace To_Do_Liste
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        public static DateTime Now { get; } // Uhrzeit holen
        private List<string> list = new List<string>();
        private int number = 1;

        public Form1()
        {
            InitializeComponent();
            timer.Interval = 1000; // Setzt das Intervall auf 1 Sekunde (1000 Millisekunden)
            timer.Tick += new EventHandler(timer1_Tick); // Fügt das Event hinzu, das bei jedem Tick aufgerufen wird
            timer.Start(); // Startet den Time
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                list.Add(textBox1.Text);
                textBox2.Text += number + "." + textBox1.Text + Environment.NewLine;
                number++;
            }
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            string searchText = textBox3.Text.Trim(); // Remove leading and trailing whitespace

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] == searchText)
                {
                    MessageBox.Show("Wert gelöscht: " + list[i]);
                    list.RemoveAt(i);
                    RefreshTextBox(); // Refresh the textbox after removing the item
                    number--;
                    return; // Exit the loop after finding and removing the item
                    
                }
            }

            MessageBox.Show("Wert nicht gefunden: " + searchText);
        }

        private void RefreshTextBox()
        {
            textBox2.Text = "";
            for (int i = 0; i < list.Count; i++)
            {
                textBox2.Text += (i + 1) + "." + list[i] + Environment.NewLine;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "";
            number = 1;
            list.Clear(); // Clear the list when clearing the textbox.
        }

        private void Ende_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox4.Text = DateTime.Now.ToString("HH:mm:ss"); // Aktualisiert den Text der TextBox bei jedem Tick

        }
    }
}
