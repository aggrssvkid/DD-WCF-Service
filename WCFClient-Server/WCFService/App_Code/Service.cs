using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

public class Service : IService
{
    public ConcurrentDictionary<string, int> ParallelParse(string[] fContent)
    {
        ConcurrentDictionary<string, int> dict = new ConcurrentDictionary<string, int>();
        char[] delimeters = { ')', '(', ']', '[', '{', '}', ' ', ',', '.', '!', '?', ':', ';', '-', '—' };

        Parallel.ForEach(fContent, delegate (string str)
        {
            var words = str.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
                dict.AddOrUpdate(word, 1, (key, value) => ++value);
        });
        return dict;
    }
}
