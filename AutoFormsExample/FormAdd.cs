using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace AutoFormsExample
{
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string resultrule = "";

            string str = textBoxAddQueryRules.Text;
            string[] ItemsRule = str.Split(' ');

            resultrule = $"(defrule {ItemsRule[0]} \"\"\n\t({ItemsRule[1]} {ItemsRule[2]})\n\t(not ({ItemsRule[3]} ?))\n\t(not (conclusion))\n\t=>\n\t(bind ? answers(create$ no yes))" +
                $"\n\t(handle-state interview\n\t\t?*target*\n\t\t(find-text-for-id {ItemsRule[4]})\n\t\t{ItemsRule[3]}\n\t\t(nht$ 1 ?answers)\n\t\t?answers\n\t\t(translate-av ?answers)))";

            MessageBox.Show(resultrule);
            textBoxAddQueryRules.Clear();
        }

        private void buttonAddQueryRules_Click(object sender, EventArgs e)
        {
            string resultrule = "";
            int countline = 0;

            var exePath = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(exePath, @"auto.clp");

            string str = textBoxAddQueryRules.Text;
            string[] ItemsRule = str.Split(' ');

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != ";;;* REPAIR RULES *")
                {
                    countline++;
                }
            }

            var text = File.ReadAllLines(path).ToList();
            text.Insert(countline - 2, resultrule);
            File.WriteAllLines(path, text.ToArray());
            MessageBox.Show("Готово");
            textBoxAddQueryRules.Clear();
        }

        private void buttonMakeRepair_Click(object sender, EventArgs e)
        {
            string resultrule = "";

            string str = textBoxAddRepairRules.Text;
            string[] ItemsRule = str.Split(' ');

            resultrule = $"(defrule {ItemsRule[0]} \"\"\n\t(declare(salience {ItemsRule[1]}))\n\t({ItemsRule[2]} yes)\n\t=>\n\t(handle-state conclusion *target* (find-text-for-id {ItemsRule[3]})))";

            MessageBox.Show(resultrule);
            textBoxAddRepairRules.Clear();
        }

        private void buttonAddRepairRules_Click(object sender, EventArgs e)
        {
            string resultrule = "";
            int countline = 0;

            var exePath = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(exePath, @"auto.clp");

            string str = textBoxAddRepairRules.Text;
            string[] ItemsRule = str.Split(' ');

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    countline++;
                }
            }

            resultrule = $"(defrule {ItemsRule[0]} \"\"\n\t(declare(salience {ItemsRule[1]}))\n\t({ItemsRule[2]} yes)\n\t=>\n\t(handle-state conclusion *target* (find-text-for-id {ItemsRule[3]})))";

            var text = File.ReadAllLines(path).ToList();
            text.Insert(countline, "\n" + resultrule);
            File.WriteAllLines(path, text.ToArray());

            MessageBox.Show("Готово");
            textBoxAddRepairRules.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}
