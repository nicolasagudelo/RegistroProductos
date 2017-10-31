﻿Imports MySql.Data.MySqlClient
Imports System.Configuration
Public Class Form6
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

    Dim cliente As Integer

    Public Sub RecibirClienteId(c As Integer)
        cliente = c
    End Sub


    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        control = 0
        Connect()
        CargarClientes()
        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("Select Direccion from clientes where ClienteID =" & cliente), conn)
            TxtBxDireccion.Text = cmd.ExecuteScalar.ToString
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
            conn.Close()
        End Try
        CargarProductos()
        CargarCategorias()
        FechaHoyBD()
    End Sub

    Private Sub FechaHoyBD()

        Dim fecha_registro As String

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("SELECT DATE(NOW())"), conn)
            Dim fecha_registro_datetime As DateTime = cmd.ExecuteScalar
            fecha_registro = fecha_registro_datetime.ToString("yyyy-MM-dd")
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
            Exit Sub
        End Try

        TxtBxFechaRegistro.Text = fecha_registro

    End Sub

    Public Sub CargarCategorias()
        Dim query As String = " Select ID_Categoria, Nombre from categorias"
        Dim cmd As New MySqlCommand(query, conn)
        Dim sqlAdap As New MySqlDataAdapter(cmd)
        Dim dtRecord As New DataTable
        sqlAdap.Fill(dtRecord)
        CmbBxCategorias.DataSource = dtRecord
        CmbBxCategorias.DisplayMember = "Nombre"
        CmbBxCategorias.ValueMember = "ID_Categoria"
    End Sub

    Dim control As Integer = 0
    Private Sub Form6_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        control = 1
    End Sub

    Dim CheckBoxButtonArray() As CheckBox
    Dim pruebascategoria As Integer
    Dim cod_prue As New List(Of String)()
    Dim nombre_prueba As New List(Of String)()

    Private Sub CmbBxCategorias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBxCategorias.SelectedIndexChanged
        If control = 0 Then
            Exit Sub
        End If

        RBQuitarTodo.Visible = True
        RBSeleccionarTodo.Visible = True

        Dim categoria As String = CmbBxCategorias.SelectedValue.ToString

        If categoria = "20" Then
            RBQuitarTodo.Checked = True
            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("Select count(*) from Pruebas"), conn)
                pruebascategoria = cmd.ExecuteScalar
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, False, "Error")
                conn.Close()
            End Try

            ReDim CheckBoxButtonArray(pruebascategoria)

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("select ID_Prueba from Pruebas"), conn)
                Dim dr = cmd.ExecuteReader
                While dr.Read
                    cod_prue.Add(dr("ID_Prueba").ToString())
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, False, "Error")
                conn.Close()
            End Try

            'For Each item As String In cod_prue
            '    Console.WriteLine(item)
            'Next


            For Each item As String In cod_prue
                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("select Nombre from pruebas where ID_Prueba = '" & item & "';"), conn)
                    Dim dr = cmd.ExecuteReader
                    While dr.Read
                        nombre_prueba.Add(dr("nombre").ToString())
                    End While
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, False, "Error")
                    conn.Close()
                End Try
            Next

            'For Each item As String In nombre_prueba
            '    Console.WriteLine(item)
            'Next

            Panel1.Controls.Clear()

            Dim X1, Y1 As Integer
            Dim deltay As Integer = 40
            For i = 0 To pruebascategoria - 1
                X1 = 7
                If i = 0 Then
                    Y1 = 15
                Else
                    Y1 = Y1 + deltay
                End If
                CheckBoxButtonArray(i) = New CheckBox With {
                    .Location = New Point(X1, Y1),
                    .Text = cod_prue(i).ToString + " " + nombre_prueba(i) + ":",
                    .AutoEllipsis = True,
                    .AutoSize = True, '.Width = 300,'.Height = 20,
                    .ForeColor = Color.Black,
                    .Visible = True,
                    .Parent = Me.Panel1,
                    .Name = i.ToString,
                    .Checked = False
                }
            Next
        Else
            RBSeleccionarTodo.Checked = True
            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("Select count(*) from pruebasxcategoria where id_categoria = " & categoria & ";"), conn)
                pruebascategoria = cmd.ExecuteScalar
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, False, "Error")
                conn.Close()
            End Try

            ReDim CheckBoxButtonArray(pruebascategoria)

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("select ID_Prueba from pruebasxcategoria where ID_Categoria = " & categoria & ";"), conn)
                Dim dr = cmd.ExecuteReader
                While dr.Read
                    cod_prue.Add(dr("ID_Prueba").ToString())
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, False, "Error")
                conn.Close()
            End Try

            For Each item As String In cod_prue
                Console.WriteLine(item)
            Next


            For Each item As String In cod_prue
                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("select Nombre from pruebas where ID_Prueba = '" & item & "';"), conn)
                    Dim dr = cmd.ExecuteReader
                    While dr.Read
                        nombre_prueba.Add(dr("nombre").ToString())
                    End While
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, False, "Error")
                    conn.Close()
                End Try
            Next

            For Each item As String In nombre_prueba
                Console.WriteLine(item)
            Next

            Panel1.Controls.Clear()

            Dim X1, Y1 As Integer
            Dim deltay As Integer = 40
            For i = 0 To pruebascategoria - 1
                X1 = 7
                If i = 0 Then
                    Y1 = 15
                Else
                    Y1 = Y1 + deltay
                End If
                CheckBoxButtonArray(i) = New CheckBox With {
                    .Location = New Point(X1, Y1),
                    .Text = cod_prue(i).ToString + " " + nombre_prueba(i) + ":",
                    .AutoEllipsis = True,
                    .AutoSize = True, '.Width = 300,'.Height = 20,
                    .ForeColor = Color.Black,
                    .Visible = True,
                    .Parent = Me.Panel1,
                    .Name = i.ToString,
                    .Checked = True
                }
            Next

        End If
    End Sub

    Private Sub RBSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles RBSeleccionarTodo.CheckedChanged
        If RBSeleccionarTodo.Checked = True Then
            For i As Integer = 0 To pruebascategoria - 1
                CheckBoxButtonArray(i).Checked = True
            Next
        End If
    End Sub

    Private Sub RBQuitarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles RBQuitarTodo.CheckedChanged
        If RBQuitarTodo.Checked = True Then
            For i As Integer = 0 To pruebascategoria - 1
                CheckBoxButtonArray(i).Checked = False
            Next
        End If
    End Sub

    Public Sub CargarClientes()
        Dim query As String = " Select ClienteID, Nombre from Clientes"
        Dim cmd As New MySqlCommand(query, conn)
        Dim sqlAdap As New MySqlDataAdapter(cmd)
        Dim dtRecord As New DataTable
        sqlAdap.Fill(dtRecord)
        CmbBxCliente.DataSource = dtRecord
        CmbBxCliente.DisplayMember = "Nombre"
        CmbBxCliente.ValueMember = "ClienteID"
    End Sub

    Public Sub CargarProductos()
        Dim query As String = " Select Tipo_Producto_ID, Nombre from tipo_productos"
        Dim cmd As New MySqlCommand(query, conn)
        Dim sqlAdap As New MySqlDataAdapter(cmd)
        Dim dtRecord As New DataTable
        sqlAdap.Fill(dtRecord)
        CmbBxProducto.DataSource = dtRecord
        CmbBxProducto.DisplayMember = "Nombre"
        CmbBxProducto.ValueMember = "Tipo_Producto_ID"
    End Sub

    Private Sub CmbBxProducto_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbBxProducto.SelectedValueChanged
        Dim var As String = CmbBxProducto.SelectedValue.ToString

        If var = "3" Then
            PorcentajeBioD.Visible = True
            LblPorcentajeBioD.Visible = True
        Else
            PorcentajeBioD.Visible = False
            LblPorcentajeBioD.Visible = False
        End If
    End Sub

    Private Sub Form6_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Form2.Close()
    End Sub
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RchTxtBxObservaciones.TextChanged
        Dim i As Integer = RchTxtBxObservaciones.TextLength
        LblContadorCaracteres.Text = i.ToString + "/500"
        If i >= 450 Then
            LblContadorCaracteres.ForeColor = Color.Red
        Else
            LblContadorCaracteres.ForeColor = Color.Black
        End If
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If TxtBxOrigen.Text.Trim.Length = 0 Then
            MsgBox("Introduzca un Origen de la muestra", MsgBoxStyle.Exclamation, "Error")
            With TxtBxOrigen
                .Focus()
                .SelectAll()
            End With
            Exit Sub
        End If

        Dim año_actual As String

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("SELECT YEAR (NOW());"), conn)
            año_actual = (cmd.ExecuteScalar).ToString
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
            Exit Sub
        End Try

        Dim consecutivo As String

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("select count(*)+1 as c from productos where ProductoID like '" & año_actual & "%';"), conn)
            consecutivo = cmd.ExecuteScalar()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
            Exit Sub
        End Try

        Dim ProductoID = año_actual & "-" & consecutivo
        Dim Tipo_ProductoID As String = CmbBxProducto.SelectedValue.ToString
        Dim Fecha_Registro As String = TxtBxFechaRegistro.Text
        Dim ID_Muestra As String = TxtBxIDMuestra.Text
        Dim Lote As String = TxtBxLote.Text
        Dim Origen As String = TxtBxOrigen.Text
        Dim ObservacionesC As String = RchTxtBxObservaciones.Text
        If PorcentajeBioD.Visible = True Then
            Dim PorBioD As String = PorcentajeBioD.Value.ToString

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`productos` (`ProductoID`, `ClienteID`, `Tipo_Producto_ID`, `Observaciones_Cliente`, `Fecha_Registro`, `Estado`, `ID_Muestra`, `Tanque`, `Lote`, `PortBioD`) VALUES ('" & ProductoID & "', '" & cliente & "', '" & Tipo_ProductoID & "', '" & ObservacionesC & "', '" & Fecha_Registro & "', 'Transito', '" & ID_Muestra & "', '" & Origen & "', '" & Lote & "', '" & PorBioD & "');"), conn)
                cmd.ExecuteNonQuery()
                Console.WriteLine("Reporte Registrado")
                'MsgBox("Reporte Registrado", False, "Reporte Registrado")
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, False, "Error")
                conn.Close()
                Exit Sub
            End Try

        Else

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`productos` (`ProductoID`, `ClienteID`, `Tipo_Producto_ID`, `Observaciones_Cliente`, `Fecha_Registro`, `Estado`, `ID_Muestra`, `Tanque`, `Lote`) VALUES ('" & ProductoID & "', '" & cliente & "', '" & Tipo_ProductoID & "', '" & ObservacionesC & "', '" & Fecha_Registro & "', 'Transito', '" & ID_Muestra & "', '" & Origen & "', '" & Lote & "');"), conn)
                cmd.ExecuteNonQuery()
                Console.WriteLine("Reporte Registrado")
                'MsgBox("Reporte Registrado", False, "Reporte Registrado")
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, False, "Error")
                conn.Close()
                Exit Sub
            End Try

        End If

        For i = 0 To pruebascategoria - 1
            If CheckBoxButtonArray(i).Checked = True Then
                'MsgBox(cod_prue(i) & "-" & nombre_prueba(i))
                Dim ID_Prueba As String = cod_prue(i)
            End If
        Next


    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
End Class