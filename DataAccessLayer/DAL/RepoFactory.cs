using DataAccessLayer.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAL
{
    public static class RepoFactory
    {

        public static IFile GetFileRepository() => new FileRepo();

        public static IRepo GetChampionship(string gender)
        {
            if (gender=="Muško")
            {
                return new ApiRepoMen();
            }
            else
            {
                return new ApiRepoWomen();
            }
        }
    }
}
