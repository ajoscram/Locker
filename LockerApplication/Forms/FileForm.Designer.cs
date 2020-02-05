namespace LockerUI
{
    partial class FileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileForm));
            this.fieldListbox = new System.Windows.Forms.ListBox();
            this.fieldTextboxContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToClipboardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldlListboxMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.addMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchTextbox = new System.Windows.Forms.TextBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToClipboardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewFieldMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.sortAlphabeticallyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noFileLabel = new System.Windows.Forms.Label();
            this.utilitiesPanel = new System.Windows.Forms.Panel();
            this.fieldTextboxContextMenu.SuspendLayout();
            this.menu.SuspendLayout();
            this.utilitiesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fieldListbox
            // 
            this.fieldListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldListbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fieldListbox.ContextMenuStrip = this.fieldTextboxContextMenu;
            this.fieldListbox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldListbox.FormattingEnabled = true;
            this.fieldListbox.ItemHeight = 15;
            this.fieldListbox.Location = new System.Drawing.Point(0, 22);
            this.fieldListbox.Margin = new System.Windows.Forms.Padding(0);
            this.fieldListbox.Name = "fieldListbox";
            this.fieldListbox.ScrollAlwaysVisible = true;
            this.fieldListbox.Size = new System.Drawing.Size(437, 510);
            this.fieldListbox.TabIndex = 0;
            // 
            // fieldTextboxContextMenu
            // 
            this.fieldTextboxContextMenu.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldTextboxContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardMenuItem,
            this.fieldlListboxMenuSeparator,
            this.addMenuItem,
            this.deleteMenuItem});
            this.fieldTextboxContextMenu.Name = "contextMenuStrip1";
            this.fieldTextboxContextMenu.Size = new System.Drawing.Size(194, 76);
            // 
            // copyToClipboardMenuItem
            // 
            this.copyToClipboardMenuItem.Name = "copyToClipboardMenuItem";
            this.copyToClipboardMenuItem.Size = new System.Drawing.Size(193, 22);
            this.copyToClipboardMenuItem.Text = "Copy to Clipboard";
            this.copyToClipboardMenuItem.Click += new System.EventHandler(this.copyToClipboardMenuItem_Click);
            // 
            // fieldlListboxMenuSeparator
            // 
            this.fieldlListboxMenuSeparator.Name = "fieldlListboxMenuSeparator";
            this.fieldlListboxMenuSeparator.Size = new System.Drawing.Size(190, 6);
            // 
            // addMenuItem
            // 
            this.addMenuItem.Name = "addMenuItem";
            this.addMenuItem.Size = new System.Drawing.Size(193, 22);
            this.addMenuItem.Text = "Add";
            this.addMenuItem.Click += new System.EventHandler(this.addMenuItem_Click);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(193, 22);
            this.deleteMenuItem.Text = "Delete";
            this.deleteMenuItem.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // searchLabel
            // 
            this.searchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLabel.Location = new System.Drawing.Point(3, 5);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(31, 22);
            this.searchLabel.TabIndex = 1;
            this.searchLabel.Text = "🔍";
            // 
            // searchTextbox
            // 
            this.searchTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextbox.Location = new System.Drawing.Point(34, 6);
            this.searchTextbox.Name = "searchTextbox";
            this.searchTextbox.Size = new System.Drawing.Size(393, 20);
            this.searchTextbox.TabIndex = 1;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.Control;
            this.menu.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.editMenuItem,
            this.settingsMenuItem,
            this.helpMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(437, 24);
            this.menu.TabIndex = 3;
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.newMenuItem,
            this.toolStripSeparator4,
            this.saveMenuItem,
            this.closeMenuItem,
            this.toolStripSeparator1,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(47, 20);
            this.fileMenuItem.Text = "File";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenuItem.Size = new System.Drawing.Size(172, 22);
            this.openMenuItem.Text = "Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // newMenuItem
            // 
            this.newMenuItem.Name = "newMenuItem";
            this.newMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMenuItem.Size = new System.Drawing.Size(172, 22);
            this.newMenuItem.Text = "New";
            this.newMenuItem.Click += new System.EventHandler(this.newMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(169, 6);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(172, 22);
            this.saveMenuItem.Text = "Save As";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.closeMenuItem.Size = new System.Drawing.Size(172, 22);
            this.closeMenuItem.Text = "Close";
            this.closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitMenuItem.Size = new System.Drawing.Size(172, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // editMenuItem
            // 
            this.editMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copySelectedToClipboardMenuItem,
            this.toolStripSeparator2,
            this.addNewFieldMenuItem,
            this.deleteSelectedMenuItem});
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Size = new System.Drawing.Size(47, 20);
            this.editMenuItem.Text = "Edit";
            // 
            // copySelectedToClipboardMenuItem
            // 
            this.copySelectedToClipboardMenuItem.Name = "copySelectedToClipboardMenuItem";
            this.copySelectedToClipboardMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copySelectedToClipboardMenuItem.Size = new System.Drawing.Size(305, 22);
            this.copySelectedToClipboardMenuItem.Text = "Copy Selected to Clipboard";
            this.copySelectedToClipboardMenuItem.Click += new System.EventHandler(this.copySelectedToClipboardMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(302, 6);
            // 
            // addNewFieldMenuItem
            // 
            this.addNewFieldMenuItem.Name = "addNewFieldMenuItem";
            this.addNewFieldMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addNewFieldMenuItem.Size = new System.Drawing.Size(305, 22);
            this.addNewFieldMenuItem.Text = "Add New Field";
            this.addNewFieldMenuItem.Click += new System.EventHandler(this.addNewFieldMenuItem_Click);
            // 
            // deleteSelectedMenuItem
            // 
            this.deleteSelectedMenuItem.Name = "deleteSelectedMenuItem";
            this.deleteSelectedMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteSelectedMenuItem.Size = new System.Drawing.Size(305, 22);
            this.deleteSelectedMenuItem.Text = "Delete Selected";
            this.deleteSelectedMenuItem.Click += new System.EventHandler(this.deleteSelectedMenuItem_Click);
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeSettingsMenuItem,
            this.toolStripSeparator5,
            this.sortAlphabeticallyMenuItem});
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(75, 20);
            this.settingsMenuItem.Text = "Settings";
            // 
            // changeSettingsMenuItem
            // 
            this.changeSettingsMenuItem.Name = "changeSettingsMenuItem";
            this.changeSettingsMenuItem.Size = new System.Drawing.Size(207, 22);
            this.changeSettingsMenuItem.Text = "Change Settings";
            this.changeSettingsMenuItem.Click += new System.EventHandler(this.changeSettingsMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(204, 6);
            // 
            // sortAlphabeticallyMenuItem
            // 
            this.sortAlphabeticallyMenuItem.CheckOnClick = true;
            this.sortAlphabeticallyMenuItem.Name = "sortAlphabeticallyMenuItem";
            this.sortAlphabeticallyMenuItem.Size = new System.Drawing.Size(207, 22);
            this.sortAlphabeticallyMenuItem.Text = "Sort Alphabetically";
            this.sortAlphabeticallyMenuItem.CheckedChanged += new System.EventHandler(this.sortAlphabeticallyMenuItem_CheckChanged);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpMenuItem,
            this.toolStripSeparator3,
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(47, 20);
            this.helpMenuItem.Text = "Help";
            // 
            // viewHelpMenuItem
            // 
            this.viewHelpMenuItem.Name = "viewHelpMenuItem";
            this.viewHelpMenuItem.Size = new System.Drawing.Size(137, 22);
            this.viewHelpMenuItem.Text = "View Help";
            this.viewHelpMenuItem.Click += new System.EventHandler(this.viewHelpMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(134, 6);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(137, 22);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // noFileLabel
            // 
            this.noFileLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.noFileLabel.AutoSize = true;
            this.noFileLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.noFileLabel.Location = new System.Drawing.Point(109, 258);
            this.noFileLabel.Name = "noFileLabel";
            this.noFileLabel.Size = new System.Drawing.Size(211, 26);
            this.noFileLabel.TabIndex = 4;
            this.noFileLabel.Text = "Press Ctrl+O to open a file.\r\nPress Ctrl+N to create a new file.";
            // 
            // utilitiesPanel
            // 
            this.utilitiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.utilitiesPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.utilitiesPanel.Controls.Add(this.searchLabel);
            this.utilitiesPanel.Controls.Add(this.searchTextbox);
            this.utilitiesPanel.Location = new System.Drawing.Point(0, 535);
            this.utilitiesPanel.Name = "utilitiesPanel";
            this.utilitiesPanel.Size = new System.Drawing.Size(437, 32);
            this.utilitiesPanel.TabIndex = 5;
            // 
            // FileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(437, 567);
            this.Controls.Add(this.utilitiesPanel);
            this.Controls.Add(this.noFileLabel);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.fieldListbox);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menu;
            this.Name = "FileForm";
            this.Text = "Locker";
            this.fieldTextboxContextMenu.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.utilitiesPanel.ResumeLayout(false);
            this.utilitiesPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fieldListbox;
        private System.Windows.Forms.ContextMenuStrip fieldTextboxContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.ToolStripSeparator fieldlListboxMenuSeparator;
        private System.Windows.Forms.ToolStripMenuItem addMenuItem;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox searchTextbox;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToClipboardMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addNewFieldMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeSettingsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMenuItem;
        private System.Windows.Forms.Label noFileLabel;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.Panel utilitiesPanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem sortAlphabeticallyMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}