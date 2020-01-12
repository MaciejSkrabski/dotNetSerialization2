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
using System.IO;
using System.Xml;

namespace Serialization2
{
    /// <summary>
    /// Interaction logic for usunControll.xaml
    /// </summary>
    public partial class usunControl : UserControl
    {
        public usunControl()
        {
            InitializeComponent();
        }

        private void BZaladuj_Click(object sender, RoutedEventArgs e)
        {
            String sc = @sciezka.Text;
            Boolean fe = File.Exists(sc);

            Console.WriteLine(fe ? "File exists." : "File does not exist.");
            if(fe)
            {
                XmlDocument doc = new XmlDocument();
                try {
                    doc.Load(sc);
                    XmlTextReader reader = new XmlTextReader(sc);
                    foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                    {
                        string text = node.InnerXml; //or loop through its children as well
                        contentsLB.Items.Add(text);
                    }

                }
                catch (Exception err) { Console.WriteLine(err); }
            }
            
        }

        private void BUsun_Click(object sender, RoutedEventArgs e)
        {
           contentsLB.Items.Remove(contentsLB.SelectedItem);
        }

        private void BZapisz_Click(object sender, RoutedEventArgs e)
        {
            String sc = @sciezka.Text;
            Boolean fe = File.Exists(sc);
            if (fe)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string it in contentsLB.Items)
                {
                    sb.Append(it);
                }
            
                string s = "<xml>" + sb.ToString() + "</xml>";
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(s);
                xdoc.Save(sc);
            }
        }
    }
}
