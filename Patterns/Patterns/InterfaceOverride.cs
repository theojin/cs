using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public interface IUndoable { void Undo(); }

    public class TextBox : IUndoable
    {
        void IUndoable.Undo() => Undo();
        public virtual void Undo() => Console.WriteLine("Textbox.Undo");
    }

    public class RichTextBox : TextBox
    {
        public override void Undo() => Console.WriteLine("RichTextBox.Undo");
    }

#if false
    class InterfaceOverride
    {
        private static void Main()
        {
            RichTextBox r = new RichTextBox();
            r.Undo();
        }
    }
#endif
}
