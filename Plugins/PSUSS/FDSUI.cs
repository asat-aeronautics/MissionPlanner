
// Requires that the image names that are given are chronologically in ascending alphabetical order


using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PSUSS
{
    public partial class FDSUI : MyUserControl
    {
        public string path = @"C:\Users\asata\Documents\swd-repos\dummy photos";
        int idx =0;
        public FDSUI()
        {
            InitializeComponent();
        }

        private void FDSUI_Load(object sender, EventArgs e)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();

            watcher.Path = path;
            watcher.NotifyFilter = NotifyFilters.LastAccess
                | NotifyFilters.LastWrite
                | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;
            watcher.Created += OnCreated;
            watcher.EnableRaisingEvents = true;

//            string[] files = Directory.GetFiles(path);

 /*           int i = 0;
            foreach (var image in files)
            {
                listView1.Items.Add(Path.GetFileName(image),i);
                imageList1.Images.Add(Image.FromFile(image));
                i = i+1;
                
            }
*/
            listView1.SmallImageList = imageList1;  
            listView1.LargeImageList = imageList1;
            listView1.Sorting = SortOrder.Descending;
            listView1.MultiSelect = false;
 /*           listView1.Items[0].Selected = true;*/
           
        }
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }


        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedImage = listView1.SelectedItems[0].Text;
                var fullPath = Path.Combine(path, selectedImage);
                pictureBox1.Image = Image.FromFile(fullPath);
                pictureBox1.Show();
            }       
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            listView1.SelectedItems.Clear();

            listView1.BeginUpdate();
            listView1.Items.Add(Path.GetFileName(e.FullPath.ToString()), idx);
            imageList1.Images.Add(Image.FromFile(e.FullPath.ToString()));
            listView1.EndUpdate();

            listView1.Items[0].Selected = true;
            idx = idx + 1;
        }

    }
}
/* Button to stop the live feed / slide show
 * Change color when selected and while hover
 * change color of item when % > x
 * diplay image data
 */