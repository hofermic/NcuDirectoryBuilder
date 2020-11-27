using System.ComponentModel;
using System.Runtime.CompilerServices;
using NcuDirectoryBuilder.Annotations;

namespace NcuDirectoryBuilder.Model
{
    
    public class DirectoryModel: INotifyPropertyChanged
    {
        
        private string _defaultDocumentPath;
        private string _coursePath;
        private string _courseName;
        private string _userName;
        private int _weeks;
        private string _courseNumber;
        private string _defaultDocumentPrefix;

        public string UserName
        {
            get => _userName;
            set
            {
                if (value == _userName) return;
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string CourseNumber
        {
            get => _courseNumber;
            set
            {
                if (value == _courseNumber) return;
                _courseNumber = value;
                OnPropertyChanged();
            }
        }

        public string CourseName
        {
            get => _courseName;
            set
            {
                if (value == _courseName) return;
                _courseName = value;
                OnPropertyChanged();
            }
        }

        public string CoursePath
        {
            get => _coursePath;
            set
            {
                if (value == _coursePath) return;
                _coursePath = value;
                OnPropertyChanged();
            }
        }

        public string DefaultDocumentPrefix
        {
            get => _defaultDocumentPrefix;
            set
            {
                if (value == _defaultDocumentPrefix) return;
                _defaultDocumentPrefix = value;
                OnPropertyChanged();
            }
        }


        public string DefaultDocumentPath
        {
            get => _defaultDocumentPath;
            set
            {
                if (value == _defaultDocumentPath) return;
                _defaultDocumentPath = value;
                OnPropertyChanged();
            }
        }

        public int Weeks
        {
            get => _weeks;
            set
            {
                if (value == _weeks) return;
                _weeks = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}