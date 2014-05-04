using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Collections.Specialized;
using System.Collections;

namespace Base_NewFeatures
{
    class Program
    {
        //dynamic Feature, function params:方法参数之可选参数
        private static void DynamicFeature(DateTime birthday, string name = "wingsfree", string sex = "male")
        {
            dynamic dy = new ExpandoObject();
            dy.key = "dynamic";
            dy.value = "System.Dynamic";
            Console.WriteLine(string.Format("key={0},value={1}", dy.key, dy.value));
            Console.WriteLine(string.Format("birthday={0},name={1},sex={2}", birthday.ToShortDateString(), name, sex));
        }

        //方法参数之命名参数:命名参数让我们可以在调用方法时指定参数名字来给参数赋值，这种情况下可以忽略参数的顺序
        static void DoSomething(int height, int width, string openerName, string scroll)
        {
            Console.WriteLine("height = {0},width = {1},openerName = {2}, scroll = {3}", height, width, openerName, scroll);
        }

        // NameValueCollection的使用
        //显示键，值  
        public static void PrintKeysAndValues(NameValueCollection myCol)
        {
            IEnumerator myEnumerator = myCol.GetEnumerator();
            Console.WriteLine("   KEY        VALUE");
            foreach (String s in myCol.AllKeys)
                Console.WriteLine("   {0,-10} {1}", s, myCol[s]);
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            DynamicFeature(DateTime.Parse("1989-06-12"));
            DynamicFeature(DateTime.Parse("1989-06-12"), "airfly");

            DoSomething(scroll: "no", height: 10, width: 5, openerName: "windowname");


            //初始化NameValueCollection需引用using System.Collections.Specialized;  
            NameValueCollection myCol = new NameValueCollection();
            myCol.Add("red", "rojo");//如果键值red相同结果合并 rojo,rouge  
            myCol.Add("green", "verde");
            myCol.Add("blue", "azul");
            myCol.Add("red", "rouge");

            Console.WriteLine("Displays the elements using the AllKeys property and the Item (indexer) property:");
            PrintKeysAndValues(myCol);
            Console.WriteLine("TrCatch Result:" + new TryCatch().TryFinally(10));

            Console.ReadLine();
        }
    }

    public class People
    {
        public DateTime birthday { set; get; }
        public string name { set; get; }
        public string sex { set; get; }
    }

    public class TryCatch
    {
        public int TryFinally(int i)
        {
            int result = i;
            try
            {
                if (result == 10)
                    return result;
                return 100;
            }
            finally
            {
                result++;
            }
        }
    }
}
