using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateListing
{
    class Create
    {
        private static void Main() 
        {
            string root = @"D:\root";
            const string first = @"\First";
            const string second = @"\Second";
            var header = "***********************************" + Environment.NewLine;

            var rootFirst = root + first;
            var files = Directory.GetFiles(rootFirst, "*.cs", SearchOption.TopDirectoryOnly);

            var result = files.Select(path => new { Name = Path.GetFileName(path), Contents = File.ReadAllText(path) })
                            .Select(info =>
                                header
                            + "Filename: " + info.Name + Environment.NewLine
                            + header
                            + info.Contents);


            var singleStr = string.Join(Environment.NewLine, result);
            File.AppendAllText(@"D:\Listing.txt", singleStr, Encoding.UTF8);

            var rootSecond = root + second;
            files = Directory.GetFiles(rootSecond, "*.cs", SearchOption.TopDirectoryOnly);

            var ret = files.Select(path => new { Name = Path.GetFileName(path), Contents = File.ReadAllText(path) })
                            .Select(info =>
                                header
                            + "Filename: " + info.Name + Environment.NewLine
                            + header
                            + info.Contents);


            var single = string.Join(Environment.NewLine, ret);
            File.AppendAllText(@"D:\Listing.txt", single, Encoding.UTF8);
        }
    }
}
