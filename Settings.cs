using Newtonsoft.Json;
using OdooRunner.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OdooRunner
{
    public partial class Settings : Form
    {
        private const string ConfigFilePath = "config.json";
        private OdooConfig config;

        public Settings()
        {
            InitializeComponent();
            LoadConfig();
        }

        private void LoadConfig()
        {
            if (File.Exists(ConfigFilePath))
            {
                string json = File.ReadAllText(ConfigFilePath);
                config = JsonConvert.DeserializeObject<OdooConfig>(json);
                lblPath.Text = config.OdooPath;
            }
            else
            {
                config = new OdooConfig();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.FileName = "odoo-bin";
                openFileDialog.Title = "Select odoo-bin file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    lblPath.Text = selectedFilePath;
                    config.OdooPath = selectedFilePath;
                }
            }
        }

        private void SaveConfig()
        {
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(ConfigFilePath, json);
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }
    }
}
