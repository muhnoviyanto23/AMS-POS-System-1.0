Imports MySql.Data.MySqlClient

Public Class Transaksi
    Dim TextToPrint As String = ""
    Dim jumlahkarakter As Integer = 40 '40 adalah jumlah karakter (lebar) yang ada pada struk
    Dim Curwidth As Integer = Me.Width
    Dim Curheight As Integer = Me.Height
    Private Sub Transaksi_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub Transaksi_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim RatioHeight As Double = (Me.Height - Curheight) / Curheight
        Dim RatioWidth As Double = (Me.Width - Curwidth) / Curwidth

        For Each Ctrl As Control In Controls
            Ctrl.Width += Ctrl.Width * RatioWidth
            Ctrl.Height += Ctrl.Height * RatioHeight
            Ctrl.Left += Ctrl.Left * RatioWidth
            Ctrl.Top += Ctrl.Top * RatioHeight
        Next

        Curheight = Me.Height
        Curwidth = Me.Width

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TabControl1.SelectedIndex = 1
        tampil_penjualan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TabControl1.SelectedIndex = 0
    End Sub

    Sub cetak_struk()
        Dim strPrint As String
        Dim alamat As String
        strPrint = "Toko Jualan Saya" & vbCrLf
        strPrint = strPrint & "------------------------------" & vbCrLf
        strPrint = strPrint & "No   : " & +no_invoice.Text & +vbCrLf
        strPrint = strPrint & "Kasir: Lana" & vbCrLf
        strPrint = strPrint & " " & vbCrLf
        strPrint = strPrint & "Nama   Qty. Harga SubTotal" & vbCrLf
        strPrint = strPrint & "------------------------------" & vbCrLf
        strPrint = strPrint & "Ciki     2   5000    10000" & vbCrLf
        strPrint = strPrint & "Akua     3   1000     3000" & vbCrLf
        strPrint = strPrint & "------------------------------" & vbCrLf
        strPrint = strPrint & "Total                13000" & vbCrLf

        Printer.Print(strPrint)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim regDate As DateTime = DateTime.Now
        Dim regDate2 As Date = Date.Now

        If DataGridView1.Rows.Count > 0 Then
            conn.Close()

            Dim cmd_input As MySqlCommand
            conn.Open()

            For i As Integer = 0 To DataGridView1.Rows.Count - 1 Step +1
                cmd_input = New MySqlCommand("Insert into db_detail_transaksi(invoice,no_plu,nama_produk,qty,harga,diskon,sub_total,tgl_waktu,tanggal,modal,kode_outlet) Values (@inv,@plu,@nama,@qty,@harga,@diskon,@sub,@tgl,@tgl2,@mdl,@kode)", conn)
                cmd_input.Parameters.Add("inv", MySqlDbType.VarChar).Value = no_invoice.Text
                cmd_input.Parameters.Add("plu", MySqlDbType.VarChar).Value = DataGridView1.Rows(i).Cells(0).Value.ToString()
                cmd_input.Parameters.Add("nama", MySqlDbType.VarChar).Value = DataGridView1.Rows(i).Cells(1).Value.ToString()
                cmd_input.Parameters.Add("qty", MySqlDbType.Int32).Value = DataGridView1.Rows(i).Cells(2).Value.ToString()
                cmd_input.Parameters.Add("harga", MySqlDbType.Int32).Value = DataGridView1.Rows(i).Cells(3).Value.ToString()
                cmd_input.Parameters.Add("diskon", MySqlDbType.Int32).Value = DataGridView1.Rows(i).Cells(4).Value.ToString()
                cmd_input.Parameters.Add("sub", MySqlDbType.Int64).Value = DataGridView1.Rows(i).Cells(5).Value.ToString()
                cmd_input.Parameters.Add("tgl", MySqlDbType.DateTime).Value = regDate
                cmd_input.Parameters.Add("tgl2", MySqlDbType.DateTime).Value = regDate2
                cmd_input.Parameters.Add("mdl", MySqlDbType.Int32).Value = DataGridView1.Rows(i).Cells(6).Value.ToString()
                cmd_input.Parameters.Add("kode", MySqlDbType.VarChar).Value = kode_outlet.Text

                cmd_input.ExecuteNonQuery()
            Next
            conn.Close()
            input_total_trx()

            cetak_struk()

            bersihkan_data()
            tampil()
            update_invoice()

            total_sementara.Text = "0"
            total_belanja.Text = "0"

            terbayar.Text = ""
            kembalian.Text = ""
            combo_ket.SelectedIndex = -1
            combo_sales.SelectedIndex = -1
        Else
            MessageBox.Show("Silahkan melakukan pilih produk dahulu")
        End If
    End Sub

    Sub input_total_trx()
        Dim regDate As DateTime = DateTime.Now
        Dim regDate2 As Date = Date.Now
        conn.Close()
        Dim cmd_total As MySqlCommand
        conn.Open()
        cmd_total = New MySqlCommand("Insert into db_transaksi (invoice,total_bayar,terbayar,kasir,sales,keterangan,status,tgl,tgl_waktu,kode_outlet) Values (@inv,@tot_byr,@byr,@kasir,@sales,@ket,@stts,@tgl1,@tgl2,@kode)", conn)
        cmd_total.Parameters.Add("inv", MySqlDbType.VarChar).Value = no_invoice.Text
        cmd_total.Parameters.Add("tot_byr", MySqlDbType.Int64).Value = Convert.ToInt64(total_sementara.Text)
        cmd_total.Parameters.Add("byr", MySqlDbType.Int64).Value = Convert.ToInt64(terbayar.Text)
        cmd_total.Parameters.Add("kasir", MySqlDbType.VarChar).Value = nama_user.Text
        cmd_total.Parameters.Add("sales", MySqlDbType.VarChar).Value = combo_sales.Text
        cmd_total.Parameters.Add("ket", MySqlDbType.VarChar).Value = combo_ket.Text
        cmd_total.Parameters.Add("stts", MySqlDbType.VarChar).Value = "null"
        cmd_total.Parameters.Add("tgl1", MySqlDbType.Date).Value = regDate2
        cmd_total.Parameters.Add("tgl2", MySqlDbType.DateTime).Value = regDate
        cmd_total.Parameters.Add("kode", MySqlDbType.VarChar).Value = kode_outlet.Text

        cmd_total.ExecuteNonQuery()

        conn.Close()

    End Sub
    Private Sub Transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tampil()
        ambil_total()
        ambil_sales()
        update_invoice()

        total_sementara.Text = "0"
        total_belanja.Text = "0"
    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles no_plu.KeyDown
        If e.KeyCode = Keys.Enter Then
            koneksi()
            cmd = New MySqlCommand("SELECT * from db_produk where no_plu='" & no_plu.Text & "' and kode_outlet='" & kode_outlet.Text & "'")
            cmd.Connection = conn
            rd = cmd.ExecuteReader()
            rd.Read()
            Dim tgl As DateTime = DateTime.Now
            Dim tglskrg As String = tgl.ToString("yyyy-MM-dd HH:mm:ss")
            If rd.HasRows Then
                Try
                    koneksi()
                    Dim cmd1 As MySqlCommand
                    Dim rd1 As MySqlDataReader
                    cmd1 = New MySqlCommand("SELECT * from db_temp_pilih_produk where no_plu='" & rd.Item(1) & "' and kode_outlet='" & kode_outlet.Text & "'")
                    cmd1.Connection = conn
                    rd1 = cmd1.ExecuteReader()
                    rd1.Read()
                    If rd1.HasRows Then
                        ModuleKoneksi.koneksi()
                        simpan_temp_pilih = "UPDATE db_temp_pilih_produk SET qty=@qty,sub_total=@sub WHERE no_plu='" & rd.Item(1) & "' and kode_outlet='" & kode_outlet.Text & "'"
                        cmd = conn.CreateCommand
                        With cmd
                            .Connection = conn
                            .CommandText = simpan_temp_pilih
                            .Parameters.Add("qty", MySqlDbType.String, 50).Value = rd1.Item(3) + 1
                            .Parameters.Add("sub", MySqlDbType.String, 50).Value = (rd.Item(6) - (rd.Item(6) * rd.Item(7) / 100)) * (rd1.Item(3) + 1)
                            .ExecuteNonQuery()
                        End With

                    Else
                        ModuleKoneksi.koneksi()
                        simpan_temp_pilih = "INSERT INTO db_temp_pilih_produk (invoice,no_plu,nama_produk,qty,modal,harga,diskon,sub_total,tgl_waktu,kode_outlet) VALUES (@inv,@plu,@nama,@qty,@modal,@harga,@diskon,@sub_total,@tgl_waktu,@kode)"
                        cmd = conn.CreateCommand
                        With cmd
                            .Connection = conn
                            .CommandText = simpan_temp_pilih
                            .Parameters.Add("inv", MySqlDbType.String, 50).Value = no_invoice.Text
                            .Parameters.Add("plu", MySqlDbType.String, 50).Value = rd.Item(1)
                            .Parameters.Add("nama", MySqlDbType.String, 50).Value = rd.Item(2)
                            .Parameters.Add("qty", MySqlDbType.String, 50).Value = 1
                            .Parameters.Add("modal", MySqlDbType.String, 50).Value = rd.Item(5)
                            .Parameters.Add("harga", MySqlDbType.String, 50).Value = rd.Item(6)
                            .Parameters.Add("diskon", MySqlDbType.String, 50).Value = rd.Item(7)
                            .Parameters.Add("sub_total", MySqlDbType.String, 50).Value = rd.Item(6) - (rd.Item(6) * rd.Item(7) / 100)
                            .Parameters.Add("tgl_waktu", MySqlDbType.String, 50).Value = tglskrg
                            .Parameters.Add("kode", MySqlDbType.String, 50).Value = kode_outlet.Text
                            .ExecuteNonQuery()
                        End With

                    End If
                    tampil()
                    ambil_total()

                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
                End Try
                temp_total.Text = rd.Item(6)
                no_plu.Text = ""
            Else
                MessageBox.Show("Data tidak ditemukan.!!")
            End If
        End If
    End Sub

    Public da1 As MySqlDataAdapter
    Public da2 As MySqlDataAdapter
    Public dt1 As DataTable
    Public dt2 As DataTable
    Public total As String
    Public cmd1 As MySqlCommand
    Public rd1 As MySqlDataReader
    Sub ambil_total()
        If DataGridView1.RowCount > 0 Then
            Dim total As Integer = 0
            For index As Integer = 0 To DataGridView1.RowCount - 1
                total += Convert.ToDouble(DataGridView1.Rows(index).Cells(5).Value.ToString)
            Next
            total_sementara.Text = total.ToString()
            total_belanja.Text = total.ToString()
            total_belanja.Text = FormatNumber(total_belanja.Text, 0)
        End If
    End Sub
    Sub tampil()
        conn.Close()
        conn.Open()

        da1 = New MySqlDataAdapter("select no_plu,nama_produk,qty,harga,diskon,sub_total,modal from db_temp_pilih_produk", conn)
        dt1 = New DataTable
        da1.Fill(dt1)
        DataGridView1.DataSource = dt1


        DataGridView1.Columns(0).HeaderText = "No Plu"
        DataGridView1.Columns(1).HeaderText = "Nama Produk"
        DataGridView1.Columns(2).HeaderText = "Qty"
        DataGridView1.Columns(3).HeaderText = "Harga"
        DataGridView1.Columns(4).HeaderText = "Diskon"
        DataGridView1.Columns(5).HeaderText = "Sub Total"
        DataGridView1.Columns(6).HeaderText = "Modal"

        DataGridView1.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill


        DataGridView1.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular)
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray

        DataGridView1.Columns(5).DefaultCellStyle.Format = "N0"
        DataGridView1.Columns(3).DefaultCellStyle.Format = "N0"
        DataGridView1.Columns(6).Visible = False

        conn.Close()

    End Sub

    Sub tampil_penjualan()
        conn.Close()

        Dim tgl As DateTime = DateTime.Now
        Dim tglskrg As String = tgl.ToString("yyyy-MM-dd")
        Dim cmd_tampil As MySqlCommand

        conn.Open()
        da2 = New MySqlDataAdapter("select invoice,tgl_waktu,total_bayar,terbayar,kasir,sales,keterangan from db_transaksi where tgl = '" & tglskrg & "' and kode_outlet ='" & kode_outlet.Text & "'", conn)
        dt2 = New DataTable
        da2.Fill(dt2)
        DataGridView2.DataSource = dt2


        DataGridView2.Columns(0).HeaderText = "No. Invoice"
        DataGridView2.Columns(1).HeaderText = "Tanggal"
        DataGridView2.Columns(2).HeaderText = "Total Bayar"
        DataGridView2.Columns(3).HeaderText = "Terbayar"
        DataGridView2.Columns(4).HeaderText = "Kasir"
        DataGridView2.Columns(5).HeaderText = "Sales"
        DataGridView2.Columns(6).HeaderText = "Keterangan"

        DataGridView2.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DataGridView2.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill


        DataGridView2.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular)
        DataGridView2.EnableHeadersVisualStyles = False
        DataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray

        DataGridView2.Columns(5).DefaultCellStyle.Format = "N0"
        DataGridView2.Columns(3).DefaultCellStyle.Format = "N0"

        conn.Close()

    End Sub

    Sub ambil_sales()
        ModuleKoneksi.koneksi()
        Dim str As String
        str = "select nama_sales from db_sales order by id_sales"
        cmd = New MySqlCommand(str, conn)
        rd = cmd.ExecuteReader
        If rd.HasRows Then
            Do While rd.Read
                combo_sales.Items.Add(rd("nama_sales"))
            Loop
        Else
        End If
    End Sub

    Sub bersihkan_data()
        koneksi()
        cmd = New MySqlCommand("Delete from db_temp_pilih_produk where kode_outlet = '" & kode_outlet.Text & "'", conn)
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles terbayar.TextChanged
        Dim bayar As Integer
        Dim total1 As Integer
        Dim kembali As Integer
        If terbayar.Text = "" Then
            bayar = 0
        Else
            bayar = Convert.ToInt32(terbayar.Text)
        End If
        total1 = Convert.ToInt32(total_sementara.Text)
        kembali = bayar - total1
        If kembali < -1 Then
            kembalian.Text = "0"
        Else
            kembalian.Text = kembali.ToString()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles terbayar.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim pesan As String
        pesan = MessageBox.Show("Yakin melakukan void??", "Void Transaksi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If pesan = DialogResult.Yes Then
            Try
                koneksi()
                cmd = New MySqlCommand("Delete from db_temp_pilih_produk where kode_outlet = '" & kode_outlet.Text & "'", conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Void data berhasil")
            Catch ex As Exception
                MessageBox.Show("Void data gagal")
            End Try
            total_sementara.Text = "0"
            total_belanja.Text = "0"
            tampil()
        End If
    End Sub

    Private Sub terbayar_DoubleClick(sender As Object, e As EventArgs) Handles terbayar.DoubleClick
        terbayar.Text = total_sementara.Text
    End Sub

    Sub update_invoice()
        Dim tgl As Date = Date.Now()
        Dim str_tgl As String = tgl.ToString("ddMMyyyy")

        conn.Close()

        Dim cmd_jum As MySqlCommand

        Try
            conn.Open()
            Dim Query As String

            Query = "Select * from db_transaksi"
            cmd = New MySqlCommand(Query, conn)
            rd = cmd.ExecuteReader
            Dim count As Integer
            count = 0
            While rd.Read
                count = count + 1
            End While

            no_invoice.Text = kode_outlet.Text + "-" + str_tgl + "-" + Convert.ToString(count)
            conn.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn.Dispose()
        End Try
    End Sub

End Class