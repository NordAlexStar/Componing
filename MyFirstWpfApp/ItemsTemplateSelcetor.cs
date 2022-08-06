using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyFirstWpfApp
{
    public class ItemsTemplateSeletor : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is IGrouping<string, Car>)
            {
                return element.FindResource("H") as DataTemplate;
            }
            else return element.FindResource("P") as DataTemplate;
        }
    }
}
