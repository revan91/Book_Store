using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Book_Store
{
    partial class Form1
    {
        private IContainer components = null;

        // Tab control 與分頁
        private TabControl tabControlMain;
        private TabPage tabBooks;
        private TabPage tabAuthors;
        private TabPage tabGenres;
        private TabPage tabPublishers;

        // Authors 分頁 UI（新增，不會影響書籍頁面）
        private DataGridView dgvAuthors;
        private Label lblAuthorId;
        private TextBox txtAuthorId;
        private Label lblAuthorFirst;
        private TextBox txtAuthorFirst;
        private Label lblAuthorLast;
        private TextBox txtAuthorLast;
        private Button btnAuthorAdd;
        private Button btnAuthorUpdate;
        private Button btnAuthorDelete;
        private Button btnAuthorClear;
        private TextBox txtAuthorSearch;
        private Button btnAuthorSearch;
        // Author photo area
        private GroupBox groupBoxAuthorImage;
        private PictureBox pictureBoxAuthor;
        private Button btnAuthorUploadImage;
        private Button btnAuthorRemoveImage;

        // Genres 分頁 UI（新增）
        private DataGridView dgvGenres;
        private Label lblGenreId;
        private TextBox txtGenreId;
        private Label lblGenreName;
        private TextBox txtGenreName;
        private Button btnGenreAdd;
        private Button btnGenreUpdate;
        private Button btnGenreDelete;
        private Button btnGenreClear;
        private TextBox txtGenreSearch;
        private Button btnGenreSearch;

        // Publishers 分頁 UI（新增）
        private DataGridView dgvPublishers;
        private Label lblPublisherId;
        private TextBox txtPublisherId;
        private Label lblPublisherName;
        private TextBox txtPublisherName;
        private Button btnPublisherAdd;
        private Button btnPublisherUpdate;
        private Button btnPublisherDelete;
        private Button btnPublisherClear;
        private TextBox txtPublisherSearch;
        private Button btnPublisherSearch;

        // 書籍分頁所需的控制項宣告（先補齊所有被參考但未宣告的控制項）
        private DataGridView dgvBooks;
        private GroupBox groupBoxImage;
        private PictureBox pictureBoxBook;
        private Button btnUploadImage;
        private Label lblId;
        private TextBox txtBookId;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblISBN;
        private TextBox txtISBN;
        private Label lblYear;
        private TextBox txtYear;
        private Label lblPrice;
        private TextBox txtPrice;
        private ComboBox cmbAuthor;
        private ComboBox cmbPublisher;
        private ComboBox cmbGenre;
        private TextBox txtSearch;
        private OpenFileDialog openFileDialog1;

        // 新增書籍分頁的控制項實例化
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnSearch;
        private Button btnRemoveImage;

        private void InitializeComponent()
        {
            tabControlMain = new TabControl();
            tabBooks = new TabPage();
            dgvBooks = new DataGridView();
            groupBoxImage = new GroupBox();
            pictureBoxBook = new PictureBox();
            btnUploadImage = new Button();
            btnRemoveImage = new Button();
            lblId = new Label();
            txtBookId = new TextBox();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblISBN = new Label();
            txtISBN = new TextBox();
            lblYear = new Label();
            txtYear = new TextBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            cmbAuthor = new ComboBox();
            cmbPublisher = new ComboBox();
            cmbGenre = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            tabAuthors = new TabPage();
            dgvAuthors = new DataGridView();
            lblAuthorId = new Label();
            txtAuthorId = new TextBox();
            lblAuthorFirst = new Label();
            txtAuthorFirst = new TextBox();
            lblAuthorLast = new Label();
            txtAuthorLast = new TextBox();
            btnAuthorAdd = new Button();
            btnAuthorUpdate = new Button();
            btnAuthorDelete = new Button();
            btnAuthorClear = new Button();
            txtAuthorSearch = new TextBox();
            btnAuthorSearch = new Button();
            groupBoxAuthorImage = new GroupBox();
            pictureBoxAuthor = new PictureBox();
            btnAuthorUploadImage = new Button();
            btnAuthorRemoveImage = new Button();
            tabGenres = new TabPage();
            dgvGenres = new DataGridView();
            lblGenreId = new Label();
            txtGenreId = new TextBox();
            lblGenreName = new Label();
            txtGenreName = new TextBox();
            btnGenreAdd = new Button();
            btnGenreUpdate = new Button();
            btnGenreDelete = new Button();
            btnGenreClear = new Button();
            txtGenreSearch = new TextBox();
            btnGenreSearch = new Button();
            tabPublishers = new TabPage();
            dgvPublishers = new DataGridView();
            lblPublisherId = new Label();
            txtPublisherId = new TextBox();
            lblPublisherName = new Label();
            txtPublisherName = new TextBox();
            btnPublisherAdd = new Button();
            btnPublisherUpdate = new Button();
            btnPublisherDelete = new Button();
            btnPublisherClear = new Button();
            txtPublisherSearch = new TextBox();
            btnPublisherSearch = new Button();
            openFileDialog1 = new OpenFileDialog();
            tabControlMain.SuspendLayout();
            tabBooks.SuspendLayout();
            ((ISupportInitialize)dgvBooks).BeginInit();
            groupBoxImage.SuspendLayout();
            ((ISupportInitialize)pictureBoxBook).BeginInit();
            tabAuthors.SuspendLayout();
            ((ISupportInitialize)dgvAuthors).BeginInit();
            groupBoxAuthorImage.SuspendLayout();
            ((ISupportInitialize)pictureBoxAuthor).BeginInit();
            tabGenres.SuspendLayout();
            ((ISupportInitialize)dgvGenres).BeginInit();
            tabPublishers.SuspendLayout();
            ((ISupportInitialize)dgvPublishers).BeginInit();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabBooks);
            tabControlMain.Controls.Add(tabAuthors);
            tabControlMain.Controls.Add(tabGenres);
            tabControlMain.Controls.Add(tabPublishers);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Location = new Point(0, 0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(900, 560);
            tabControlMain.TabIndex = 0;
            // 
            // tabBooks
            // 
            tabBooks.Controls.Add(dgvBooks);
            tabBooks.Controls.Add(groupBoxImage);
            tabBooks.Controls.Add(lblId);
            tabBooks.Controls.Add(txtBookId);
            tabBooks.Controls.Add(lblTitle);
            tabBooks.Controls.Add(txtTitle);
            tabBooks.Controls.Add(lblISBN);
            tabBooks.Controls.Add(txtISBN);
            tabBooks.Controls.Add(lblYear);
            tabBooks.Controls.Add(txtYear);
            tabBooks.Controls.Add(lblPrice);
            tabBooks.Controls.Add(txtPrice);
            tabBooks.Controls.Add(cmbAuthor);
            tabBooks.Controls.Add(cmbPublisher);
            tabBooks.Controls.Add(cmbGenre);
            tabBooks.Controls.Add(btnAdd);
            tabBooks.Controls.Add(btnUpdate);
            tabBooks.Controls.Add(btnDelete);
            tabBooks.Controls.Add(btnClear);
            tabBooks.Controls.Add(txtSearch);
            tabBooks.Controls.Add(btnSearch);
            tabBooks.Location = new Point(4, 24);
            tabBooks.Name = "tabBooks";
            tabBooks.Padding = new Padding(6);
            tabBooks.Size = new Size(892, 532);
            tabBooks.TabIndex = 0;
            tabBooks.Text = "書籍";
            tabBooks.UseVisualStyleBackColor = true;
            // 
            // dgvBooks
            // 
            dgvBooks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.Location = new Point(8, 10);
            dgvBooks.MultiSelect = false;
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(642, 260);
            dgvBooks.TabIndex = 0;
            dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;
            // 
            // groupBoxImage
            // 
            groupBoxImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxImage.Controls.Add(pictureBoxBook);
            groupBoxImage.Controls.Add(btnUploadImage);
            groupBoxImage.Controls.Add(btnRemoveImage);
            groupBoxImage.Location = new Point(656, 10);
            groupBoxImage.Name = "groupBoxImage";
            groupBoxImage.Size = new Size(223, 340);
            groupBoxImage.TabIndex = 1;
            groupBoxImage.TabStop = false;
            groupBoxImage.Text = "書籍圖片";
            // 
            // pictureBoxBook
            // 
            pictureBoxBook.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxBook.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxBook.Location = new Point(6, 20);
            pictureBoxBook.Name = "pictureBoxBook";
            pictureBoxBook.Size = new Size(211, 240);
            pictureBoxBook.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxBook.TabIndex = 0;
            pictureBoxBook.TabStop = false;
            pictureBoxBook.Click += pictureBoxBook_Click;
            // 
            // btnUploadImage
            // 
            btnUploadImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUploadImage.Location = new Point(6, 270);
            btnUploadImage.Name = "btnUploadImage";
            btnUploadImage.Size = new Size(211, 28);
            btnUploadImage.TabIndex = 1;
            btnUploadImage.Text = "上傳";
            btnUploadImage.Click += btnUploadImage_Click;
            // 
            // btnRemoveImage
            // 
            btnRemoveImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRemoveImage.Location = new Point(6, 304);
            btnRemoveImage.Name = "btnRemoveImage";
            btnRemoveImage.Size = new Size(211, 28);
            btnRemoveImage.TabIndex = 2;
            btnRemoveImage.Text = "移除";
            btnRemoveImage.Click += btnRemoveImage_Click;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(10, 280);
            lblId.Name = "lblId";
            lblId.Size = new Size(55, 15);
            lblId.TabIndex = 2;
            lblId.Text = "書籍編號";
            // 
            // txtBookId
            // 
            txtBookId.Location = new Point(80, 276);
            txtBookId.Name = "txtBookId";
            txtBookId.Size = new Size(270, 23);
            txtBookId.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(10, 310);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(31, 15);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "書名";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(80, 306);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(270, 23);
            txtTitle.TabIndex = 5;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(10, 340);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(34, 15);
            lblISBN.TabIndex = 6;
            lblISBN.Text = "ISBN";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(80, 336);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(270, 23);
            txtISBN.TabIndex = 7;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(10, 373);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(43, 15);
            lblYear.TabIndex = 8;
            lblYear.Text = "出版年";
            // 
            // txtYear
            // 
            txtYear.Location = new Point(80, 365);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(270, 23);
            txtYear.TabIndex = 9;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(390, 487);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(31, 15);
            lblPrice.TabIndex = 10;
            lblPrice.Text = "價格";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(427, 484);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(200, 23);
            txtPrice.TabIndex = 11;
            // 
            // cmbAuthor
            // 
            cmbAuthor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAuthor.Location = new Point(427, 276);
            cmbAuthor.Name = "cmbAuthor";
            cmbAuthor.Size = new Size(200, 23);
            cmbAuthor.TabIndex = 12;
            // 
            // cmbPublisher
            // 
            cmbPublisher.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPublisher.Location = new Point(427, 307);
            cmbPublisher.Name = "cmbPublisher";
            cmbPublisher.Size = new Size(200, 23);
            cmbPublisher.TabIndex = 13;
            // 
            // cmbGenre
            // 
            cmbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenre.Location = new Point(427, 340);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(200, 23);
            cmbGenre.TabIndex = 14;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(427, 385);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(95, 30);
            btnAdd.TabIndex = 15;
            btnAdd.Text = "新增";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(532, 385);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(95, 30);
            btnUpdate.TabIndex = 16;
            btnUpdate.Text = "更新";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(427, 430);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(95, 30);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "刪除";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(532, 430);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(95, 30);
            btnClear.TabIndex = 18;
            btnClear.Text = "清除";
            btnClear.Click += btnClear_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(10, 410);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(260, 23);
            txtSearch.TabIndex = 19;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(280, 408);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(70, 26);
            btnSearch.TabIndex = 20;
            btnSearch.Text = "搜尋";
            btnSearch.Click += btnSearch_Click;
            // 
            // tabAuthors
            // 
            tabAuthors.Controls.Add(dgvAuthors);
            tabAuthors.Controls.Add(lblAuthorId);
            tabAuthors.Controls.Add(txtAuthorId);
            tabAuthors.Controls.Add(lblAuthorFirst);
            tabAuthors.Controls.Add(txtAuthorFirst);
            tabAuthors.Controls.Add(lblAuthorLast);
            tabAuthors.Controls.Add(txtAuthorLast);
            tabAuthors.Controls.Add(btnAuthorAdd);
            tabAuthors.Controls.Add(btnAuthorUpdate);
            tabAuthors.Controls.Add(btnAuthorDelete);
            tabAuthors.Controls.Add(btnAuthorClear);
            tabAuthors.Controls.Add(txtAuthorSearch);
            tabAuthors.Controls.Add(btnAuthorSearch);
            tabAuthors.Controls.Add(groupBoxAuthorImage);
            tabAuthors.Location = new Point(4, 24);
            tabAuthors.Name = "tabAuthors";
            tabAuthors.Padding = new Padding(6);
            tabAuthors.Size = new Size(892, 532);
            tabAuthors.TabIndex = 1;
            tabAuthors.Text = "作者";
            tabAuthors.UseVisualStyleBackColor = true;
            // 
            // dgvAuthors
            // 
            dgvAuthors.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvAuthors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuthors.Location = new Point(8, 10);
            dgvAuthors.MultiSelect = false;
            dgvAuthors.Name = "dgvAuthors";
            dgvAuthors.ReadOnly = true;
            dgvAuthors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuthors.Size = new Size(560, 300);
            dgvAuthors.TabIndex = 0;
            dgvAuthors.SelectionChanged += dgvAuthors_SelectionChanged;
            // 
            // lblAuthorId
            // 
            lblAuthorId.AutoSize = true;
            lblAuthorId.Location = new Point(8, 320);
            lblAuthorId.Name = "lblAuthorId";
            lblAuthorId.Size = new Size(55, 15);
            lblAuthorId.TabIndex = 1;
            lblAuthorId.Text = "作者編號";
            // 
            // txtAuthorId
            // 
            txtAuthorId.Location = new Point(100, 316);
            txtAuthorId.Name = "txtAuthorId";
            txtAuthorId.Size = new Size(200, 23);
            txtAuthorId.TabIndex = 2;
            // 
            // lblAuthorFirst
            // 
            lblAuthorFirst.AutoSize = true;
            lblAuthorFirst.Location = new Point(8, 350);
            lblAuthorFirst.Name = "lblAuthorFirst";
            lblAuthorFirst.Size = new Size(31, 15);
            lblAuthorFirst.TabIndex = 3;
            lblAuthorFirst.Text = "名字";
            // 
            // txtAuthorFirst
            // 
            txtAuthorFirst.Location = new Point(100, 346);
            txtAuthorFirst.Name = "txtAuthorFirst";
            txtAuthorFirst.Size = new Size(200, 23);
            txtAuthorFirst.TabIndex = 4;
            // 
            // lblAuthorLast
            // 
            lblAuthorLast.AutoSize = true;
            lblAuthorLast.Location = new Point(320, 350);
            lblAuthorLast.Name = "lblAuthorLast";
            lblAuthorLast.Size = new Size(31, 15);
            lblAuthorLast.TabIndex = 5;
            lblAuthorLast.Text = "姓氏";
            // 
            // txtAuthorLast
            // 
            txtAuthorLast.Location = new Point(370, 346);
            txtAuthorLast.Name = "txtAuthorLast";
            txtAuthorLast.Size = new Size(200, 23);
            txtAuthorLast.TabIndex = 6;
            // 
            // btnAuthorAdd
            // 
            btnAuthorAdd.Location = new Point(580, 346);
            btnAuthorAdd.Name = "btnAuthorAdd";
            btnAuthorAdd.Size = new Size(95, 30);
            btnAuthorAdd.TabIndex = 7;
            btnAuthorAdd.Text = "新增";
            btnAuthorAdd.Click += btnAuthorAdd_Click;
            // 
            // btnAuthorUpdate
            // 
            btnAuthorUpdate.Location = new Point(690, 346);
            btnAuthorUpdate.Name = "btnAuthorUpdate";
            btnAuthorUpdate.Size = new Size(95, 30);
            btnAuthorUpdate.TabIndex = 8;
            btnAuthorUpdate.Text = "更新";
            btnAuthorUpdate.Click += btnAuthorUpdate_Click;
            // 
            // btnAuthorDelete
            // 
            btnAuthorDelete.Location = new Point(580, 390);
            btnAuthorDelete.Name = "btnAuthorDelete";
            btnAuthorDelete.Size = new Size(95, 30);
            btnAuthorDelete.TabIndex = 9;
            btnAuthorDelete.Text = "刪除";
            btnAuthorDelete.Click += btnAuthorDelete_Click;
            // 
            // btnAuthorClear
            // 
            btnAuthorClear.Location = new Point(690, 390);
            btnAuthorClear.Name = "btnAuthorClear";
            btnAuthorClear.Size = new Size(95, 30);
            btnAuthorClear.TabIndex = 10;
            btnAuthorClear.Text = "清除";
            btnAuthorClear.Click += btnAuthorClear_Click;
            // 
            // txtAuthorSearch
            // 
            txtAuthorSearch.Location = new Point(8, 390);
            txtAuthorSearch.Name = "txtAuthorSearch";
            txtAuthorSearch.Size = new Size(260, 23);
            txtAuthorSearch.TabIndex = 11;
            // 
            // btnAuthorSearch
            // 
            btnAuthorSearch.Location = new Point(280, 388);
            btnAuthorSearch.Name = "btnAuthorSearch";
            btnAuthorSearch.Size = new Size(70, 26);
            btnAuthorSearch.TabIndex = 12;
            btnAuthorSearch.Text = "搜尋";
            btnAuthorSearch.Click += btnAuthorSearch_Click;
            // 
            // groupBoxAuthorImage
            // 
            groupBoxAuthorImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxAuthorImage.Controls.Add(pictureBoxAuthor);
            groupBoxAuthorImage.Controls.Add(btnAuthorUploadImage);
            groupBoxAuthorImage.Controls.Add(btnAuthorRemoveImage);
            groupBoxAuthorImage.Location = new Point(580, 10);
            groupBoxAuthorImage.Name = "groupBoxAuthorImage";
            groupBoxAuthorImage.Size = new Size(300, 300);
            groupBoxAuthorImage.TabIndex = 10;
            groupBoxAuthorImage.TabStop = false;
            groupBoxAuthorImage.Text = "作者照片";
            // 
            // pictureBoxAuthor
            // 
            pictureBoxAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxAuthor.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxAuthor.Location = new Point(6, 20);
            pictureBoxAuthor.Name = "pictureBoxAuthor";
            pictureBoxAuthor.Size = new Size(288, 230);
            pictureBoxAuthor.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAuthor.TabIndex = 0;
            pictureBoxAuthor.TabStop = false;
            // 
            // btnAuthorUploadImage
            // 
            btnAuthorUploadImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAuthorUploadImage.Location = new Point(6, 256);
            btnAuthorUploadImage.Name = "btnAuthorUploadImage";
            btnAuthorUploadImage.Size = new Size(138, 28);
            btnAuthorUploadImage.TabIndex = 1;
            btnAuthorUploadImage.Text = "上傳照片";
            btnAuthorUploadImage.Click += btnAuthorUploadImage_Click;
            // 
            // btnAuthorRemoveImage
            // 
            btnAuthorRemoveImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAuthorRemoveImage.Location = new Point(156, 256);
            btnAuthorRemoveImage.Name = "btnAuthorRemoveImage";
            btnAuthorRemoveImage.Size = new Size(138, 28);
            btnAuthorRemoveImage.TabIndex = 2;
            btnAuthorRemoveImage.Text = "移除照片";
            btnAuthorRemoveImage.Click += btnAuthorRemoveImage_Click;
            // 
            // tabGenres
            // 
            tabGenres.Controls.Add(dgvGenres);
            tabGenres.Controls.Add(lblGenreId);
            tabGenres.Controls.Add(txtGenreId);
            tabGenres.Controls.Add(lblGenreName);
            tabGenres.Controls.Add(txtGenreName);
            tabGenres.Controls.Add(btnGenreAdd);
            tabGenres.Controls.Add(btnGenreUpdate);
            tabGenres.Controls.Add(btnGenreDelete);
            tabGenres.Controls.Add(btnGenreClear);
            tabGenres.Controls.Add(txtGenreSearch);
            tabGenres.Controls.Add(btnGenreSearch);
            tabGenres.Location = new Point(4, 24);
            tabGenres.Name = "tabGenres";
            tabGenres.Padding = new Padding(6);
            tabGenres.Size = new Size(892, 532);
            tabGenres.TabIndex = 2;
            tabGenres.Text = "類別";
            tabGenres.UseVisualStyleBackColor = true;
            // 
            // dgvGenres
            // 
            dgvGenres.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvGenres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGenres.Location = new Point(8, 10);
            dgvGenres.MultiSelect = false;
            dgvGenres.Name = "dgvGenres";
            dgvGenres.ReadOnly = true;
            dgvGenres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGenres.Size = new Size(760, 300);
            dgvGenres.TabIndex = 0;
            dgvGenres.SelectionChanged += dgvGenres_SelectionChanged;
            // 
            // lblGenreId
            // 
            lblGenreId.AutoSize = true;
            lblGenreId.Location = new Point(8, 320);
            lblGenreId.Name = "lblGenreId";
            lblGenreId.Size = new Size(55, 15);
            lblGenreId.TabIndex = 1;
            lblGenreId.Text = "類別編號";
            // 
            // txtGenreId
            // 
            txtGenreId.Location = new Point(100, 316);
            txtGenreId.Name = "txtGenreId";
            txtGenreId.Size = new Size(200, 23);
            txtGenreId.TabIndex = 2;
            // 
            // lblGenreName
            // 
            lblGenreName.AutoSize = true;
            lblGenreName.Location = new Point(8, 350);
            lblGenreName.Name = "lblGenreName";
            lblGenreName.Size = new Size(55, 15);
            lblGenreName.TabIndex = 3;
            lblGenreName.Text = "類別名稱";
            // 
            // txtGenreName
            // 
            txtGenreName.Location = new Point(100, 346);
            txtGenreName.Name = "txtGenreName";
            txtGenreName.Size = new Size(200, 23);
            txtGenreName.TabIndex = 4;
            // 
            // btnGenreAdd
            // 
            btnGenreAdd.Location = new Point(572, 320);
            btnGenreAdd.Name = "btnGenreAdd";
            btnGenreAdd.Size = new Size(95, 30);
            btnGenreAdd.TabIndex = 5;
            btnGenreAdd.Text = "新增";
            btnGenreAdd.Click += btnGenreAdd_Click;
            // 
            // btnGenreUpdate
            // 
            btnGenreUpdate.Location = new Point(673, 320);
            btnGenreUpdate.Name = "btnGenreUpdate";
            btnGenreUpdate.Size = new Size(95, 30);
            btnGenreUpdate.TabIndex = 6;
            btnGenreUpdate.Text = "更新";
            btnGenreUpdate.Click += btnGenreUpdate_Click;
            // 
            // btnGenreDelete
            // 
            btnGenreDelete.Location = new Point(572, 360);
            btnGenreDelete.Name = "btnGenreDelete";
            btnGenreDelete.Size = new Size(95, 30);
            btnGenreDelete.TabIndex = 7;
            btnGenreDelete.Text = "刪除";
            btnGenreDelete.Click += btnGenreDelete_Click;
            // 
            // btnGenreClear
            // 
            btnGenreClear.Location = new Point(673, 360);
            btnGenreClear.Name = "btnGenreClear";
            btnGenreClear.Size = new Size(95, 30);
            btnGenreClear.TabIndex = 8;
            btnGenreClear.Text = "清除";
            btnGenreClear.Click += btnGenreClear_Click;
            // 
            // txtGenreSearch
            // 
            txtGenreSearch.Location = new Point(8, 390);
            txtGenreSearch.Name = "txtGenreSearch";
            txtGenreSearch.Size = new Size(260, 23);
            txtGenreSearch.TabIndex = 9;
            // 
            // btnGenreSearch
            // 
            btnGenreSearch.Location = new Point(280, 388);
            btnGenreSearch.Name = "btnGenreSearch";
            btnGenreSearch.Size = new Size(70, 26);
            btnGenreSearch.TabIndex = 10;
            btnGenreSearch.Text = "搜尋";
            btnGenreSearch.Click += btnGenreSearch_Click;
            // 
            // tabPublishers
            // 
            tabPublishers.Controls.Add(dgvPublishers);
            tabPublishers.Controls.Add(lblPublisherId);
            tabPublishers.Controls.Add(txtPublisherId);
            tabPublishers.Controls.Add(lblPublisherName);
            tabPublishers.Controls.Add(txtPublisherName);
            tabPublishers.Controls.Add(btnPublisherAdd);
            tabPublishers.Controls.Add(btnPublisherUpdate);
            tabPublishers.Controls.Add(btnPublisherDelete);
            tabPublishers.Controls.Add(btnPublisherClear);
            tabPublishers.Controls.Add(txtPublisherSearch);
            tabPublishers.Controls.Add(btnPublisherSearch);
            tabPublishers.Location = new Point(4, 24);
            tabPublishers.Name = "tabPublishers";
            tabPublishers.Padding = new Padding(6);
            tabPublishers.Size = new Size(892, 532);
            tabPublishers.TabIndex = 3;
            tabPublishers.Text = "出版社";
            tabPublishers.UseVisualStyleBackColor = true;
            // 
            // dgvPublishers
            // 
            dgvPublishers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvPublishers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPublishers.Location = new Point(8, 10);
            dgvPublishers.MultiSelect = false;
            dgvPublishers.Name = "dgvPublishers";
            dgvPublishers.ReadOnly = true;
            dgvPublishers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPublishers.Size = new Size(760, 300);
            dgvPublishers.TabIndex = 0;
            dgvPublishers.SelectionChanged += dgvPublishers_SelectionChanged;
            // 
            // lblPublisherId
            // 
            lblPublisherId.AutoSize = true;
            lblPublisherId.Location = new Point(8, 320);
            lblPublisherId.Name = "lblPublisherId";
            lblPublisherId.Size = new Size(67, 15);
            lblPublisherId.TabIndex = 1;
            lblPublisherId.Text = "出版社編號";
            // 
            // txtPublisherId
            // 
            txtPublisherId.Location = new Point(120, 316);
            txtPublisherId.Name = "txtPublisherId";
            txtPublisherId.Size = new Size(200, 23);
            txtPublisherId.TabIndex = 2;
            // 
            // lblPublisherName
            // 
            lblPublisherName.AutoSize = true;
            lblPublisherName.Location = new Point(8, 350);
            lblPublisherName.Name = "lblPublisherName";
            lblPublisherName.Size = new Size(67, 15);
            lblPublisherName.TabIndex = 3;
            lblPublisherName.Text = "出版社名稱";
            // 
            // txtPublisherName
            // 
            txtPublisherName.Location = new Point(120, 346);
            txtPublisherName.Name = "txtPublisherName";
            txtPublisherName.Size = new Size(200, 23);
            txtPublisherName.TabIndex = 4;
            // 
            // btnPublisherAdd
            // 
            btnPublisherAdd.Location = new Point(572, 320);
            btnPublisherAdd.Name = "btnPublisherAdd";
            btnPublisherAdd.Size = new Size(95, 30);
            btnPublisherAdd.TabIndex = 5;
            btnPublisherAdd.Text = "新增";
            btnPublisherAdd.Click += btnPublisherAdd_Click;
            // 
            // btnPublisherUpdate
            // 
            btnPublisherUpdate.Location = new Point(673, 320);
            btnPublisherUpdate.Name = "btnPublisherUpdate";
            btnPublisherUpdate.Size = new Size(95, 30);
            btnPublisherUpdate.TabIndex = 6;
            btnPublisherUpdate.Text = "更新";
            btnPublisherUpdate.Click += btnPublisherUpdate_Click;
            // 
            // btnPublisherDelete
            // 
            btnPublisherDelete.Location = new Point(572, 356);
            btnPublisherDelete.Name = "btnPublisherDelete";
            btnPublisherDelete.Size = new Size(95, 30);
            btnPublisherDelete.TabIndex = 7;
            btnPublisherDelete.Text = "刪除";
            btnPublisherDelete.Click += btnPublisherDelete_Click;
            // 
            // btnPublisherClear
            // 
            btnPublisherClear.Location = new Point(673, 356);
            btnPublisherClear.Name = "btnPublisherClear";
            btnPublisherClear.Size = new Size(95, 30);
            btnPublisherClear.TabIndex = 8;
            btnPublisherClear.Text = "清除";
            btnPublisherClear.Click += btnPublisherClear_Click;
            // 
            // txtPublisherSearch
            // 
            txtPublisherSearch.Location = new Point(8, 390);
            txtPublisherSearch.Name = "txtPublisherSearch";
            txtPublisherSearch.Size = new Size(260, 23);
            txtPublisherSearch.TabIndex = 9;
            // 
            // btnPublisherSearch
            // 
            btnPublisherSearch.Location = new Point(280, 388);
            btnPublisherSearch.Name = "btnPublisherSearch";
            btnPublisherSearch.Size = new Size(70, 26);
            btnPublisherSearch.TabIndex = 10;
            btnPublisherSearch.Text = "搜尋";
            btnPublisherSearch.Click += btnPublisherSearch_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(900, 560);
            Controls.Add(tabControlMain);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Book Store";
            tabControlMain.ResumeLayout(false);
            tabBooks.ResumeLayout(false);
            tabBooks.PerformLayout();
            ((ISupportInitialize)dgvBooks).EndInit();
            groupBoxImage.ResumeLayout(false);
            ((ISupportInitialize)pictureBoxBook).EndInit();
            tabAuthors.ResumeLayout(false);
            tabAuthors.PerformLayout();
            ((ISupportInitialize)dgvAuthors).EndInit();
            groupBoxAuthorImage.ResumeLayout(false);
            ((ISupportInitialize)pictureBoxAuthor).EndInit();
            tabGenres.ResumeLayout(false);
            tabGenres.PerformLayout();
            ((ISupportInitialize)dgvGenres).EndInit();
            tabPublishers.ResumeLayout(false);
            tabPublishers.PerformLayout();
            ((ISupportInitialize)dgvPublishers).EndInit();
            ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
