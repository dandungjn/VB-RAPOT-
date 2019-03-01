Imports System.Data.OleDb
Public Class Form8
    Dim sqlnya As String
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
        objcmd.connection = conn
        objcmd.CommandType = CommandType.Text
        objcmd.CommandText = sqlnya
        objcmd.ExecuteNonQuery()
        objcmd.Dispose()
        
    End Sub
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        konek()
        da = New OleDb.OleDbDataAdapter("select * from tb_nilai where nama like '%" & TextBox1.Text & "%'", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tb_nilai")
        DataGridView1.DataSource = ds.Tables("tb_nilai")
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form2.Show()


    End Sub
End Class