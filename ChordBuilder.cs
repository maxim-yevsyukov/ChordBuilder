using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Configuration;

namespace ToliyGuitarSchoolHelper
{
    public partial class ChordBuilder : Form
    {

        #region private members
        private const string imageDirectory = "./Images/";

        public const string OutputDirectory = "./Output/";

        private const int rPanelCtrlXStep = 20;

        private const int rPanelCtrlYStep = 15;

        private ChordBuilder.Mode mode;

        public Image AccordCurrent = null;

        private string StrChordFileName = "default.tif";

        private static int nameCounter;

        private Image accordPrevious = null;

        private Image accordBlank = null;

        private Point accordScreenLocation;

        private ArrayList dockArray;

        private bool workSheetModified = false;

        private bool workSheetOpenedForEdit = false;
        #endregion

        public string ChordFileName
        {
            set
            {
                this.StrChordFileName = value;
            }
        }

        static ChordBuilder()
        {
            ChordBuilder.nameCounter = 1;
        }

        public ChordBuilder()
        {
            this.InitializeComponent();
            base.Move += new EventHandler(this.AccordBuilder_Move);
            this.btnUndoLastEdit.Enabled = false;
            this.dockArray = new ArrayList();
            this.LoadResources();
            this.mode = ChordBuilder.Mode.Place;
            this.btnAssemblyMode.Enabled = false;
        }

        private void AccordBuilder_Move(object sender, EventArgs e)
        {
            int x = this.pnlLeft.Location.X;
            Point location = this.splitContainer1.Location;
            int num = x + location.X;
            location = this.pnlBase.Location;
            int x1 = num + location.X;
            location = base.Location;
            int num1 = x1 + location.X + 4;
            int y = this.pnlLeft.Location.Y;
            location = this.splitContainer1.Location;
            int y1 = y + location.Y;
            location = this.pnlBase.Location;
            int y2 = y1 + location.Y;
            location = base.Location;
            this.accordScreenLocation = new Point(num1, y2 + location.Y + 30);
        }

        private void btnAssemblyMode_Click(object sender, EventArgs e)
        {
            this.mode = ChordBuilder.Mode.Place;
            ((Button)sender).Enabled = false;
            this.btnDeleteMode.Enabled = true;
        }

        private void btnDeleteMode_Click(object sender, EventArgs e)
        {
            this.mode = ChordBuilder.Mode.Erase;
            ((Button)sender).Enabled = false;
            this.btnAssemblyMode.Enabled = true;
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            this.LoadNewBlank();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!this.workSheetModified)
            {
                this.openChordForEdit();
            }
            else if (MessageBox.Show("Есть несохранённые изменения. Сохранить?", "Сохранить?", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                this.openChordForEdit();
            }
            else if (this.Save())
            {
                this.openChordForEdit();
            }
        }

        private void btnGiveName_Click(object sender, EventArgs e)
        {
            (new NameChord(this)).ShowDialog(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
            Console.WriteLine("Accord successfully saved!");
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                this.LoadNewBlank();
                this.pnlLeft.Refresh();
            }
        }

        private void btnUndoLastEdit_Click(object sender, EventArgs e)
        {
            this.restoreChordFromCopy();
            this.pnlLeft.BackgroundImage = this.AccordCurrent;
            this.pnlLeft.Refresh();
        }

        private void cboActivityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.workSheetModified)
            {
                this.setBackgroundAndDocking();
            }
            else
            {
                DialogResult res = MessageBox.Show("Сохранить?", "Ойбай!", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Yes)
                {
                    this.Save();
                    this.setBackgroundAndDocking();
                }
                else if (res == DialogResult.No)
                {
                    this.setBackgroundAndDocking();
                }
            }
        }

        private void CheckAndErase(object sender, MouseEventArgs e)
        {
            foreach (BaseDock dck in this.dockArray)
            {
                if (dck.IsNear(e.Location))
                {
                    this.restoreBlankFragment(sender, dck);
                    break;
                }
            }
        }


        private void LoadNewBlank()
        {
            if (this.AccordCurrent != null)
            {
                this.AccordCurrent.Dispose();
            }
            this.AccordCurrent = (Image)this.accordBlank.Clone();
            this.pnlLeft.BackgroundImage = this.AccordCurrent;
            this.pnlLeft.Refresh();
            this.StrChordFileName = "default.tif";
            this.workSheetOpenedForEdit = false;
        }

        private void LoadResources()
        {
            Image img;
            Exception ex;
            SelectableBackground sbg;
            string[] files = Directory.GetFiles("./Images/");
            int curCtrlXCoord = 20;
            int curCtrlYCoord = 50;
            int counter = 0;
            string[] strArrays = files;
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string fname = strArrays[i];
                if (fname.Contains<char>('\u005F'))
                {
                    try
                    {
                        img = Image.FromFile(fname);
                    }
                    catch (Exception exception)
                    {
                        ex = exception;
                        continue;
                    }
                    Panel pnl = new Panel();
                    int undScrIdx = fname.IndexOf('\u005F');
                    int lastSlashIdx = fname.LastIndexOf('/');
                    img.Tag = fname.Substring(lastSlashIdx + 1, undScrIdx - lastSlashIdx - 1);
                    pnl.Name = string.Concat("pnl", fname.Substring(undScrIdx + 1, fname.LastIndexOf('.') - undScrIdx - 1));
                    pnl.Size = img.Size;
                    pnl.BackgroundImage = img;
                    int num = counter;
                    counter = num + 1;
                    pnl.TabIndex = num;
                    pnl.Enabled = true;
                    pnl.Visible = true;
                    pnl.Location = new Point(curCtrlXCoord, curCtrlYCoord);
                    pnl.MouseDown += new MouseEventHandler(this.panel_MouseDown);
                    this.splitContainer1.Panel2.Controls.Add(pnl);
                    Size size = pnl.Size;
                    curCtrlXCoord = curCtrlXCoord + size.Width + 20;
                    if (counter % 4 == 0)
                    {
                        size = pnl.Size;
                        curCtrlYCoord = curCtrlYCoord + size.Height + 15;
                        curCtrlXCoord = 20;
                    }
                }
                else if (fname.Contains("empty"))
                {
                    int dashIdx = fname.IndexOf('-');
                    int dotIdx = fname.Substring(dashIdx).IndexOf('.');
                    string curFretNumber = fname.Substring(dashIdx + 1, dotIdx - 1);
                    try
                    {
                        sbg = new SelectableBackground(fname, curFretNumber);
                    }
                    catch (Exception exception1)
                    {
                        ex = exception1;
                        continue;
                    }
                    this.cboActivityType.Items.Add(sbg);
                    if (curFretNumber == ConfigurationManager.AppSettings["FretNumber"])
                    {
                        this.cboActivityType.SelectedItem = sbg;
                        this.setBackgroundAndDocking();
                        int num1 = counter;
                        counter = num1 + 1;
                        this.pnlLeft.TabIndex = num1;
                        this.pnlLeft.Enabled = true;
                        this.pnlLeft.Visible = true;
                        this.pnlLeft.BackgroundImageLayout = ImageLayout.Center;
                        this.pnlLeft.MouseDown += new MouseEventHandler(this.panel_MouseDown);
                        this.splitContainer1.Panel1.Controls.Add(this.pnlLeft);
                    }
                }
                //Label0:
            }
        }

        public void makeChordReserveCopy()
        {
            if (this.AccordCurrent != null)
            {
                this.workSheetModified = true;
                if (this.accordPrevious != null)
                {
                    this.accordPrevious.Dispose();
                }
                this.accordPrevious = (Image)this.AccordCurrent.Clone();
                this.btnUndoLastEdit.Enabled = true;
            }
        }

        private void openChordForEdit()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                this.makeChordReserveCopy();
                if (this.AccordCurrent != null)
                {
                    this.AccordCurrent.Dispose();
                }
                string filename = ofd.FileName;
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                this.AccordCurrent = Image.FromStream(fs);
                this.ChordFileName = filename.Substring(filename.LastIndexOf('\\') + 1);
                filename = null;
                this.pnlLeft.BackgroundImage = this.AccordCurrent;
                this.pnlLeft.Refresh();
                this.workSheetOpenedForEdit = true;
            }
            ofd.Dispose();
        }

        private void panel_DragDrop(object sender, DragEventArgs e)
        {
            Panel destination = (Panel)sender;
            Image droppedImage = (Bitmap)e.Data.GetData(typeof(Bitmap));
            switch (this.mode)
            {
                case ChordBuilder.Mode.Place:
                    {
                        foreach (BaseDock dock in this.dockArray)
                        {
                            if (dock.Type.ToString().ToLower() == droppedImage.Tag.ToString())
                            {
                                if (dock.IsNear(new Point(e.X - this.accordScreenLocation.X, e.Y - this.accordScreenLocation.Y)))
                                {
                                    this.makeChordReserveCopy();
                                    Graphics graphics = Graphics.FromImage(destination.BackgroundImage);
                                    graphics.DrawImage(droppedImage, dock.InLocX, dock.InLocY);
                                    destination.Refresh();
                                    graphics.Dispose();
                                    break;
                                }
                            }
                        }
                        break;
                    }
            }
        }

        private void panel_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(Bitmap)))
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            switch (this.mode)
            {
                case ChordBuilder.Mode.Place:
                    {
                        base.DoDragDrop(((Panel)sender).BackgroundImage, DragDropEffects.Copy);
                        break;
                    }
                case ChordBuilder.Mode.Erase:
                    {
                        this.CheckAndErase(sender, e);
                        break;
                    }
            }
        }

        private void readDocksIn()
        {
            BaseDockType dockType;
            string docking = File.ReadAllText(string.Concat("docking_", this.cboActivityType.SelectedItem.ToString(), "_frets.txt"));
            char[] chrArray = new char[] { '\n' };
            string[] strArrays = docking.Split(chrArray);
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str = strArrays[i];
                chrArray = new char[] { '\n', '\r' };
                string str1 = str.TrimEnd(chrArray);
                chrArray = new char[] { ' ' };
                string[] parts = str1.Split(chrArray);
                if ((int)parts.Length == 7)
                {
                    Point loc = new Point(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]));
                    Size size = new Size(Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]));
                    string str2 = parts[6];
                    if (str2 != null)
                    {
                        if (str2 == "Fret")
                        {
                            dockType = BaseDockType.Fret;
                            goto Label0;
                        }
                        else if (str2 == "Muting")
                        {
                            dockType = BaseDockType.Muting;
                            goto Label0;
                        }
                        else
                        {
                            if (str2 != "Finger")
                            {
                                goto Label2;
                            }
                            dockType = BaseDockType.Finger;
                            goto Label0;
                        }
                    }
                    Label2:
                    dockType = BaseDockType.Finger;
                    Label0:
                    BaseDock dock = new BaseDock(this.pnlLeft, dockType, loc, size, Convert.ToInt32(parts[4]), Convert.ToInt32(parts[5]));
                    this.dockArray.Add(dock);
                }
            }
        }

        private void restoreBlankFragment(object sender, BaseDock dock)
        {
            this.makeChordReserveCopy();
            Graphics graphCurrent = Graphics.FromImage(((Panel)sender).BackgroundImage);
            graphCurrent.DrawImage(this.accordBlank, dock.InLocX, dock.InLocY, new Rectangle(dock.InLocX, dock.InLocY, dock.InWidth, dock.InHeight), GraphicsUnit.Pixel);
            ((Panel)sender).Refresh();
            graphCurrent.Dispose();
        }

        private void restoreChordFromCopy()
        {
            if (this.accordPrevious != null)
            {
                if (this.AccordCurrent != null)
                {
                    this.AccordCurrent.Dispose();
                }
                this.AccordCurrent = (Image)this.accordPrevious.Clone();
                this.btnUndoLastEdit.Enabled = false;
            }
        }

        private bool Save()
        {
            bool flag;
            if (!(this.StrChordFileName == "default.tif"))
            {
                if (this.AccordCurrent == null)
                {
                    flag = false;
                    return flag;
                }
                if (File.Exists(this.StrChordFileName))
                {
                    if (this.workSheetOpenedForEdit)
                    {
                        File.Delete(this.StrChordFileName);
                        this.AccordCurrent.Save(string.Concat(ConfigurationManager.AppSettings["OutputDirectory"], "\\", this.StrChordFileName), ImageFormat.Tiff);
                        this.workSheetModified = false;
                        flag = true;
                        return flag;
                    }
                    MessageBox.Show(string.Concat("Файл с именем ", this.StrChordFileName, " уже существует. Задайте другое имя!"), "Ойбай!");
                    flag = false;
                    return flag;
                }

                using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(string.Concat(ConfigurationManager.AppSettings["OutputDirectory"], "\\", this.StrChordFileName), FileMode.Create, FileAccess.ReadWrite))
                    {
                        AccordCurrent.Save(memory, ImageFormat.Tiff);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
                //this.AccordCurrent.Save(string.Concat(ConfigurationManager.AppSettings["OutputDirectory"], "\\", this.StrChordFileName), ImageFormat.Tiff);

                this.workSheetModified = false;
                flag = true;
                return flag;
            }
            else
            {
                MessageBox.Show("Не задано имя аккорда", "Внимание!");
            }
            flag = false;
            return flag;
        }

        private void setBackgroundAndDocking()
        {
            SelectableBackground sbg = this.cboActivityType.SelectedItem as SelectableBackground;
            this.accordBlank = (Image)sbg.Image.Clone();
            this.AccordCurrent = sbg.Image.Clone() as Image;
            this.pnlLeft.Size = sbg.Image.Size;
            this.pnlLeft.BackgroundImage = this.AccordCurrent;
            this.readDocksIn();
        }

        public enum Mode
        {
            Place,
            Erase
        }
    }
}
