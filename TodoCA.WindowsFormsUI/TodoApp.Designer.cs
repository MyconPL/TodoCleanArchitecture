namespace TodoCA.WindowsFormsUI
{
    partial class TodoApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.ListBox lstToDoItems;
        private System.Windows.Forms.TextBox txtTitle;

        private void InitializeComponent() {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnToggle = new System.Windows.Forms.Button();
            this.lstToDoItems = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            this.txtTitle.Location = new System.Drawing.Point(12, 12);
            this.txtTitle.Size = new System.Drawing.Size(200, 22);

            this.btnAdd.Location = new System.Drawing.Point(12, 40);
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnDelete.Location = new System.Drawing.Point(93, 40);
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.lstToDoItems.Location = new System.Drawing.Point(12, 69);
            this.lstToDoItems.Size = new System.Drawing.Size(200, 150);

            this.btnToggle = new System.Windows.Forms.Button();
            this.btnToggle.Location = new System.Drawing.Point(190, 40);
            this.btnToggle.Size = new System.Drawing.Size(100, 25);
            this.btnToggle.Text = "Toggle Complete";
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
        }
}
