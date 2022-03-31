using System;
using ReactiveUI;
using System.ComponentModel;
using lab7vs_pr.Models;

namespace lab7vs_pr.ViewModels
{
    public class AddStudent : ViewModelBase
    {
        public AddStudent()
        {
            studentToReturn =
            new Student("", "", "", new string[5] { "0", "0", "0", "0", "0" });
            studentToReturn.PropertyChanged += resetEnable;
        }

        Student studentToReturn;
        public Student StudentToReturn
        {
            get { return studentToReturn; }
            set
            {
                this.RaiseAndSetIfChanged(ref studentToReturn, value);
            }
        }
        bool enable;
        public bool Enable
        { get { return enable; } set { this.RaiseAndSetIfChanged(ref enable, value); } }
        public void resetEnable(object? sender, PropertyChangedEventArgs e)
        {
            int x;
            Enable = !string.IsNullOrEmpty(studentToReturn.FirstName) &&
                !string.IsNullOrEmpty(studentToReturn.SecondName);
            for (int i = 0; i < 5; i++)
            {
                if (!Int32.TryParse(studentToReturn[i], out x) && studentToReturn[i].Length > 1)
                {
                    Enable = false;
                    break;
                }
                Enable = Enable && x <= 2 && x >= 0;
            }
        }
    }
}