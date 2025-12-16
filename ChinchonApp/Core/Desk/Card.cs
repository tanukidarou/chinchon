using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinchonApp.Core.Desk
{
    abstract class Card
    {
        public CardType CardType { get; internal set; }
    }
}
