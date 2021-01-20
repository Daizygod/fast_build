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
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            grid_paint_calc.Visibility = Visibility.Hidden;
            paint_options_grid.Visibility = Visibility.Hidden;
            space_grid.Visibility = Visibility.Hidden;
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        Boolean language = true; // false - Russian, true - English
        byte measure_system = 1; // 1 - meters, 2 - centimetrs, 3 - inches
        string measure_ln = "м";
        string centim_ln;
        string inch_ln;
        string metr_ln;
        string height_ln;
        string width_ln;
        string lenght_ln;
        string wallarea_ln;
        string perimetr_ln;
        string groundarea_ln;
        string metr_ru = "м";
        string metr_en = "m";
        string centim_ru = "см";
        string centim_en = "cm";
        string inch_ru = "дюйм";
        string inch_en = "inch";
        string width_ru = "Ширина";
        string width_en = "width";
        string lenght_ru = "Длина";
        string lenght_en = "Lenght";
        string height_ru = "Высота";
        string height_en = "Height";
        string wallarea_ru = "Площадь";
        string wallarea_en = "Square area";
        string perimetr_ru = "Периметр";
        string perimetr_en = "Perimetr";
        string groundarea_ru = "Площадь пола/потолка";
        string groundarea_en = "Ground/ceiling area";
        float wallarea = 0;
        float perimetr = 0;
        float groundarea = 0;
        float height1;
        float width1;
        float length1;
        float space_width;
        float space_height;
        float space_square;
        int space_id = 0;
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            height1 = float.Parse(height_textbox.Text);
            width1 = float.Parse(width_textbox.Text);
            length1 = float.Parse(length_textbox.Text);
            wallarea = (width1 * height1 + length1 * height1) * 2;
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
                simple_room.Text = "Обычная комната";
                centim_ln = centim_ru;
                inch_ln = inch_ru;
                metr_ln = metr_ru;
                height_ln = height_ru;
                width_ln = width_ru;
                wallarea_ln = wallarea_ru;
                perimetr_ln = perimetr_ru;
                groundarea_ln = groundarea_ru;
                lenght_ln = lenght_ru;
                metr_ln = metr_ru;
                centim_ln = centim_ru;
                inch_ln = inch_ru;
                language_bt.Content = "English";
                switch (measure_system)
                {
                    case 1:
                        width_label.Content = width_ln + ", " + metr_ln;
                        length_label.Content = lenght_ln + ", " + metr_ln;
                        height_label.Content = height_ln + ", " + metr_ln;
                        perimetr_label.Content = perimetr_ln + ", " + metr_ln;
                        groundarea_label.Content = groundarea_ln + ", " + metr_ln;
                        wallArea_label.Content = wallarea_ln + ", " + metr_ln + "\u00B2";
                        groundarea_label.Content = groundarea_ln + ", " + metr_ln + "\u00B2";
                        measure_bt.Content = "Метры";
                        measure_ln = metr_ln;
                        break;
                    case 2:
                        width_label.Content = width_ln + ", " + centim_ln;
                        length_label.Content = lenght_ln + ", " + centim_ln;
                        height_label.Content = height_ln + ", " + centim_ln;
                        perimetr_label.Content = perimetr_ln + ", " + centim_ln;
                        width_label.Content = width_ln + ", " + centim_ln;
                        wallArea_label.Content = wallarea_ln + ", " + centim_ln + "\u00B2";
                        groundarea_label.Content = groundarea_ln + ", " + centim_ln + "\u00B2";
                        measure_bt.Content = "Сантиметры";
                        measure_ln = centim_ln;
                        break;
                    case 3:
                        width_label.Content = width_ln + ", " + inch_ln;
                        length_label.Content = lenght_ln + ", " + inch_ln;
                        height_label.Content = height_ln + ", " + inch_ln;
                        perimetr_label.Content = perimetr_ln + ", " + inch_ln;
                        width_label.Content = width_ln + ", " + inch_ln;
                        wallArea_label.Content = wallarea_ln + ", " + inch_ln + "\u00B2";
                        groundarea_label.Content = groundarea_ln + ", " + inch_ln + "\u00B2";
                        measure_bt.Content = "Дюймы";
                        measure_ln = inch_ln;
                        break;
                }
            }
            else
            {
                language_bt.Content = "Русский";
                simple_room.Text = "Simple room";
                centim_ln = centim_en;
                inch_ln = inch_en;
                metr_ln = metr_en;
                height_ln = height_en;
                width_ln = width_en;
                wallarea_ln = wallarea_en;
                perimetr_ln = perimetr_en;
                groundarea_ln = groundarea_en;
                lenght_ln = lenght_en;
                switch (measure_system)
                {
                    case 1:
                        width_label.Content = width_ln + ", " + metr_ln;
                        length_label.Content = lenght_ln + ", " + metr_ln;
                        height_label.Content = height_ln + ", " + metr_ln;
                        perimetr_label.Content = perimetr_ln + ", " + metr_ln;
                        groundarea_label.Content = groundarea_ln + ", " + metr_ln;
                        wallArea_label.Content = wallarea_ln + ", " + metr_ln + "\u00B2";
                        groundarea_label.Content = groundarea_ln + ", " + metr_ln + "\u00B2";
                        measure_bt.Content = "Meters";
                        measure_ln = metr_ln;
                        break;
                    case 2:
                        width_label.Content = width_ln + ", " + centim_ln;
                        length_label.Content = lenght_ln + ", " + centim_ln;
                        height_label.Content = height_ln + ", " + centim_ln;
                        perimetr_label.Content = perimetr_ln + ", " + centim_ln;
                        width_label.Content = width_ln + ", " + centim_ln;
                        wallArea_label.Content = wallarea_ln + ", " + centim_en + "\u00B2";
                        groundarea_label.Content = groundarea_ln + ", " + centim_ln + "\u00B2";
                        measure_bt.Content = "Centimetrs";
                        measure_ln = centim_ln;
                        break;
                    case 3:
                        width_label.Content = width_ln + ", " + inch_ln;
                        length_label.Content = lenght_ln + ", " + inch_ln;
                        height_label.Content = height_ln + ", " + inch_ln;
                        perimetr_label.Content = perimetr_ln + ", " + inch_ln;
                        width_label.Content = width_ln + ", " + inch_ln;
                        wallArea_label.Content = wallarea_ln + ", " + inch_ln + "\u00B2";
                        groundarea_label.Content = groundarea_ln + ", " + inch_ln + "\u00B2";
                        measure_bt.Content = "Inches";
                        measure_ln = inch_ln;
                        break;
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) // measure system button
        {
            if (measure_system < 3) measure_system += 1; else measure_system = 1;
            switch (measure_system)
            {
                case 1:
                    wallarea = wallarea * 254 / 10000;
                    perimetr = perimetr * 254 / 10000;
                    groundarea = groundarea * 254 / 10000;
                    wallArea_textbox.Text = wallarea.ToString();
                    perimetr_textbox.Text = perimetr.ToString();
                    ground_textbox.Text = groundarea.ToString();
                    if (language)
                    {
                        width_label.Content = width_ru + ", " + metr_ru;
                        length_label.Content = lenght_ru + ", " + metr_ru;
                        height_label.Content = height_ru + ", " + metr_ru;
                        perimetr_label.Content = perimetr_ru + ", " + metr_ru;
                        groundarea_label.Content = groundarea_ru + ", " + metr_ru;
                        wallArea_label.Content = wallarea_ru + ", " + metr_ru + "\u00B2";
                        groundarea_label.Content = groundarea_ru + ", " + metr_ru + "\u00B2";
                        measure_bt.Content = "Метры";
                        measure_ln = metr_ru;
                    }
                    else
                    {
                        width_label.Content = width_en + ", " + metr_en;
                        length_label.Content = lenght_en + ", " + metr_en;
                        height_label.Content = height_en + ", " + metr_en;
                        perimetr_label.Content = perimetr_en + ", " + metr_en;
                        groundarea_label.Content = groundarea_en + ", " + metr_en;
                        wallArea_label.Content = wallarea_en + ", " + metr_en + "\u00B2";
                        groundarea_label.Content = groundarea_en + ", " + metr_en + "\u00B2";
                        measure_bt.Content = "Meters";
                        measure_ln = metr_en;
                    }
                    
                    break;
                case 2:
                    wallarea = wallarea * 100;
                    perimetr = perimetr * 100;
                    groundarea = groundarea * 100;                      //  5/2,55 = 2 => 5*100/255 = 2
                    wallArea_textbox.Text = wallarea.ToString();
                    perimetr_textbox.Text = perimetr.ToString();
                    ground_textbox.Text = groundarea.ToString();
                    if (language)
                    {
                        width_label.Content = width_ru + ", " + centim_ru;
                        length_label.Content = lenght_ru + ", " + centim_ru;
                        height_label.Content = height_ru + ", " + centim_ru;
                        perimetr_label.Content = perimetr_ru + ", " + centim_ru;
                        width_label.Content = width_ru + ", " + centim_ru;
                        wallArea_label.Content = wallarea_ru + ", " + centim_ru + "\u00B2";
                        groundarea_label.Content = groundarea_ru + ", " + centim_ru + "\u00B2";
                        measure_bt.Content = "Сантиметры";
                        measure_ln = centim_ru;
                    }
                    else
                    {
                        width_label.Content = width_en + ", " + centim_en;
                        length_label.Content = lenght_en + ", " + centim_en;
                        height_label.Content = height_en + ", " + centim_en;
                        perimetr_label.Content = perimetr_en + ", " + centim_en;
                        width_label.Content = width_en + ", " + centim_en;
                        wallArea_label.Content = wallarea_en + ", " + centim_en + "\u00B2";
                        groundarea_label.Content = groundarea_en + ", " + centim_en + "\u00B2";
                        measure_bt.Content = "Centimetrs";
                        measure_ln = centim_en;
                    }
                    
                    break;
                case 3:
                    wallarea = wallarea * 100 / 254;
                    perimetr = perimetr * 100 / 254;
                    groundarea = groundarea * 100 / 254;
                    wallArea_textbox.Text = wallarea.ToString();
                    perimetr_textbox.Text = perimetr.ToString();
                    ground_textbox.Text = groundarea.ToString();
                    if (language)
                    {
                        width_label.Content = width_ru + ", " + inch_ru;
                        length_label.Content = lenght_ru + ", " + inch_ru;
                        height_label.Content = height_ru + ", " + inch_ru;
                        perimetr_label.Content = perimetr_ru + ", " + inch_ru;
                        width_label.Content = width_ru + ", " + inch_ru;
                        wallArea_label.Content = wallarea_ru + ", " + inch_ru + "\u00B2";
                        groundarea_label.Content = groundarea_ru + ", " + inch_ru + "\u00B2";
                        measure_bt.Content = "Дюймы";
                        measure_ln = inch_ru;
                    }
                    else
                    {
                        width_label.Content = width_en + ", " + inch_en;
                        length_label.Content = lenght_en + ", " + inch_en;
                        height_label.Content = height_en + ", " + inch_en;
                        perimetr_label.Content = perimetr_en + ", " + inch_en;
                        width_label.Content = width_en + ", " + inch_en;
                        wallArea_label.Content = wallarea_en + ", " + inch_en + "\u00B2";
                        groundarea_label.Content = groundarea_en + ", " + inch_en + "\u00B2";
                        measure_bt.Content = "Inches";
                        measure_ln = inch_en;
                    }
                    
                    break;
            }    

        }
 
        Boolean grid_paint1 = true;

        public object RootLayout { get; private set; }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (grid_paint1)
            {
                grid_paint_calc.Visibility = Visibility.Visible;
                paint_options_grid.Visibility = Visibility.Visible;
                grid_paint1 = !grid_paint1;
                paint_calcs_btn.Visibility = Visibility.Hidden;
            }
            else
            {
                grid_paint_calc.Visibility = Visibility.Hidden;
                paint_options_grid.Visibility = Visibility.Hidden;
                space_grid.Visibility = Visibility.Hidden;
                grid_paint1 = !grid_paint1;
            }
        }

        private void Main_menu_btn_Click(object sender, RoutedEventArgs e)
        {
           // spaces_check = unchecked(unchecked);


            if (!grid_paint1)
            {
                grid_paint_calc.Visibility = Visibility.Hidden;
                paint_options_grid.Visibility = Visibility.Hidden;
                paint_calcs_btn.Visibility = Visibility.Visible;
                space_grid.Visibility = Visibility.Hidden;
                grid_paint1 = !grid_paint1;
            }
            
        }

        private void Paint_calcs_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            byte selected_type_of_calc = Convert.ToByte(paint_calcs_combobox.SelectedIndex + 1);
            //MessageBox.Show(selected_type_of_calc.ToString());
            switch(selected_type_of_calc)
            {
                case 1:

                break;
                case 2:

                break;
                case 3:

                break;
                case 4:

                break;
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            space_id++;
            space_width = float.Parse(space_width_textbox.Text);
            space_height = float.Parse(space_height_textbox.Text);
            space_square = space_width * space_height;
            space_listbox.Items.Add("Проем №" + space_id + ", Ширина - " + space_width +  ", Высота - " + space_height + ", Площадь - " + space_square + " - " + measure_ln + "\u00B2");
           // space_width_listbox.Items.Add(space_width);
           // space_height_listbox.Items.Add(space_height);
           // space_square_listbox.Items.Add(space_width* space_height);
            //string position_of = space_height_listbox.ScrollIntoView(space_height_listbox.SelectedIndex);
            
            //MessageBox.Show(selected_type_of_calc.ToString());
        }

        
        private void Space_history_listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Clear_button_Click(object sender, RoutedEventArgs e)
        {
            space_id = 0;
            space_listbox.Items.Clear();
        }
        
        private void Spaces_check_Checked(object sender, RoutedEventArgs e)
        {
            space_grid.Visibility = Visibility.Visible;
        }
        private void Spaces_check_Unchecked(object sender, RoutedEventArgs e)
        {
            space_grid.Visibility = Visibility.Hidden;
        }
    }
}
