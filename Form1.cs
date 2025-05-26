using System.Diagnostics.Eventing.Reader;
using System.Xml.Linq;

namespace StellarisNanotechHelper
{
    public partial class Form1 : Form
    {
        private bool needsTranslation = false; // Flag to indicate if translation is needed

        string[] namelist1 = File.ReadAllText($"{System.Environment.CurrentDirectory}" + "\\prescripted_countries_names_l_simp_chinese.yml").Split('\n');
        string[] namelist2 = File.ReadAllText($"{System.Environment.CurrentDirectory}" + "\\random_names_l_simp_chinese.yml").Split('\n');
        string[] namelist3 = File.ReadAllText($"{System.Environment.CurrentDirectory}" + "\\species_machine_names_l_simp_chinese.yml").Split('\n');

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
        private void buttom_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            textBox_filePath.Text = ofd.FileName;
        }


        private void search_button_Click(object sender, EventArgs e)
        {
            read_savedata();
        }

        private void read_savedata()
        {
            string savedataPath = textBox_filePath.Text;

            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 1000;
            progressBar1.Step = 1;

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
                string outputLine = string.Empty;

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
                                    /* check if planet_class is valid */
                                    if (planet_class.Contains("_star") || planet_class.Contains("_gas_giant") || planet_class.Contains("_black_hole"))
                                    {
                                        /*invalid planet_class*/
                                        break;
                                    }
                                    else { }

                                    //output_box.Text += planet_class + " ";

                                    /* search the first key="PARENT" before it and show its value */
                                    string numeral = string.Empty;
                                    string system_name = string.Empty;
                                    for (int j = line_number; j >= 0; j--)
                                    {
                                        if (lines[j].Contains("key=\"NUMERAL"))
                                        {
                                            numeral = lines[j + 3].Split('=')[1];
                                        }
                                        else { }
                                        if (lines[j].Contains("key=\"PARENT"))
                                        {
                                            system_name = lines[j + 3].Split('=')[1];
                                            if (system_name.Contains("\"STAR_NAME_"))
                                            {
                                                system_name = lines[j + 11].Split('=')[1];
                                            }
                                            else { }

                                            /* output system name, planet class and numeral */
                                            planet_class = planet_class.Replace("\"", ""); // Remove quotes from planet_class
                                            system_name = system_name.Replace("\"", ""); // Remove quotes from system_name
                                            numeral = numeral.Replace("\"", ""); // Remove quotes from numeral
                                            if (needsTranslation)
                                            {
                                                planet_class = translate_planet_class(planet_class);
                                                system_name = translate_system_name(system_name);
                                            }
                                            else
                                            {
                                                planet_class = planet_class.Replace("pc_", "");
                                            }
                                            outputLine = planet_class + " " + system_name + " " + numeral + "\r\n";

                                            output_box.Text += outputLine;
                                            progressBar1.PerformStep();
                                            //output_box.Text += lines[j + 3].Split('=')[1] + " ";
                                            //output_box.Text += numeral + "\r\n";
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
                progressBar1.Value = 0; /* Reset progress bar after completion */
            }
            else
            {
                MessageBox.Show("Invalid file path");
            }
        }

        private string translate_planet_class(string planet_class)
        {
            switch (planet_class)
            {
                case "pc_gas_giant":
                    return "��̬������";
                case "pc_asteroid":
                    return "С����";
                case "pc_molten":
                    return "��������";
                case "pc_frozen":
                    return "��������";
                case "pc_broken":
                    return "��������";
                case "pc_barren":
                    return "��������";
                case "pc_barren_cold":
                    return "��������";
                case "pc_desert":
                    return "ɳĮ����";
                case "pc_arid":
                    return "�ɺ�����";
                case "pc_tundra":
                    return "̦ԭ����";
                case "pc_continental":
                    return "½������";
                case "pc_tropical":
                    return "�ȴ�����";
                case "pc_ocean":
                    return "��������";
                case "pc_arctic":
                    return "��������";
                case "pc_alpine":
                    return "��ɽ����";
                case "pc_savannah":
                    return "��ԭ����";
                case "pc_habitat":
                case "pc_habitat_plural":
                    return "�����סվ";
                case "pc_toxic":
                    return "�綾����";
                case "pc_shrouded":
                    return "�龳����";
                case "pc_b_star":
                    return "B�ͺ���";
                case "pc_a_star":
                    return "A�ͺ���";
                case "pc_f_star":
                    return "F�ͺ���";
                case "pc_g_star":
                    return "G�ͺ���";
                case "pc_k_star":
                    return "K�ͺ���";
                case "pc_m_star":
                    return "M�ͺ���";
                case "pc_t_star":
                    return "T�ͺְ���";
                case "pc_m_giant_star":
                    return "M�ͺ����";
                case "pc_black_hole":
                    return "�ڶ�";
                case "pc_neutron_star":
                    return "������";
                case "pc_pulsar":
                    return "������";
                case "pc_toxoid_star":
                    return "���ʹ";
                case "pc_infested":
                    return "��������";
                case "pc_gaia":
                case "pc_gaia_plural":
                    return "��������";
                case "pc_nuked":
                case "pc_nuked_plural":
                    return "��������";
                case "pc_ringworld_habitable":
                case "pc_ringworld_tech":
                case "pc_ringworld_seam":
                    return "��������";
                case "pc_ringworld_habitable_damaged":
                case "pc_ringworld_tech_damaged":
                case "pc_ringworld_seam_damaged":
                    return "����Ļ�������";
                case "pc_shielded":
                    return "��������";
                case "pc_ai":
                    return "�˹���������";
                case "pc_machine":
                    return "��е����";
                case "pc_machine_broken":
                    return "�������˹���������";
                case "pc_hive":
                    return "�䳲����";
                case "pc_cybrex":
                    return "�������Σ������տ�˹��";
                case "pc_shattered":
                    return "��������";
                case "pc_ice_asteroid":
                    return "����С����";
                case "pc_crystal_asteroid":
                case "pc_rare_crystal_asteroid":
                    return "��̬С����";
                case "pc_shattered_ring_habitable":
                    return "����֮������";
                default:
                    /* translate not found, keep orignal string */
                    return planet_class;
            }
        }

        private string translate_system_name(string system_name)
        {
            switch (system_name)
            {
                case "NAME_Last_Thought":
                    return "����˼��";
                case "NAME_Trial_of_Survival":
                    return "��������";
                case "NAME_Klendath":
                    return "���״���";
                default:
                    break;
            }

            if (system_name.Contains("SPEC_"))
            {
                foreach (string name in namelist3)
                {
                    if (name.Contains(system_name))
                    {
                        /* Extract the translated name from the line */
                        //system_name = "translation found";
                        system_name = name.Split(':')[1].Trim();
                        system_name = system_name.Split('#')[0].Trim();
                        system_name = system_name.Replace("\"", "");
                        break;
                    }
                    else { }
                }
                system_name += "�����������/�Զ������ĸ��ϵ�� ";
                return system_name;
            }
            else { }

            if (system_name.Contains("PRESCRIPTED_"))
            {
                foreach (string name in namelist1)
                {
                    if (name.Contains(system_name))
                    {
                        /* Extract the translated name from the line */
                        //system_name = "translation found";
                        system_name = name.Split(':')[1].Trim();
                        system_name = system_name.Split('#')[0].Trim();
                        system_name = system_name.Replace("\"", "");
                        break;
                    }
                    else
                    {
                    }
                }
                system_name += "��������Ԥ�����ĸ��ϵ�� ";
                return system_name; /* If no translation found, return the original name */
            }
            else { }

            foreach (string name in namelist2)
            {
                if (name.Contains(system_name))
                {
                    /* Extract the translated name from the line */
                    //system_name = "translation found";
                    system_name = name.Split(':')[1].Trim();
                    system_name = system_name.Split('#')[0].Trim();
                    system_name = system_name.Replace("\"", "");
                    break;
                }
                else { }
            }

            return system_name; /* If no translation found, return the original name */
        }

        private void English_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            needsTranslation = false;
            search_button.Text = "search";
            buttom_browse.Text = "Browse";
            return;
        }

        private void Chinese_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            needsTranslation = true;
            search_button.Text = "��ʼ����";
            buttom_browse.Text = "���";
            return;
        }
    }
}
