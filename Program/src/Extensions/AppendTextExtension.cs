namespace MainFunction;
static class AppendTextExtension
{
    public static void AppendTextColorful(this RichTextBox rtBox, string addtext, Color color, int addNewLine = 1)
    {
        if (addtext.Equals(""))
        {
            return;
        }

        while (addNewLine-- > 0)
        {
            addtext += "\n";
        }

        rtBox.SelectionStart = rtBox.TextLength;
        rtBox.SelectionLength = addtext.Length;
        rtBox.SelectionColor = color;
        rtBox.AppendText(addtext);
        rtBox.SelectionColor = rtBox.ForeColor;
    }
}
