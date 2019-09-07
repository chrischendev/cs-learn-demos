using System;

namespace cs_tech_demo.models
{
    public class UserModel
    {
        private string name;
        private int age;
        private string address;

        public UserModel()
        {
        }

        public static UserModel create()
        {
            return new UserModel();
        }

        public UserModel(string name, int age, string address)
        {
            this.name = name;
            this.age = age;
            this.address = address;
        }

        public static UserModel create(string name, int age, string address)
        {
            return new UserModel(name, age, address);
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }

        /**
         * 特性测试
         */
        [Obsolete("don't use this method", true)]
        public void sayHello()
        {
            Console.WriteLine(name + " say Hello!");
        }

        public void say()
        {
            Console.WriteLine(name + " say Hello!");
        }
    }
}