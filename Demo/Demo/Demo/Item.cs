using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using Xamarin.Forms;

namespace Demo
{
    [Persistent]
    public class Item : XPObject
    {
       
        string text;
        [Size(256)]
        public string Text
        {
            get { return text; }
            set { SetPropertyValue("Text", ref text, value); }
        }
        string description;

        public Item()
        {
        }

        public Item(Session session) : base(session)
        {
        }

        public Item(Session session, XPClassInfo classInfo) : base(session, classInfo)
        {
        }

        [Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get { return description; }
            set { SetPropertyValue("Description", ref description, value); }
        }

        int _index;
        public int Index
        {
            get => _index;
            set => SetPropertyValue(nameof(Index), ref _index, value);
        }
    }
}
