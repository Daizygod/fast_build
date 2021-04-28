using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class output_paints
    {
        public int id { get; set; }

        private string user_id, wall_square, ceiling_perimetr, ceiling_area, ground_area, ground_perimetr, space_square, height_lenght, date;


        public string User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        public string Wall_square
        {
            get { return wall_square; }
            set { wall_square = value; }
        }
        public string Ceiling_perimetr
        {
            get { return ceiling_perimetr; }
            set { ceiling_perimetr = value; }
        }
        public string Ceiling_area
        {
            get { return ceiling_area; }
            set { ceiling_area = value; }
        }
        public string Ground_area
        {
            get { return ground_area; }
            set { ground_area = value; }
        }
        public string Ground_perimetr
        {
            get { return ground_perimetr; }
            set { ground_perimetr = value; }
        }
        public string Space_square
        {
            get { return space_square; }
            set { space_square = value; }
        }
        public string Height_lenght
        {
            get { return height_lenght; }
            set { height_lenght = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public output_paints() { }
        public output_paints(string user_id, string wall_square, string ceiling_perimetr, string ceiling_area, string ground_area, string ground_perimetr, string space_square, string height_lenght, string date) {
            this.user_id = user_id;
            this.wall_square = wall_square;
            this.ceiling_perimetr = ceiling_perimetr;
            this.ceiling_area = ceiling_area;
            this.ground_area = ground_area;
            this.ground_perimetr = ground_perimetr;
            this.space_square = space_square;
            this.height_lenght = height_lenght;
            this.date = date;
        }
        
    }
}
