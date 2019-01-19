using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToliyGuitarSchoolHelper
{
    partial class ChordBuilder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlBase = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnDeleteMode = new System.Windows.Forms.Button();
            this.btnAssemblyMode = new System.Windows.Forms.Button();
            this.btnUndoLastEdit = new System.Windows.Forms.Button();
            this.cboActivityType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnGiveName = new System.Windows.Forms.Button();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.splitContainer1);
            this.pnlBase.Location = new System.Drawing.Point(25, 70);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(486, 444);
            this.pnlBase.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AllowDrop = true;
            this.splitContainer1.Panel1.Controls.Add(this.pnlLeft);
            this.splitContainer1.Size = new System.Drawing.Size(486, 444);
            this.splitContainer1.SplitterDistance = 201;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.AllowDrop = true;
            this.pnlLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlLeft.Location = new System.Drawing.Point(20, 3);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(148, 410);
            this.pnlLeft.TabIndex = 0;
            this.pnlLeft.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel_DragDrop);
            this.pnlLeft.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // btnDeleteMode
            // 
            this.btnDeleteMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteMode.Location = new System.Drawing.Point(107, 19);
            this.btnDeleteMode.Name = "btnDeleteMode";
            this.btnDeleteMode.Size = new System.Drawing.Size(61, 22);
            this.btnDeleteMode.TabIndex = 9;
            this.btnDeleteMode.Text = "Чистка";
            this.btnDeleteMode.UseVisualStyleBackColor = true;
            this.btnDeleteMode.Click += new System.EventHandler(this.btnDeleteMode_Click);
            // 
            // btnAssemblyMode
            // 
            this.btnAssemblyMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssemblyMode.Location = new System.Drawing.Point(35, 19);
            this.btnAssemblyMode.Name = "btnAssemblyMode";
            this.btnAssemblyMode.Size = new System.Drawing.Size(45, 22);
            this.btnAssemblyMode.TabIndex = 8;
            this.btnAssemblyMode.Text = "Сборка";
            this.btnAssemblyMode.UseVisualStyleBackColor = true;
            this.btnAssemblyMode.Click += new System.EventHandler(this.btnAssemblyMode_Click);
            // 
            // btnUndoLastEdit
            // 
            this.btnUndoLastEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndoLastEdit.Location = new System.Drawing.Point(38, 19);
            this.btnUndoLastEdit.Name = "btnUndoLastEdit";
            this.btnUndoLastEdit.Size = new System.Drawing.Size(104, 22);
            this.btnUndoLastEdit.TabIndex = 7;
            this.btnUndoLastEdit.Text = "Отменить последнее";
            this.btnUndoLastEdit.UseVisualStyleBackColor = true;
            this.btnUndoLastEdit.Click += new System.EventHandler(this.btnUndoLastEdit_Click);
            // 
            // cboActivityType
            // 
            this.cboActivityType.FormattingEnabled = true;
            this.cboActivityType.Location = new System.Drawing.Point(99, 543);
            this.cboActivityType.Name = "cboActivityType";
            this.cboActivityType.Size = new System.Drawing.Size(88, 21);
            this.cboActivityType.TabIndex = 1;
            this.cboActivityType.SelectedIndexChanged += new System.EventHandler(this.cboActivityType_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(231, 604);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Location = new System.Drawing.Point(25, 604);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(162, 23);
            this.btnSaveNew.TabIndex = 3;
            this.btnSaveNew.Text = "Сохранить и начать новый";
            this.btnSaveNew.UseVisualStyleBackColor = true;
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(379, 605);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(123, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Править существующий";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnGiveName
            // 
            this.btnGiveName.Location = new System.Drawing.Point(231, 541);
            this.btnGiveName.Name = "btnGiveName";
            this.btnGiveName.Size = new System.Drawing.Size(280, 23);
            this.btnGiveName.TabIndex = 5;
            this.btnGiveName.Text = "Описать аккорд...";
            this.btnGiveName.UseVisualStyleBackColor = true;
            this.btnGiveName.Click += new System.EventHandler(this.btnGiveName_Click);
            // 
            // btnDiscard
            // 
            this.btnDiscard.Location = new System.Drawing.Point(148, 19);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(91, 23);
            this.btnDiscard.TabIndex = 6;
            this.btnDiscard.Text = "Очистить";
            this.btnDiscard.UseVisualStyleBackColor = true;
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteMode);
            this.groupBox1.Controls.Add(this.btnAssemblyMode);
            this.groupBox1.Location = new System.Drawing.Point(25, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 52);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режим";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 546);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Кол-во ладов:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDiscard);
            this.groupBox2.Controls.Add(this.btnUndoLastEdit);
            this.groupBox2.Location = new System.Drawing.Point(231, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 52);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Отмена";
            // 
            // ChordBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 630);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGiveName);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSaveNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboActivityType);
            this.Controls.Add(this.pnlBase);
            this.Name = "ChordBuilder";
            this.Text = "Аккорд";
            this.pnlBase.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private Panel pnlBase;
        private ComboBox cboActivityType;
        private Button btnSave;
        private Button btnSaveNew;
        private ImageList imageList1;
        private Button btnEdit;
        private SplitContainer splitContainer1;
        private Panel pnlLeft;
        private Button btnGiveName;
        private Button btnDiscard;
        private Button btnUndoLastEdit;
        private Button btnAssemblyMode;
        private Button btnDeleteMode;
        private GroupBox groupBox1;
        private Label label1;
        private GroupBox groupBox2;


        #endregion
    }
}

