using MapApp.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapApp.Hints
{
    internal interface IHint
    {
        void show(HintPage hintPage);

        void hideHint(HintPage hintPage);
    }
}
