using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbr_line_split
{
    public partial class Window: Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private void convertbtn_Click(object sender, EventArgs e)
        {
            this.convertbtn.Enabled = false;
            int max = (int)this.numericUpDown1.Value;
            string text = this.policyfield.Text;
            if(!text.Contains(' '))
            {
                MessageBox.Show("Error: the policy does not contain spaces.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //first count how many occurences we get by dividing all spaces by max.
            int occurencies = text.Split(' ').Length;

            if ((occurencies / max) <= 0) {
                MessageBox.Show("Error: the policy is less than the maximum defined spaces.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Console.WriteLine("occurencies: " + occurencies/max);

            string[] list = text.Split(' ');
            int index = 0;
            Console.WriteLine("max:"+max);
            for(int occurence = 0; occurence <= list.Length/max-1; occurence++) {

                Console.WriteLine("occurence: "+occurence);

                StringBuilder build = new StringBuilder();
                for(int i = 0; i < max; i++)
                {
                    Console.WriteLine("i:"+(i+index));
                    build.Append(list[i + index]).Append(" ");   
                }
     

                result.Text += "Policy #" + occurence + ": "+build.ToString().TrimEnd(' ')+"\n\n";
                result.Update();
                index+=max;
            }

            if (index < list.Length - 1)
            {
                //okay we add the remaining ones.
                StringBuilder build = new StringBuilder();
                for (int i = index; i <= list.Length-1; i++) {
                    Console.WriteLine("i:" + i);
                    build.Append(list[i]).Append(" ");
                }
                result.Text += "Policy #" + (occurencies / max+1) + ": " + build.ToString().TrimEnd(' ') + "\n\n";
                result.Update();
                index += max;
            }

            Console.WriteLine("size: "+(list.Length-1));

            this.result.Update();
            this.convertbtn.Enabled = true;
        }
    }
}
