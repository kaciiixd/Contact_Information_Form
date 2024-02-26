namespace Contact_Information_Form
{
    partial class ContactForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any 
        /// s being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactForm));
            buttons_strip = new ToolStrip();
            saveButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            cancelButton = new ToolStripButton();
            lang_cbox = new ToolStripComboBox();
            toolStripLabel1 = new ToolStripLabel();
            toolStripLabel2 = new ToolStripLabel();
            contact_info_groupbox = new GroupBox();
            gdpr_link = new LinkLabel();
            checkRC_button = new Button();
            gdpr_cbox = new CheckBox();
            bezRC_cbox = new CheckBox();
            state_combo = new ComboBox();
            label7 = new Label();
            gender_combo = new ComboBox();
            bDate_pick = new DateTimePicker();
            rc_tbox2 = new TextBox();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            rc_tbox1 = new TextBox();
            label4 = new Label();
            email_tbox = new TextBox();
            label3 = new Label();
            lastname_tbox = new TextBox();
            label2 = new Label();
            name_tbox = new TextBox();
            label1 = new Label();
            label10 = new Label();
            buttons_strip.SuspendLayout();
            contact_info_groupbox.SuspendLayout();
            SuspendLayout();
            // 
            // buttons_strip
            // 
            resources.ApplyResources(buttons_strip, "buttons_strip");
            buttons_strip.ImageScalingSize = new Size(20, 20);
            buttons_strip.Items.AddRange(new ToolStripItem[] { saveButton, toolStripSeparator1, cancelButton, lang_cbox, toolStripLabel1, toolStripLabel2 });
            buttons_strip.Name = "buttons_strip";
            buttons_strip.UseWaitCursor = true;
            // 
            // saveButton
            // 
            resources.ApplyResources(saveButton, "saveButton");
            saveButton.Image = Properties.Resources.save;
            saveButton.Name = "saveButton";
            saveButton.Click += saveButton_Click;
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // cancelButton
            // 
            resources.ApplyResources(cancelButton, "cancelButton");
            cancelButton.Image = Properties.Resources.cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Click += cancelButton_Click;
            // 
            // lang_cbox
            // 
            resources.ApplyResources(lang_cbox, "lang_cbox");
            lang_cbox.Alignment = ToolStripItemAlignment.Right;
            lang_cbox.AutoCompleteCustomSource.AddRange(new string[] { resources.GetString("lang_cbox.AutoCompleteCustomSource"), resources.GetString("lang_cbox.AutoCompleteCustomSource1") });
            lang_cbox.DropDownStyle = ComboBoxStyle.DropDownList;
            lang_cbox.Items.AddRange(new object[] { resources.GetString("lang_cbox.Items"), resources.GetString("lang_cbox.Items1") });
            lang_cbox.Name = "lang_cbox";
            lang_cbox.SelectedIndexChanged += lang_cbox_SelectedIndexChanged;
            // 
            // toolStripLabel1
            // 
            resources.ApplyResources(toolStripLabel1, "toolStripLabel1");
            toolStripLabel1.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel1.Name = "toolStripLabel1";
            // 
            // toolStripLabel2
            // 
            resources.ApplyResources(toolStripLabel2, "toolStripLabel2");
            toolStripLabel2.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel2.Name = "toolStripLabel2";
            // 
            // contact_info_groupbox
            // 
            resources.ApplyResources(contact_info_groupbox, "contact_info_groupbox");
            contact_info_groupbox.Controls.Add(gdpr_link);
            contact_info_groupbox.Controls.Add(checkRC_button);
            contact_info_groupbox.Controls.Add(gdpr_cbox);
            contact_info_groupbox.Controls.Add(bezRC_cbox);
            contact_info_groupbox.Controls.Add(state_combo);
            contact_info_groupbox.Controls.Add(label7);
            contact_info_groupbox.Controls.Add(gender_combo);
            contact_info_groupbox.Controls.Add(bDate_pick);
            contact_info_groupbox.Controls.Add(rc_tbox2);
            contact_info_groupbox.Controls.Add(label8);
            contact_info_groupbox.Controls.Add(label6);
            contact_info_groupbox.Controls.Add(label5);
            contact_info_groupbox.Controls.Add(rc_tbox1);
            contact_info_groupbox.Controls.Add(label4);
            contact_info_groupbox.Controls.Add(email_tbox);
            contact_info_groupbox.Controls.Add(label3);
            contact_info_groupbox.Controls.Add(lastname_tbox);
            contact_info_groupbox.Controls.Add(label2);
            contact_info_groupbox.Controls.Add(name_tbox);
            contact_info_groupbox.Controls.Add(label1);
            contact_info_groupbox.Controls.Add(label10);
            contact_info_groupbox.Name = "contact_info_groupbox";
            contact_info_groupbox.TabStop = false;
            // 
            // gdpr_link
            // 
            resources.ApplyResources(gdpr_link, "gdpr_link");
            gdpr_link.Cursor = Cursors.Hand;
            gdpr_link.LinkColor = Color.Black;
            gdpr_link.Name = "gdpr_link";
            gdpr_link.TabStop = true;
            gdpr_link.LinkClicked += gdpr_link_LinkClicked;
            // 
            // checkRC_button
            // 
            resources.ApplyResources(checkRC_button, "checkRC_button");
            checkRC_button.Name = "checkRC_button";
            checkRC_button.UseVisualStyleBackColor = true;
            checkRC_button.Click += checkRC_button_Click;
            // 
            // gdpr_cbox
            // 
            resources.ApplyResources(gdpr_cbox, "gdpr_cbox");
            gdpr_cbox.Name = "gdpr_cbox";
            gdpr_cbox.UseVisualStyleBackColor = true;
            gdpr_cbox.CheckedChanged += gdpr_cbox_CheckedChanged;
            // 
            // bezRC_cbox
            // 
            resources.ApplyResources(bezRC_cbox, "bezRC_cbox");
            bezRC_cbox.Name = "bezRC_cbox";
            bezRC_cbox.UseVisualStyleBackColor = true;
            bezRC_cbox.CheckedChanged += bezRC_cbox_CheckedChanged;
            // 
            // state_combo
            // 
            resources.ApplyResources(state_combo, "state_combo");
            state_combo.Cursor = Cursors.Hand;
            state_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            state_combo.FormattingEnabled = true;
            state_combo.Items.AddRange(new object[] { resources.GetString("state_combo.Items"), resources.GetString("state_combo.Items1"), resources.GetString("state_combo.Items2"), resources.GetString("state_combo.Items3"), resources.GetString("state_combo.Items4"), resources.GetString("state_combo.Items5"), resources.GetString("state_combo.Items6"), resources.GetString("state_combo.Items7"), resources.GetString("state_combo.Items8"), resources.GetString("state_combo.Items9"), resources.GetString("state_combo.Items10"), resources.GetString("state_combo.Items11"), resources.GetString("state_combo.Items12"), resources.GetString("state_combo.Items13"), resources.GetString("state_combo.Items14"), resources.GetString("state_combo.Items15"), resources.GetString("state_combo.Items16") });
            state_combo.Name = "state_combo";
            state_combo.SelectedIndexChanged += state_combo_SelectedIndexChanged;
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // gender_combo
            // 
            resources.ApplyResources(gender_combo, "gender_combo");
            gender_combo.Cursor = Cursors.Hand;
            gender_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            gender_combo.FormattingEnabled = true;
            gender_combo.Items.AddRange(new object[] { resources.GetString("gender_combo.Items"), resources.GetString("gender_combo.Items1") });
            gender_combo.Name = "gender_combo";
            gender_combo.SelectedIndexChanged += gender_combo_SelectedIndexChanged;
            // 
            // bDate_pick
            // 
            resources.ApplyResources(bDate_pick, "bDate_pick");
            bDate_pick.Cursor = Cursors.Hand;
            bDate_pick.Format = DateTimePickerFormat.Short;
            bDate_pick.MaxDate = new DateTime(2099, 12, 31, 0, 0, 0, 0);
            bDate_pick.Name = "bDate_pick";
            bDate_pick.Value = new DateTime(2024, 2, 25, 0, 0, 0, 0);
            bDate_pick.ValueChanged += bDate_pick_ValueChanged;
            // 
            // rc_tbox2
            // 
            resources.ApplyResources(rc_tbox2, "rc_tbox2");
            rc_tbox2.Name = "rc_tbox2";
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // rc_tbox1
            // 
            resources.ApplyResources(rc_tbox1, "rc_tbox1");
            rc_tbox1.Name = "rc_tbox1";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // email_tbox
            // 
            resources.ApplyResources(email_tbox, "email_tbox");
            email_tbox.Name = "email_tbox";
            email_tbox.Leave += email_tbox_Leave;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // lastname_tbox
            // 
            resources.ApplyResources(lastname_tbox, "lastname_tbox");
            lastname_tbox.Name = "lastname_tbox";
            lastname_tbox.TextChanged += lastname_tbox_TextChanged;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // name_tbox
            // 
            resources.ApplyResources(name_tbox, "name_tbox");
            name_tbox.Name = "name_tbox";
            name_tbox.TextChanged += name_tbox_TextChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.ForeColor = Color.Red;
            label10.Name = "label10";
            // 
            // ContactForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(contact_info_groupbox);
            Controls.Add(buttons_strip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ContactForm";
            buttons_strip.ResumeLayout(false);
            buttons_strip.PerformLayout();
            contact_info_groupbox.ResumeLayout(false);
            contact_info_groupbox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStrip buttons_strip;
        private ToolStripButton saveButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton cancelButton;
        private GroupBox contact_info_groupbox;
        private TextBox email_tbox;
        private Label label3;
        private TextBox lastname_tbox;
        private Label label2;
        private TextBox name_tbox;
        private Label label1;
        private DateTimePicker bDate_pick;
        private TextBox rc_tbox2;
        private Label label8;
        private Label label6;
        private Label label5;
        private TextBox rc_tbox1;
        private Label label4;
        private CheckBox gdpr_cbox;
        private CheckBox bezRC_cbox;
        private ComboBox state_combo;
        private Label label7;
        private ComboBox gender_combo;
        private Button checkRC_button;
        private LinkLabel gdpr_link;
        private ToolStripComboBox lang_cbox;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
        private Label label10;
    }
}