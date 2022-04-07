using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7vs_pr.Models
{
	[Serializable()]
	public class Students : INotifyPropertyChanged
	{
		public string Name { get; set; }
		public ObservableCollection<KS> KSS { get; set; }
		public bool IsChecked { get; set; }
		string average;

		[field: NonSerialized()]
		public event PropertyChangedEventHandler? PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public string Average
		{
			get => average;
			set
			{
				average = value;
				double val = Convert.ToDouble(value);
				if (val < 1) Background = Brushes.Red;
				else if (val < 1.5) Background = Brushes.Yellow;
				else Background = Brushes.Green;
				NotifyPropertyChanged();
			}
		}
		[field: NonSerialized()]
		IBrush background;
		[field: NonSerialized()]
		public IBrush Background
		{
			get => background;
			set
			{
				background = value;
				NotifyPropertyChanged();
			}
		}
		public Students(string name)
		{
			Name = name;
			KSS = new ObservableCollection<KS>();
			for (int i = 0; i < 4; i++)
			{
				KSS.Add(new KS("0"));
			}
		}
		public void CountAverage()
		{
			double sum = 0, count = 0;
			for (int i = 0; i < 4; i++)
			{
				if (KSS[i].Mark != "#ERROR") sum += Convert.ToDouble(KSS[i].Mark);
				count++;
			}
			Average = Convert.ToString(sum / count);
		}
	}
}
