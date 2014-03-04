using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var dir = LyraSoft.Util.Geo.GeoCalculator.GetDirection(120, 30, 119.999999999, 29.99);
            Console.WriteLine(dir);


            var dis = LyraSoft.Util.Geo.GeoCalculator.GetDistance(120, 30, 119, 29);
            Console.WriteLine(dis);


//            起点经度：116.235(度)
//终点纬度：37.435(度)
//方向角：50（度）
//长度：500（米）
//终点经纬度（"经度,纬度"）=Computation(37.435,116.235,50,500)

            double lat2, lng2;
            double lat1, lng1;
            lat1 = 37.435;
            lng1 = 116.235;
            dis = 500;
            dir = 50;
            LyraSoft.Util.Geo.GeoCalculator.GetPostion(lng1, lat1, dir, dis, out lng2, out lat2);


             dir = LyraSoft.Util.Geo.GeoCalculator.GetDirection(lng1,lat1,lng2,lat2);
            Console.WriteLine(dir);


            lat1 = 30.1234456;
            lng1 = 120.1234456;

            lat2 = 30.1234456;
            lng2 = 120.1244456;

            dis = LyraSoft.Util.Geo.GeoCalculator.GetDistance(lng1, lat1, lng2, lat2);
            Console.WriteLine(dis);

            var filepath = Console.ReadLine();

            if(File.Exists(filepath))
            using (var file = File.Open(filepath, FileMode.Open, FileAccess.Read))
            {
                int aa = LyraSoft.Util.FileCheck.CheckSum.CheckSum32(file);
                string bb = Convert.ToString(aa, 16).ToUpper();
                Console.WriteLine(bb);
    
                file.Seek(0L, SeekOrigin.Begin);
                var Crc16 = new LyraSoft.Util.FileCheck.CRC16Provider();
                 aa = Crc16.CRC16(file);
                 bb = Convert.ToString(aa, 16).ToUpper();
                Console.WriteLine(bb);
            }


            dynamic obj = new LyraSoft.Util.DynamicObj();

            obj.Hello = "Hello";
            obj.World = "World";
            obj.List = new int[] { 1,2,3,4,5};

            obj.SayHello = LyraSoft.Util.DelegateObj.Function(new LyraSoft.Util.DyMethodDelegate((x, y) => {

                Console.WriteLine("{0} {1}!", x.Hello, x.World);
                foreach (var object__ in y)
                    Console.WriteLine(object__);
                ;return null; }));


            Console.WriteLine("{0} {1}!", obj.Hello, obj.World);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));

            obj.SayHello();
            obj.SayHello("abc", "ABC");
                Console.ReadKey(true);
        }
    }
}
