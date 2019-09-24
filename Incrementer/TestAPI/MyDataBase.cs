using System.Collections.Generic;

namespace TestAPI
{
    public interface IMyDataBase
    {
        void AddValue(int value);

        bool Contains(int value);

        bool ContainsLittle(int value);

        List<int> GetValues();
    }
    
    public class MyDataBase : IMyDataBase
    {
        private List<int> _Db = new List<int>();

        public void AddValue(int value)
        {
            _Db.Add(value);
        }

        public bool Contains(int value)
        {
            foreach (var item in _Db)
            {
                if (item == value)
                    return true;
            }

            return false;
        }

        public bool ContainsLittle(int value)
        {
            foreach (var item in _Db)
            {
                if (item - value == 1)
                {
                    return true;
                }
            }

            return false;
        }

        public List<int> GetValues()
        {
            return _Db;
        }
    }
}