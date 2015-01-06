using System.Collections.ObjectModel;
using System.Windows;

namespace LocalizedWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    
    class TheDataContext
    {
        // NOTE:
        // English resources are in Properties\Resources.resx
        // Japanese resources are in Properties\Resources.ja.resx
        // When compiling, Visual Studio will create the file ja\LocalizedWpfApp.resources.dll which contains Japanese resources.

        public ObservableCollection<string> ManyItemsCollection { get; private set; }

        public string NumberText { get; private set; }
        public string CurrencyText { get; private set; }

        public TheDataContext()
        {
            ManyItemsCollection = new ObservableCollection<string>();

            // Numbers should be formatted according to the location we're in (e.g. US, Japan)
            // We should use standard formats as much as we can.
            // Standard number formats are in http://msdn.microsoft.com/en-us/library/dwhawy9k(v=vs.110).aspx
            const int theNumber = 12345;
            NumberText = theNumber.ToString("n");
            CurrencyText = theNumber.ToString("c");

            // Texts should be put into resources.
            // The Name of the resource should indicate the context of the string (e.g. where it is, how it is used).
            // Use comments in the resource file to explain more about the usage of the string, if necessary.
            var templatePlural = Properties.Resources.TheDataContext_Template;

            var count = 3;
            ManyItemsCollection.Add(templatePlural.Fill(Properties.Resources.TheDataContext_FirstSmall, count));
            ManyItemsCollection.Add(templatePlural.Fill(Properties.Resources.TheDataContext_SecondSmall, count));
            ManyItemsCollection.Add(templatePlural.Fill(Properties.Resources.TheDataContext_ThirdSmall, count));
        }
    }
}
