using System;
using System.Windows.Forms;

public class ImeRichTextBox : RichTextBox
{
    private const int WM_IME_COMPOSITION = 0x010F;

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_IME_COMPOSITION)
        {
            OnImeCompositionChanged();
        }
        base.WndProc(ref m);
    }

    public event EventHandler ImeCompositionChanged;

    protected virtual void OnImeCompositionChanged()
    {
        ImeCompositionChanged?.Invoke(this, EventArgs.Empty);
    }
}
