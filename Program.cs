using System;
using System.IO;

namespace MetarAverage
{
    class Program
    {
        static public StreamReader sr;

        static public String rec;

        static public String[] fields;

        static public String station;
        static public String valid;
        static public String tmpf;
        static public String dwpf;
        static public String relh;
        static public String drct;
        static public String sknt;
        static public String alti;
        static public String p01m;
        static public String vsby;
        static public String gust;

        static public Double total_drct = 0;
        static public Double count_drct = 0;

        static void Main(string[] args)
        {
            sr = new StreamReader(args[0]);

            // Read Header
            rec = sr.ReadLine();

            rec = sr.ReadLine();

            while(!sr.EndOfStream)
            {
                fields = rec.Split(',');

                station = fields[0];
                valid = fields[1];
                tmpf = fields[2];
                dwpf = fields[3];
                relh = fields[4];
                drct = fields[5];
                sknt = fields[6];
                alti = fields[7];
                p01m = fields[8];
                vsby = fields[9];
                gust = fields[10];

                if (drct != "M")
                {
                    total_drct += Convert.ToDouble(drct);
                    count_drct++;
                }

                rec = sr.ReadLine();
            }

            fields = rec.Split(',');

            station = fields[0];
            valid = fields[1];
            tmpf = fields[2];
            dwpf = fields[3];
            relh = fields[4];
            drct = fields[5];
            sknt = fields[6];
            alti = fields[7];
            p01m = fields[8];
            vsby = fields[9];
            gust = fields[10];

            if (drct != "M")
            {
                total_drct += Convert.ToDouble(drct);
                count_drct++;
            }

            Double f = total_drct / count_drct;

            Console.WriteLine("From: {0:F2}", f);

            sr.Close();
        }
    }
}
