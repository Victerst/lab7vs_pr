using Avalonia.Media;
using System;

namespace lab7vs_pr.Models
{
    [Serializable()]
    public class KS
    {
        string mark;

        public string Mark
        {
            get => mark;
            set
            {
                mark = value;
                switch (value)
                {
                    case "0":
                        Background = Brushes.Red;
                        break;
                    case "1":
                        Background = Brushes.Yellow;
                        break;
                    case "2":
                        Background = Brushes.Green;
                        break;
                    default:
                        mark = "#ERROR";
                        Background = Brushes.White;
                        break;
                }
            }
        }
        [field: NonSerialized()]
        public IBrush Background { get; set; }

        public KS(string mark)
        {
            Mark = mark;
        }
    }
}
