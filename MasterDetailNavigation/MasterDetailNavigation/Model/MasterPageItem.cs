using System;
namespace MasterDetailNavigation
{
    public class MasterPageItem
    {
        public string Title {get; set;}
        public Type TargetType { get; set;  }

        public MasterPageItem()
        {
        }
    }
}
