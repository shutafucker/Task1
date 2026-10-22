namespace LinqWinFormsApp;

public class FormQuestions : Form
{
    public FormQuestions()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.Text = "Вопросы для устной защиты работы (LINQ)";
        this.Size = new Size(820, 650);
        this.StartPosition = FormStartPosition.CenterParent;
        this.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
        this.BackColor = Color.FromArgb(245, 247, 250);

        var headerPanel = new Panel
        {
            Dock = DockStyle.Top,
            Height = 65,
            BackColor = Color.FromArgb(41, 128, 185),
            Padding = new Padding(15)
        };

        var titleLabel = new Label
        {
            Text = "Ответы на вопросы преподавателя для устной защиты",
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 13f, FontStyle.Bold),
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft
        };
        headerPanel.Controls.Add(titleLabel);

        var rtb = new RichTextBox
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            BackColor = Color.White,
            BorderStyle = BorderStyle.None,
            Padding = new Padding(20),
            Font = new Font("Segoe UI", 10.5f, FontStyle.Regular)
        };

        var bottomPanel = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 55,
            BackColor = Color.FromArgb(235, 240, 245),
            Padding = new Padding(10)
        };

        var btnClose = new Button
        {
            Text = "Закрыть",
            DialogResult = DialogResult.OK,
            Dock = DockStyle.Right,
            Width = 110,
            BackColor = Color.FromArgb(52, 152, 219),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
        btnClose.FlatAppearance.BorderSize = 0;
        bottomPanel.Controls.Add(btnClose);

        this.Controls.Add(rtb);
        this.Controls.Add(headerPanel);
        this.Controls.Add(bottomPanel);

        rtb.Rtf = GetQuestionsRtf();
    }

    private string GetQuestionsRtf()
    {
        // Создаем аккуратный форматированный текст с ответами на 4 вопроса
        return @"{\rtf1\ansi\ansicpg1251\deff0\nouicompat{\fonttbl{\f0\fnil\fcharset204 Segoe UI;}{\f1\fnil\fcharset0 Consolas;}}
{\colortbl ;\red41\green128\blue185;\red39\green174\blue96;\red192\green57\blue43;\red52\green73\blue94;\red127\green140\blue141;}
\viewkind4\uc1 
\pard\sa200\sl276\slmult1\b\f0\fs26\cf1 1. \'c2 \'f7\'e5\'ec \'f0\'e0\'e7\'ed\'e8\'f6\'e0 \'ec\'e5\'e6\'e4\'f3 \'ee\'ef\'e5\'f0\'e0\'f2\'ee\'f0\'e0\'ec\'e8 LINQ Join \'e8 GroupJoin?\b0\fs22\par
\pard\sa150\sl250\slmult1\cf4\b \'95 Join (Inner Join / \'c2\'ed\'f3\'f2\'f0\'e5\'ed\'ed\'e5\'e5 \'f1\'ee\'e5\'e4\'e8\'ed\'e5\'ed\'e8\'e5):\b0  \'f1\'ee\'ef\'ee\'f1\'f2\'e0\'e2\'eb\'ff\'e5\'f2 \'ea\'e0\'e6\'e4\'fb\'e9 \'fd\'eb\'e5\'ec\'e5\'ed\'f2 \'ef\'e5\'f0\'e2\'ee\'e9 \'ea\'ee\'eb\'eb\'e5\'ea\'f6\'e8\'e8 \'f1 \'ea\'e0\'e6\'e4\'fb\'ec \'f1\'ee\'e2\'ef\'e0\'e4\'e0\'fe\'f9\'e8\'ec \'fd\'eb\'e5\'ec\'e5\'ed\'f2\'ee\'ec \'e2\'f2\'ee\'f0\'ee\'e9 \'ea\'ee\'eb\'eb\'e5\'ea\'f6\'e8\'e8 (1-\'ea-1 \'e8\'eb\'e8 \'ef\'eb\'ee\'f1\'ea\'ee\'e5 1-\'ea-\'cc\'ed\'ee\'e3\'e8\'ec). \'c5\'f1\'eb\'e8 \'f1\'ee\'e2\'ef\'e0\'e4\'e5\'ed\'e8\'ff \'ed\'e5\'f2, \'fd\'eb\'e5\'ec\'e5\'ed\'f2 \b \'e8\'f1\'ea\'eb\'fe\'f7\'e0\'e5\'f2\'f1\'ff\b0  \'e8\'e7 \'e8\'f2\'ee\'e3\'ee\'e2\'ee\'e3\'ee \'f0\'e5\'e7\'f3\'eb\'fc\'f2\'e0\'f2\'e0.\par
\b \'95 GroupJoin (Left Outer / Hierarchical Join):\b0  \'e4\'eb\'ff \'ea\'e0\'e6\'e4\'ee\'e3\'ee \'fd\'eb\'e5\'ec\'e5\'ed\'f2\'e0 \'ef\'e5\'f0\'e2\'ee\'e9 \'ea\'ee\'eb\'eb\'e5\'ea\'f6\'e8\'e8 \'f4\'ee\'f0\'ec\'e8\'f0\'f3\'e5\'f2 \b \'e8\'e5\'f0\'e0\'f0\'f5\'e8\'f7\'e5\'f1\'ea\'f3\'fe \'e3\'f0\'f3\'ef\'ef\'f3\b0  \'e2\'f1\'e5\'f5 \'f1\'ee\'ee\'f2\'e2\'e5\'f2\'f1\'f2\'e2\'f3\'fe\'f9\'e8\'ec \'fd\'eb\'e5\'ec\'e5\'ed\'f2\'ee\'e2 \'e2\'f2\'ee\'f0\'ee\'e9 \'ea\'ee\'eb\'eb\'e5\'ea\'f6\'e8\'e8 (\f1 IEnumerable<TInner>\f0 ). \'c5\'f1\'eb\'e8 \'f1\'ee\'e2\'ef\'e0\'e4\'e5\'ed\'e8\'e9 \'ed\'e5\'f2, \'fd\'eb\'e5\'ec\'e5\'ed\'f2 \b \'ed\'e5 \'f2\'e5\'f0\'ff\'e5\'f2\'f1\'ff\b0 , \'e0 \'ef\'ee\'eb\'f3\'f7\'e0\'e5\'f2 \'ef\'f3\'f1\'f2\'f3\'fe \'ea\'ee\'eb\'eb\'e5\'ea\'f6\'e8\'fe (\f1 Count == 0\f0 ).\par

\pard\sa200\sl276\slmult1\b\fs26\cf1 2. \'ca\'e0\'ea\'f3\'fe \'f1\'f2\'f0\'f3\'ea\'f2\'f3\'f0\'f3 \'e8\'ec\'e5\'e5\'f2 \'f0\'e5\'e7\'f3\'eb\'fc\'f2\'e0\'f2 \'e2\'fb\'ef\'ee\'eb\'ed\'e5\'ed\'e8\'ff \'ec\'e5\'f2\'ee\'e4\'e0 GroupBy (IGrouping<TKey, TElement>)?\b0\fs22\par
\pard\sa150\sl250\slmult1\cf4 \'cc\'e5\'f2\'ee\'e4 \f1 GroupBy\f0  \'e2\'ee\'e7\'e2\'f0\'e0\'f9\'e0\'e5\'f2 \'ea\'ee\'eb\'eb\'e5\'ea\'f6\'e8\'fe \f1 IEnumerable<IGrouping<TKey, TElement>>\f0 .\par
\'ca\'e0\'e6\'e4\'fb\'e9 \'ee\'e1\'fa\'e5\'ea\'f2 \f1 IGrouping<TKey, TElement>\f0  \'ef\'f0\'e5\'e4\'f1\'f2\'e0\'e2\'eb\'ff\'e5\'f2 \'f1\'ee\'e1\'ee\'e9 \'ea\'ee\'eb\'eb\'e5\'ea\'f6\'e8\'fe \'fd\'eb\'e5\'ec\'e5\'ed\'f2\'ee\'e2 \f1 IEnumerable<TElement>\f0 , \'ee\'e1\'eb\'e0\'e4\'e0\'fe\'f9\'f3\'fe \'f1\'e2\'ee\'e9\'f1\'f2\'e2\'ee\'ec \b\f1 Key\b0\f0  (\f1 TKey\f0  \'97 \'ea\'eb\'fe\'f7 \'e3\'f0\'f3\'ef\'ef\'e8\'f0\'ee\'e2\'ea\'e8). \'d2\'ee \'e5\'f1\'f2\'fc \f1 IGrouping\f0  \'97 \'fd\'f2\'ee \'ea\'ee\'eb\'eb\'e5\'ea\'f6\'e8\'ff \'fd\'eb\'e5\'ec\'e5\'ed\'f2\'ee\'e2, \'f1\'e3\'f0\'f3\'ef\'ef\'e8\'f0\'ee\'e2\'e0\'ed\'ed\'fb\'f5 \'ef\'ee \'ee\'e1\'f9\'e5\'ec\'f3 \'ef\'f0\'e8\'e7\'ed\'e0\'ea\'f3 (Key).\par

\pard\sa200\sl276\slmult1\b\fs26\cf1 3. \'ca\'e0\'ea \'f0\'e0\'e1\'ee\'f2\'e0\'e5\'f2 \'ea\'ee\'ec\'e1\'e8\'ed\'e0\'f6\'e8\'ff \'ec\'e5\'f2\'ee\'e4\'ee\'e2 Skip(N) \'e8 Take(M) \'ef\'f0\'e8 \'f0\'e5\'e0\'eb\'e8\'e7\'e0\'f6\'e8\'e8 \'ef\'ee\'f1\'f2\'f0\'e0\'ed\'e8\'f7\'ed\'ee\'e3\'ee \'e2\'fb\'e2\'ee\'e4\'e0?\b0\fs22\par
\pard\sa150\sl250\slmult1\cf4\b \'95 Skip(N):\b0  \'ef\'f0\'ee\'ef\'f3\'f1\'ea\'e0\'e5\'f2 \'ef\'e5\'f0\'e2\'fb\'e5 N \'fd\'eb\'e5\'ec\'e5\'ed\'f2\'ee\'e2 \'ef\'ee\'f1\'eb\'e5\'e4\'ee\'e2\'e0\'f2\'e5\'eb\'fc\'ed\'ee\'f1\'f2\'e8. \'c4\'eb\'ff \'ef\'e5\'e9\'e4\'e6\'e8\'ed\'e3\'e0: \f1 Skip((pageNumber - 1) * pageSize)\f0 .\par
\b \'95 Take(M):\b0  \'e8\'e7 \'ee\'f1\'f2\'e0\'e2\'f8\'e5\'e9\'f1\'ff \'f7\'e0\'f1\'f2\'e8 \'e2\'fb\'e1\'e8\'f0\'e0\'e5\'f2 \'ed\'e5 \'e1\'ee\'eb\'e5\'e5 M \'fd\'eb\'e5\'ec\'e5\'ed\'f2\'ee\'e2 (pageSize).\par
\'c2\'ec\'e5\'f1\'f2\'e5 \'ee\'ed\'e8 \'f4\'ee\'f0\'ec\'e8\'f0\'f3\'e5\'f2 \b \'f1\'ea\'ee\'eb\'fc\'e7\'ff\'f9\'e5\'e5 \'ee\'ea\'ed\'ee\b0  \'f0\'e0\'e7\'ec\'e5\'f0\'ee\'ec M, \'f1\'e4\'e2\'e8\'ed\'f3\'f2\'ee\'e5 \'ed\'e0 N \'fd\'eb\'e5\'ec\'e5\'ed\'f2\'ee\'e2, \'f7\'f2\'ee \'ef\'ee\'e7\'e2\'ee\'eb\'ff\'e5\'f2 \'e8\'e7\'e2\'eb\'e5\'ea\'e0\'f2\'fc \'f1\'f2\'f0\'ee\'e3\'ee \'ee\'e4\'ed\'f3 \'f1\'f2\'f0\'e0\'ed\'e8\'f6\'f3 \'e1\'e5\'e7 \'e7\'e0\'e3\'f0\'f3\'e7\'ea\'e8 \'e2\'f1\'e5\'e9 \'ea\'ee\'eb\'eb\'e5\'ea\'f6\'e8\'e8 \'e2 \'ef\'e0\'ec\'ff\'f2\'fc.\par

\pard\sa200\sl276\slmult1\b\fs26\cf1 4. \'c2 \'ea\'e0\'ea\'ee\'ec \'ef\'ee\'f0\'ff\'e4\'ea\'e5 \'ed\'e5\'ee\'e1\'f5\'ee\'e4\'e8\'ec\'ee \'e2\'fb\'e7\'fb\'e2\'e0\'f2\'fc OrderBy, Skip \'e8 Take \'e4\'eb\'ff \'ea\'ee\'f0\'f0\'e5\'ea\'f2\'ed\'ee\'e9 \'f1\'ee\'f0\'f2\'e8\'f0\'ee\'e2\'ea\'e8 \'ef\'e0\'e3\'e8\'ed\'e8\'f0\'ee\'e2\'e0\'ed\'ed\'fb\'f5 \'e4\'e0\'ed\'ed\'fb\'f5?\b0\fs22\par
\pard\sa150\sl250\slmult1\cf4 \'cf\'ee\'f0\'ff\'e4\'ee\'ea \'f1\'f2\'f0\'ee\'e3\'ee \'f1\'eb\'e5\'e4\'f3\'fe\'f9\'e8\'e9: \b\cf2 1) OrderBy  -->  2) Skip  -->  3) Take\cf4\b0\par
\b \'cf\'ee\'f7\'e5\'ec\'f3:\b0  \'c5\'f1\'eb\'e8 \'f1\'ed\'e0\'f7\'e0\'eb\'e0 \'f1\'e4\'e5\'eb\'e0\'f2\'fc Skip/Take, \'e0 \'ef\'ee\'f2\'ee\'ec OrderBy, \'f1\'ee\'f0\'f2\'e8\'f0\'ee\'e2\'ea\'e0 \'ef\'f0\'e8\'ec\'e5\'ed\'e8\'f2\'f1\'ff \b \'f2\'ee\'eb\'fc\'ea\'ee \'ea \'fd\'eb\'e5\'ec\'e5\'ed\'f2\'e0\'ec \'f2\'e5\'ea\'f3\'f9\'e5\'e9 \'f1\'f2\'f0\'e0\'ed\'e8\'f6\'fb\b0 , \'e0 \'ed\'e5 \'ea\'ee \'e2\'f1\'e5\'ec\'f3 \'ed\'e0\'e1\'ee\'f0\'f3, \'f7\'f2\'ee \'ef\'f0\'e8\'e2\'e5\'e4\'e5\'f2 \'ea \'f5\'e0\'ee\'f1\'f3 \'ef\'f0\'e8 \'ef\'e5\'f0\'e5\'ea\'eb\'fe\'f7\'e5\'ed\'e8\'e8 \'f1\'f2\'f0\'e0\'ed\'e8\'f6 \'e8 \'ef\'ee\'f2\'e5\'f0\'e5 \'e4\'e5\'f2\'e5\'f0\'ec\'e8\'ed\'e8\'f0\'ee\'e2\'e0\'ed\'ed\'ee\'f1\'f2\'e8.\par
}";
    }
}
