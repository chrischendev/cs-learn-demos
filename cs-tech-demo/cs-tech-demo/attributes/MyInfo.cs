using System;

/**
 * 自定义特性
 */

namespace cs_tech_demo.attributes
{
    [
        //加载目标 可以是多个
        AttributeUsage(AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = true)
    ]
    public class MyInfo : Attribute
    {
        //内部跟一个封装类一样
        private string name;
        private string job;

        public MyInfo()
        {
        }

        public MyInfo(string name, string job)
        {
            this.name = name;
            this.job = job;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Job
        {
            get => job;
            set => job = value;
        }
    }
}