using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    //public class FileRepoMen : IRepoJson
    //{
    //    private const string DIR = @"C:";
    //    private const string PATHResults = DIR + @"\results.txt";

    //   public FileRepoMen()
    //    {
    //        CreateFileIfNonExists();
    //    }

       

    //    private void CreateFileIfNonExists()
    //    {
    //        Directory.CreateDirectory(DIR);
    //        if (!File.Exists(PATHResults))
    //        {
    //            File.Create(PATHResults).Close();
    //        }
    //    }
    //    public IList<Results> LoadResults()
    //    {
    //        IList<Results> results = new List<Results>();
    //        string [] lines = File.ReadAllLines(PATHResults);
    //        lines.ToList().ForEach(line => results.Add(Results.ParseFromFile(line)));

    //        return results;
    //    }

       
    //}
}
