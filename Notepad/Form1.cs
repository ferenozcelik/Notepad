using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class Form1 : Form
    {
        // Dialogs
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private FontDialog fontDialog;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fontDialog = new FontDialog();
        }




        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(richTextBox1.Text)) // if textbox is not empty
                {
                    SaveFile();
                }
                else
                {
                    Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Font = fontDialog.Font;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }




        /// <summary>
        /// Create new file
        /// </summary>
        private void NewFile()
        {
            try
            {
                if (!string.IsNullOrEmpty(richTextBox1.Text)) // if textbox is NOT null or empty
                {
                    MessageBox.Show("You need to save current file first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else // if textbox is empty
                {
                    richTextBox1.Text = string.Empty;
                    Text = "Untitled";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
        }

        /// <summary>
        /// Save the current file
        /// </summary>
        private void SaveFile()
        {
            try
            {
                if (!string.IsNullOrEmpty(richTextBox1.Text)) // if textbox is not empty
                {
                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Documents (*.txt) | *.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                        Text = saveFileDialog.FileName;
                    }
                }
                else // if textbox is empty
                {
                    MessageBox.Show("The file is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
        }


        /// <summary>
        /// Open the existing file
        /// </summary>
        private void OpenFile()
        {
            try
            {
                openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                    Text = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while trying to open the file", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                openFileDialog = null;
            }
        }


        private void SaveFileAs()
        {
            try
            {
                if (!string.IsNullOrEmpty(richTextBox1.Text)) // if textbox is not empty
                {
                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Documents (*.txt) | *.txt | All Files (*.*) | *.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                        Text = saveFileDialog.FileName;
                    }
                }
                else // if textbox is empty
                {
                    MessageBox.Show("The file is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
        }
        


    }
}
