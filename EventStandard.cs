using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
    public class EventStandard
    {
        public static void Show()
        {
            Lesson lesson = new Lesson()
            {
                Id = 123,
                Name = "零基础到多项目实战班",
                Price = 2699
            };
            //订阅：把订户和发布者的事件关联起来
            lesson.IncreaseHandler += new Student().Buy;
            lesson.IncreaseHandler += new Tencent().Popularize;
            lesson.Price = 3999;
        }


        /// <summary>
        /// 订户：关注事件，事件发生后，自己做出对应的动作
        /// </summary>
        public class Student
        {
            public void Buy(object sender, EventArgs e)
            {
                Lesson lesson = (Lesson)sender;
                Console.WriteLine($"This is {lesson.Name} Lesson");

                XEventArgs args = (XEventArgs)e;
                Console.WriteLine($"之前价格{args.OldPrice}");
                Console.WriteLine($"现在价格{args.NewPrice}");
                Console.WriteLine("果断买了！！！");
            }
        }
        public class Tencent
        {
            public void Popularize(object sender, EventArgs e)
            {
                Lesson lesson = (Lesson)sender;
                Console.WriteLine($"This is {lesson.Name} Lesson");

                XEventArgs args = (XEventArgs)e;
                Console.WriteLine($"之前价格{args.OldPrice}");
                Console.WriteLine($"现在价格{args.NewPrice}");
                Console.WriteLine("广大用户请留意！！！");
            }
        }

        /// <summary>
        /// 事件参数  一般会为特定的事件去封装个参数类型
        /// </summary>
        public class XEventArgs : EventArgs
        {
            public int OldPrice { get; set; }
            public int NewPrice { get; set; }
        }


        /// <summary>
        /// 事件的发布者，发布事件并且在满足条件的时候，触发事件
        /// </summary>
        public class Lesson
        {
            public int Id { get; set; }
            public string Name { get; set; }

            private int _price;
            public int Price
            {
                get
                {
                    return this._price;
                }
                set
                {
                    if (value > this._price)
                    {
                        this.IncreaseHandler?.Invoke(this,
                            new XEventArgs()
                            {
                                OldPrice = this._price,
                                NewPrice = value
                            });
                        this._price = value;
                    }
                }
            }

            /// <summary>
            /// 打折事件
            /// 
            /// </summary>
            public event EventHandler IncreaseHandler;

        }
    }
}
