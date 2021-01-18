using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//here we go again
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        Boolean language = false; // false - Russian, true - English
        byte measure_system = 1; // 1 - meters, 2 - centimetrs, 3 - inches
        string metr_ru = "м";
        string metr_en = "m";
        string centim_ru = "см";
        string centim_en = "cm";
        string inch_ru = "дюйм";
        string inch_en = "inch";
        string width_ru = "Ширина";
        string width_en = "Width";
        string lenght_ru = "Длина";
        string lenght_en = "Lenght";
        string height_ru = "Высота";
        string height_en = "Height";
        string wallarea_ru = "Площадь стен";
        string wallarea_en = "Wallarea";
        string perimetr_ru = "Периметр";
        string perimetr_en = "Perimetr";
        string groundarea_ru = "Площадь пола/потолка";
        string groundarea_en = "Ground area/хз как на анг";
        float wallarea = 0;
        float perimetr = 0;
        float groundarea = 0;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            float height1 = float.Parse(height_textbox.Text);
            float width1 = float.Parse(width_textbox.Text);
            float length1 = float.Parse(length_textbox.Text);
            wallarea = (width1*height1+length1*height1) * 2;
            perimetr = (width1 + length1) * 2;
            groundarea = width1 * length1;
            wallArea_textbox.Text = wallarea.ToString();
            perimetr_textbox.Text = perimetr.ToString();
            ground_textbox.Text = groundarea.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //language button
        {
            language = !language;
            if (language)
            {
                
                language_bt.Content = "Русский";
                switch (measure_system)
                {
                    case 1:
                        width_label.Content = width_ru + ", " + metr_ru;
                        length_label.Content = lenght_ru + ", " + metr_ru;
                        height_label.Content = height_ru + ", " + metr_ru;
                        perimetr_label.Content = perimetr_ru + ", " + metr_ru;
                        groundarea_label.Content = groundarea_ru + ", " + metr_ru;
                        wallArea_label.Content = wallarea_ru + ", " + metr_ru + "\u00B2";
                        measure_bt.Content = "Метры";
                        break;
                    case 2:
                        width_label.Content = width_ru + ", " + centim_ru;
                        length_label.Content = lenght_ru + ", " + centim_ru;
                        height_label.Content = height_ru + ", " + centim_ru;
                        perimetr_label.Content = perimetr_ru + ", " + centim_ru;
                        width_label.Content = width_ru + ", " + centim_ru;
                        wallArea_label.Content = wallarea_ru + ", " + centim_ru + "\u00B2";
                        measure_bt.Content = "Сантиметры";
                        break;
                    case 3:
                        width_label.Content = width_ru + ", " + inch_ru;
                        length_label.Content = lenght_ru + ", " + inch_ru;
                        height_label.Content = height_ru + ", " + inch_ru;
                        perimetr_label.Content = perimetr_ru + ", " + inch_ru;
                        width_label.Content = width_ru + ", " + inch_ru;
                        wallArea_label.Content = wallarea_ru + ", " + inch_ru + "\u00B2";
                        measure_bt.Content = "Дюймы";
                        break;
                }
            }
            else
            {
                language_bt.Content = "English";
                switch (measure_system)
                {
                    case 1:
                        width_label.Content = width_en + ", " + metr_en;
                        length_label.Content = lenght_en + ", " + metr_en;
                        height_label.Content = height_en + ", " + metr_en;
                        perimetr_label.Content = perimetr_en + ", " + metr_en;
                        groundarea_label.Content = groundarea_en + ", " + metr_en;
                        wallArea_label.Content = wallarea_en + ", " + metr_en + "\u00B2";
                        measure_bt.Content = "Meters";
                        break;
                    case 2:
                        width_label.Content = width_en + ", " + centim_en;
                        length_label.Content = lenght_en + ", " + centim_en;
                        height_label.Content = height_en + ", " + centim_en;
                        perimetr_label.Content = perimetr_en + ", " + centim_en;
                        width_label.Content = width_en + ", " + centim_en;
                        wallArea_label.Content = wallarea_en + ", " + centim_en + "\u00B2";
                        measure_bt.Content = "Centimetrs";
                        break;
                    case 3:
                        width_label.Content = width_en + ", " + inch_en;
                        length_label.Content = lenght_en + ", " + inch_en;
                        height_label.Content = height_en + ", " + inch_en;
                        perimetr_label.Content = perimetr_en + ", " + inch_en;
                        width_label.Content = width_en + ", " + inch_en;
                        wallArea_label.Content = wallarea_en + ", " + inch_en + "\u00B2";
                        measure_bt.Content = "Inches";
                        break;
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) // measure system button
        {

            switch (measure_system)
            {
                case 1:
                    if (language)
                    {
                        width_label.Content = width_ru + ", " + metr_ru;
                        length_label.Content = lenght_ru + ", " + metr_ru;
                        height_label.Content = height_ru + ", " + metr_ru;
                        perimetr_label.Content = perimetr_ru + ", " + metr_ru;
                        groundarea_label.Content = groundarea_ru + ", " + metr_ru;
                        wallArea_label.Content = wallarea_ru + ", " + metr_ru + "\u00B2";
                        measure_bt.Content = "Метры";
                    }
                    else
                    {
                        width_label.Content = width_en + ", " + metr_en;
                        length_label.Content = lenght_en + ", " + metr_en;
                        height_label.Content = height_en + ", " + metr_en;
                        perimetr_label.Content = perimetr_en + ", " + metr_en;
                        groundarea_label.Content = groundarea_en + ", " + metr_en;
                        wallArea_label.Content = wallarea_en + ", " + metr_en + "\u00B2";
                        measure_bt.Content = "Meters";
                    }
                    measure_system += 1;
                    break;
                case 2:
                    if (language)
                    {
                        width_label.Content = width_ru + ", " + centim_ru;
                        length_label.Content = lenght_ru + ", " + centim_ru;
                        height_label.Content = height_ru + ", " + centim_ru;
                        perimetr_label.Content = perimetr_ru + ", " + centim_ru;
                        width_label.Content = width_ru + ", " + centim_ru;
                        wallArea_label.Content = wallarea_ru + ", " + centim_ru + "\u00B2";
                        measure_bt.Content = "Сантиметры";
                    }
                    else
                    {
                        width_label.Content = width_en + ", " + centim_en;
                        length_label.Content = lenght_en + ", " + centim_en;
                        height_label.Content = height_en + ", " + centim_en;
                        perimetr_label.Content = perimetr_en + ", " + centim_en;
                        width_label.Content = width_en + ", " + centim_en;
                        wallArea_label.Content = wallarea_en + ", " + centim_en + "\u00B2";
                        measure_bt.Content = "Centimetrs";
                    }
                    measure_system += 1;
                    break;
                case 3:
                    if (language)
                    {
                        width_label.Content = width_ru + ", " + inch_ru;
                        length_label.Content = lenght_ru + ", " + inch_ru;
                        height_label.Content = height_ru + ", " + inch_ru;
                        perimetr_label.Content = perimetr_ru + ", " + inch_ru;
                        width_label.Content = width_ru + ", " + inch_ru;
                        wallArea_label.Content = wallarea_ru + ", " + inch_ru + "\u00B2";
                        measure_bt.Content = "Дюймы";
                    }
                    else
                    {
                        width_label.Content = width_en + ", " + inch_en;
                        length_label.Content = lenght_en + ", " + inch_en;
                        height_label.Content = height_en + ", " + inch_en;
                        perimetr_label.Content = perimetr_en + ", " + inch_en;
                        width_label.Content = width_en + ", " + inch_en;
                        wallArea_label.Content = wallarea_en + ", " + inch_en + "\u00B2";
                        measure_bt.Content = "Inches";
                    }
                    measure_system = 1;
                    break;
            }    

        }


            



        
    }
}
