using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Book_Store
{
    public partial class Form1 : Form
    {
        private readonly string _connString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BOOK_STORE;Integrated Security=True;TrustServerCertificate=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCombos();
            LoadBooks();
            LoadAuthors();
            LoadGenres();
            LoadPublishers();
        }

        private void LoadCombos()
        {
            try
            {
                using var conn = new SqlConnection(_connString);
                conn.Open();

                // Authors
                using var cmdA = new SqlCommand("SELECT author_id, first_name + ' ' + ISNULL(last_name,'') AS name FROM Author ORDER BY first_name, last_name", conn);
                using var daA = new SqlDataAdapter(cmdA);
                var dtA = new DataTable();
                daA.Fill(dtA);
                if (cmbAuthor != null)
                {
                    cmbAuthor.DisplayMember = "name";
                    cmbAuthor.ValueMember = "author_id";
                    cmbAuthor.DataSource = dtA;
                }

                // Publishers
                using var cmdP = new SqlCommand("SELECT publisher_id, publisher_name FROM Publisher ORDER BY publisher_name", conn);
                using var daP = new SqlDataAdapter(cmdP);
                var dtP = new DataTable();
                daP.Fill(dtP);
                if (cmbPublisher != null)
                {
                    cmbPublisher.DisplayMember = "publisher_name";
                    cmbPublisher.ValueMember = "publisher_id";
                    cmbPublisher.DataSource = dtP;
                }

                // Genres
                using var cmdG = new SqlCommand("SELECT genre_id, genre_name FROM [Genre] ORDER BY genre_name", conn);
                using var daG = new SqlDataAdapter(cmdG);
                var dtG = new DataTable();
                daG.Fill(dtG);
                if (cmbGenre != null)
                {
                    cmbGenre.DisplayMember = "genre_name";
                    cmbGenre.ValueMember = "genre_id";
                    cmbGenre.DataSource = dtG;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("���J�U�Կ�楢�ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooks(string filter = "")
        {
            try
            {
                using var conn = new SqlConnection(_connString);
                var sql = @"SELECT book_id, title, isbn, publication_year, price, author_id, publisher_id, genre_id FROM Books";
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    sql += " WHERE title LIKE @f OR isbn LIKE @f";
                }
                using var cmd = new SqlCommand(sql, conn);
                if (!string.IsNullOrWhiteSpace(filter))
                    cmd.Parameters.AddWithValue("@f", "%" + filter + "%");

                using var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                if (dgvBooks != null) dgvBooks.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("���J���y���ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // �s�W�G���J�@�̲M��P�v��
        private void LoadAuthors(string filter = "")
        {
            try
            {
                using var conn = new SqlConnection(_connString);
                var sql = @"SELECT author_id, first_name, last_name FROM Author";
                if (!string.IsNullOrWhiteSpace(filter))
                    sql += " WHERE first_name LIKE @f OR last_name LIKE @f OR (first_name + ' ' + ISNULL(last_name,'')) LIKE @f";
                using var cmd = new SqlCommand(sql, conn);
                if (!string.IsNullOrWhiteSpace(filter))
                    cmd.Parameters.AddWithValue("@f", "%" + filter + "%");

                using var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                if (dgvAuthors != null) dgvAuthors.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("���J�@�̥��ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // �s�W�G���J���O�M��
        private void LoadGenres(string filter = "")
        {
            try
            {
                using var conn = new SqlConnection(_connString);
                var sql = @"SELECT genre_id, genre_name FROM [Genre]";
                if (!string.IsNullOrWhiteSpace(filter))
                    sql += " WHERE genre_name LIKE @f OR genre_id LIKE @f";
                using var cmd = new SqlCommand(sql, conn);
                if (!string.IsNullOrWhiteSpace(filter))
                    cmd.Parameters.AddWithValue("@f", "%" + filter + "%");

                using var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                if (dgvGenres != null) dgvGenres.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("���J���O���ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // �s�W�G���J�X�����M��
        private void LoadPublishers(string filter = "")
        {
            try
            {
                using var conn = new SqlConnection(_connString);
                var sql = @"SELECT publisher_id, publisher_name FROM Publisher";
                if (!string.IsNullOrWhiteSpace(filter))
                    sql += " WHERE publisher_name LIKE @f OR publisher_id LIKE @f";
                using var cmd = new SqlCommand(sql, conn);
                if (!string.IsNullOrWhiteSpace(filter))
                    cmd.Parameters.AddWithValue("@f", "%" + filter + "%");

                using var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                if (dgvPublishers != null) dgvPublishers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("���J�X�������ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBooks?.CurrentRow == null) return;
            var row = dgvBooks.CurrentRow;
            if (txtBookId != null)
                txtBookId.Text = row.Cells["book_id"].Value?.ToString();
            if (txtTitle != null)
                txtTitle.Text = row.Cells["title"].Value?.ToString();
            if (txtISBN != null)
                txtISBN.Text = row.Cells["isbn"].Value?.ToString();
            if (txtYear != null)
                txtYear.Text = row.Cells["publication_year"].Value?.ToString();
            if (txtPrice != null)
                txtPrice.Text = row.Cells["price"].Value?.ToString();

            if (row.Cells["author_id"].Value != DBNull.Value && cmbAuthor != null)
                cmbAuthor.SelectedValue = row.Cells["author_id"].Value;
            else if (cmbAuthor != null)
                cmbAuthor.SelectedIndex = -1;

            if (row.Cells["publisher_id"].Value != DBNull.Value && cmbPublisher != null)
                cmbPublisher.SelectedValue = row.Cells["publisher_id"].Value;
            else if (cmbPublisher != null)
                cmbPublisher.SelectedIndex = -1;

            if (row.Cells["genre_id"].Value != DBNull.Value && cmbGenre != null)
                cmbGenre.SelectedValue = row.Cells["genre_id"].Value;
            else if (cmbGenre != null)
                cmbGenre.SelectedIndex = -1;

            // ���J�v���]�W�߬d���קK DataGridView ���J�j�q�G�i�����^
            var id = txtBookId?.Text ?? string.Empty;
            LoadBookImage(id);
        }

        private void LoadBookImage(string bookId)
        {
            try
            {
                using var conn = new SqlConnection(_connString);
                using var cmd = new SqlCommand("SELECT image FROM Books WHERE book_id = @id", conn);
                cmd.Parameters.AddWithValue("@id", bookId);
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    var bytes = (byte[])result;
                    if (pictureBoxBook != null)
                        pictureBoxBook.Image = BytesToImage(bytes);
                }
                else
                {
                    if (pictureBoxBook != null)
                        pictureBoxBook.Image = null;
                }
            }
            catch
            {
                if (pictureBoxBook != null)
                    pictureBoxBook.Image = null;
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1?.ShowDialog() != DialogResult.OK) return;
            try
            {
                // openFileDialog1 �w�ˬd�L�D null
                var img = Image.FromFile(openFileDialog1!.FileName);
                if (pictureBoxBook != null) pictureBoxBook.Image = img;
            }
            catch (Exception ex)
            {
                MessageBox.Show("���J�v�����ѡG" + ex.Message);
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            if (pictureBoxBook != null) pictureBoxBook.Image = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using var conn = new SqlConnection(_connString);
                var sql = @"INSERT INTO Books(book_id, title, isbn, publication_year, price, author_id, publisher_id, genre_id, image)
                            VALUES(@book_id,@title,@isbn,@year,@price,@author,@publisher,@genre,@image)";
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@book_id", txtBookId?.Text ?? string.Empty);
                cmd.Parameters.AddWithValue("@title", txtTitle?.Text ?? string.Empty);
                cmd.Parameters.AddWithValue("@isbn", txtISBN?.Text ?? string.Empty);
                cmd.Parameters.AddWithValue("@year", txtYear?.Text ?? string.Empty);
                cmd.Parameters.AddWithValue("@price", txtPrice?.Text ?? string.Empty);
                cmd.Parameters.AddWithValue("@author", cmbAuthor?.SelectedValue ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@publisher", cmbPublisher?.SelectedValue ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@genre", cmbGenre?.SelectedValue ?? (object)DBNull.Value);
                var imgBytes = pictureBoxBook?.Image != null ? ImageToBytes(pictureBoxBook.Image) : null;
                cmd.Parameters.AddWithValue("@image", imgBytes ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("�s�W���\");
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("�s�W���ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookId?.Text))
            {
                MessageBox.Show("�п�ܩο�J���y�s���A��s�C");
                return;
            }

            try
            {
                using var conn = new SqlConnection(_connString);
                var sql = @"UPDATE Books SET title=@title, isbn=@isbn, publication_year=@year, price=@price, author_id=@author, publisher_id=@publisher, genre_id=@genre, image=@image
                            WHERE book_id=@book_id";
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@book_id", txtBookId?.Text ?? string.Empty);
                cmd.Parameters.AddWithValue("@title", txtTitle?.Text ?? string.Empty);
                cmd.Parameters.AddWithValue("@isbn", txtISBN?.Text ?? string.Empty);
                cmd.Parameters.AddWithValue("@year", txtYear?.Text ?? string.Empty);
                cmd.Parameters.AddWithValue("@price", txtPrice?.Text ?? string.Empty);
                cmd.Parameters.AddWithValue("@author", cmbAuthor?.SelectedValue ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@publisher", cmbPublisher?.SelectedValue ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@genre", cmbGenre?.SelectedValue ?? (object)DBNull.Value);
                var imgBytes = pictureBoxBook?.Image != null ? ImageToBytes(pictureBoxBook.Image) : null;
                cmd.Parameters.AddWithValue("@image", imgBytes ?? (object)DBNull.Value);

                conn.Open();
                var affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                    MessageBox.Show("��s����");
                else
                    MessageBox.Show("�䤣��n��s�����");
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("��s���ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookId?.Text))
            {
                MessageBox.Show("�п�ܭn�R�������y�C");
                return;
            }

            if (MessageBox.Show("�T�w�n�R�������y�H", "�T�{", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                using var conn = new SqlConnection(_connString);
                using var cmd = new SqlCommand("DELETE FROM Books WHERE book_id=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtBookId?.Text ?? string.Empty);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("�R������");
                ClearForm();
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("�R�����ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtBookId?.Clear();
            txtTitle?.Clear();
            txtISBN?.Clear();
            txtYear?.Clear();
            txtPrice?.Clear();
            if (cmbAuthor != null) cmbAuthor.SelectedIndex = -1;
            if (cmbPublisher != null) cmbPublisher.SelectedIndex = -1;
            if (cmbGenre != null) cmbGenre.SelectedIndex = -1;
            if (pictureBoxBook != null) pictureBoxBook.Image = null;
            if (dgvBooks != null) dgvBooks.ClearSelection();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadBooks(txtSearch?.Text?.Trim() ?? string.Empty);
        }

        // �ȫO�d�@�ռv��/�G�i���ഫ���U��k�A�קK���Ʃw�q�P�ҸW��i
        private static byte[] ImageToBytes(Image img)
        {
            using var ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        private static Image BytesToImage(byte[] bytes)
        {
            using var ms = new MemoryStream(bytes);
            return Image.FromStream(ms);
        }

        private void pictureBoxBook_Click(object sender, EventArgs e)
        {
            // �i�H�O�d�Ź�@�� Designer �j�w
        }

        // �s�W�@��
        private void btnAuthorAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAuthorId?.Text) || string.IsNullOrWhiteSpace(txtAuthorFirst?.Text))
            {
                MessageBox.Show("�п�J�@�̽s���P�W�r�C");
                return;
            }

            try
            {
                using var conn = new SqlConnection(_connString);
                var sql = @"INSERT INTO Author (author_id, first_name, last_name, photo)
                            VALUES (@id, @first, @last, @photo)";
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", txtAuthorId.Text.Trim());
                cmd.Parameters.AddWithValue("@first", txtAuthorFirst.Text.Trim());
                cmd.Parameters.AddWithValue("@last", string.IsNullOrWhiteSpace(txtAuthorLast?.Text) ? (object)DBNull.Value : txtAuthorLast.Text.Trim());
                var imgBytes = pictureBoxAuthor?.Image != null ? ImageToBytes(pictureBoxAuthor.Image) : null;
                cmd.Parameters.AddWithValue("@photo", imgBytes ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("�s�W�@�̦��\");
                LoadAuthors();
                if (dgvAuthors != null) dgvAuthors.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("�s�W�@�̥��ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAuthorImage(string authorId)
        {
            try
            {
                using var conn = new SqlConnection(_connString);
                using var cmd = new SqlCommand("SELECT photo FROM Author WHERE author_id = @id", conn);
                cmd.Parameters.AddWithValue("@id", authorId ?? string.Empty);
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    var bytes = (byte[])result;
                    if (pictureBoxAuthor != null)
                        pictureBoxAuthor.Image = BytesToImage(bytes);
                }
                else
                {
                    if (pictureBoxAuthor != null)
                        pictureBoxAuthor.Image = null;
                }
            }
            catch
            {
                if (pictureBoxAuthor != null)
                    pictureBoxAuthor.Image = null;
            }
        }

        // ���N�G��@�̿���ܧ�ɶ�J���P���J�Ӥ�
        private void dgvAuthors_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAuthors?.CurrentRow == null) return;
            var row = dgvAuthors.CurrentRow;
            if (txtAuthorId != null)
                txtAuthorId.Text = row.Cells["author_id"].Value?.ToString();
            if (txtAuthorFirst != null)
                txtAuthorFirst.Text = row.Cells["first_name"].Value?.ToString();
            if (txtAuthorLast != null)
                txtAuthorLast.Text = row.Cells["last_name"].Value?.ToString();

            var id = txtAuthorId?.Text ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(id))
                LoadAuthorImage(id);
            else if (pictureBoxAuthor != null)
                pictureBoxAuthor.Image = null;
        }

        // ��s�@��
        private void btnAuthorUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAuthorId?.Text))
            {
                MessageBox.Show("�п�ܩο�J�@�̽s���A��s�C");
                return;
            }

            try
            {
                using var conn = new SqlConnection(_connString);
                var sql = @"UPDATE Author SET first_name=@first, last_name=@last, photo=@photo WHERE author_id=@id";
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", txtAuthorId.Text.Trim());
                cmd.Parameters.AddWithValue("@first", txtAuthorFirst?.Text?.Trim() ?? string.Empty);
                cmd.Parameters.AddWithValue("@last", string.IsNullOrWhiteSpace(txtAuthorLast?.Text) ? (object)DBNull.Value : txtAuthorLast.Text.Trim());
                var imgBytes = pictureBoxAuthor?.Image != null ? ImageToBytes(pictureBoxAuthor.Image) : null;
                cmd.Parameters.AddWithValue("@photo", imgBytes ?? (object)DBNull.Value);

                conn.Open();
                var affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                    MessageBox.Show("��s�@�̧���");
                else
                    MessageBox.Show("�䤣��n��s���@��");
                LoadAuthors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("��s�@�̥��ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // �R���@��
        private void btnAuthorDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAuthorId?.Text))
            {
                MessageBox.Show("�п�ܭn�R�����@�̡C");
                return;
            }

            if (MessageBox.Show("�T�w�n�R�����@�̡H\n�]�`�N�G�Y�����p�����y�i��|�y�� FK ���~�^", "�T�{", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                using var conn = new SqlConnection(_connString);
                using var cmd = new SqlCommand("DELETE FROM Author WHERE author_id=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtAuthorId.Text.Trim());
                conn.Open();
                var affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                {
                    MessageBox.Show("�R���@�̧���");
                    // �ǤJ this �H�ŦX�D nullable �Ѽ�ñ���A�קK CS8625
                    btnAuthorClear_Click(this, EventArgs.Empty);
                    LoadAuthors();
                }
                else
                {
                    MessageBox.Show("�䤣��n�R�����@��");
                }
            }
            catch (SqlException ex) when (ex.Number == 547) // �~��H��
            {
                MessageBox.Show("�L�k�R���G���@�̦����p�����y�C�Х������Χ�s���p�����y�C", "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("�R���@�̥��ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAuthorClear_Click(object sender, EventArgs e)
        {
            txtAuthorId?.Clear();
            txtAuthorFirst?.Clear();
            txtAuthorLast?.Clear();
            if (pictureBoxAuthor != null) pictureBoxAuthor.Image = null;
            if (dgvAuthors != null) dgvAuthors.ClearSelection();
        }

        private void btnAuthorSearch_Click(object sender, EventArgs e)
        {
            LoadAuthors(txtAuthorSearch?.Text?.Trim() ?? string.Empty);
        }

        private void btnAuthorRemoveImage_Click(object sender, EventArgs e)
        {
            if (pictureBoxAuthor != null) pictureBoxAuthor.Image = null;
        }

        // �d�ҡG�}���ɮ׹�ܮؿ�ܹϤ��A����ܩ� pictureBoxAuthor
        private void btnAuthorUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "��ܧ@�̷Ӥ�";
                openFileDialog.Filter = "�Ϥ��ɮ�|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxAuthor.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        // ---------- Genre handlers ----------
        private void dgvGenres_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGenres?.CurrentRow == null) return;
            var row = dgvGenres.CurrentRow;
            if (txtGenreId != null)
                txtGenreId.Text = row.Cells["genre_id"].Value?.ToString();
            if (txtGenreName != null)
                txtGenreName.Text = row.Cells["genre_name"].Value?.ToString();
        }

        private void btnGenreAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGenreId?.Text) || string.IsNullOrWhiteSpace(txtGenreName?.Text))
            {
                MessageBox.Show("�п�J���O�s���P�W�١C");
                return;
            }

            try
            {
                using var conn = new SqlConnection(_connString);
                var sql = @"INSERT INTO [Genre] (genre_id, genre_name) VALUES (@id, @name)";
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", txtGenreId.Text.Trim());
                cmd.Parameters.AddWithValue("@name", txtGenreName.Text.Trim());
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("�s�W���O���\");
                LoadGenres();
                LoadCombos();
                if (dgvGenres != null) dgvGenres.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("�s�W���O���ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenreUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGenreId?.Text))
            {
                MessageBox.Show("�п�ܩο�J���O�s���A��s�C");
                return;
            }

            try
            {
                using var conn = new SqlConnection(_connString);
                var sql = @"UPDATE [Genre] SET genre_name=@name WHERE genre_id=@id";
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", txtGenreId.Text.Trim());
                cmd.Parameters.AddWithValue("@name", txtGenreName?.Text?.Trim() ?? string.Empty);
                conn.Open();
                var affected = cmd.ExecuteNonQuery();
                if (affected > 0) MessageBox.Show("��s���O����");
                else MessageBox.Show("�䤣��n��s�����O");
                LoadGenres();
                LoadCombos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("��s���O���ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenreDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGenreId?.Text))
            {
                MessageBox.Show("�п�ܭn�R�������O�C");
                return;
            }

            if (MessageBox.Show("�T�w�n�R�������O�H\n�]�`�N�G�Y�����p�����y�i��|�y�� FK ���~�^", "�T�{", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                using var conn = new SqlConnection(_connString);
                using var cmd = new SqlCommand("DELETE FROM [Genre] WHERE genre_id=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtGenreId.Text.Trim());
                conn.Open();
                var affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                {
                    MessageBox.Show("�R�����O����");
                    btnGenreClear_Click(this, EventArgs.Empty);
                    LoadGenres();
                    LoadCombos();
                }
                else
                {
                    MessageBox.Show("�䤣��n�R�������O");
                }
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("�L�k�R���G�����O�����p�����y�C�Х������Χ�s���p�����y�C", "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("�R�����O���ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenreClear_Click(object sender, EventArgs e)
        {
            txtGenreId?.Clear();
            txtGenreName?.Clear();
            if (dgvGenres != null) dgvGenres.ClearSelection();
        }

        private void btnGenreSearch_Click(object sender, EventArgs e)
        {
            LoadGenres(txtGenreSearch?.Text?.Trim() ?? string.Empty);
        }

        // ---------- Publisher handlers ----------
        private void dgvPublishers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPublishers?.CurrentRow == null) return;
            var row = dgvPublishers.CurrentRow;
            if (txtPublisherId != null)
                txtPublisherId.Text = row.Cells["publisher_id"].Value?.ToString();
            if (txtPublisherName != null)
                txtPublisherName.Text = row.Cells["publisher_name"].Value?.ToString();
        }

        private void btnPublisherAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPublisherId?.Text) || string.IsNullOrWhiteSpace(txtPublisherName?.Text))
            {
                MessageBox.Show("�п�J�X�����s���P�W�١C");
                return;
            }

            try
            {
                using var conn = new SqlConnection(_connString);
                var sql = @"INSERT INTO Publisher (publisher_id, publisher_name) VALUES (@id, @name)";
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", txtPublisherId.Text.Trim());
                cmd.Parameters.AddWithValue("@name", txtPublisherName.Text.Trim());
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("�s�W�X�������\");
                LoadPublishers();
                LoadCombos();
                if (dgvPublishers != null) dgvPublishers.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("�s�W�X�������ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPublisherUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPublisherId?.Text))
            {
                MessageBox.Show("�п�ܩο�J�X�����s���A��s�C");
                return;
            }

            try
            {
                using var conn = new SqlConnection(_connString);
                var sql = @"UPDATE Publisher SET publisher_name=@name WHERE publisher_id=@id";
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", txtPublisherId.Text.Trim());
                cmd.Parameters.AddWithValue("@name", txtPublisherName?.Text?.Trim() ?? string.Empty);
                conn.Open();
                var affected = cmd.ExecuteNonQuery();
                if (affected > 0) MessageBox.Show("��s�X��������");
                else MessageBox.Show("�䤣��n��s���X����");
                LoadPublishers();
                LoadCombos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("��s�X�������ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPublisherDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPublisherId?.Text))
            {
                MessageBox.Show("�п�ܭn�R�����X�����C");
                return;
            }

            if (MessageBox.Show("�T�w�n�R�����X�����H\n�]�`�N�G�Y�����p�����y�i��|�y�� FK ���~�^", "�T�{", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                using var conn = new SqlConnection(_connString);
                using var cmd = new SqlCommand("DELETE FROM Publisher WHERE publisher_id=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtPublisherId.Text.Trim());
                conn.Open();
                var affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                {
                    MessageBox.Show("�R���X��������");
                    btnPublisherClear_Click(this, EventArgs.Empty);
                    LoadPublishers();
                    LoadCombos();
                }
                else
                {
                    MessageBox.Show("�䤣��n�R�����X����");
                }
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("�L�k�R���G���X���������p�����y�C�Х������Χ�s���p�����y�C", "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("�R���X�������ѡG" + ex.Message, "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPublisherClear_Click(object sender, EventArgs e)
        {
            txtPublisherId?.Clear();
            txtPublisherName?.Clear();
            if (dgvPublishers != null) dgvPublishers.ClearSelection();
        }

        private void btnPublisherSearch_Click(object sender, EventArgs e)
        {
            LoadPublishers(txtPublisherSearch?.Text?.Trim() ?? string.Empty);
        }
    }
}
