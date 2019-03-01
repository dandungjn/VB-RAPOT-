Imports System.Data
Imports System.Data.OleDb
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objcmd As New System.Data.OleDb.OleDbCommand
        Call konek()
        objcmd.Connection = conn
        objcmd.CommandType = CommandType.Text
        objcmd.CommandText = "select * from tb_user where username='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'"
        dr = objcmd.ExecuteReader()
        If dr.HasRows Then
            MsgBox("Login berhasil !")
            Me.Hide()
            Form2.Show()
        Else
            MsgBox("Username dan password salah !")
        End If

    End Sub
End Class
