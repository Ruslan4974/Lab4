Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'Нажатие по кнопке Обзор - выбор загружаемого файла на FTP-сервер
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then TextBox4.Text = OpenFileDialog1.FileName
    End Sub

    'Нажатие на кнопку Загрузить - загрузка файла на FTP-сервер
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'путь к файлу, адрес сервера, имя файла на сервере, имя пользователя, пароль
        'Пример ввода вдреса сервера: ftp://имясервера/
        My.Computer.Network.UploadFile(TextBox4.Text, TextBox1.Text & OpenFileDialog1.SafeFileName, TextBox2.Text, TextBox3.Text)
    End Sub

End Class
