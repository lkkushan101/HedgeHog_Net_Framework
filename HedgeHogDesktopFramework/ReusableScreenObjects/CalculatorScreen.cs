using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace HedgeHogDesktopFramework.ReusableScreenObjects
{
    class CalculatorScreen
    {
        public Window bootupApplication (String application_name, string appTitle)
        {
            Application application = Application.Launch(application_name);
            Window window = application.GetWindow(appTitle, InitializeOption.NoCache);
            return window;
        }
        public void clickButton (string button_caption, Window window)
        {
            Button button = window.Get<Button>(button_caption);
            button.Click();
        }

        public string getCalcAnswer(Window window, string automation_ID)
        {
            var textBox = window.Get(SearchCriteria.ByAutomationId(automation_ID));


            return  textBox.Name.ToString();
        }
    }
}
