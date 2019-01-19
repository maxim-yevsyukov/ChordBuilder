using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ToliyGuitarSchoolHelper
{
    public partial class NameChord : Form
    {

        #region private fields
        private int curStrIdx = 0;
        private int curXoffset = 0;
        private Font font = null;
        private int pixPerLetter = 10;
        private int startDrawStringX;
        private int startDrawStringY = 4;
        private float baseMainFontSize = 9f;
        private float baseFlatSharpFontSize = 8f;
        private float mainFontSize = 12f;
        private float mainFlatSharpFontSize = 8f;
        private float mainSuperFontSize = 10f;
        private float minorFontSize = 11f;
        private float majFontSize = 8f;
        private float dimFontSize = 7f;
        private float susFontSize = 9f;
        private float addFontSize = 9f;
        private int baseMainYAdj = 5;
        private int baseFlatSharpYAdj = 2;
        private int mainFlatSharpYAdj = -3;
        private int mainSupYAdj = -2;
        private int minorYAdj = 4;
        private float majYAdj = 2f;
        private float dimYAdj = -2f;
        private float susYAdj = 4f;
        private float addYAdj = 5f;
        private int baseMainXStep = 8;
        private int baseFlatSharpXStep = 6;
        private int slashXStep = 3;
        private int mainMainXStep = 12;
        public int mainSupXStep = 7;
        private int mainFlatSharpXStep = 6;
        private int minorXStep = 15;
        private int majXStep = 40;
        private int dimXStep = 5;
        private int susXStep = 20;
        private int addXStep = 20;
        #endregion

        public NameChord(Form ownr)
        {
            InitializeComponent();
            Owner = ownr;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!(this.txbMain.Text != ""))
            {
                MessageBox.Show("Поле не должно быть пустым", "Вы что?!");
            }
            else
            {
                ((ChordBuilder)base.Owner).makeChordReserveCopy();
                Panel pnlLeft = (Panel)((SplitContainer)base.Owner.Controls["pnlBase"].Controls["splitContainer1"]).Panel1.Controls["pnlLeft"];
                string filename = "";
                Graphics grph = Graphics.FromImage(pnlLeft.BackgroundImage);
                grph.SmoothingMode = SmoothingMode.AntiAlias;
                Size size = ((ChordBuilder)base.Owner).AccordCurrent.Size;
                this.startDrawStringX = (size.Width - this.estimateNameLength()) / 2;
                try
                {
                    if (this.txbBase.Text != "")
                    {
                        filename = string.Concat(filename, "base", this.txbBase.Text.ToUpper());
                        this.font = new Font("Arial", this.baseMainFontSize, FontStyle.Bold);
                        grph.DrawString(this.txbBase.Text, this.font, SystemBrushes.WindowText, (float)this.startDrawStringX, (float)(this.startDrawStringY + this.baseMainYAdj));
                        this.curXoffset += this.baseMainXStep;
                        if (this.chbBaseFlat.Checked)
                        {
                            filename = string.Concat(filename, "Flat");
                            this.font = new Font("Arial", this.baseMainFontSize, FontStyle.Bold);
                            grph.DrawString("b", this.font, SystemBrushes.WindowText, (float)(this.startDrawStringX + this.curXoffset), (float)(this.startDrawStringY + this.baseFlatSharpYAdj));
                            this.curXoffset += this.baseFlatSharpXStep;
                        }
                        else if (this.chbBaseSharp.Checked)
                        {
                            filename = string.Concat(filename, "Sharp");
                            this.font = new Font("Arial", this.baseFlatSharpFontSize, FontStyle.Bold);
                            grph.DrawString("#", this.font, SystemBrushes.WindowText, (float)(this.startDrawStringX + this.curXoffset), (float)(this.startDrawStringY + this.baseFlatSharpYAdj));
                            this.curXoffset += this.baseFlatSharpXStep;
                        }
                        grph.DrawString("\\", this.font, SystemBrushes.WindowText, (float)(this.startDrawStringX + this.curXoffset), (float)(this.startDrawStringY + 3));
                        this.curXoffset += 3;
                    }
                    if (this.txbMain.Text != "")
                    {
                        filename = string.Concat(filename, this.txbMain.Text.ToUpper());
                        this.font = new Font("Arial", this.mainFontSize, FontStyle.Bold);
                        grph.DrawString(this.txbMain.Text, this.font, SystemBrushes.WindowText, (float)(this.startDrawStringX + this.curXoffset), (float)this.startDrawStringY);
                        this.curXoffset += this.mainMainXStep;
                    }
                    if (this.chbMainFlat.Checked)
                    {
                        filename = string.Concat(filename, "Flat");
                        this.font = new Font("Arial", this.mainSuperFontSize, FontStyle.Bold);
                        grph.DrawString("b", this.font, SystemBrushes.WindowText, (float)(this.startDrawStringX + this.curXoffset), (float)(this.startDrawStringY + this.mainFlatSharpYAdj));
                        this.curXoffset += this.mainFlatSharpXStep;
                    }
                    else if (this.chbMainSharp.Checked)
                    {
                        filename = string.Concat(filename, "Sharp");
                        this.font = new Font("Arial", this.mainSuperFontSize, FontStyle.Bold);
                        grph.DrawString("#", this.font, SystemBrushes.WindowText, (float)(this.startDrawStringX + this.curXoffset), (float)(this.startDrawStringY + this.mainFlatSharpYAdj));
                        this.curXoffset += this.mainFlatSharpXStep;
                    }
                    if (this.chbMinor.Checked)
                    {
                        filename = string.Concat(filename, "minor");
                        this.font = new Font("Arial", this.minorFontSize, FontStyle.Bold);
                        grph.DrawString("m", this.font, SystemBrushes.WindowText, (float)(this.startDrawStringX + this.curXoffset), (float)(this.startDrawStringY + 2));
                        this.curXoffset += this.minorXStep;
                    }
                    if (this.txbMaj.Text != "")
                    {
                        if (this.chbMinor.Checked)
                        {
                            this.curXoffset += 5;
                        }
                        filename = string.Concat(filename, "Maj", this.txbMaj.Text);
                        this.font = new Font("Arial", this.mainFontSize, FontStyle.Bold);
                        grph.DrawString(string.Concat("maj", this.txbMaj.Text), this.font, SystemBrushes.WindowText, (float)(this.startDrawStringX + this.curXoffset), (float)this.startDrawStringY + this.majYAdj);
                        this.curXoffset += this.majXStep;
                    }
                    if (this.txbSuper.Text != "")
                    {
                        if (this.chbMinor.Checked)
                        {
                            this.curXoffset += 3;
                        }
                        filename = string.Concat(filename, this.txbSuper.Text);
                        this.font = new Font("Arial", this.mainSuperFontSize, FontStyle.Bold);
                        grph.DrawString(this.txbSuper.Text, this.font, SystemBrushes.WindowText, (float)(this.startDrawStringX + this.curXoffset), (float)(this.startDrawStringY + this.mainSupYAdj));
                        this.curXoffset += this.mainSupXStep;
                    }
                    if (this.chbDiminished.Checked)
                    {
                        filename = string.Concat(filename, "dim");
                        this.font = new Font("Arial", this.dimFontSize, FontStyle.Bold);
                        grph.DrawString("o", this.font, SystemBrushes.WindowText, (float)(this.startDrawStringX + this.curXoffset), (float)this.startDrawStringY + this.dimYAdj);
                        this.curXoffset += this.dimXStep;
                    }
                    else if (this.chbHalfDiminished.Checked)
                    {
                        filename = string.Concat(filename, "hdim");
                        this.font = new Font("Arial", this.dimFontSize, FontStyle.Bold);
                        grph.DrawString("o", this.font, SystemBrushes.WindowText, (float)(this.startDrawStringX + this.curXoffset), (float)this.startDrawStringY + this.dimYAdj);
                        grph.DrawString("/", this.font, SystemBrushes.WindowText, (float)(this.startDrawStringX + this.curXoffset + 2), (float)this.startDrawStringY + this.dimYAdj + 1f);
                        this.curXoffset += this.dimXStep;
                    }
                    if (this.txbSuspend.Text != "")
                    {
                        filename = string.Concat(filename, "sus", this.txbSuspend.Text);
                        this.font = new Font("Arial", this.susFontSize, FontStyle.Bold);
                        grph.DrawString(string.Concat("sus", this.txbSuspend.Text), this.font, SystemBrushes.WindowText, (float)(this.startDrawStringX + this.curXoffset), (float)this.startDrawStringY + this.susYAdj);
                        this.curXoffset += this.susXStep;
                    }
                    if (this.txbAdd.Text != "")
                    {
                        filename = string.Concat(filename, "add", this.txbAdd.Text);
                        this.font = new Font("Arial", this.addFontSize, FontStyle.Bold);
                        grph.DrawString(string.Concat("add", this.txbAdd.Text), this.font, SystemBrushes.WindowText, (float)(this.startDrawStringX + this.curXoffset), (float)this.startDrawStringY + this.addYAdj);
                        this.curXoffset += this.addXStep;
                    }
                    if (this.txbVersion.Text != "")
                    {
                        filename = string.Concat(filename, "V", this.txbVersion.Text);
                        this.font = new Font("Arial", this.mainFontSize, FontStyle.Bold);
                        grph.DrawString(string.Concat("ver.", this.txbVersion.Text), this.font, SystemBrushes.WindowText, (float)(this.startDrawStringX + this.curXoffset + 3), (float)this.startDrawStringY);
                        NameChord nameChord = this;
                        nameChord.curXoffset = nameChord.curXoffset + this.mainMainXStep * 6;
                    }
                    filename = string.Concat(filename, this.txbFilenameSuffix.Text);
                    filename = string.Concat(filename, ".tif");
                    ((ChordBuilder)base.Owner).ChordFileName = filename;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                    MessageBox.Show("Ошибка", "Ойбай...");
                }
                pnlLeft.Refresh();
                grph.Dispose();
                base.Close();
                this.Dispose(true);
            }
        }

        private int estimateNameLength()
        {
            int ret = 0;
            if (this.txbBase.Text != "")
            {
                ret += this.pixPerLetter;
            }
            if ((this.chbBaseFlat.Checked ? true : this.chbBaseSharp.Checked))
            {
                ret += 3;
            }
            if (this.txbMain.Text != "")
            {
                ret += this.pixPerLetter;
            }
            if ((this.chbMainFlat.Checked ? true : this.chbMainSharp.Checked))
            {
                ret += 3;
            }
            if (this.chbMinor.Checked)
            {
                ret += this.pixPerLetter;
            }
            if (this.txbMaj.Text != "")
            {
                ret = ret + this.pixPerLetter * 5;
            }
            if (this.txbSuper.Text != "")
            {
                ret += 4;
            }
            if ((this.chbDiminished.Checked ? true : this.chbHalfDiminished.Checked))
            {
                ret += 3;
            }
            if (this.txbSuspend.Text != "")
            {
                ret = ret + this.pixPerLetter * 5;
            }
            if (this.txbAdd.Text != "")
            {
                ret = ret + this.pixPerLetter * 5;
            }
            if (this.txbVersion.Text != "")
            {
                ret = ret + this.pixPerLetter * 5;
            }
            return ret;
        }

        private void lblAdd_Click(object sender, EventArgs e)
        {
        }

        private void NameChord_Load(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }
    }
}