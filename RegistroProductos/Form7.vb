Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class Form7

    Dim conn As New MySqlConnection

    Public Sub Connect()

        conn.ConnectionString = ConfigurationManager.ConnectionStrings("cs").ConnectionString
        Try
            conn.Open()
            Console.WriteLine("conectandose a la base de datos")
        Catch ex As Exception
            MsgBox(ex.Message)
            End
        End Try
        conn.Close()

    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
        CargarDGV()
    End Sub

    Dim id_producto As String
    Dim id_prueba As String

    Public Sub RecibirVariablesForm5(ByVal var As String, ByVal var2 As String)
        id_producto = var
        id_prueba = var2
    End Sub

    Private Sub CargarDGV()

        If id_prueba = "D-3242" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'WP', Dato_2 as 'Vol', Dato_3 as 'Vb', Dato_4 as 'N', Dato_5 as 'W Muestra', Dato_6 as 'Vol Muestra', Dato_7 as 'Vol Blanco', Dato_8 as 'Temp. Muestra antes de la titulacion'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"

            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader

            Try
                conn.Open()
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
        End If

    End Sub
End Class