using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Helper
{

    public enum Lang
    {
        RUS,
        ENG,
    }
    class LANG
    {
        public static string l1 { get; private set; }
        public static string l2 { get; private set; }




        public static void ChangeLang(Lang lang)
        {
            switch (lang)
            {
                case Lang.RUS:
                    l1 = "дом";
                    l2 = "имя";
                    break;
                case Lang.ENG:
                    l1 = "home";
                    l2 = "name";
                    break;
                default:
                    break;
            }
        }
}
