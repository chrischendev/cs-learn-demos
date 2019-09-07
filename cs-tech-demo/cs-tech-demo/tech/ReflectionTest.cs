using System;
using System.Collections.Generic;
using System.Reflection;
using cs_tech_demo.models;


/**
 * 反射测试
 */
namespace cs_tech_demo.tech
{
    public class ReflectionTest
    {
        private static UserModel userModel = UserModel.create("mike", 23, "陕西汉中");

        public static void MainTest()
        {
            test08();
        }

        /**
         * 获取程序集
         */
        public static void test01()
        {
            Console.WriteLine(userModel.GetType().Assembly);
            Console.WriteLine(typeof(Program).Assembly);
        }


        /**
         * 反射字段
         */
        public static void test02()
        {
            //以下是反射操作
            Type type = typeof(UserModel);
            //获取非公有的实例字段 name
            FieldInfo nameField = type.GetField("name", BindingFlags.NonPublic | BindingFlags.Instance);
            //取值
            object nameObj = nameField.GetValue(userModel);

            Console.WriteLine(nameObj.ToString());

            //修改
            nameField.SetValue(userModel, "Bill");
            Console.WriteLine(userModel.Name);
        }

        /**
         * 反射方法
         */
        public static void test03()
        {
            Type type = typeof(UserModel);

            MethodInfo sayMethod = type.GetMethod("say", BindingFlags.Public | BindingFlags.Instance);

            //执行
            sayMethod.Invoke(userModel, null);
        }

        /**
         * 反射方法 带参数
         */
        public static void test04()
        {
            Type type = typeof(UserModel);

            MethodInfo createMethod = type.GetMethod("create", BindingFlags.Public | BindingFlags.Static, null,
                new Type[] {typeof(string), typeof(int), typeof(string)}, null);

            //执行
            object obj = createMethod.Invoke(userModel, new object[] {"张三", 12, "灵异空间"});
            UserModel user = (UserModel) obj;

            Console.WriteLine(user.Name);
            user.say();
        }

        /**
         * 实例化
         * 必须要有公有无参构造函数
         */
        public static void test05()
        {
            Type type = typeof(UserModel);

            Console.WriteLine(type.FullName);
            object obj = type.Assembly.CreateInstance(type.FullName);
            UserModel user = (UserModel) obj;
            user.Name = "bill";
            Console.WriteLine(user.Name);
        }

        /**
         * 获取泛型参数
         */
        public static void test06()
        {
            Type type = typeof(List<UserModel>);

            Console.WriteLine(type.IsGenericType ? "是泛型类" : "不是泛型类");

            Type[] genericArguments = type.GetGenericArguments();

            foreach (Type genericArgument in genericArguments)
            {
                Console.WriteLine(genericArgument.FullName);
            }
        }

        /**
         * 实例化泛型集合
         */
        public static void test07()
        {
            //获取泛型类
            Type type = typeof(List<>);

            //创建泛型参数
            Type[] typeArgs = {typeof(UserModel)};
            //设置泛型参数
            Type genericType = type.MakeGenericType(typeArgs);

            //实例化
            object obj = Activator.CreateInstance(genericType);
            //转化测试 这个只用于测试
            List<UserModel> userList = (List<UserModel>) obj;
            userList.Add(UserModel.create("姚诗涵", 18, "北京朝阳"));
            foreach (UserModel user in userList)
            {
                Console.WriteLine(user.Name);
            }
        }

        /**
         * 实例化泛型集合
         * 此处全程不调用被反射的类但是我们要知道被反射操作的类具有的特征
         */
        public static void test08()
        {
            //获取泛型类
            Type type = Type.GetType("System.Collections.Generic.List`1");

            //创建泛型参数
            Type[] typeArgs = {typeof(UserModel)};
            //设置泛型参数
            Type genericType = type.MakeGenericType(typeArgs);

            //实例化
            object obj = Activator.CreateInstance(genericType);

            //调用Add方法添加元素
            MethodInfo addMethod = genericType.GetMethod("Add", BindingFlags.Public | BindingFlags.Instance, null,
                typeArgs, null);
            addMethod.Invoke(obj, new object[] {UserModel.create("姚诗涵", 18, "北京朝阳")});
            addMethod.Invoke(obj, new object[] {UserModel.create("孙菲菲", 35, "北京朝阳")});
            addMethod.Invoke(obj, new object[] {UserModel.create("陈发宝", 18, "中国汉中")});
            addMethod.Invoke(obj, new object[] {UserModel.create("陈凯利", 18, "四川成都")});


            //为了不出现List这个类的调用，我们调用其toArray函数将其转换为数组，再进行遍历输出
            MethodInfo toArrayMethod = genericType.GetMethod("ToArray", BindingFlags.Public | BindingFlags.Instance);
            object arrObj = toArrayMethod.Invoke(obj, null);
            //这里可以强转为数组
            UserModel[] userModels = (UserModel[]) arrObj;
            //遍历数组
            foreach (UserModel user in userModels)
            {
                Console.WriteLine(user.Name);
            }
        }
    }
}