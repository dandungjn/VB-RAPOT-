Imports System.Data.OleDb
Public Class Form3
    Dim sqlnya As String

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Sub panggildata()
        konek()
        da = New OleDb.OleDbDataAdapter("SELECT * FROM tb_rayon", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tb_rayon")
        DataGridView1.DataSource = ds.Tables("tb_rayon")
        DataGridView1.Enabled = True
    End Sub
    Sub jalan()
        Dim objcmd As New System.Data.OleDb.OleDbCommand
        Call konek()
        objcmd.connection = conn
        objcmd.CommandType = CommandType.Text
        objcmd.CommandText = sqlnya
        objcmd.ExecuteNonQuery()
        objcmd.Dispose()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Data Masih Ada yang Kosong !", MsgBoxStyle.Critical, "WARNING")
            TextBox1.Focus()
        Else
            Call konek()
            Dim str As String
            str = "insert into tb_rayon values ('" & TextBox1.Text & "','" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "')"
            cmd = New OleDbCommand(str, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Simpan Data Siswa Berhasil Dilakukan")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            Call panggildata()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sqlnya = "delete from tb_rayon where kd_rayon = '" & TextBox1.Text & "'"
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


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sqlnya = "UPDATE tb_rayon set rayon =  '" & TextBox2.Text & "', pembimbing = '" & TextBox3.Text & "', ruangan ='" & TextBox4.Text & "' where kd_rayon = '" & TextBox1.Text & "'"
        Call jalan()
        MsgBox("data terupdate !")
        Call panggildata()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        konek()
        da = New OleDb.OleDbDataAdapter("select * from tb_rayon where rayon like '%" & TextBox5.Text & "%'", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tb_rayon")
        DataGridView1.DataSource = ds.Tables("tb_rayon")
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class