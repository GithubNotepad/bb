namespace ASimpleNotepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "MyNotepad";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            openFileDialog1.ShowDialog();

            

            textBox1.Text= File.ReadAllText(openFileDialog1.FileName);
            lblWorkingFile.Text = openFileDialog1.FileName;

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {


            InitiateSave();
            


        }
        public void InitiateSave()
        {

            if (lblWorkingFile.Text.Length >= 0)
            {
                File.WriteAllText(lblWorkingFile.Text, textBox1.Text);
                lblModified.Text = "";
            }
            else { Save(); }
        }
        public void Save()
        {
            saveFileDialog1.Filter = "text File |*.txt";
            saveFileDialog1.ShowDialog();

            File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
            lblModified.Text = "";

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBox1.Font = fontDialog1.Font;
;
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lblModified.Text = "*";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lblModified.Text == "*")
            {
               DialogResult result= MessageBox.Show("Do you Want To Save", "Unsaved Changes",MessageBoxButtons.YesNoCancel);


                if (result == DialogResult.Yes)
                {
                    InitiateSave();
                }
                if (result == DialogResult.No) { }
                if (result == DialogResult.Cancel)
                {

                }
            }
        }
    }
}