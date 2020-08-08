using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NcuDirectoryBuilder.Model;
using System.IO;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Path = System.IO.Path;

namespace NcuDirectoryBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DirectoryModel _model = new DirectoryModel();

        public MainWindow()
        {
            InitializeComponent();
            _model.CourseNumber = "TIM-xxxx";
            _model.CourseName = "";
            _model.Weeks = 8;
            _model.UserName = "HoferM";
            _model.CoursePath = @"C:\Users\mhofer\Dropbox\School\NorthCentral";
            _model.DefaultDocumentPath = @"C:\Users\mhofer\Dropbox\School\NorthCentral\HoferMTIM.docx";
            DataContext = _model;
        }

        private void BtnCoursePath_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog()
            {
                Multiselect = false,
                IsFolderPicker = true
            };
            var result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                _model.CoursePath = dialog.FileName;
            }
        }

        private void BtnDocumentPatH_OnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Multiselect = false
            };
            if (openFileDialog.ShowDialog() == true)
            {
                _model.DefaultDocumentPath = openFileDialog.FileName;
            }
        }

        private void BtnSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            if (_model.CourseName.Trim().Length == 0 || _model.CoursePath.Trim().Length == 0 ||
                _model.DefaultDocumentPath.Trim().Length == 0)
            {
                MessageBox.Show("Invalid Entries, all fields much be filled out!", "ERROR", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            var root = $"{_model.CoursePath}\\{_model.CourseNumber}-{_model.CourseName}";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            for (int i = 1; i < _model.Weeks + 1; i++)
            {
                var weekPath = $"{root}\\Week{i}";
                var resourcePath = $"{root}\\Week{i}\\Resources";
                var referencePath = $"{root}\\Week{i}\\References";
                var documentPath =
                    $"{root}\\Week{i}\\{_model.UserName}{_model.CourseNumber.Replace("-","")}-{i}{Path.GetExtension(_model.DefaultDocumentPath)}";
                if (!Directory.Exists(weekPath))
                {
                    Directory.CreateDirectory(weekPath);
                }

                if (!Directory.Exists(resourcePath))
                {
                    Directory.CreateDirectory(resourcePath);
                }

                if (!Directory.Exists(referencePath))
                {
                    Directory.CreateDirectory(referencePath);
                }

                if (File.Exists(_model.DefaultDocumentPath) && !File.Exists(documentPath))
                {
                    File.Copy(_model.DefaultDocumentPath,documentPath);
                }
            }

            MessageBox.Show("Course Folder Structure Successfully Created!", "Success", MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}