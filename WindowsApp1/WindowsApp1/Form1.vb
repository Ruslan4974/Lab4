Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'Нажатие по кнопке Обзор - выбор загружаемого файла на FTP-сервер
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            TextBox4.Text = OpenFileDialog1.FileName
        End If
    End Sub

    'Нажатие на кнопку Загрузить - загрузка файла на FTP-сервер
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'путь к файлу, адрес сервера, имя файла на сервере, имя пользователя, пароль
        'Пример ввода вдреса сервера: ftp://имясервера/
        Try
            My.Computer.Network.UploadFile(TextBox4.Text, TextBox1.Text & OpenFileDialog1.SafeFileName, TextBox2.Text, TextBox3.Text)
        Catch ex As Exception
            MsgBox("Ошибка, проверьте корректность введенных данных!!!")
        End Try
        If My.Computer.Network.IsAvailable Then
            MsgBox("Файл успешно отправлен")
        End If

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Dim FI As IO.FileInfo = New IO.FileInfo(TextBox4.Text)
        If FI.Exists Then
            MsgBox("Есть такой файл!")
        Else
            MsgBox("Файл не найден...")
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If (TextBox1.Text = "") Then
            Button2.Visible = False
            Button2.Enabled = False
        Else
            Button2.Visible = True
            Button2.Enabled = True
        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If (TextBox2.Text = "") Then
            Button2.Enabled = False
            MsgBox("Не введено имя пользователя!!!")
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If (TextBox3.Text = "") Then
            Button2.Enabled = False
            MsgBox("Не введен пароль!!!")
        End If
    End Sub
End Class
