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

            Dim query As String = "SELECT DatoID, Dato_1 as 'WP', Dato_2 as 'Vol', Dato_3 as 'Vb', Dato_4 as 'Normalidad', Dato_5 as 'W Muestra', Dato_6 as 'Vol Muestra', Dato_7 as 'Vol Blanco', Dato_8 as 'Temp. Muestra antes de la titulacion' , Dato_9 as 'Acidez'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-1319-01" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Longitud Total 1 (mm)', Dato_2 as 'Longitud Total 2 (mm)', Dato_3 as 'Longitud Total 3 (mm)', Dato_4 as 'Longitud Total 4 (mm)', Dato_5 as 'Longitud Aromaticos 1 (mm)', Dato_6 as 'Longitud Aromaticos 2 (mm)', Dato_7 as 'Longitud Aromaticos 3 (mm)', Dato_8 as 'Longitud Aromaticos 4 (mm)', Dato_9 as 'La1/Lt1 * 100', Dato_10 as 'La2/Lt2 * 100', Dato_11 as 'La3/Lt3 * 100', Dato_12 as 'La4/Lt4 * 100', Dato_13 as 'Promedio'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-1319-02" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Longitud Total 1 (mm)', Dato_2 as 'Longitud Total 2 (mm)', Dato_3 as 'Longitud Total 3 (mm)', Dato_4 as 'Longitud Total 4 (mm)', Dato_5 as 'Longitud Olefina 1 (mm)', Dato_6 as 'Longitud Olefina 2 (mm)', Dato_7 as 'Longitud Olefina 3 (mm)', Dato_8 as 'Longitud Olefina 4 (mm)', Dato_9 as 'Lo1/Lt1 * 100', Dato_10 as 'Lo2/Lt2 * 100', Dato_11 as 'Lo3/Lt3 * 100', Dato_12 as 'Lo4/Lt4 * 100', Dato_13 as 'Promedio'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-1319-03" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Longitud Total 1 (mm)', Dato_2 as 'Longitud Total 2 (mm)', Dato_3 as 'Longitud Total 3 (mm)', Dato_4 as 'Longitud Total 4 (mm)', Dato_5 as 'Longitud Saturados 1 (mm)', Dato_6 as 'Longitud Saturados 2 (mm)', Dato_7 as 'Longitud Saturados 3 (mm)', Dato_8 as 'Longitud Saturados 4 (mm)', Dato_9 as 'Li1/Lt1 * 100', Dato_10 as 'Li2/Lt2 * 100', Dato_11 as 'Li3/Lt3 * 100', Dato_12 as 'Li4/Lt4 * 100', Dato_13 as 'Promedio'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-1840" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Absorbancia (285nm)', Dato_2 as 'Peso Muestra', Dato_3 as 'Constante (K)', Dato_4 as 'Absortividad Naftaleno', Dato_5 as 'Densidad Rel. Muestra a 15ºC', Dato_6 as 'Densidad Rel. Naftaleno a 15ºC', Dato_7 as '% Mass', Dato_8 as 'B/C', Dato_9 as '% Volumen'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-1322" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Turbidez', Dato_2 as 'Filtracion', Dato_3 as 'Presion Barometrica (kPal)', Dato_4 as 'Temperatura Muestra (°C)', Dato_5 as 'Lectura 1 (mm)', Dato_6 as 'Lectura 2 (mm)', Dato_7 as 'Lectura 3 (mm)', Dato_8 as 'Promedio', Dato_9 as 'Factor de Correccion', Dato_10 as 'Valor Final'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-56" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Temperatura Muestra (°C)', Dato_2 as 'Presion Barometrica Observada (kPal)', Dato_3 as ' Punto de Chispa Observado(°C)', Dato_4 as 'Punto de Chispa Corregido (°C)'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-93" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Temperatura Muestra (°C)', Dato_2 as 'Presion Barometrica Observada (kPal)', Dato_3 as ' Punto de Chispa Observado(°C)', Dato_4 as 'Punto de Chispa Corregido (°C)'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-4294-01" Or id_prueba = "D-4294-02" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Agua Suspendida', Dato_2 as 'Homogeniziacion y Analisis Inmediato', Dato_3 as 'Muestra 1', Dato_4 as 'Muestra 2', Dato_5 as 'Promedio'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        End If




    End Sub

    Private Sub LoadDGV(ByVal query As String)
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

        DGV.Columns(0).Visible = False

    End Sub
End Class