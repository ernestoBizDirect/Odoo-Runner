using Newtonsoft.Json;
using OdooRunner.data;
using System.Diagnostics;

namespace OdooRunner
{
    public partial class Form1 : Form
    {
        private const string ConfigFilePath = "config.json";
        private OdooConfig config;
        private Process odooProcess;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            LoadConfig();
            DisplayConfig();
        }

        private void LoadConfig()
        {
            if (File.Exists(ConfigFilePath))
            {
                string json = File.ReadAllText(ConfigFilePath);
                config = JsonConvert.DeserializeObject<OdooConfig>(json);
            }
            else
            {
                config = new OdooConfig()
                {
                    OdooPath = ""
                };
            }
        }

        private void DisplayConfig()
        {
            lstConfiguration.Items.Clear();
            foreach (var setting in config.OdooSettings)
            {
                lstConfiguration.Items.Add(setting.FileName);
            }
        }

        private void stgsMenu_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();
            settingsForm.ShowDialog();
            Init();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(config.OdooPath))
            {
                MessageBox.Show("Odoo path is not configured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lstConfiguration.SelectedItem == null)
            {
                MessageBox.Show("There are no settings selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedConfigFileName = lstConfiguration.SelectedItem.ToString();
            OdooSetting selectedSetting = config.OdooSettings.FirstOrDefault(setting => setting.FileName == selectedConfigFileName);

            if (selectedSetting != null)
            {
                // Verificar si el proceso de Odoo ya está en ejecución
                if (IsOdooRunning())
                {
                    MessageBox.Show("The Odoo server is now running.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string command = $"python \"{config.OdooPath}\" -c \"{selectedSetting.FilePath}\"";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C {command}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                try
                {
                    odooProcess = new Process();
                    odooProcess.StartInfo = psi;
                    odooProcess.EnableRaisingEvents = true;
                    odooProcess.OutputDataReceived += OdooProcess_OutputDataReceived;
                    odooProcess.ErrorDataReceived += OdooProcess_ErrorDataReceived;

                    odooProcess.Start();
                    odooProcess.BeginOutputReadLine();
                    odooProcess.BeginErrorReadLine();

                    MessageBox.Show($"Odoo server started", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while executing the command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsOdooRunning()
        {
            Process[] processes = Process.GetProcessesByName("python");
            return processes.Length > 0;
        }

        private void OdooProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                txtOdooLog.Invoke(new Action(() =>
                {
                    txtOdooLog.AppendText(e.Data + Environment.NewLine);
                }));
            }
        }

        private void OdooProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                txtOdooLog.Invoke(new Action(() =>
                {
                    txtOdooLog.AppendText(e.Data + Environment.NewLine);
                }));
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (odooProcess != null)
            {
                try
                {
                    int odooProcessId = odooProcess.Id;

                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = "/C taskkill /F /IM python.exe",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    using (Process process = Process.Start(psi))
                    {
                        string output = process.StandardOutput.ReadToEnd();
                        string error = process.StandardError.ReadToEnd();
                        process.WaitForExit();

                        if (process.ExitCode == 0)
                        {
                            MessageBox.Show("The Odoo server has been stopped.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtOdooLog.Clear();
                        }
                        else
                        {
                            MessageBox.Show($"Could not stop Odoo server. Error: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while stopping the Odoo server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    odooProcess.Dispose();
                    odooProcess = null;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Config Files (*.conf)|*.conf",
                Title = "Select configuration file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog.FileName);
                lstConfiguration.Items.Add(fileName);
                config.OdooSettings.Add(new OdooSetting
                {
                    FileName = fileName,
                    FilePath = openFileDialog.FileName
                });
            }

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(ConfigFilePath, json);

            MessageBox.Show("Successfully saved!");
        }

        private void lstConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstConfiguration.SelectedItem != null)
            {
                lblConfig.Text = lstConfiguration.SelectedItem.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstConfiguration.SelectedItem != null)
            {
                var selectedConfig = config.OdooSettings.FirstOrDefault((element) => element.FileName == lstConfiguration.SelectedItem.ToString());
                lstConfiguration.Items.Remove(lstConfiguration.SelectedItem);
                lblConfig.Text = "";

                if (selectedConfig != null)
                {
                    config.OdooSettings.Remove(selectedConfig);
                    string json = JsonConvert.SerializeObject(config, Formatting.Indented);
                    File.WriteAllText(ConfigFilePath, json);

                    MessageBox.Show("Successfully deleted!");
                }
            }
        }
    }
}