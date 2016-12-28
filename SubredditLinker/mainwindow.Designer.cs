namespace SubredditLinker
{
    partial class mainwindow
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
            this.textBoxSubreddit = new System.Windows.Forms.TextBox();
            this.buttonAnalyze = new System.Windows.Forms.Button();
            this.tableLayoutPanelOuter = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelInner = new System.Windows.Forms.TableLayoutPanel();
            this.progressBarMain = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeViewResults = new System.Windows.Forms.TreeView();
            this.treeViewSub = new System.Windows.Forms.TreeView();
            this.tableLayoutPanelOuter.SuspendLayout();
            this.tableLayoutPanelInner.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSubreddit
            // 
            this.textBoxSubreddit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxSubreddit.Location = new System.Drawing.Point(203, 4);
            this.textBoxSubreddit.Name = "textBoxSubreddit";
            this.textBoxSubreddit.Size = new System.Drawing.Size(391, 20);
            this.textBoxSubreddit.TabIndex = 0;
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonAnalyze.Location = new System.Drawing.Point(600, 3);
            this.buttonAnalyze.Name = "buttonAnalyze";
            this.buttonAnalyze.Size = new System.Drawing.Size(134, 23);
            this.buttonAnalyze.TabIndex = 1;
            this.buttonAnalyze.Text = "Analyze Mods";
            this.buttonAnalyze.UseVisualStyleBackColor = true;
            this.buttonAnalyze.Click += new System.EventHandler(this.buttonAnalyze_Click);
            // 
            // tableLayoutPanelOuter
            // 
            this.tableLayoutPanelOuter.ColumnCount = 1;
            this.tableLayoutPanelOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOuter.Controls.Add(this.tableLayoutPanelInner, 0, 1);
            this.tableLayoutPanelOuter.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelOuter.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelOuter.Name = "tableLayoutPanelOuter";
            this.tableLayoutPanelOuter.RowCount = 2;
            this.tableLayoutPanelOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOuter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOuter.Size = new System.Drawing.Size(743, 438);
            this.tableLayoutPanelOuter.TabIndex = 2;
            // 
            // tableLayoutPanelInner
            // 
            this.tableLayoutPanelInner.ColumnCount = 3;
            this.tableLayoutPanelInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanelInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelInner.Controls.Add(this.buttonAnalyze, 2, 0);
            this.tableLayoutPanelInner.Controls.Add(this.textBoxSubreddit, 1, 0);
            this.tableLayoutPanelInner.Controls.Add(this.progressBarMain, 0, 0);
            this.tableLayoutPanelInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelInner.Location = new System.Drawing.Point(3, 408);
            this.tableLayoutPanelInner.Name = "tableLayoutPanelInner";
            this.tableLayoutPanelInner.RowCount = 1;
            this.tableLayoutPanelInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInner.Size = new System.Drawing.Size(737, 27);
            this.tableLayoutPanelInner.TabIndex = 0;
            // 
            // progressBarMain
            // 
            this.progressBarMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarMain.Location = new System.Drawing.Point(3, 3);
            this.progressBarMain.Name = "progressBarMain";
            this.progressBarMain.Size = new System.Drawing.Size(194, 23);
            this.progressBarMain.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(737, 399);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeViewResults);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(729, 373);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "By User";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeViewSub);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(729, 373);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "By Subreddit";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // treeViewResults
            // 
            this.treeViewResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewResults.Location = new System.Drawing.Point(3, 3);
            this.treeViewResults.Name = "treeViewResults";
            this.treeViewResults.Size = new System.Drawing.Size(723, 367);
            this.treeViewResults.TabIndex = 0;
            // 
            // treeViewSub
            // 
            this.treeViewSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewSub.Location = new System.Drawing.Point(3, 3);
            this.treeViewSub.Name = "treeViewSub";
            this.treeViewSub.Size = new System.Drawing.Size(723, 367);
            this.treeViewSub.TabIndex = 0;
            // 
            // mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 438);
            this.Controls.Add(this.tableLayoutPanelOuter);
            this.Name = "mainwindow";
            this.Text = "SubredditLinker";
            this.tableLayoutPanelOuter.ResumeLayout(false);
            this.tableLayoutPanelInner.ResumeLayout(false);
            this.tableLayoutPanelInner.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSubreddit;
        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOuter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInner;
        private System.Windows.Forms.ProgressBar progressBarMain;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView treeViewResults;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeViewSub;
    }
}

