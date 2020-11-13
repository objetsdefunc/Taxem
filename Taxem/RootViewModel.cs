namespace Taxem
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;

    public class RootViewModel : Caliburn.Micro.Screen
    {
        private IReadOnlyList<string> fills = new List<string>();

        public RootViewModel()
        {
            var lines = new List<string>();
            using (var reader = new StreamReader(File.OpenRead(@"D:\Taxes\Crypto\fills.csv")))
            {
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
            }

            fills = lines;
        }

        public IReadOnlyList<string> Fills
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
