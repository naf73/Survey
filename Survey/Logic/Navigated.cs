using Survey.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Survey.Logic
{
    public static class Navigated
    {
        private static Frame _frame;

        public static void Init(Frame frame)
        {
            _frame = frame;
        }

        public static void GoToAuthPage()
        {
            _frame.Navigate(new AuthPage());
        }
    }
}
