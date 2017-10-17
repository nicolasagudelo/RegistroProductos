Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class Form3
    Dim conn As New MySqlConnection

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        control = 0
        Connect()
        LlenarCmbBxCategorias()
    End Sub

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
    Private Sub LlenarCmbBxCategorias()
        Dim query As String = " Select ID_Categoria, Nombre from categorias"
        Dim cmd As New MySqlCommand(query, conn)
        Dim sqlAdap As New MySqlDataAdapter(cmd)
        Dim dtRecord As New DataTable
        sqlAdap.Fill(dtRecord)
        CmbBxCategorias.DataSource = dtRecord
        CmbBxCategorias.DisplayMember = "Nombre"
        CmbBxCategorias.ValueMember = "ID_Categoria"
        CmbBxCategorias.DataSource = dtRecord
        CmbBxCategorias.DisplayMember = "Nombre"
        CmbBxCategorias.ValueMember = "ID_Categoria"
    End Sub

    Dim CheckBoxButtonArray() As CheckBox
    Dim TextBoxArray() As TextBox
    Dim tamaniobuttonarray As Integer = 0
    Dim ButtonArray(6) As Button
    Dim pruebascategoria As Integer
    Dim cod_prue As New List(Of String)()
    Dim nombre_prueba As New List(Of String)()



    Private Sub CmbBxCategorias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBxCategorias.SelectedIndexChanged
        If control = 0 Then
            Exit Sub
        End If
        cod_prue.Clear()
        nombre_prueba.Clear()

        Dim categoria As String = CmbBxCategorias.SelectedValue.ToString

        If categoria = "5" Then
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
            ReDim TextBoxArray(pruebascategoria)

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

            Dim X1, Y1, Y2 As Integer
            Dim deltay As Integer = 70
            For i = 0 To pruebascategoria - 1
                X1 = 7
                If i = 0 Then
                    Y1 = 15
                    Y2 = 40
                Else
                    Y1 = Y1 + deltay
                    Y2 = Y2 + deltay
                End If
                CheckBoxButtonArray(i) = New CheckBox With {
                    .Location = New Point(X1, Y1),
                    .Text = cod_prue(i).ToString + " " + nombre_prueba(i) + ":",
                    .Width = 300,
                    .Height = 20,
                    .ForeColor = Color.Black,
                    .Visible = True,
                    .Parent = Me.Panel1,
                    .Name = i.ToString,
                    .Checked = False
                }
                TextBoxArray(i) = New TextBox With {
                    .Location = New Point(X1, Y2),
                    .Size = New Size(300, 40),
                    .Enabled = False,
                    .Visible = True,
                    .Parent = Me.Panel1,
                    .Name = "TxtBx" + cod_prue(i).ToString
                }

                If cod_prue(i).ToString = "D-130-2" Or cod_prue(i).ToString = "D-86-9" Then
                    ButtonArray(tamaniobuttonarray) = New Button With {
                    .Location = New Point(332, Y2),
                    .Size = New Size(66, 40),
                    .Enabled = True,
                    .Visible = True,
                    .Parent = Me.Panel1,
                    .Text = "Calculo",
                    .Name = "Button" + cod_prue(i).ToString
                    }
                    AddHandler ButtonArray(tamaniobuttonarray).Click, AddressOf Button_Clicked
                    tamaniobuttonarray += 1
                End If

                AddHandler CheckBoxButtonArray(i).Click, AddressOf CheckBox_Clicked
            Next
        Else
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
            ReDim TextBoxArray(pruebascategoria)

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

            Dim X1, Y1, Y2 As Integer
            Dim deltay As Integer = 70
            For i = 0 To pruebascategoria - 1
                X1 = 7
                If i = 0 Then
                    Y1 = 15
                    Y2 = 40
                Else
                    Y1 = Y1 + deltay
                    Y2 = Y2 + deltay
                End If
                CheckBoxButtonArray(i) = New CheckBox With {
                    .Location = New Point(X1, Y1),
                    .Text = cod_prue(i).ToString + " " + nombre_prueba(i) + ":",
                    .Width = 300,
                    .Height = 20,
                    .ForeColor = Color.Black,
                    .Visible = True,
                    .Parent = Me.Panel1,
                    .Name = i.ToString,
                    .Checked = True
                }
                TextBoxArray(i) = New TextBox With {
                    .Location = New Point(X1, Y2),
                    .Size = New Size(300, 40),
                    .Enabled = True,
                    .Visible = True,
                    .Parent = Me.Panel1,
                    .Name = "TxtBx" + cod_prue(i).ToString
                }

                If cod_prue(i).ToString = "D-130-2" Or cod_prue(i).ToString = "D-86-9" Then
                    Console.WriteLine("Entramos")
                    ButtonArray(tamaniobuttonarray) = New Button With {
                    .Location = New Point(332, Y2),
                    .Size = New Size(66, 40),
                    .Enabled = True,
                    .Visible = True,
                    .Parent = Me.Panel1,
                    .Text = "Calculo",
                    .Name = "Button" + cod_prue(i).ToString
                    }
                    AddHandler ButtonArray(tamaniobuttonarray).Click, AddressOf Button_Clicked
                    tamaniobuttonarray += 1
                End If


                AddHandler CheckBoxButtonArray(i).Click, AddressOf CheckBox_Clicked
            Next

        End If
    End Sub

    Private Sub Button_Clicked(sender As Object, e As EventArgs)
        Dim bt As Button = CType(sender, Button)
        Console.WriteLine(bt.Name.ToString)
        If bt.Name = "ButtonD-130-2" Then
            MsgBox("Click")
        End If
    End Sub

    Private Sub CheckBox_Clicked(sender As Object, e As EventArgs)
        Dim Cb As CheckBox = CType(sender, CheckBox)
        If Cb.Checked = True Then
            TextBoxArray(Cb.Name).Enabled = True
        Else
            TextBoxArray(Cb.Name).Enabled = False
            TextBoxArray(Cb.Name).Text = ""
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnRegistrarReporte.Click
        Dim ProductoID As String = TxtBxIDProducto.Text
        Dim NumeroSerie As String = TxtBxNumeroSerie.Text
        Dim Fecha_Ingreso As String = TxtBxFechaEntrada.Text
        Dim Fecha_Reporte As String = TxtBxFechaRegistro.Text
        Dim ClienteID As String = TxtBxClienteID.Text
        Dim TipoProducto As String = TxtBxTipoProductoID.Text
        Dim Observaciones As String = RchTxtBxObservaciones.Text
        Dim UsuarioID As String = TxtBxIdUsuario.Text

        For i = 0 To pruebascategoria - 1
            If TextBoxArray(i).Enabled = True Then
                If TextBoxArray(i).Text = "" Then
                    MsgBox("ThenEl valor para la prueba" & cod_prue(i) & " esta vacio, Asignele un valor o desmarque la prueba antes de continuar", False, "Error")
                    Exit Sub
                End If
            End If
        Next

        For i = 0 To pruebascategoria - 1
            If TextBoxArray(i).Enabled = True Then
                'MsgBox(cod_prue(i) & "-" & nombre_prueba(i) & "-" & TextBoxArray(i).Text)
                Dim ID_Prueba As String = cod_prue(i)
                Dim valor As String = TextBoxArray(i).Text
                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("INSERT INTO reportes (`ProductoID`, `ClienteID`, `Tipo_Producto_ID`, `Numero_Serie`, `Observaciones`, `Fecha_Ingreso`, `Fecha_Reporte`, `ID_Prueba`, `Valor`, `UsuarioID`) VALUES ('" & ProductoID & "', '" & ClienteID & "', '" & TipoProducto & "', '" & NumeroSerie & "', '" & Observaciones & "', '" & Fecha_Ingreso & "', '" & Fecha_Reporte & "', '" & ID_Prueba & "', '" & valor & "', '" & UsuarioID & "');"), conn)
                    Dim cmd2 As New MySqlCommand(String.Format("Update productos SET Estado = 'Revisado', Fecha_Reporte = '" & Fecha_Reporte & "', UsuarioID = '" & UsuarioID & "' WHERE ProductoID = '" & ProductoID & "' ;"), conn)
                    cmd.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            Console.WriteLine("Reporte Registrado")
            conn.Close()
            Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
            Exit Sub
            End Try
        End If
        Next
        MsgBox("Reporte Registrado", False, "Reporte Registrado")
        Form1.CargarDGVProductosLimite()
        Form1.CargarDGVProductosSinRevisar()
        Form1.ProductosFechaLimiteCerca()
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Dim control As Integer = 0
    Private Sub Form3_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        control = 1
    End Sub
End Class