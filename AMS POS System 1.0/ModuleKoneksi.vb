﻿Imports MySql.Data.MySqlClient
Module ModuleKoneksi
    Public conn As MySqlConnection
    Public cmd As MySqlCommand
    Public rd As MySqlDataReader
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public str As String
    Public simpan_temp_pilih As String
    Sub koneksi()
        Try
            Dim str As String = "server=amsgroup.id; user id=u6820955_admin_xpos; password=tanyanov123 ; database=u6820955_xpos"
            conn = New MySqlConnection(str)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Module
