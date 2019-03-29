using MyDelegateEvent.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
    /// <summary>
    /// 1 委托的声明、实例化和调用
    /// 2 委托的意义：解耦
    /// 3 泛型委托--Func Action
    /// 
    /// 委托也是无处不在，
    /// Func Action 异步多线程 事件 
    /// Framework1.0 ----4.7  Core到处都是委托
    /// 
    /// 
    /// 如果需要定义委托 就用Func Action
    /// 
    /// 
    /// 
    /// 1 泛型委托--Func Action
    /// 2 委托的意义：多播委托
    /// 3 event和观察者模式
    /// 4 框架搭建中的事件应用
    /// 
    /// 高级班的传统，准备好学习的小伙伴儿，给Eleven老师刷个字母E，然后课程就正式开始了!!!
    /// 
    /// 事件event真的是无处不在的，
    /// winform无处不在---WPF---webform服务端控件/请求级事件
    /// 
    /// 为啥要用事件？事件究竟能干什么？
    /// 事件(观察者模式)能把固定动作和可变动作分开，完成固定动作,把可变动作分离出去，由外部控制
    /// 搭建框架时，恰好就需要这个特点，可以通过事件去分离可变动作，支持扩展
    /// 
    /// 控件事件：
    /// 启动Form---初始化控件Button---Click事件---+=一个动作
    /// 
    /// 点击按钮--鼠标操作--操作系统收到信号--发送给程序--程序得接受信号，判断控件--登陆--
    /// (事件只能类的内部发生)Button类自己调用Click--肯定是触发了Click事件---登陆动作就会执行
    /// 
    /// 点击按钮--鼠标操作--操作系统收到信号--发送给程序--程序得接受信号，判断控件--支付--
    /// (事件只能类的内部发生)Button类自己调用Click--肯定是触发了Click事件---支付动作就会执行
    /// 
    /// 2次按钮操作，大部分东西都是一样的，就是具体业务不一样的，
    /// 封装的控件就完成了固定动作--接受信号&默认动作。。。
    /// 可变部分，就是事件---是一个开放的扩展接口，想扩展什么就添加什么
    /// event限制权限，避免外部乱来，
    /// 
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班VIP课程，今天是Eleven老师为大家带来的委托事件的学习");
                #region 委托
                {
                    //Console.WriteLine("****************************MyDelegate*************************");
                    MyDelegate myDelegate = new MyDelegate();
                    myDelegate.Show();
                }

                {
                    //Console.WriteLine("****************************委托解耦，代码复用*************************");
                    //Student student = new Student()
                    //{
                    //    Id = 123,
                    //    Name = "Rabbit",
                    //    Age = 23,
                    //    ClassId = 1
                    //};
                    //Student student1;
                    ////上端还不是得知道是哪个国家的人？
                    //student.Study();
                    //student.SayHi("大脸猫", PeopleType.Chinese);

                    //student.SayHi("icefoxz", PeopleType.Malaysia);

                    //student.SayHiChinese("大脸猫");

                    //{
                    //    SayHiDelegate method = new SayHiDelegate(student.SayHiChinese);
                    //    student.SayHiPerfact("大脸猫", method);
                    //}
                    //{
                    //    SayHiDelegate method = new SayHiDelegate(student.SayHiAmerican);
                    //    student.SayHiPerfact("PHS", method);
                    //}
                    //{
                    //    SayHiDelegate method = new SayHiDelegate(student.SayHiMalaysia);
                    //    student.SayHiPerfact("icefoxz", method);
                    //}
                }
                #endregion

                #region Action Func
                {
                    Console.WriteLine("****************************ActionFunc*************************");
                    MyDelegate myDelegate = new MyDelegate();
                    myDelegate.Show();
                }
                {
                    Console.WriteLine("****************************Event*************************");
                    Cat cat = new Cat();
                    cat.Miao();

                    Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
                    cat.CatMiaoAction += new Dog().Wang;
                    cat.CatMiaoAction += new Mouse().Run;
                    cat.CatMiaoAction += new Baby().Cry;
                    cat.CatMiaoAction += new Mother().Wispher;

                    cat.CatMiaoAction.Invoke();
                    cat.CatMiaoAction = null;

                    cat.CatMiaoAction += new Brother().Turn;
                    cat.CatMiaoAction += new Father().Roar;
                    cat.CatMiaoAction += new Neighbor().Awake;
                    cat.CatMiaoAction += new Stealer().Hide;
                    cat.MiaoDelegate();
                    //去除依赖，Cat稳定了；还可以有多个Cat实例


                    Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
                    cat.CatMiaoActionHandler += new Dog().Wang;
                    cat.CatMiaoActionHandler += new Mouse().Run;
                    cat.CatMiaoActionHandler += new Baby().Cry;

                    //cat.CatMiaoActionHandler.Invoke();
                    //cat.CatMiaoActionHandler = null;

                    cat.CatMiaoActionHandler += new Mother().Wispher;
                    cat.CatMiaoActionHandler += new Brother().Turn;
                    cat.CatMiaoActionHandler += new Father().Roar;
                    cat.CatMiaoActionHandler += new Neighbor().Awake;
                    cat.CatMiaoActionHandler += new Stealer().Hide;
                    cat.MiaoEvent();


                    Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
                    cat.AddObserver(new Dog());
                    cat.AddObserver(new Mouse());
                    cat.AddObserver(new Baby());
                    cat.AddObserver(new Mother());
                    cat.AddObserver(new Brother());
                    cat.AddObserver(new Father());
                    cat.AddObserver(new Neighbor());
                    cat.AddObserver(new Stealer());
                    cat.MiaoObserver();
                }
                #endregion
                {
                    EventStandard.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
