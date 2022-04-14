using System;


namespace ThiTracNghiem
{
    internal class Recovery
    {

        private string type;
        private string sqlString;
        private string sqlBeforeUpdateString;
        private string maPosition;

        public Recovery(string sqlString, string type)
        {
            this.sqlString = sqlString;
            this.type = type;
        }

        public Recovery(string sqlString, string type, string maPosition)
        {
            this.sqlString = sqlString;
            this.type = type;
            this.maPosition = maPosition;
        }



        public Recovery(string sqlString, string sqlBeforeUpdateString, string type, string maPosition)
        {
            this.sqlString = sqlString;
            this.sqlBeforeUpdateString = sqlBeforeUpdateString;
            this.type = type;
            this.maPosition = maPosition;
        }


        public String SqlString
        {
            get { return sqlString; }
            set { sqlString = value; }
        }

        public String SqlBeforeUpdateString
        {
            get { return sqlBeforeUpdateString; }
            set { sqlBeforeUpdateString = value; }
        }

        public String MaPosition
        {
            get { return maPosition; }
            set { maPosition = value; } 
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

    }
}
