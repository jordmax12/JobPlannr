using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Engine
{
    public class ContributorEngine : IContributorEngine
    {
        public ContributorEngine()
        {

        }

        public Contributor Update(Contributor contributor)
        {
            throw new NotImplementedException();
        }

        public void Delete(Contributor contributor)
        {
            throw new NotImplementedException();
        }

        public void Add(Contributor contributor)
        {
            throw new NotImplementedException();
        }

        public Contributor Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contributor> GetAll(int id)
        {
            throw new NotImplementedException();
        }
    }

    public interface IContributorEngine
    {
        Contributor Get(int id);
        List<Contributor> GetAll(int id);
        Contributor Update(Contributor contributor);
        void Add(Contributor contributor);
        void Delete(Contributor contributor);
    }
}
