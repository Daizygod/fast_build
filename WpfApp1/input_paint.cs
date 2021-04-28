using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class input_paints
    {
        public int id { get; set; }

        private string calc_type, an1, an2, an3, an4, w1, w2, l1, l2, h1, h2, h3, h4, space_square, date, room_num;
        private string user_id;


        public string User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        public string Calc_type
        {
            get { return calc_type; }
            set { calc_type = value; }
        }
        public string An1
        {
            get { return an1; }
            set { an1 = value; }
        }
        public string An2
        {
            get { return an2; }
            set { an2 = value; }
        }
        public string An3
        {
            get { return an3; }
            set { an3 = value; }
        }
        public string An4
        {
            get { return an4; }
            set { an4 = value; }
        }
        public string W1
        {
            get { return w1; }
            set { w1 = value; }
        }
        public string W2
        {
            get { return w2; }
            set { w2 = value; }
        }
        public string L1
        {
            get { return l1; }
            set { l1 = value; }
        }
        public string L2
        {
            get { return l2; }
            set { l2 = value; }
        }
        public string H1
        {
            get { return h1; }
            set { h1 = value; }
        }
        public string H2
        {
            get { return h2; }
            set { h2 = value; }
        }
        public string H3
        {
            get { return h3; }
            set { h3 = value; }
        }
        public string H4
        {
            get { return h4; }
            set { h4 = value; }
        }
        public string Space_square
        {
            get { return space_square; }
            set { space_square = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Room_number
        {
            get { return room_num; }
            set { room_num = value; }
        }


        public input_paints() { }
        public input_paints(string user_id, string calc_type, string an1, string an2, string an3, string an4, string w1, string w2, string l1, string l2, string h1, string h2, string h3, string h4, string space_square, string date, string room_num) {
            this.user_id = user_id;
            this.calc_type = calc_type;
            this.an1 = an1;
            this.an2 = an2;
            this.an3 = an3;
            this.an4 = an4;
            this.w1 = w1;
            this.w2 = w2;
            this.l1 = l1;
            this.l2 = l2;
            this.h1 = h1;
            this.h2 = h2;
            this.h3 = h3;
            this.h4 = h4;
            this.space_square = space_square;
            this.date = date;
            this.room_num = room_num;
        }
        
    }
}
