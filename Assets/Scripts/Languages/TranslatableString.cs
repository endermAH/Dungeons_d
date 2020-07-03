using System.Collections.Generic;

namespace Languages
{
    public readonly struct TranslatableString
    {
        public readonly string[] Text;

        public TranslatableString(string[] text)
        {
            Text = text;
        }
        
        // TODO: Global language variable
        public override string ToString()
        {
            return Text[0];
        }
    }
}
