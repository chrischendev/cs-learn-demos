using System.Collections.Generic;

namespace cs_tech_demo.models
{
    public class PageData<T>
    {
        private int page;
        private int pageSize;
        private long count;
        private bool hasNext;
        private List<T> dataList;

        private PageData()
        {
            if (dataList == null)
            {
                dataList = new List<T>();
            }
        }

        public static PageData<T> create()
        {
            return new PageData<T>();
        }

        public PageData(int page, int pageSize, long count, bool hasNext, List<T> dataList)
        {
            this.page = page;
            this.pageSize = pageSize;
            this.count = count;
            this.hasNext = hasNext;
            this.dataList = dataList;
        }

        public static PageData<T> create(int page, int pageSize, long count, bool hasNext, List<T> dataList)
        {
            return new PageData<T>(page, pageSize, count, hasNext, dataList);
        }

        public int Page
        {
            get => page;
            set => page = value;
        }

        public int PageSize
        {
            get => pageSize;
            set => pageSize = value;
        }

        public long Count
        {
            get => count;
            set => count = value;
        }

        public bool HasNext
        {
            get => hasNext;
            set => hasNext = value;
        }

        public List<T> DataList
        {
            get => dataList;
            set => dataList = value;
        }

        public PageData<T> addUser(T t)
        {
            if (dataList == null)
            {
                dataList = new List<T>();
            }

            dataList.Add(t);
            return this;
        }
    }
}