using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
    /// <summary>
    /// 学生抽象
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public int Age { get; set; }

        public void Study()
        {
            Console.WriteLine("学习.net高级班公开课");
        }

        /// <summary>
        /// 中国人---晚上好
        /// 美国人---good evening
        /// ...
        /// 
        /// 假如要增加一个国家的人Malaysia,就得修改方法，增加一个分支
        /// 任意分支变化 都得修改方法
        /// 经常改动  很不稳定  难以维护
        /// 
        /// 增加公共逻辑方便
        /// 
        /// 为不同的人，进行不同的问候
        /// 传递个变量---判断一下---执行对应的逻辑
        /// 能不能直接点，直接传递逻辑呗
        /// 逻辑就是方法---委托
        /// </summary>
        /// <param name="name"></param>
        public void SayHi(string name, PeopleType peopleType)
        {
            Console.WriteLine("prepare SayHi..");
            switch (peopleType)
            {
                case PeopleType.Chinese:
                    Console.WriteLine($"{name},晚上好~");
                    break;
                case PeopleType.American:
                    Console.WriteLine($"{name},good evening~");
                    break;

                case PeopleType.Malaysia:
                    Console.WriteLine($"{name},*^%*^%^&%^%~");
                    break;

                default://遇到不认识的枚举，说明调用有问题，那就不要隐藏，直接异常
                    throw new Exception("wrong peopleType");
            }
        }

        //1 加参数判断---执行分支逻辑
        //2 加方法满足不同的场景   如果方法特别复杂，就推荐这个

        /// <summary>
        /// 既增加公共逻辑方便，又逻辑分离维护简单  鱼肉熊掌怎么兼得？
        /// 自上往下---逻辑解耦，方便维护升级
        /// 
        /// 自下往上---代码重用，去掉重复代码
        /// </summary>
        public void SayHiPerfact(string name, SayHiDelegate method)
        {
            //Action<string,int>
            //Func<string>

            Console.WriteLine("prepare SayHi..");

            method.Invoke(name);
        }

        /// <summary>
        /// 增加分支，就增加方法--不影响别的方法
        /// 修改某个方法--不影响别的方法
        /// 
        /// 增加公共逻辑---多个方法有很多重复代码
        /// 
        /// 既有相同的东西，也有不同的东西
        /// 相同的东西用一个方法实现，不同的各自去写，然后通过委托组合
        /// </summary>
        /// <param name="name"></param>
        public void SayHiChinese(string name)
        {
            //Console.WriteLine("prepare SayHi..");

            Console.WriteLine($"{name},晚上好~");
        }

        public void SayHiAmerican(string name)
        {
            //Console.WriteLine("prepare SayHi..");

            Console.WriteLine($"{name},good evening~");
        }

        public void SayHiMalaysia(string name)
        {
            //Console.WriteLine("prepare SayHi..");

            Console.WriteLine($"{name},*^%*^%^&%^%~~");
        }

        public static void StudyAdvanced()
        {
            Console.WriteLine("学习.net高级班vip课");
        }

        public static void Show()
        {
            Console.WriteLine("123");
        }
    }

    public delegate void SayHiDelegate(string name);



    public enum PeopleType
    {
        Chinese = 1,
        American = 2,
        Malaysia = 3
    }
}
