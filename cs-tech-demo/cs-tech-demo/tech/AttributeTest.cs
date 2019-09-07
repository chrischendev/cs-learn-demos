using System;
using System.Reflection;
using cs_tech_demo.attributes;
using cs_tech_demo.models;

/**
 * 特性测试
 */
namespace cs_tech_demo.tech
{
    public class AttributeTest
    {
        public static void MainTest()
        {
            test02();
        }

        /**
         * 测试失效特性
         */
        private static void test01()
        {
            UserModel userModel = UserModel.create("岑剑兰", 40, "离界海岛");
            //userModel.sayHello();
        }

        /**
         * 测试自定义特性
         */
        private static void test02()
        {
            MyClass myClass = new MyClass("爱拼才会赢");
            Type type = typeof(MyClass);
            //通过反射获取字段
            FieldInfo fieldInfo = type.GetField("content", BindingFlags.NonPublic | BindingFlags.Instance);
            //获取字段的特性
            MyInfo attribute = (MyInfo) fieldInfo.GetCustomAttribute(typeof(MyInfo));
            Console.WriteLine(attribute.Name);
            //获取方法上面的特性
            MethodInfo methodInfo = type.GetMethod("say", BindingFlags.Public | BindingFlags.Instance, null,
                new Type[] {typeof(string)}, null);
            MyInfo attribute1 = (MyInfo) methodInfo.GetCustomAttribute(typeof(MyInfo));
            string name = attribute1.Name;
            string job = attribute1.Job;
            Console.WriteLine(name);
            //下面的代码主要是为了实现特性的处理器
            methodInfo.Invoke(myClass, new object[] {name + "是一个" + job});
        }
    }

    /**
     * 应用特性的类
     */
    class MyClass
    {
        [MyInfo("陈凯利", "未来编剧")] private string content;

        public MyClass()
        {
        }

        public MyClass(string content)
        {
            this.content = content;
        }

        public string Content
        {
            get => content;
            set => content = value;
        }

        [MyInfo("樊冬梅", "小护士")]
        public void say(string content)
        {
            Console.WriteLine(content);
        }

        public void say()
        {
            Console.WriteLine(content);
        }
    }
}