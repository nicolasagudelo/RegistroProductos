Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO

Public Class Form3
    Dim conn As New MySqlConnection

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        control = 0
        Connect()
        CargarPruebasProducto()
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

    Dim CheckBoxButtonArray() As CheckBox
    Dim TextBoxArray() As TextBox
    Dim cod_prue As New List(Of String)()
    Dim pruebasproducto As Integer
    Dim nombre_prueba As New List(Of String)()

    Private Sub CargarPruebasProducto()
        cod_prue.Clear()
        nombre_prueba.Clear()
        Dim ProductoID As String = TxtBxIDProducto.Text

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("select count(*) from pruebasxproducto where ProductoID = '" & ProductoID & "';"), conn)
            pruebasproducto = cmd.ExecuteScalar
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
        End Try

        ReDim CheckBoxButtonArray(pruebasproducto)
        ReDim TextBoxArray(pruebasproducto)

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("select ID_Prueba from pruebasxproducto where ProductoID = '" & ProductoID & "';"), conn)
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

        For Each item As String In cod_prue
            Console.WriteLine(item)
        Next

        Panel1.Controls.Clear()

        Dim X1, Y1, Y2 As Integer
        Dim deltay As Integer = 70
        For i = 0 To pruebasproducto - 1
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
                .AutoEllipsis = True,
                .AutoSize = True, '.Width = 300,'.Height = 20,
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

            'If cod_prue(i).ToString = "D-130-2" Or cod_prue(i).ToString = "D-86-9" Then
            '    ButtonArray(tamaniobuttonarray) = New Button With {
            '    .Location = New Point(332, Y2),
            '    .Size = New Size(66, 40),
            '    .Enabled = True,
            '    .Visible = True,
            '    .Parent = Me.Panel1,
            '    .Text = "Calculo",
            '    .Name = "Button" + cod_prue(i).ToString
            '    }
            '    AddHandler ButtonArray(tamaniobuttonarray).Click, AddressOf Button_Clicked
            '    tamaniobuttonarray += 1
            'End If

            AddHandler CheckBoxButtonArray(i).Click, AddressOf CheckBox_Clicked
        Next
    End Sub

    Private Sub RBSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles RBSeleccionarTodo.CheckedChanged
        If RBSeleccionarTodo.Checked = True Then
            For i As Integer = 0 To pruebasproducto - 1
                CheckBoxButtonArray(i).Checked = True
                TextBoxArray(i).Enabled = True
            Next
        End If
    End Sub

    Private Sub RBQuitarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles RBQuitarTodo.CheckedChanged
        If RBQuitarTodo.Checked = True Then
            For i As Integer = 0 To pruebasproducto - 1
                CheckBoxButtonArray(i).Checked = False
                TextBoxArray(i).Enabled = False
            Next
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

    'Private Sub Button_Clicked(sender As Object, e As EventArgs)
    '    Dim bt As Button = CType(sender, Button)
    '    Console.WriteLine(bt.Name.ToString)
    '    If bt.Name = "ButtonD-130-2" Then
    '        Dim prueba As String = bt.Name.ToString.Substring(6)
    '        For i As Integer = 0 To pruebasproducto - 1
    '            If TextBoxArray(i).Name = "TxtBx" + prueba Then
    '                TextBoxArray(i).Text = "Calculo!"
    '            End If
    '        Next
    '    End If
    'End Sub

    Private Sub ButtonRegistrarReporte_Click(sender As Object, e As EventArgs) Handles BtnRegistrarReporte.Click
        Dim ProductoID As String = TxtBxIDProducto.Text
        Dim Fecha_Ingreso As String = TxtBxFechaEntrada.Text
        Dim Hora_Ingreso As String = TxtBxHoraEntrada.Text
        Dim Fecha_Reporte As String = TxtBxFechaRegistro.Text
        Dim ClienteID As String = TxtBxClienteID.Text
        Dim TipoProducto As String = TxtBxTipoProductoID.Text
        Dim Observaciones As String = RchTxtBxObservaciones.Text
        Dim UsuarioID As String = TxtBxIdUsuario.Text
        Dim ObservacionesAnalista As String = RchTxtBxObservaciones.Text

        Dim checks As Integer = 0

        For i = 0 To pruebasproducto - 1
            If TextBoxArray(i).Enabled = True Then
                checks += 1
                If TextBoxArray(i).Text = "" Then
                    MsgBox("El valor para la prueba" & cod_prue(i) & " esta vacio, Asignele un valor o desmarquelo antes de continuar", False, "Error")
                    Exit Sub
                End If
            End If
        Next

        Dim steps As Integer = 100 / checks
        Dim max = (steps * pruebasproducto) - steps
        ProgressBar1.Maximum = max

        For i = 0 To pruebasproducto - 1
            If TextBoxArray(i).Enabled = True Then
                'MsgBox(cod_prue(i) & "-" & nombre_prueba(i) & "-" & TextBoxArray(i).Text)
                Dim ID_Prueba As String = cod_prue(i)
                Dim valor As String = TextBoxArray(i).Text
                Dim existevalor As Boolean
                Dim existevalor2 As Boolean
                Dim existevalor3 As Boolean
                Dim existevalor4 As Boolean
                Dim existevalor5 As Boolean

                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("Select Valor from reportes where ProductoID  ='" & ProductoID & "' and ID_Prueba = '" & cod_prue(i) & "';"), conn)
                    Dim var = cmd.ExecuteScalar
                    If var Is Nothing Then
                        existevalor = False
                    Else
                        existevalor = True
                    End If
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try

                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("Select Valor_2 from reportes where ProductoID  ='" & ProductoID & "' and ID_Prueba = '" & cod_prue(i) & "';"), conn)
                    Dim reader As MySqlDataReader
                    reader = cmd.ExecuteReader
                    If reader.Read() Then

                        If reader.IsDBNull(0) Then
                            existevalor2 = False
                        Else
                            existevalor2 = True
                        End If
                    End If
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try

                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("Select Valor_3 from reportes where ProductoID  ='" & ProductoID & "' and ID_Prueba = '" & cod_prue(i) & "';"), conn)
                    Dim reader As MySqlDataReader
                    reader = cmd.ExecuteReader
                    If reader.Read() Then

                        If reader.IsDBNull(0) Then
                            existevalor3 = False
                        Else
                            existevalor3 = True
                        End If
                    End If
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try

                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("Select Valor_4 from reportes where ProductoID  ='" & ProductoID & "' and ID_Prueba = '" & cod_prue(i) & "';"), conn)
                    Dim reader As MySqlDataReader
                    reader = cmd.ExecuteReader
                    If reader.Read() Then

                        If reader.IsDBNull(0) Then
                            existevalor4 = False
                        Else
                            existevalor4 = True
                        End If
                    End If
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try

                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("Select Valor_5 from reportes where ProductoID  ='" & ProductoID & "' and ID_Prueba = '" & cod_prue(i) & "';"), conn)
                    Dim reader As MySqlDataReader
                    reader = cmd.ExecuteReader
                    If reader.Read() Then

                        If reader.IsDBNull(0) Then
                            existevalor5 = False
                        Else
                            existevalor5 = True
                        End If
                    End If
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try

                If existevalor = False Then

                    Try
                        conn.Open()
                        Dim cmd As New MySqlCommand(String.Format("INSERT INTO reportes (`ProductoID`, `ClienteID`, `Tipo_Producto_ID`, `Fecha_Ingreso`, `Hora_Ingreso`, `Fecha_Reporte`, `ID_Prueba`, `Valor`, `UsuarioID`) VALUES ('" & ProductoID & "', '" & ClienteID & "', '" & TipoProducto & "', '" & Fecha_Ingreso & "', '" & Hora_Ingreso & "', '" & Fecha_Reporte & "', '" & ID_Prueba & "', '" & valor & "', '" & UsuarioID & "');"), conn)
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
                    If existevalor2 = False Then
                        Try
                            conn.Open()
                            Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`reportes` SET `Valor_2`='" & valor & "' WHERE `ProductoID`='" & ProductoID & "' and`ID_Prueba`='" & ID_Prueba & "';"), conn)
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
                        If existevalor3 = False Then
                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`reportes` SET `Valor_3`='" & valor & "' WHERE `ProductoID`='" & ProductoID & "' and`ID_Prueba`='" & ID_Prueba & "';"), conn)
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
                            If existevalor4 = False Then
                                Try
                                    conn.Open()
                                    Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`reportes` SET `Valor_4`='" & valor & "' WHERE `ProductoID`='" & ProductoID & "' and`ID_Prueba`='" & ID_Prueba & "';"), conn)
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
                                If existevalor5 = False Then
                                    Try
                                        conn.Open()
                                        Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`reportes` SET `Valor_5`='" & valor & "' WHERE `ProductoID`='" & ProductoID & "' and`ID_Prueba`='" & ID_Prueba & "';"), conn)
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
                            End If
                        End If
                    End If
                End If
                ProgressBar1.Increment(steps)
            End If
        Next

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("Update productos SET Estado = 'Revisado', Fecha_Reporte = '" & Fecha_Reporte & "', UsuarioID = '" & UsuarioID & "', Observaciones_Analista = '" & ObservacionesAnalista & "' WHERE ProductoID = '" & ProductoID & "' ;"), conn)
            cmd.ExecuteNonQuery()
            Console.Write("Producto Reportado")
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
            conn.Close()
        End Try

        Form1.CargarDGVProductosLimite()
        Form1.CargarDGVProductosSinRevisar()
        Form1.ProductosFechaLimiteCerca()
        MsgBox("Reporte Registrado", False, "Reporte Registrado")
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Dim control As Integer = 0
    Private Sub Form3_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        control = 1
    End Sub

    Private Sub BtnEncontrarRuta_Click(sender As Object, e As EventArgs) Handles BtnEncontrarRuta.Click
        Dim getruta As New OpenFileDialog
        getruta.InitialDirectory = "C:\"
        getruta.RestoreDirectory = False
        getruta.Filter = "PDF Files(*.pdf)|*.pdf"
        getruta.ShowDialog()

        Dim filepath As String

        Try
            filepath = Path.GetFullPath(getruta.FileName)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End Try

        TxtBxRuta.Text = filepath

    End Sub

    Private Sub BtnAbrirDatos_Click(sender As Object, e As EventArgs) Handles BtnAbrirDatos.Click
        If TxtBxRuta.Text.Trim = "" Then
            MsgBox("Seleccione la ruta del archivo antes de continuar", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        Try
            Process.Start(TxtBxRuta.Text)
        Catch ex As Exception
            MsgBox("No se encontro archivo en la ruta seleccionada", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
End Class