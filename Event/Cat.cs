using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.Event
{
    /// <summary>
    /// 发布者
    /// 一只猫，miao一声
    /// 导致一系列的触发动作
    /// 
    /// 依赖太重，依赖了多个类型，任何类型的变化都得修改猫
    /// 职责耦合，猫不仅自己Miao  还得找各种对象执行各种动作甚至控制顺序
    /// 任意环节增加减少调整顺序  都得修改猫
    /// 
    /// 实际上不该如此，猫就是猫，只做自己的事儿
    /// 需求是猫Miao一声---触发一系列的动作---代码还指定了动作
    /// 猫只miao一声---触发一系列动作，动作从哪里来？不管，我只负责调用
    /// </summary>
    public class Cat
    {
        public void Miao()
        {
            Console.WriteLine("{0} Miao", this.GetType().Name);
            new Dog().Wang();
            new Mouse().Run();
            new Baby().Cry();
            new Mother().Wispher();
            new Brother().Turn();
            new Father().Roar();
            new Neighbor().Awake();
            new Stealer().Hide();
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
        }
        private List<IObject> _ObserverList = new List<IObject>();
        public void AddObserver(IObject observer)
        {
            this._ObserverList.Add(observer);
        }
        //观察者模式
        public void MiaoObserver()
        {
            Console.WriteLine("{0} MiaoObserver", this.GetType().Name);
            foreach (var item in this._ObserverList)
            {
                item.DoAction();
            }
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
        }

        public Action CatMiaoAction;
        public void MiaoDelegate()
        {
            Console.WriteLine("{0} MiaoDelegate", this.GetType().Name);
            this.CatMiaoAction?.Invoke();
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
        }

        //事件event：一个委托的实例，带一个event关键字
        //限制权限，只允许在事件声明类里面去invoke和赋值，不允许外面，甚至子类
        //事件和委托的区别与联系？ 
        //委托是一种类型，事件是委托类型的一个实例，加上了event的权限控制
        //Student是一种类型，Tony就是Student类型的一个实例，
        public event Action CatMiaoActionHandler;
        public void MiaoEvent()
        {
            Console.WriteLine("{0} MiaoEvent", this.GetType().Name);
            this.CatMiaoActionHandler?.Invoke();
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
        }
    }

    //public class MiniCat : Cat
    //{
    //    public void Do()
    //    {
    //        this.CatMiaoActionHandler = null;//即使是子类  也不行
    //    }
    //}
}
