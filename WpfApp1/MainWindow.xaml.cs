using System;
using System.IO;
using System.Globalization;
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
using Microsoft.Win32;
using System.Security.Cryptography;
using ClosedXML.Excel;
//here we go again
namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        //MediaPlayer highest_in_the_room
        private MediaPlayer mediaPlayer = new MediaPlayer();
        string list_string;
        ApplicationContext db;

        public MainWindow()
        {
            db = new ApplicationContext();
            List<user> users = db.users.ToList();
            list_string = " ";
            foreach (user user in users)
            {
                list_string += "login: " + user.Login + " | "; //+ " Email: " + user.Email + " Password: " + user.Password;
            }
            //List<input_paint> inputs_paint = db.inputs_paint.ToList();

            InitializeComponent();
            register_grid.Visibility = Visibility.Hidden;
            grid_menu.Visibility = Visibility.Hidden;
            grid_paint_calc.Visibility = Visibility.Hidden;
            paint_options_grid.Visibility = Visibility.Hidden;
            space_grid.Visibility = Visibility.Hidden;
            height2_grid.Visibility = Visibility.Hidden;
            history_grid.Visibility = Visibility.Hidden;
            menu2_grid.Visibility = Visibility.Hidden;
            profile_grid1.Visibility = Visibility.Hidden;
            admin_grid.Visibility = Visibility.Hidden;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        Boolean language = true; // false - Russian, true - English
        byte measure_system = 1; // 1 - meters, 2 - centimetrs, 3 - inches
        byte user_type = 0;
        string measure_ln = "м";
        string centim_ln, perimetr_ln, metr_ln, inch_ln, wallarea_ln, height_ln, width_ln, lenght_ln, groundarea_ln;
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
        float ceiling_area = 0;
        float ceiling_perimetr = 0;
        float perimetr = 0;
        float groundarea = 0;
        float height1, width1, length1, height2, width2, length2, space_width, space_height, space_square, all_space_square, all_height_lenght;
        float an1, an2, an3, an4;
        int space_id = 0;
        int current_user_id;
        string profile_user_mail = "NOTHING";
        string profile_user_login = "NOTHING";

        // start check value func
        static string only_numbers(string number)
        {
            string number_str = number.ToString();
            float number_float;

            NumberStyles style;
            CultureInfo culture;
            style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint;
            culture = CultureInfo.CreateSpecificCulture("ru-RU");

            if (float.TryParse(number_str, style, culture, out number_float))
            {
                return number_float.ToString();
            }
            else
            {
                return "false";
            }
        }
        static float check_value(string value_str){
            float value_float;
            if (only_numbers(value_str) != "false")
            {
                value_float = float.Parse(only_numbers(value_str));
                return value_float;
            }
            else
            {
                string value_string_2 = value_str.Replace(".", ",");
                if (float.TryParse(value_string_2, out value_float))
                {
                    value_float = float.Parse(value_str.Replace(".", ","));
                    return value_float;
                }
                else
                {
                    return -1;
                }
            }
        }
        // end check value func

        int room_number_export = 1;
        public void calculation()
        {
            height1 = check_value(height_textbox.Text);
            height2 = check_value(height2_textbox.Text);
            width1 = check_value(width_textbox.Text);
            length1 = check_value(length_textbox.Text);
            if (height1 > 0 && width1 > 0 && length1 > 0)
            {
                TimeZone curTimeZone = TimeZone.CurrentTimeZone;
                TimeSpan curUTC = curTimeZone.GetUtcOffset(DateTime.Now);
                string date = DateTime.Now.ToString();
                string utc_type = curUTC.ToString();
                string date_of_calc = date + ", UTC+" + utc_type;
                input_paints input = new input_paints();
                output_paints output = new output_paints();
                switch (selected_type_of_calc)
                {

                    case 1:


                        wallarea = (width1 * height1 + length1 * height1) * 2 - all_space_square;
                        perimetr = (width1 + length1) * 2;
                        groundarea = width1 * length1;

                        all_height_lenght = height1 * 4;
                        an1 = 90;
                        an2 = 90;
                        an3 = 90;
                        an4 = 90;
                        //space_grid.Margin = new Thickness(0, 300, 0, 0);
                        //textblock_paint_result.Margin = new Thickness(0, 115, 0, 0);
                        textblock_paint_result.Text = "Площадь стен: " + wallarea.ToString() + " Периметр пола: " + perimetr.ToString() + " Площадь потолка: " + groundarea.ToString();




                        /* user user = new user(register_user_login, register_user_email, register_user_pass1, "false");

                         db.users.Add(user);
                         db.SaveChanges();*/

                        break;
                    case 2:
                        height2 = check_value(height2_textbox.Text);
                        if (height2 > 0 && height1 > 0)
                        {
                            groundarea = width1 * length1;
                            perimetr = (width1 + length1) * 2;

                            if (height1 > height2)
                            {


                                wallarea = (width1 * (height1 - height2)) + (height2 * length1) + (height1 * length1) + (width1 * height2 * 2) - all_space_square;
                                ceiling_area = (float)Math.Sqrt((height1 - height2) * (height1 - height2) + width1 * width1) * length1;
                                ceiling_perimetr = (float)Math.Sqrt((height1 - height2) * (height1 - height2) + width1 * width1) * 2 + length1 * 2;
                            }
                            else if (height1 < height2)
                            {
                                wallarea = (width1 * (height2 - height1)) + (height2 * length1) + (height1 * length1) + (width1 * height1 * 2) - all_space_square;
                                ceiling_area = (float)Math.Sqrt((height2 - height1) * (height2 - height1) + width1 * width1) * length1;
                                ceiling_perimetr = (float)Math.Sqrt((height2 - height1) * (height2 - height1) + width1 * width1) * 2 + length1 * 2;
                            }
                            else
                            {
                                wallarea = (width1 * height1 + length1 * height1) * 2 - all_space_square;
                                ceiling_area = groundarea;
                                ceiling_perimetr = perimetr;
                            }
                            groundarea = width1 * length1;
                            textblock_paint_result.Text = "Площадь стен: " + wallarea.ToString() + " Периметр пола: " + perimetr.ToString() + " Площадь потолка: " + ceiling_area.ToString();
                            all_height_lenght = (height1 + height2) * 2;

                            //space_grid.Margin = new Thickness(0, 345, 0, 0);
                            //textblock_paint_result.Margin = new Thickness(0, 160, 0, 0);
                        }
                        else
                        {
                            warning_number_window();
                        }
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                }
                input = new input_paints(current_user_id.ToString(), selected_type_of_calc.ToString(), an1.ToString(), an2.ToString(), an3.ToString(), an4.ToString(), width1.ToString(), width1.ToString(), length1.ToString(), length1.ToString(), height1.ToString(), height1.ToString(), height1.ToString(), height1.ToString(), all_space_square.ToString(), date_of_calc, room_number_export.ToString());
                db.input_paint.Add(input);

                output = new output_paints(current_user_id.ToString(), wallarea.ToString(), perimetr.ToString(), groundarea.ToString(), groundarea.ToString(), perimetr.ToString(), all_space_square.ToString(), all_height_lenght.ToString(), date_of_calc);
                db.output_paint.Add(output);
                db.SaveChanges();


                //current_user_id = 0;

            }
            else
            {
                warning_number_window();
            }
        }
        // button "give result" was tapped
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            calculation();
        }
        static void warning_number_window()
        {
            MessageBox.Show("Не правильно введено число");
        }
        
        //language button
        private void Button_Click_2(object sender, RoutedEventArgs e) 
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
                        measure_bt.Content = "Метры";
                        break;
                    case 2:
                        measure_bt.Content = "Сантиметры";
                        break;
                    case 3:
                        measure_bt.Content = "Дюймы";
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
                        measure_bt.Content = "Meters";
                        break;
                    case 2:
                        measure_bt.Content = "Centimetrs";
                        break;
                    case 3:
                        measure_bt.Content = "Inches";
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
                    if (language)
                    {
                        measure_bt.Content = "Метры";
                        measure_ln = metr_ru;
                    }
                    else
                    {
                        measure_bt.Content = "Meters";
                        measure_ln = metr_en;
                    }

                    break;
                case 2:
                    wallarea = wallarea * 100;
                    perimetr = perimetr * 100;
                    groundarea = groundarea * 100; //  5/2,55 = 2 => 5*100/255 = 2
                    if (language)
                    {
                        measure_bt.Content = "Сантиметры";
                        measure_ln = centim_ru;
                    }
                    else
                    {
                        measure_bt.Content = "Centimetrs";
                        measure_ln = centim_en;
                    }

                    break;
                case 3:
                    wallarea = wallarea * 100 / 254;
                    perimetr = perimetr * 100 / 254;
                    groundarea = groundarea * 100 / 254;
                    if (language)
                    {
                        measure_bt.Content = "Дюймы";
                        measure_ln = inch_ru;
                    }
                    else
                    {
                         measure_bt.Content = "Inches";
                        measure_ln = inch_en;
                    }

                    break;
            }

        }

        Boolean grid_paint1 = true;

        public object RootLayout { get; private set; }
        //paint calc button
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //if (grid_paint1)
           // {
                //grid_paint_calc.Visibility = Visibility.Visible;
                //paint_options_grid.Visibility = Visibility.Visible;
                //grid_paint1 = !grid_paint1;
                //paint_calcs_btn.Visibility = Visibility.Hidden;
                hide_menu2(1);
                hide_paint_calc(0);
                
            /*}
            else
            {
                //grid_paint_calc.Visibility = Visibility.Hidden;
                //paint_options_grid.Visibility = Visibility.Hidden;
                //space_grid.Visibility = Visibility.Hidden;
                hide_menu2(0);
                hide_paint_calc(1);
                grid_paint1 = !grid_paint1;
            }*/
        }
        //Кнопка истории расчётов
        public class MyItem
        {
            public int id_calc { get; set; }

            public string date_calc { get; set; }
            public string type_calc { get; set; }
            public string square_calc { get; set; }
            public string square2_calc { get; set; }

        }
        public class MyItem2
        {
            public int user_id { get; set; }

            public string user_login { get; set; }
            public string user_mail { get; set; }
            public string user_pass { get; set; }
            public string user_admin { get; set; }

        }
        /*private void Button_delete_Click(object sender, RoutedEventArgs e)
        {
            //Button button = sender as Button;
            //Game game = button.DataContext as Game;
            //int id = game.ID;
            //int inex1 = sender.SelectedIndex
            int list_index = calcs_out_listview.SelectedIndex;
            MessageBox.Show("удалить запись номер "+ list_index + " ?");
        }*/
        private void profile_btn_Click(object sender, RoutedEventArgs e)
        {
            //history_listbox
            hide_menu2(1);
            hide_history_calc(0);
            calcs_history_update();
        }
        public void users_list_update()
        {
            List<user> users = db.users.ToList();

            var md5 = MD5.Create();
            int admin_count = 0;

            users_listview.Items.Clear();
            foreach (user user in users)
            {
                if (user.Admin_status != "true")
                {
                    int list_user_id = user.id;
                    string list_user_login = user.Login, list_user_mail = user.Email, list_user_admin = user.Admin_status;
                    string list_user_pass = user.Password;
                    list_user_pass = Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(list_user_pass)));
                    users_listview.Items.Add(new MyItem2 { user_id = list_user_id, user_login = list_user_login, user_mail = list_user_mail, user_pass = list_user_pass, user_admin = list_user_admin });
                }
                else
                {
                    admin_count++;
                }
                
            }
            MessageBox.Show("Пользователей со статусом администратора = " + admin_count);
        }
        public void calcs_history_update()
        {
            List<input_paints> inputs;
            List<output_paints> outputs;
            if (user_type == 2)
            {
                inputs = db.input_paint.ToList();
                outputs = db.output_paint.ToList();
            } else
            {
                inputs = db.input_paint.Where(b => b.User_id == current_user_id.ToString()).ToList();
                outputs = db.output_paint.Where(b => b.User_id == current_user_id.ToString()).ToList();
            }
            calcs_out_listview.Items.Clear();
            foreach (input_paints input in inputs)
            {
                int cur_id = input.id;
                int out_id;
                string out_square = "0", out_square2 = "0";
                foreach (output_paints output in outputs)
                {
                    if (output.id == cur_id)
                    {
                        out_id = output.id;
                        out_square = output.Wall_square;
                        out_square2 = output.Ceiling_area;
                    }
                }
                calcs_out_listview.Items.Add(new MyItem { id_calc = input.id, date_calc = input.Date, type_calc = input.Calc_type, square_calc = out_square, square2_calc = out_square2 });
            }
        }
        private void calcs_out_listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //go to main menu button
        Boolean menu_btn = false;
        private void Main_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            if (menu_btn)
            {
                hide_menu2(0);
                admin_grid.Visibility = Visibility.Hidden;
                hide_paint_calc(1);
                hide_profile(1);
                hide_history_calc(1);

                menu_btn = !menu_btn;
            } else
            {
                hide_menu2(0);
                admin_grid.Visibility = Visibility.Hidden;
                hide_paint_calc(1);
                hide_history_calc(1);
                hide_profile(1);

                menu_btn = !menu_btn;
            }
        }
        byte selected_type_of_calc;

        // delete calc button
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {

            var a = Int32.TryParse(deleted_calcs_id_textbox.Text.ToString(), out int value_1);
            if (a)
            {
                int delete_id = Math.Abs(Int32.Parse(deleted_calcs_id_textbox.Text.ToString()));
                try
                {
                    var input_del = db.input_paint.FirstOrDefault(x => x.id == delete_id);
                    db.input_paint.Remove(input_del);
                    db.SaveChanges();
                    var output_del = db.output_paint.FirstOrDefault(x => x.id == delete_id);
                    db.output_paint.Remove(output_del);
                    db.SaveChanges();
                    calcs_history_update();
                }
                catch
                {

                }
            }
            else
            {
                warning_number_window();
            }
        }


        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            grid_menu.Visibility = Visibility.Visible;
            main_menu_grid.Visibility = Visibility.Hidden;
            history_button.IsEnabled = false;
            history_btn.IsEnabled = false;
            user_type = 3;

            login_textbox.Text = "";
            pass_textbox.Password = "";
            textblock_paint_result.Text = "Выберете \"Тип расчёта\"";
        }

        //when type of calc changed
        private void Paint_calcs_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selected_type_of_calc = Convert.ToByte(paint_calcs_combobox.SelectedIndex + 1);
            //MessageBox.Show(selected_type_of_calc.ToString());
            //Thickness space_margin = space_grid.Margin;
            textblock_paint_result.Text = "Нажмите \"Рассчитать\"";
            switch (selected_type_of_calc)
            {
                case 1:
                    //space_grid.Margin = new Thickness(0, 300, 0, 0);
                    //textblock_paint_result.Margin = new Thickness(0, 115, 0, 0);
                    height2_grid.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    //space_grid.Margin = new Thickness(0, 345, 0, 0);
                    //textblock_paint_result.Margin = new Thickness(0, 160, 0, 0);
                    height2_grid.Visibility = Visibility.Visible;
                    break;
                case 3:
                    height2_grid.Visibility = Visibility.Visible;
                    break;
                case 4:

                    break;
            }
        }
        // add space button
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            space_width = check_value(space_width_textbox.Text);
            space_height = check_value(space_height_textbox.Text);
            if (space_height > 0 && space_width > 0)
            {
                space_id++;
                space_square = space_width * space_height;
                space_listbox.Items.Add("Проем №" + space_id + ", Ширина - " + space_width + ", Высота - " + space_height + ", Площадь - " + space_square + " - " + measure_ln + "\u00B2");
                all_space_square += space_square;
            } else
            {
                warning_number_window();
            }
        }


        private void Space_history_listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Account_info_btn_Click(object sender, RoutedEventArgs e)
        {
            hide_profile(0);
            hide_menu2(1);
            login_info_textbox.Text = profile_user_login;
            mail_info_textbox.Text = profile_user_mail;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void history_button_Click(object sender, RoutedEventArgs e)
        {
            admin_grid.Visibility = Visibility.Visible;
            hide_menu2(1);
            users_list_update();
        }

        private void delete_user_button_Click(object sender, RoutedEventArgs e)
        {
            var a = Int32.TryParse(deleted_user_id_textbox.Text.ToString(), out int value_1);
            if (a)
            {
                int delete_id = Math.Abs(Int32.Parse(deleted_user_id_textbox.Text.ToString()));
                user admin_stat = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    admin_stat = db.users.Where(b => b.id == delete_id).FirstOrDefault();
                }
                try
                {
                    if (admin_stat != null)
                    {

                        if (admin_stat.Admin_status != "true")
                        {
                            try
                            {
                                var input_del = db.users.FirstOrDefault(x => x.id == delete_id);
                                db.users.Remove(input_del);
                                db.SaveChanges();
                                users_list_update();
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }
            else
            {
                warning_number_window();
            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            void Create(string filePath)
            {
                string calc_id, user_id, calc_type, an1, an2, an3, an4, w1, w2, l1, l2, h1, h2, h3, h4, space_square, date;
                string wall_square, ceiling_perimetr, ceiling_area, ground_area, ground_perimetr, height_length;
                List<input_paints> inputs;
                List<output_paints> outputs;
                if (user_type == 2)
                {
                    inputs = db.input_paint.ToList();
                    outputs = db.output_paint.ToList();
                }
                else
                {
                    inputs = db.input_paint.Where(b => b.User_id == current_user_id.ToString()).ToList();
                    outputs = db.output_paint.Where(b => b.User_id == current_user_id.ToString()).ToList();
                }

                string a_col = "A", b_col = "B", c_col = "C", d_col = "D", e_col = "E", f_col = "F", g_col = "G", h_col = "H";
                string i_col = "I", j_col = "J", k_col = "K", l_col = "L", m_col = "M", n_col = "N", o_col = "O", p_col = "P";
                string q_col = "Q", r_col = "R", s_col = "S", t_col = "T", u_col = "U", v_col = "V", w_col = "W", x_col = "X";
                int row_count = 2;

                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("Расчёты");
                ws.Cell("A1").Value = "Id Расчета";
                ws.Cell("B1").Value = "Id Пользователя";
                ws.Cell("C1").Value = "Тип расчёта";
                ws.Cell("D1").Value = "Угол №1";
                ws.Cell("E1").Value = "Угол №2";
                ws.Cell("F1").Value = "Угол №3";
                ws.Cell("G1").Value = "Угол №4";
                ws.Cell("H1").Value = "Ширнина №1";
                ws.Cell("I1").Value = "Ширнина №2";
                ws.Cell("J1").Value = "Длина №1";
                ws.Cell("K1").Value = "Длина №2";
                ws.Cell("L1").Value = "Высота №1";
                ws.Cell("M1").Value = "Высота №2";
                ws.Cell("N1").Value = "Высота №3";
                ws.Cell("O1").Value = "Высота №4";
                ws.Cell("P1").Value = "Площадь стен";
                ws.Cell("Q1").Value = "Периметр потолка";
                ws.Cell("R1").Value = "Площадь потолка";
                ws.Cell("S1").Value = "Площадь пола";
                ws.Cell("T1").Value = "Периметр пола";
                ws.Cell("U1").Value = "Площадь проемов";
                ws.Cell("V1").Value = "Общая высота всех углов";
                ws.Cell("W1").Value = "Дата";

                
                foreach (input_paints input in inputs)
                {
                    int cur_id = input.id;
                    calc_id = cur_id.ToString();
                    user_id = current_user_id.ToString();
                    calc_type = input.Calc_type;
                    an1 = input.An1;
                    an2 = input.An2;
                    an3 = input.An3;
                    an4 = input.An4;
                    w1 = input.W1;
                    w2 = input.W2;
                    l1 = input.L1;
                    l2 = input.L2;
                    h1 = input.H1;
                    h2 = input.H2;
                    h3 = input.H3;
                    h4 = input.H4;
                    space_square = input.Space_square;
                    date = input.Date;
                    int out_id;
                    string out_square = "0", out_square2 = "0";
                    foreach (output_paints output in outputs)
                    {
                        
                        if (output.id == cur_id)
                        {
                            wall_square = output.Wall_square;
                            ceiling_perimetr = output.Ceiling_perimetr;
                            ceiling_area = output.Ceiling_area;
                            ground_area = output.Ground_area;
                            ground_perimetr = output.Ground_perimetr;
                            height_length = output.Height_lenght;

                            a_col += row_count.ToString();
                            b_col += row_count.ToString();
                            c_col += row_count.ToString();
                            d_col += row_count.ToString();
                            e_col += row_count.ToString();
                            f_col += row_count.ToString();
                            g_col += row_count.ToString();
                            h_col += row_count.ToString();
                            i_col += row_count.ToString();
                            j_col += row_count.ToString();
                            k_col += row_count.ToString();
                            l_col += row_count.ToString();
                            m_col += row_count.ToString();
                            n_col += row_count.ToString();
                            o_col += row_count.ToString();
                            p_col += row_count.ToString();
                            q_col += row_count.ToString();
                            r_col += row_count.ToString();
                            s_col += row_count.ToString();
                            t_col += row_count.ToString();
                            u_col += row_count.ToString();
                            v_col += row_count.ToString();
                            w_col += row_count.ToString();
                            x_col += row_count.ToString();

                            ws.Cell(a_col).Value = cur_id;
                            ws.Cell(b_col).Value = current_user_id;
                            ws.Cell(c_col).Value = calc_type;
                            ws.Cell(d_col).Value = an1;
                            ws.Cell(e_col).Value = an2;
                            ws.Cell(f_col).Value = an3;
                            ws.Cell(g_col).Value = an4;
                            ws.Cell(h_col).Value = w1;
                            ws.Cell(i_col).Value = w2;
                            ws.Cell(j_col).Value = l1;
                            ws.Cell(k_col).Value = l2;
                            ws.Cell(l_col).Value = h1;
                            ws.Cell(m_col).Value = h2;
                            ws.Cell(n_col).Value = h3;
                            ws.Cell(o_col).Value = h4;
                            ws.Cell(p_col).Value = wall_square;
                            ws.Cell(q_col).Value = ceiling_perimetr;
                            ws.Cell(r_col).Value = ceiling_area;
                            ws.Cell(s_col).Value = ground_area;
                            ws.Cell(t_col).Value = ground_perimetr;
                            ws.Cell(u_col).Value = space_square;
                            ws.Cell(v_col).Value = height_length;
                            ws.Cell(w_col).Value = date;
                            a_col = "A"; b_col = "B"; c_col = "C"; d_col = "D"; e_col = "E"; f_col = "F"; g_col = "G"; h_col = "H";
                            i_col = "I"; j_col = "J"; k_col = "K"; l_col = "L"; m_col = "M"; n_col = "N"; o_col = "O"; p_col = "P";
                            q_col = "Q"; r_col = "R"; s_col = "S"; t_col = "T"; u_col = "U"; v_col = "V"; w_col = "W"; x_col = "X";
                            row_count++;
                        }
                    }
                    wb.SaveAs(filePath);
                }
                // Creating a new workbook
                /*var wb = new XLWorkbook();

                //Adding a worksheet
                var ws = wb.Worksheets.Add("Contacts");

                //Adding text
                //Title
                ws.Cell("B2").Value = "Contacts";
                //First Names
                ws.Cell("B3").Value = "FName";
                ws.Cell("B4").Value = "John";
                ws.Cell("B5").Value = "Hank";
                ws.Cell("B6").Value = "Dagny";
                //Last Names
                ws.Cell("C3").Value = "LName";
                ws.Cell("C4").Value = "Galt";
                ws.Cell("C5").Value = "Rearden";
                ws.Cell("C6").Value = "Taggart";

                //Adding more data types
                //Is an outcast?
                ws.Cell("D3").Value = "Outcast";
                ws.Cell("D4").Value = true;
                ws.Cell("D5").Value = false;
                ws.Cell("D6").Value = false;
                //Date of Birth
                ws.Cell("E3").Value = "DOB";
                ws.Cell("E4").Value = new DateTime(1919, 1, 21);
                ws.Cell("E5").Value = new DateTime(1907, 3, 4);
                ws.Cell("E6").Value = new DateTime(1921, 12, 15);
                //Income
                ws.Cell("F3").Value = "Income";
                ws.Cell("F4").Value = 2000;
                ws.Cell("F5").Value = 40000;
                ws.Cell("F6").Value = 10000;

                //Defining ranges
                //From worksheet
                var rngTable = ws.Range("B2:F6");
                //From another range
                var rngDates = rngTable.Range("E4:E6");
                var rngNumbers = rngTable.Range("F4:F6");

                //Formatting dates and numbers
                //Using a OpenXML's predefined formats
                rngDates.Style.NumberFormat.NumberFormatId = 15;
                //Using a custom format
                rngNumbers.Style.NumberFormat.Format = "$ #,##0";

                //Formatting headers
                var rngHeaders = rngTable.Range("B3:F3");
                rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                rngHeaders.Style.Font.Bold = true;
                rngHeaders.Style.Fill.BackgroundColor = XLColor.Aqua;

                //Adding grid lines
                rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                //Format title cell
                rngTable.Cell(1, 1).Style.Font.Bold = true;
                rngTable.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.CornflowerBlue;
                rngTable.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                //Merge title cells
                rngTable.Row(1).Merge(); // We could've also used: rngTable.Range("A1:E1").Merge()

                //Add thick borders
                rngTable.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

                // You can also specify the border for each side with:
                // rngTable.FirstColumn().Style.Border.LeftBorder = XLBorderStyleValues.Thick;
                // rngTable.LastColumn().Style.Border.RightBorder = XLBorderStyleValues.Thick;
                // rngTable.FirstRow().Style.Border.TopBorder = XLBorderStyleValues.Thick;
                // rngTable.LastRow().Style.Border.BottomBorder = XLBorderStyleValues.Thick;

                // Adjust column widths to their content
                ws.Columns(2, 6).AdjustToContents();

                //Saving the workbook
                */
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Таблица Excel |*.xlsx";
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    string path2 = saveFileDialog.FileName;
                    Create(path2);
                } catch
                {
                    
                }
            }    
        }

        private void add_room_button_Click(object sender, RoutedEventArgs e)
        {
            room_number_export++;
            calculation();
            do_calculation.IsEnabled = false;
        }

        private void finish_button_Click(object sender, RoutedEventArgs e)
        {

            room_number_export = 1;
            do_calculation.IsEnabled = true;
        }

        // clear all textboxes button
        private void Clear_button_Click(object sender, RoutedEventArgs e)
        {
            space_id = 0;
            space_square = 0;
            all_space_square = 0;
            space_listbox.Items.Clear();
            textblock_paint_result.Text = "";
            width_textbox.Text = "";
            height_textbox.Text = "";
            length_textbox.Text = "";
            height2_textbox.Text = "";
            space_height_textbox.Text = "";
            space_width_textbox.Text = "";

        }
        // checkbox spaces in true position
        Boolean space_check_value;
        private void Spaces_check_Checked(object sender, RoutedEventArgs e)
        {
            space_grid.Visibility = Visibility.Visible;
            space_check_value = true;
        }
        // checkbox spaces in false position
        private void Spaces_check_Unchecked(object sender, RoutedEventArgs e)
        {
            space_grid.Visibility = Visibility.Hidden;
            space_id = 0;
            space_square = 0;
            all_space_square = 0;
            space_listbox.Items.Clear();
            space_height_textbox.Text = "0";
            space_width_textbox.Text = "0";
            space_check_value = false;
        }
        // registration form button
        private void Register_acc_btn_Click(object sender, RoutedEventArgs e)
        {
            register_grid.Visibility = Visibility.Visible;
            main_menu_grid.Visibility = Visibility.Hidden;
        }
        //registration button for check values and registrated new user
        private void Register_btn_Click(object sender, RoutedEventArgs e)
        {
            
            
            string register_user_login = registration_login.Text.Trim();
            string register_user_email = registration_email.Text.Trim().ToLower();
            string register_user_pass1 = registration_pass1.Password.Trim();
            string register_user_pass2 = registration_pass2.Password.Trim();
            string admin_status = "false";
            
            if (register_user_login.Length < 4)
            {
                registration_login.ToolTip = "Длина логина должна быть больше 4 символов";
                registration_login.BorderBrush = Brushes.Crimson;
            } else
            {
                registration_login.ToolTip = null;
                registration_login.BorderBrush = Brushes.Black;
            }


            if (register_user_pass1.Length < 4)
            {
                registration_pass1.ToolTip = "Длина пароля должна быть больше 4 символов";
                registration_pass1.BorderBrush = Brushes.Crimson;
            } else
            {
                registration_pass1.ToolTip = null;
                registration_pass1.BorderBrush = Brushes.Black;
            }


            if (register_user_pass1 != register_user_pass2)
            {
                registration_pass1.ToolTip = "Пароли не совпадают";
                registration_pass1.BorderBrush = Brushes.Crimson;
                registration_pass2.ToolTip = "Пароли не совпадают";
                registration_pass2.BorderBrush = Brushes.Crimson;
            } else if (register_user_pass1.Length < 4)
            {
                
                registration_pass1.ToolTip = "Длина пароля должна быть больше 4 символов";
                registration_pass2.ToolTip = "Длина пароля должна быть больше 4 символов";
            } else
            {
                registration_pass1.ToolTip = null;
                registration_pass1.BorderBrush = Brushes.Black;
                registration_pass2.BorderBrush = Brushes.Black;
                registration_pass2.ToolTip = null;
            }


            if (register_user_email.Length < 5)
            {
                registration_email.ToolTip = "Длина почты должна быть больше 5 символов";
                registration_email.BorderBrush = Brushes.Crimson;
            } else
            {
                registration_email.ToolTip = null;
                registration_email.BorderBrush = Brushes.Black;
            }


            if (!register_user_email.Contains('@') || !register_user_email.Contains('.'))
            {
                registration_email.ToolTip = "Почта введена неправильно";
                registration_email.BorderBrush = Brushes.Crimson;
            } else if (register_user_email.Length < 5)
            {
                registration_email.ToolTip = "Длина почты должна быть больше 5 символов";
            } else
            {
                registration_email.ToolTip = null;
                registration_email.BorderBrush = Brushes.Black;
            }


            if (register_user_login.Length >= 4 && register_user_pass1.Length >= 4 && register_user_pass1 == register_user_pass2 && (register_user_email.Contains('@') && register_user_email.Contains('.')))
            {
                registration_email.ToolTip = null;
                registration_pass1.ToolTip = null;
                registration_pass2.ToolTip = null;
                registration_login.ToolTip = null;

                user user = new user(register_user_login,register_user_email,register_user_pass1,admin_status);
                    
                db.users.Add(user);
                db.SaveChanges();
                register_grid.Visibility = Visibility.Hidden;
                main_menu_grid.Visibility = Visibility.Visible;
                MessageBox.Show("Регистрация проведена успешно");

                registration_login.Text = "";
                registration_email.Text = "";
                registration_pass1.Password = "";
                registration_pass2.Password = "";


            }
        }
        // function for check values in textboxes and login in account
        void login_account()
        {
            string user_login = login_textbox.Text.Trim();
            string user_pass = pass_textbox.Password.Trim();

            if (user_login.Length < 4)
            {
                login_textbox.ToolTip = "Длина логина должна быть больше 4 символов";
                login_textbox.BorderBrush = Brushes.Crimson;
            }
            else
            {
                login_textbox.ToolTip = null;
                login_textbox.BorderBrush = Brushes.Black;
            }


            if (user_pass.Length < 4)
            {
                pass_textbox.ToolTip = "Длина пароля должна быть больше 4 символов";
                pass_textbox.BorderBrush = Brushes.Crimson;
            }
            else
            {
                pass_textbox.ToolTip = null;
                pass_textbox.BorderBrush = Brushes.Black;
            }
            if (user_login.Length >= 4 && user_pass.Length >= 4)
            {
                user authUser = null;
                //user user_id = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.users.Where(b => b.Login == user_login && b.Password == user_pass).FirstOrDefault();
                }
                if (authUser != null)
                {
                    MessageBox.Show("Успешно!");
                    current_user_id = authUser.id;
                    //MessageBox.Show(user_id);
                    if (authUser.Admin_status == "true")
                    {
                        user_type = 2;
                        history_button.IsEnabled = true; //admin panel
                    }
                    else
                    {
                        user_type = 1;
                        history_button.IsEnabled = false; //admin panel
                    }
                    history_btn.IsEnabled = true;
                    profile_user_mail = authUser.Email;
                    profile_user_login = authUser.Login;
                    grid_menu.Visibility = Visibility.Visible;
                    main_menu_grid.Visibility = Visibility.Hidden;
                    login_textbox.Text = "";
                    pass_textbox.Password = "";
                    textblock_paint_result.Text = "Выберете \"Тип расчёта\"";
                }
                else
                {
                    user_type = 0;
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }
        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            login_account();
        }
        private MediaPlayer player = new MediaPlayer();
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            new About1().ShowDialog();
        }
        // login form button
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            register_grid.Visibility = Visibility.Hidden;
            main_menu_grid.Visibility = Visibility.Visible;
        }
        // exit button
        private void Exit_account_btn_Click(object sender, RoutedEventArgs e)
        {
            admin_grid.Visibility = Visibility.Hidden;
            register_grid.Visibility = Visibility.Hidden;
            grid_menu.Visibility = Visibility.Hidden;
            history_grid.Visibility = Visibility.Hidden;
          //grid_paint_calc.Visibility = Visibility.Hidden;
          //paint_options_grid.Visibility = Visibility.Hidden;
          //space_grid.Visibility = Visibility.Hidden;
            main_menu_grid.Visibility = Visibility.Visible;
            hide_menu2(1);
            hide_paint_calc(1);
            user_type = 0;
            current_user_id = 1;
            
        }
        //when press "enter button" in login form
        private void login_key_enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                login_account();
            }
        }
        void hide_menu2(int i)
        {
            if (i == 1)
            {
                menu2_grid.Visibility = Visibility.Hidden;
            } else
            {
                menu2_grid.Visibility = Visibility.Visible;
            }
            
        }
        void hide_paint_calc(int i)
        {
            if (i == 1)
            {
                grid_paint_calc.Visibility = Visibility.Hidden;
                paint_options_grid.Visibility = Visibility.Hidden;
                space_grid.Visibility = Visibility.Hidden;
                

            } else
            {
                grid_paint_calc.Visibility = Visibility.Visible;
                paint_options_grid.Visibility = Visibility.Visible;
                if (space_check_value)
                {
                    space_grid.Visibility = Visibility.Visible;
                }
                else
                {
                    space_grid.Visibility = Visibility.Hidden;
                }
            }
        }
        void hide_history_calc(int i)
        {
            if (i == 1)
            {
                history_grid.Visibility = Visibility.Hidden;
            }
            else
            {
                history_grid.Visibility = Visibility.Visible;
            }
        }
        void hide_profile(int i)
        {
            if (i > 0)
            {
                profile_grid1.Visibility = Visibility.Hidden;
            }
            else
            {
                profile_grid1.Visibility = Visibility.Visible;
            }
        }
        void hide_all_pages()
        {
            hide_paint_calc(1);
        }
    }
}
