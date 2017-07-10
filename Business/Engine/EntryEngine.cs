using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Engine
{
    public class EntryEngine : IEntryEngine
    {
        public EntryEngine()
        {

        }

        public Entry Update(Entry entry)
        {
            throw new NotImplementedException();
        }

        public void Delete(Entry entry)
        {
            throw new NotImplementedException();
        }

        public void Add(Entry entry)
        {
            throw new NotImplementedException();
        }

        public Entry Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entry> GetAll(int id)
        {
            throw new NotImplementedException();
        }
    }

    public interface IEntryEngine
    {
        Entry Get(int id);
        List<Entry> GetAll(int id);
        Entry Update(Entry entry);
        void Add(Entry entry);
        void Delete(Entry entry);
    }
}
