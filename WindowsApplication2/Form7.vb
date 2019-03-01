Imports System.Data.OleDb
Public Class Form7
    Dim sqlnya As String
    Sub panggildata()
        konek()
        da = New OleDb.OleDbDataAdapter("SELECT * FROM tb_siswa", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tb_siswa")
        DataGridView1.DataSource = ds.Tables("tb_siswa")
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
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Form6.TextBox1.Text = DataGridView1.Item(0, i).Value
        Form6.TextBox2.Text = DataGridView1.Item(1, i).Value
        Form6.TextBox3.Text = DataGridView1.Item(5, i).Value
        Form6.TextBox4.Text = DataGridView1.Item(6, i).Value

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        konek()
        da = New OleDb.OleDbDataAdapter("select * from tb_siswa where nama like '%" & TextBox1.Text & "%'", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tb_siswa")
        DataGridView1.DataSource = ds.Tables("tb_siswa")
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class