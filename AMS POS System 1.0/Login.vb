Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices

Public Class Login
    Public Function isConnectionAvailable() As Boolean
        Dim objURL As New System.Uri("https://www.google.co.id")
        Dim objWebReq As System.Net.WebRequest
        objWebReq = System.Net.WebRequest.Create(objURL)
        Dim objResp As System.Net.WebResponse
        Try
            objResp = objWebReq.GetResponse
            objResp.Close()
            objResp = Nothing
            Return True
        Catch ex As Exception
            objResp = Nothing
            objWebReq = Nothing
            Return False
        End Try
    End Function

    ''change textbox being password char
    Private Sub InitializeMyControl()
        nama_pengguna.Text = ""
        kata_sandi.PasswordChar = "*"
        kata_sandi.MaxLength = 14
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btn_masuk.Click
        If isConnectionAvailable() = True Then

            koneksi()
            Dim sqlQuery = "SELECT db_pengguna.nama_pengguna,db_pengguna.kode_jabatan,db_pengguna.nama_lengkap,db_outlet.kode_outlet,
db_outlet.nama_outlet FROM db_pengguna INNER JOIN db_outlet ON db_pengguna.kode_outlet = db_outlet.kode_outlet WHERE 
db_pengguna.nama_pengguna='" + nama_pengguna.Text + "' AND db_pengguna.kata_sandi='" + kata_sandi.Text + "'"
            Dim myCommand As New MySqlCommand
            With myCommand
                .Connection = conn
                .CommandText = sqlQuery
            End With
            Dim myData As MySqlDataReader
            myData = myCommand.ExecuteReader()

            Dim nama As String
            Dim jabatan As String
            Dim kode As String
            Dim outlet As String

            If myData.HasRows = 0 Then
                MsgBox("Nama Pengguna dan Kata Sandi salah!! ",
                       MsgBoxStyle.Exclamation, "Error Login")
            Else
                While myData.Read
                    nama = myData.GetString("nama_lengkap")
                    jabatan = myData.GetString("kode_jabatan")
                    kode = myData.GetString("kode_outlet")
                    outlet = myData.GetString("nama_outlet")
                End While
                MsgBox("Login berhasil, Selamat datang " & nama & "!", MsgBoxStyle.Information, "Successfull Login")
                If jabatan = 2 Then
                    Transaksi.Show()
                    Transaksi.kode_outlet.Text = kode
                    Transaksi.nama_outlet.Text = outlet
                    Transaksi.no_plu.Focus()
                    Me.Hide()
                    Transaksi.update_invoice()

                Else
                    admin_store.Show()
                End If
                Me.nama_pengguna.Text = ""
                Me.kata_sandi.Text = ""
            End If
        Else
            MsgBox("Tidak ada koneksi internet.")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        kata_sandi.UseSystemPasswordChar = Not CheckBox1.Checked
    End Sub

    Private Sub kata_sandi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles kata_sandi.KeyPress
        If e.KeyChar = Chr(13) Then
            btn_masuk.PerformClick()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class