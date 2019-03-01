Imports System.Data
Imports System.Data.OleDb
Module Module1
    Public conn As OleDbConnection
    Public cmd As OleDbCommand
    Public ds As New DataSet
    Public da As OleDbDataAdapter
    Public dr As OleDbDataReader
    Public lokasidata As String

    Public Sub konek()
        lokasidata = "provider=microsoft.jet.OLEDB.4.0;data source=gege.mdb"
        conn = New OleDbConnection(lokasidata)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
End Module
