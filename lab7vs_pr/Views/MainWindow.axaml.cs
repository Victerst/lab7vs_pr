using Avalonia.Controls;
using Avalonia.Interactivity;
using lab7vs_pr.ViewModels;
using lab7vs_pr.Models;

namespace lab7vs_pr.Views
{
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.FindControl<MenuItem>("Load").Click += async delegate
                {

                    var window = new OpenFileDialog()
                    {
                        Title = "Open File"
                    };
                    window.Filters.Add(new FileDialogFilter() { Name = "Binary files (*.bin)", Extensions = { "bin" } });
                    string[]? path = await window.ShowAsync((Window)this.VisualRoot);

                    var context = this.DataContext as MainWindowViewModel;
                    if (path == null) context.Path = "";
                    else context.Path = string.Join("\\", path);
                };
                this.FindControl<MenuItem>("Save").Click += async delegate
                {
                    var window = new SaveFileDialog()
                    {
                        Title = "Save File"
                    };
                    window.Filters.Add(new FileDialogFilter() { Name = "Binary files (*.bin)", Extensions = { "bin" } });

                    string? path = await window.ShowAsync((Window)this.VisualRoot);

                    var context = this.DataContext as MainWindowViewModel;
                    if (path == null) context.Savepath = "";
                    else context.Savepath = path;
                };
                this.FindControl<MenuItem>("Exit").Click += delegate
                {
                    this.Close();
                };
                
            }
            public void cAverage(object sender, RoutedEventArgs e)
            {
                var box = sender as TextBox;
                var student = box.DataContext as Students;
                student.CountAverage();
            }

        }
    }
