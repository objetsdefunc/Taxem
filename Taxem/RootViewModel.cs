using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxem
{
    class RootViewModel : Caliburn.Micro.Screen
    {
        private List<string> fills = new List<string>();

        public RootViewModel()
        {
            var reader = new StreamReader(File.OpenRead(@"D:\Taxes\Crypto\fills.csv"));

            var lines = new List<string>();
            while(!reader.EndOfStream)
            {
                lines.Add(reader.ReadLine());
            }

            fills = lines;
        }

        public List<string> Fills
        {
            get => fills;
            set
            {
                if (value != fills)
                {
                    fills = value;
                    NotifyOfPropertyChange(() => Fills);
                }
            }
        }
    }
}
