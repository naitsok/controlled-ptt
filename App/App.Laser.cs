using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;
using ControlledPTT.Lasers;
using System.Windows.Forms;
using System.Drawing;

namespace ControlledPTT
{
    /// <summary>
    /// This part of App class contains methods related to sensors
    /// </summary>
    partial class App
    {
        // Lasers
        private List<string> _laserPaths = new List<string>();
        private int _selectedLaserIndex = 0;
        // number of lasers installed in the default location 
        // needed to keep track of lasers added manually by user
        private int _numInstalledLasers = 0;
        private BaseLaser _laser = null;

        /// <summary>
        /// Enables or disables laser removal button is the sensors is added by
        /// user or installed in the default folder.
        /// </summary>
        private void EnableLaserRemoval()
        {
            if (cmbLasers.SelectedIndex >= _numInstalledLasers)
                btnRemoveLaser.Enabled = true;
            else
                btnRemoveLaser.Enabled = false;
        }

        /// <summary>
        /// Finds laser executables and populates the dropdown list.
        /// </summary>
        /// <param name="laserPath">Path to laser executables</param>
        /// <param name="selectedIndex">Selected index for dropdownlist</param>
        private void FindLasers(string laserPath, JArray userLasers, int selectedIndex)
        {
            if (!Path.IsPathRooted(laserPath))
            {
                laserPath = Path.GetFullPath(Path.Combine(BASE_DIR, laserPath));
            }
            ofdSelectLaser.InitialDirectory = laserPath;

            string[] allLaserExes = Directory.GetFiles(laserPath, "*.exe", SearchOption.AllDirectories);
            List<string> laserTitles = new List<string>();
            foreach (string laserExe in allLaserExes)
            {
                if (!laserExe.Contains("ref"))
                {
                    _laserPaths.Add(laserExe);
                    Assembly laserAssembly = Assembly.LoadFrom(laserExe);
                    Type[] types = laserAssembly.GetExportedTypes();
                    BaseLaser laser = Activator.CreateInstance(types[0]) as BaseLaser;
                    laserTitles.Add(laser.Title);
                }
            }

            cmbLasers.Items.AddRange(laserTitles.ToArray());
            _numInstalledLasers = laserTitles.Count;

            // Finally load the sensors added by user
            foreach (JToken laser in userLasers)
            {
                cmbLasers.Items.Add(laser["title"]);
                _laserPaths.Add(Path.GetFullPath((string)laser["path"]));
            }

            if (selectedIndex < cmbLasers.Items.Count)
                cmbLasers.SelectedIndex = selectedIndex;

            EnableLaserRemoval();
        }

        /// <summary>
        /// Opens dialog to select laser executable manually.
        /// Gets the filename of selected executable and adds it to the list of sensors to be loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadLaser_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdSelectLaser.ShowDialog();
            if (result == DialogResult.OK)
            {
                // get sensor executable title and add it to list
                Assembly laserAssembly = Assembly.LoadFrom(ofdSelectLaser.FileName);
                Type[] types = laserAssembly.GetExportedTypes();
                BaseLaser laser = Activator.CreateInstance(types[0]) as BaseLaser;
                string laserTitle = laser.Title;
                if (cmbLasers.Items.Contains(laserTitle))
                {
                    int i = 1;
                    laserTitle = laserTitle + " (" + i.ToString() + ")";
                    while (true)
                    {
                        if (!cmbLasers.Items.Contains(laserTitle))
                            break;
                    }
                }

                cmbLasers.Items.Add(laserTitle);
                _laserPaths.Add(ofdSelectLaser.FileName);
                cmbLasers.SelectedIndex = cmbLasers.Items.Count - 1;
                EnableLaserRemoval();
            }
        }

        /// <summary>
        /// Checks if the selected laser is added by user. Then this laser can be deleted.
        /// Lasers installed in their default location cannot be removed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbLasers_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableLaserRemoval();
        }

        /// <summary>
        /// Removes laser from the list if the laser was added by user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveLaser_Click(object sender, EventArgs e)
        {
            if (cmbLasers.SelectedIndex >= _numInstalledLasers)
            {
                _laserPaths.RemoveAt(cmbLasers.SelectedIndex);
                cmbLasers.Items.RemoveAt(cmbLasers.SelectedIndex);
                cmbLasers.SelectedIndex = 0;
                EnableLaserRemoval();
            }
        }

        /// <summary>
        /// Starts the selected laser.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartLaser_Click(object sender, EventArgs e)
        {
            // check the sensor part to exists
            if (!File.Exists(_laserPaths[cmbLasers.SelectedIndex]))
            {
                MessageBox.Show("The laser part is not found on path " +
                    _laserPaths[cmbLasers.SelectedIndex] +
                    ". Check the config file or load the part manually using \"Load\" button.",
                    "Laser part not found.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // load the sensor part
            Assembly laserAssembly = Assembly.LoadFrom(_laserPaths[cmbLasers.SelectedIndex]);
            Type[] types = laserAssembly.GetExportedTypes();
            _laser = Activator.CreateInstance(types[0]) as BaseLaser;
            _laser.FormClosed += laser_FormClosed;
            _laser.Show();

            // Organize windows
            _laser.Location = new Point(Location.X + Size.Width + 10, 10);

            // Disable controls
            gbLaser.Enabled = false;
        }

        /// <summary>
        /// When laser form is closed, the resources must be released.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void laser_FormClosed(object sender, FormClosedEventArgs e)
        {
            _laser.FormClosed -= laser_FormClosed;
            _laser.Dispose();
            _laser = null;
            gbLaser.Enabled = true;
        }
    }
}
