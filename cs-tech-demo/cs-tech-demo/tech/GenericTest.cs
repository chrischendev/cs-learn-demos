using System;
using cs_tech_demo.models;

/**
 * 泛型测试
 */
namespace cs_tech_demo.tech
{
    public class GenericTest
    {
        /**
         * 测试泛型
         */
        public static void MainTest()
        {
            test01();
        }
        public static void test01()
        {
            PageData<UserModel> userPage=PageData<UserModel>.create(1,10,985,true,null);
            userPage.addUser(UserModel.create("kaly", 34, "上开杨浦"));
            userPage.addUser(UserModel.create("chris", 41, "北京朝阳"));
            userPage.addUser(UserModel.create("will", 40, "成都金牛"));

            Console.WriteLine(userPage.DataList[0].Name);
        }
    }
}