using Prism.Events;
using System.Windows;

namespace WpfMvvm
{
    /// <summary>
    /// View.xaml の相互作用ロジック
    /// </summary>
    public partial class View : Window
    {
        public View()
        {
            InitializeComponent();

            Messenger.Instance
                .GetEvent<PubSubEvent<double>>().Subscribe(
                    d => MessageBox.Show(d.ToString()));
        }
    }
}
