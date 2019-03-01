Imports System.Data.OleDb
Public Class Form6
    Dim sqlnya As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form7.Show()

    End Sub

    Sub panggildata()
        konek()
        da = New OleDb.OleDbDataAdapter("SELECT * FROM tb_nilai", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tb_nilai")
        DataGridView1.DataSource = ds.Tables("tb_nilai")
        DataGridView1.Enabled = True
    End Sub

    Sub jalan()
        Dim objcmd As New System.Data.OleDb.OleDbCommand
        Call konek()
        objcmd.Connection = conn
        objcmd.CommandType = CommandType.Text
        objcmd.CommandText = sqlnya
        objcmd.ExecuteNonQuery()
        objcmd.Dispose()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As Integer
        a = TextBox5.Text
        Dim b As Integer
        b = TextBox7.Text
        Dim c As Integer
        c = TextBox8.Text
        Dim d As Integer
        d = TextBox9.Text
        TextBox6.Text = a + b + c + d
        TextBox12.Text = TextBox6.Text / 4
        If TextBox12.Text <= "75" Then
            TextBox11.Text = "BK"
        Else
            TextBox11.Text = "K"
        End If
        If TextBox11.Text = "BK" Then
            TextBox13.Text = "TIDAK LULUS"
        Else
            TextBox13.Text = "LULUS"
        End If

    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Data Masih Ada yang Kosong !", MsgBoxStyle.Critical, "WARNING")
            TextBox1.Focus()
        Else
            Call konek()
            Dim str As String
            str = "insert into tb_nilai values ('" & TextBox1.Text & "','" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "', '" & TextBox7.Text & "', '" & TextBox8.Text & "', '" & TextBox9.Text & "', '" & TextBox6.Text & "', '" & TextBox12.Text & "', '" & TextBox11.Text & "', '" & TextBox13.Text & "')"
            cmd = New OleDbCommand(str, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Simpan Data User Berhasil Dilakukan")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            TextBox11.Text = ""
            TextBox12.Text = ""
            TextBox13.Text = ""

            Call panggildata()

        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        sqlnya = "delete from tb_nilai where nis = '" & TextBox1.Text & "'"
        Call jalan()
        MsgBox("data terhapus !")
        Call panggildata()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Item(0, i).Value
        TextBox2.Text = DataGridView1.Item(1, i).Value
        TextBox3.Text = DataGridView1.Item(2, i).Value
        TextBox4.Text = DataGridView1.Item(3, i).Value
        TextBox5.Text = DataGridView1.Item(4, i).Value
        TextBox7.Text = DataGridView1.Item(5, i).Value
        TextBox8.Text = DataGridView1.Item(6, i).Value
        TextBox9.Text = DataGridView1.Item(7, i).Value
        TextBox6.Text = DataGridView1.Item(8, i).Value
        TextBox12.Text = DataGridView1.Item(9, i).Value
        TextBox11.Text = DataGridView1.Item(10, i).Value
        TextBox13.Text = DataGridView1.Item(11, i).Value
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        sqlnya = "UPDATE tb_nilai set nama =  '" & TextBox2.Text & "', rayon = '" & TextBox3.Text & "', jurusan ='" & TextBox4.Text & "', bindo ='" & TextBox5.Text & "', bing ='" & TextBox7.Text & "', mtk ='" & TextBox8.Text & "', prod ='" & TextBox9.Text & "', total ='" & TextBox6.Text & "', ratarata ='" & TextBox12.Text & "', pred ='" & TextBox11.Text & "', status ='" & TextBox13.Text & "' where nis = '" & TextBox1.Text & "'"
        Call jalan()
        MsgBox("data terupdate !")
        Call panggildata()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form2.Show()

    End Sub

    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox10.KeyPress
        konek()
        da = New OleDb.OleDbDataAdapter("select * from tb_nilai where nama like '%" & TextBox10.Text & "%'", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tb_nilai")
        DataGridView1.DataSource = ds.Tables("tb_nilai")
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

    End Sub
End Class