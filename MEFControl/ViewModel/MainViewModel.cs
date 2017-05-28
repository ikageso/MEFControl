using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MEFControlCommon;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

namespace MEFControl.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private DirectoryCatalog catalog;
        private CompositionContainer container;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }


        [ImportMany]
        private ObservableCollection<IUserControl> _ControlList;
        /// <summary>
        /// ControlList
        /// </summary>
        public ObservableCollection<IUserControl> ControlList
        {
            get
            {
                return _ControlList;
            }
            set
            {
                _ControlList = value;
                RaisePropertyChanged("ControlList");
            }
        }

        private RelayCommand _LoadCommand = null;
        public RelayCommand LoadCommand
        {
            get
            {
                return _LoadCommand ?? new RelayCommand(() =>
                {
                    //プラグインフォルダ
                    string folder = Path.GetDirectoryName(
                        System.Reflection.Assembly
                        .GetExecutingAssembly().Location);

                    catalog = new DirectoryCatalog(folder);
                    container = new CompositionContainer(catalog);
                    container.ComposeParts(this);

                    RaisePropertyChanged("ControlList");
                });
            }
        }

    }
}