using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace MEFControlCommon
{
    public interface IUserControl
    {
        string Name { get; }

        string Version { get; }
        UserControl Control { get; }
    }
}