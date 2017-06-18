namespace _7_Interfaces_Ex_9
{
    partial class Form1
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
            this.description = new System.Windows.Forms.Label();
            this.goThroughTheDoor = new System.Windows.Forms.Button();
            this.exits = new System.Windows.Forms.ComboBox();
            this.goHere = new System.Windows.Forms.Button();
            this.hide = new System.Windows.Forms.Button();
            this.check = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // description
            // 
            this.description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.description.Location = new System.Drawing.Point(13, 13);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(259, 110);
            this.description.TabIndex = 0;
            // 
            // goThroughTheDoor
            // 
            this.goThroughTheDoor.Location = new System.Drawing.Point(12, 221);
            this.goThroughTheDoor.Name = "goThroughTheDoor";
            this.goThroughTheDoor.Size = new System.Drawing.Size(260, 23);
            this.goThroughTheDoor.TabIndex = 1;
            this.goThroughTheDoor.Text = "Go through the door";
            this.goThroughTheDoor.UseVisualStyleBackColor = true;
            this.goThroughTheDoor.Click += new System.EventHandler(this.goThroughTheDoor_Click);
            // 
            // exits
            // 
            this.exits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exits.FormattingEnabled = true;
            this.exits.Location = new System.Drawing.Point(147, 134);
            this.exits.Name = "exits";
            this.exits.Size = new System.Drawing.Size(125, 21);
            this.exits.TabIndex = 2;
            // 
            // goHere
            // 
            this.goHere.Location = new System.Drawing.Point(12, 134);
            this.goHere.Name = "goHere";
            this.goHere.Size = new System.Drawing.Size(129, 23);
            this.goHere.TabIndex = 3;
            this.goHere.Text = "Go here:";
            this.goHere.UseVisualStyleBackColor = true;
            this.goHere.Click += new System.EventHandler(this.goHere_Click);
            // 
            // hide
            // 
            this.hide.Location = new System.Drawing.Point(12, 163);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(260, 23);
            this.hide.TabIndex = 4;
            this.hide.Text = "Hide";
            this.hide.UseVisualStyleBackColor = true;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            // 
            // check
            // 
            this.check.Location = new System.Drawing.Point(13, 192);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(259, 23);
            this.check.TabIndex = 5;
            this.check.Text = "Check";
            this.check.UseVisualStyleBackColor = true;
            this.check.Click += new System.EventHandler(this.check_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 257);
            this.Controls.Add(this.check);
            this.Controls.Add(this.hide);
            this.Controls.Add(this.goHere);
            this.Controls.Add(this.exits);
            this.Controls.Add(this.goThroughTheDoor);
            this.Controls.Add(this.description);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Explore the House";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Button goThroughTheDoor;
        private System.Windows.Forms.ComboBox exits;
        private System.Windows.Forms.Button goHere;
        private System.Windows.Forms.Button hide;
        private System.Windows.Forms.Button check;
    }
}

