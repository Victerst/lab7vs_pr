using lab7vs_pr.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ReactiveUI;

namespace lab7vs_pr.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ObservableCollection<Students> students;
        public ObservableCollection<Students> Students
        {
            get => students;
            set
            {
                this.RaiseAndSetIfChanged(ref students, value);
            }
        }
        string path;
        public string Path
        {
            get => path;
            set
            {
                path = value;
                if (path != "")
                {
                    Stream openFileStream = File.OpenRead(path);
                    BinaryFormatter deserializer = new BinaryFormatter();
                    Students = (ObservableCollection<Students>)deserializer.Deserialize(openFileStream);
                    foreach (Students student in Students)
                    {
                        foreach (KS cell in student.KSS)
                        {
                            cell.Mark = cell.Mark;
                        }
                        student.Average = student.Average;
                    }
                    openFileStream.Close();
                }
            }
        }
        string savepath;
        public string Savepath
        {
            get => savepath;
            set
            {
                savepath = value;
                if (savepath != "")
                {
                    Stream SaveFileStream = File.Create(savepath);
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(SaveFileStream, Students);
                    SaveFileStream.Close();
                }
            }
        }
        public MainWindowViewModel()
        {
            Students = new ObservableCollection<Students>();
        }
        public void Add()
        {
            Students s = new Students("");
            Students.Add(s);
        }
        public void Delete()
        {
            for (int i = 0; i < Students.Count;)
            {
                Students s = Students[i];
                if (s.IsChecked)
                {
                    Students.Remove(s);
                }
                else i++;
            }
        }
    }
}
