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
        private System.Windows.Forms.ListBox listBoxTodos;
        private System.Windows.Forms.TextBox txtTitle;

        private void InitializeComponent()
        {
            txtTitle = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnToggle = new Button();
            listBoxTodos = new ListBox();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 12);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(200, 23);
            txtTitle.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 40);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(93, 40);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnToggle
            // 
            btnToggle.Location = new Point(190, 40);
            btnToggle.Name = "btnToggle";
            btnToggle.Size = new Size(100, 25);
            btnToggle.TabIndex = 0;
            btnToggle.Text = "Toggle Complete";
            btnToggle.Click += btnToggle_Click;
            // 
            // listBoxTodos
            // 
            listBoxTodos.Location = new Point(12, 69);
            listBoxTodos.Name = "listBoxTodos";
            listBoxTodos.Size = new Size(200, 150);
            listBoxTodos.TabIndex = 0;
            // 
            // TodoApp
            // 
            ClientSize = new Size(916, 711);
            Name = "TodoApp";
            Load += TodoApp_Load;
            ResumeLayout(false);
        }
    }
