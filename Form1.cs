namespace StellarisNanotechHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            textBox_filePath.Text = fileList[0];
        }


        private void search_button_Click(object sender, EventArgs e)
        {
            string savedataPath = textBox_filePath.Text;

            /* Check if the file exist and is a gamestate file */
            if (File.Exists(savedataPath) && savedataPath.EndsWith("gamestate"))
            {
                /* typical data */
                /*
			    planet_class="pc_g_star"
			    coordinate=
			    {
				    x=0
				    y=0
				    origin=382
				    randomized=no
				    visual_height=0.000000
			    }
			    orbit=0
			    planet_size=25
                */


                /* Read the file */
                int line_number = 0;


                string[] lines = File.ReadAllText(savedataPath).Split('\n');
                /* Search for plane_size, if plane_size>=25, show its planet_class*/
                foreach (string line in lines)
                {
                    line_number++;
                    if (line.Contains("planet_size"))
                    {
                        int planet_size = int.Parse(line.Split('=')[1].Trim());
                        if (planet_size >= 25)
                        {
                            /* search the first planet_class before it */
                            for (int i = line_number; i >= 0; i--)
                            {
                                if (lines[i].Contains("planet_class"))
                                {
                                    string planet_class = lines[i].Split('=')[1].Trim();
                                    /* check if planet_class is not _star or _gas_giant */
                                    if (planet_class.Contains("_star") || planet_class.Contains("_gas_giant") || planet_class.Contains("_black_hole"))
                                    {
                                        /*invalid planet_class*/
                                        break;
                                    }
                                    else { }

                                    output_box.Text += planet_class + " ";
                                    /* search the first key="PARENT" before it and show its value */
                                    string numeral = string.Empty;
                                    for (int j = line_number; j >= 0; j--)
                                    {
                                        if (lines[j].Contains("key=\"NUMERAL\""))
                                        {
                                            numeral = lines[j + 3].Split('=')[1];
                                        }
                                        else { }
                                        if (lines[j].Contains("key=\"PARENT\""))
                                        {
                                            output_box.Text += lines[j + 3].Split('=')[1] + " ";
                                            output_box.Text += numeral + "\r\n";
                                            break;
                                        }
                                        else { }
                                    }

                                    break;
                                }
                                else { }
                            }

                        }
                        else { }
                    }
                    else { }
                }
            }
            else
            {
                MessageBox.Show("Invalid file path");
            }
        }
    }
}
