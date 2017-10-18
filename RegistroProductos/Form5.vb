Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class Form5

    Dim conn As New MySqlConnection

    Private Sub Connect()
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("cs").ConnectionString
        Try
            conn.Open()
            Console.WriteLine("conectandose a la base de datos")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
        CArgarDGV()

    End Sub

    Private Sub CArgarDGV()
        Dim query As String = "Select reportes.ID_Prueba, pruebas.Nombre as 'Prueba', Valor, Valor_2, Valor_3, Valor_4, Valor_5
                               from reportes inner join pruebas on reportes.ID_Prueba = pruebas.ID_Prueba
                               where ProductoID = '" & TxtBxIDProducto.Text & "';"

        Dim cmd As New MySqlCommand(query, conn)
        Dim reader As MySqlDataReader

        Try
            conn.Open()
            Console.WriteLine("Cargando Pruebas de este reporte")

            reader = cmd.ExecuteReader

            Dim table As New DataTable
            table.Load(reader)
            DGV.DataSource = table
            DGV.ReadOnly = True
            DGV.AllowUserToResizeColumns = True
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            reader.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
        End Try

    End Sub
End Class
